/********************************************************************************
** Company： 
** auth：    oofpg DLD
** date：    2018/2/24 14:44:22
** desc：    
** Ver.:     V1.0.0
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unpack
{
    /// <summary>
    /// 功能：解包 
    /// 2017/04/18 : 1、拆分多个连续的数据包。 2、每一包中多个数据帧的拆分和拼接
    /// 2017/05/04 : 1、添加对不完整包的解析。2、将无包头和包尾的数据视为一个包的数据，做单包解析。3、建立多个终端ip端口号的包缓存。
    /// 修改时间：2017/04/18
    /// 修改时间：2017/05/04
    /// </summary>
    public class Unpack
    {
        //private static string FirstHalfStr = string.Empty;
        /// <summary>
        /// UnPack 解析包时用:上一不完整包的缓存(ip地址端口号,缓存)
        /// </summary>
        private static Dictionary<string, string> FirstHalfOFPacketArray = new Dictionary<string, string>();
        /// <summary>
        /// UnPack 解析包时用:上一不完整帧的缓存(ip地址端口号,缓存)
        /// </summary>
        private static Dictionary<string, string> FirstHalfOFFrameArray = new Dictionary<string, string>();
        private Boolean packetCheck = true;
        /// <summary>
        /// 数据源
        /// </summary>
        string source;
        /// <summary>
        /// 数据所属端口号
        /// </summary>
        string endPoint;

        List<string> result = new List<string>();
        public Unpack(string src, string endPoint)
        {
            this.source = src;
            this.endPoint = endPoint;
        }

        public List<string> doUnpack()
        {
            string str = this.source;
            //包头和包尾
            byte[] bcmp1 = new byte[1];
            byte[] bcmp2 = new byte[1];
            bcmp1[0] = 0x01;
            bcmp2[0] = 0x04;
            string packetHead = Encoding.Default.GetString(bcmp1, 0, 1);
            string packetEnd = Encoding.Default.GetString(bcmp2, 0, 1);

            int pHeadMark;                  //位置mark
            int pEndMark;                  //位置mark

            //判断包头和包尾：有效包
            if (false && (this.source.Contains(packetHead) || this.source.Contains(packetEnd)))
            {
                packetCheck = true;
                while (true)
                {
                    pHeadMark = str.IndexOf(packetHead);
                    if (pHeadMark == 0)
                    {
                        pEndMark = str.IndexOf(packetEnd);
                        if (pEndMark > pHeadMark)
                        {
                            //一个包的数据:包含包头和包尾
                            string p_str = str.Substring(pHeadMark, pEndMark - pHeadMark + 1);
                            //解单个包
                            singlePacket(p_str);
                            if (pEndMark + 1 < str.Length)
                                str = str.Substring(pEndMark + 1, str.Length - (pEndMark - pHeadMark + 1));   //取出剩余部分
                            else
                                break;
                        }
                        else
                        {
                            //将前半部分包存下来
                            string firstHalfStr = str.Substring(pHeadMark, str.Length - pHeadMark);

                            if (FirstHalfOFPacketArray.ContainsKey(this.endPoint))
                            {
                                FirstHalfOFPacketArray[this.endPoint] = firstHalfStr;
                            }
                            else
                            {
                                FirstHalfOFPacketArray.Add(this.endPoint, firstHalfStr);
                            }
                            break;
                        }
                    }
                    else if (pHeadMark != 0)
                    {
                        pEndMark = str.IndexOf(packetEnd);
                        if (pEndMark > 0)
                        {
                            //取出上一不完整包
                            string firstHalfStr = string.Empty;

                            FirstHalfOFPacketArray.TryGetValue(this.endPoint, out firstHalfStr);
                            if (string.IsNullOrEmpty(firstHalfStr))
                            {
                                str = str.Substring(pEndMark + 1, str.Length - (pEndMark + 1));
                                continue;
                            }
                            string p_str = firstHalfStr;
                            p_str += str.Substring(0, pEndMark + 1);    //组成一条包含包头和包尾的一个完整包
                            //解单个包
                            singlePacket(p_str);
                            if (pEndMark + 1 < str.Length)
                                str = str.Substring(pEndMark + 1, str.Length - (pEndMark + 1));
                            else
                                break;
                        }
                        else { break; }
                    }
                }
            }
            else
            {
                packetCheck = false;
                singlePacket(str);
            }

            return result;
        }
        /// <summary>
        /// 功能：解析单个包，包的格式为（包头标志位+多个数据帧+包尾标志位）
        /// </summary>
        /// <param name="srcOfOnePacket"></param>
        public void singlePacket(string srcOfOnePacket)
        {
            string str = srcOfOnePacket;
            //包头和包尾
            byte[] bcmp1 = new byte[1];
            byte[] bcmp2 = new byte[1];
            bcmp1[0] = 0x01;
            bcmp2[0] = 0x04;
            string packetHead = Encoding.Default.GetString(bcmp1, 0, 1);
            string packetEnd = Encoding.Default.GetString(bcmp2, 0, 1);
            //帧头和帧尾
            byte[] bcmp3 = new byte[1];
            byte[] bcmp4 = new byte[1];
            bcmp3[0] = 0x02;
            bcmp4[0] = 0x03;
            string frameHead = Encoding.Default.GetString(bcmp3, 0, 1);
            string frameEnd = Encoding.Default.GetString(bcmp4, 0, 1);

            int sourceLng = srcOfOnePacket.Length;
            int fHeadMark;                  //位置mark
            int fEndMark;                  //位置mark

            //判断包头和包尾：有效包
            if (srcOfOnePacket.Contains(packetHead) && srcOfOnePacket.Contains(packetEnd) || !packetCheck)
            {
                if (packetCheck)
                {
                    //去掉包头和包尾
                    str = srcOfOnePacket.Substring(1, sourceLng - 2);
                }

                while (true)
                {
                    str = str.Replace(System.Text.Encoding.ASCII.GetString(bcmp1), "");
                    str = str.Replace(System.Text.Encoding.ASCII.GetString(bcmp2), "");

                    fHeadMark = str.IndexOf(frameHead);
                    if (fHeadMark == 0)
                    {
                        //丢弃上一个缓存

                        fEndMark = str.IndexOf(frameEnd);
                        if (fEndMark > fHeadMark)
                        {
                            string p_str = str.Substring(fHeadMark + 1, fEndMark - fHeadMark - 1);
                            result.Add(p_str);
                            if (fEndMark + 1 < str.Length)
                                str = str.Substring(fEndMark + 1, str.Length - (fEndMark + 1));   //取出剩余部分
                            else
                                break;
                        }
                        else
                        {
                            //将前半部分帧存下来
                            string firstHalfStr = str.Substring(fHeadMark, str.Length - fHeadMark);
                            if (FirstHalfOFFrameArray.ContainsKey(this.endPoint))
                            {
                                FirstHalfOFFrameArray[this.endPoint] = firstHalfStr;
                            }
                            else
                            {
                                FirstHalfOFFrameArray.Add(this.endPoint, firstHalfStr);
                            }
                            break;
                        }
                    }
                    else if (fHeadMark != 0)
                    {
                        fEndMark = str.IndexOf(frameEnd);
                        if (fEndMark > 0)
                        {
                            //取出上一不完整帧
                            string firstHalfStr = string.Empty;

                            FirstHalfOFFrameArray.TryGetValue(this.endPoint, out firstHalfStr);
                            if (string.IsNullOrEmpty(firstHalfStr))
                            {
                                str = str.Substring(fEndMark + 1, str.Length - (fEndMark + 1));
                                continue;
                            }
                            string p_str = firstHalfStr;
                            p_str += str.Substring(0, fEndMark + 1);
                            p_str = p_str.Substring(1, p_str.Length - 1 - 1);
                            result.Add(p_str);
                            if (fEndMark + 1 < str.Length)
                                str = str.Substring(fEndMark + 1, str.Length - (fEndMark + 1));
                            else
                                break;
                        }
                        else { break; }
                    }
                }
            }
            else
            {
                //丢弃无效帧
            }
        }
    }

}
