/********************************************************************************
** Company： 
** auth：    oofpg DLD
** date：    
** desc：    
** Ver.:     V1.0.0
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseDataFlows
{
    public class MsgDisp
    {
        private string source;
        private string p_source;
        //数据总长度
        int totalLength;
        //入口
        private RulesModel rules;
        /// <summary>
        /// 游标
        /// </summary>
        int mark = 0;

        public MsgDisp(string str, RulesModel rul)
        {
            this.source = str;
            this.totalLength = str.Length;
            this.rules = rul;
        }

        public RltOfCmd disp()
        {
            RltOfCmd rlt = null;
            //根据指定节点
            if (this.rules != null)
            {
                //消息处理的结果
                rlt = new RltOfCmd();

                int dataLenth = 0;
                string cmdType = "NULL";     //默认值必须为NULL

                rlt.GetinnerParams.Add("FATHER", rules.Getfather);
                rlt.GetinnerParams.Add("NAME", rules.Getname);
                rlt.GetinnerParams.Add("CMD", rules.Getcmd);
                //处理其中每一个部分
                foreach (RulesModel.Part part in rules.GetpartList)
                {
                    RltOfPart r_part = new RltOfPart(
                        part.Getname,
                        part.Getshow,
                        part.Getlength,
                        part.Getchild,
                        part.Getnum,
                        part.Getkind
                        );
                    //得到数据内容contxt
                    int len = 0;
                    Boolean notSureLength = false;      //未指定长度标识
                    //不抛出异常的数据转换
                    //int.TryParse(part.Getlength, out len);
                    //数据长度不确定在异常捕获的处理
                    try
                    {
                        if (part.Getlength.Equals("x"))
                        {
                            //长度来自 数据长度 项
                            len = dataLenth;
                            dataLenth = 0;  //重置一下
                            if (len == 0)
                            {
                                //长度来自  (长度为剩余长度)
                                len = this.totalLength - mark;
                                notSureLength = true;
                            }
                        }
                        else
                        {
                            len = int.Parse(part.Getlength);
                        }

                    }
                    catch (Exception ee)
                    {
                        //MessageBox.Show("数据错误");
                        throw new Exception("数据错误");
                    }
                    //截取数据
                    try
                    {
                        if (notSureLength == true)
                        {
                            p_source = this.source.Substring(mark, len);
                            mark += len;
                        }
                        else
                        {
                            p_source = this.source.Substring(mark, len * 2);
                            mark += (len * 2);
                        }
                    }
                    catch
                    {
                        //MessageBox.Show("截断错误");
                        throw new Exception("截断错误");
                    }

                    r_part.Getcontxt = p_source;

                    if (!part.Getchild.Equals("NO"))
                    {
                        //查找所有节点 找出child对应的"阈"和子标签
                        foreach (RulesModel p_rules in ReadXml.rulesList)
                        {
                            if (p_rules.Getfather.Equals(rules.Getname))
                            {
                                if (p_rules.Getcmd.Contains(cmdType))
                                {
                                    //申明对象
                                    MsgDisp p_msgDisp = new MsgDisp(p_source, p_rules);
                                    r_part.GetchildObj = p_msgDisp.disp();
                                }

                            }
                        }
                        r_part.GethaveChild = true;
                    }
                    //如果是数据长度则把长度给存下来
                    if (part.Getname.Equals("数据长度"))
                    {
                        dataLenth = hexToDecimal(r_part.Getcontxt);
                    }
                    if (part.Getname.Equals("功能代码"))
                    {
                        cmdType = r_part.Getcontxt;
                    }
                    //RltOfPart 放入 RltOfCmd 的 part列表中
                    rlt.Getrltofpart.Add(r_part);
                }
            }
            return rlt;
        }

        /// <summary>
        /// 功能：将十六进制的String转化为十进制int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int hexToDecimal(string str)
        {
            int i = 0, adder = 0;
            char[] chars = str.ToCharArray();
            for (i = 0; i < chars.Length; i++)
            {
                if (chars[i] >= '0' && chars[i] <= '9')
                {
                    adder = adder * 16 + chars[i] - '0';
                }
                else if (chars[i] >= 'A' && chars[i] <= 'F')
                {
                    adder = adder * 16 + chars[i] - 'A' + 10;
                }
                else if (chars[i] >= 'a' && chars[i] <= 'f')
                {
                    adder = adder * 16 + chars[i] - 'a' + 10;
                }
            }
            return adder;
        }
    }
}
