/********************************************************************************
** Company： 
** auth：   oofpg DLD
** date：    
** desc：    
** Ver.:     V1.0.0
*********************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParseDataFlows
{
    public class ReadXml
    {
        /// <summary>
        /// 存储从配置XML文件中读出的规则
        /// </summary>
        public static ArrayList rulesList = new ArrayList();

        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <returns></returns>
        public bool getCfgXml()
        {
            string path = "Myconfig.xml";    //xml文件路径
            XmlDocument doc = new XmlDocument();
            try
            {
                XmlReader xmlreader = XmlReader.Create(path);   //访问xml的读取器
                doc.Load(xmlreader);
            }
            catch (Exception ee)
            {
                //MessageBox.Show("加载XML配置文件失败！");
                throw new Exception("加载XML配置文件失败！");
                return false;
            }

            XmlElement root = doc.DocumentElement;  //获取根节点
            //-------获取第二级子节点--------//
            XmlNodeList cmdsList = root.GetElementsByTagName("cmds");  //获取<cmds></cmds>第二级子节点集合
            XmlNodeList dataAreaList = root.GetElementsByTagName("dataArea");  //获取<dataArea></dataArea>第二级子节点集合
            XmlNodeList informationAreaList = root.GetElementsByTagName("informationArea");  //获取<informationArea></informationArea>第二级子节点集合
            //-------------------------------//
            //-------获取cmds节点下每个子节点的所有内容-------//
            foreach (XmlNode firstLayer in cmdsList)
            {
                //cmd列表
                XmlNodeList secondLayerList = firstLayer.ChildNodes;

                foreach (XmlNode secondLayer in secondLayerList)
                {
                    //创建
                    RulesModel p_cmd = new RulesModel();
                    p_cmd.Getname = ((XmlElement)secondLayer).GetAttribute("NAME");  //得到NAME属性值
                    p_cmd.Getfather = ((XmlElement)secondLayer).GetAttribute("FATHER");      //得到FATHER属性值
                    p_cmd.Getcmd = ((XmlElement)secondLayer).GetAttribute("CMD");      //得到CMD属性值

                    XmlNodeList partList = secondLayer.ChildNodes;

                    foreach (XmlNode part in partList)
                    {
                        p_cmd.addPart(
                            ((XmlElement)part).GetAttribute("NAME"),
                            ((XmlElement)part).GetAttribute("SHOW"),
                            ((XmlElement)part).GetAttribute("CHILD"),
                            ((XmlElement)part).GetAttribute("KIND"),
                            ((XmlElement)part).GetAttribute("LENGTH"),
                            ((XmlElement)part).GetAttribute("NUM")
                            );    //添加所有子标签对象    
                    }

                    ReadXml.rulesList.Add(p_cmd);   //
                }
            }
            //----------------------------------------------------//
            //-------获取dataArea节点下每个子节点的所有内容-------//
            foreach (XmlNode firstLayer in dataAreaList)
            {
                //cmd列表
                XmlNodeList secondLayerList = firstLayer.ChildNodes;

                foreach (XmlNode secondLayer in secondLayerList)
                {
                    //创建
                    RulesModel p_dataArea = new RulesModel();
                    p_dataArea.Getname = ((XmlElement)secondLayer).GetAttribute("NAME");  //得到NAME属性值
                    p_dataArea.Getfather = ((XmlElement)secondLayer).GetAttribute("FATHER");      //得到FATHER属性值
                    p_dataArea.Getcmd = ((XmlElement)secondLayer).GetAttribute("CMD");      //得到CMD属性值
                                                                                            //part列表
                    XmlNodeList partList = secondLayer.ChildNodes;

                    foreach (XmlNode part in partList)
                    {
                        p_dataArea.addPart(
                            ((XmlElement)part).GetAttribute("NAME"),
                            ((XmlElement)part).GetAttribute("SHOW"),
                            ((XmlElement)part).GetAttribute("CHILD"),
                            ((XmlElement)part).GetAttribute("KIND"),
                            ((XmlElement)part).GetAttribute("LENGTH"),
                            ((XmlElement)part).GetAttribute("NUM")
                            );    //添加所有子标签对象    
                    }
                    ReadXml.rulesList.Add(p_dataArea);   //
                }
            }
            //----------------------------------------------------//
            //-------获取informationArea节点下每个子节点的所有内容-------//
            foreach (XmlNode firstLayer in informationAreaList)
            {
                //cmd列表
                XmlNodeList secondLayerList = firstLayer.ChildNodes;

                foreach (XmlNode secondLayer in secondLayerList)
                {
                    //创建
                    RulesModel p_informationArea = new RulesModel();
                    p_informationArea.Getname = ((XmlElement)secondLayer).GetAttribute("NAME");  //得到NAME属性值
                    p_informationArea.Getfather = ((XmlElement)secondLayer).GetAttribute("FATHER");      //得到FATHER属性值
                    p_informationArea.Getcmd = ((XmlElement)secondLayer).GetAttribute("CMD");      //得到CMD属性值
                    //part列表
                    XmlNodeList partList = secondLayer.ChildNodes;

                    foreach (XmlNode part in partList)
                    {
                        p_informationArea.addPart(
                            ((XmlElement)part).GetAttribute("NAME"),
                            ((XmlElement)part).GetAttribute("SHOW"),
                            ((XmlElement)part).GetAttribute("CHILD"),
                            ((XmlElement)part).GetAttribute("KIND"),
                            ((XmlElement)part).GetAttribute("LENGTH"),
                            ((XmlElement)part).GetAttribute("NUM")
                            );    //添加所有子标签对象    
                    }
                    ReadXml.rulesList.Add(p_informationArea);   //
                }
            }
            //----------------------------------------------------// 
            return true;
        }
    }
}
