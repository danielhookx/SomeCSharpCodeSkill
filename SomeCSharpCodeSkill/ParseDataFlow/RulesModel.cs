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
    public class RulesModel
    {
        /// <summary>
        /// cmds标签的NAME属性
        /// </summary>
        private string name;
        /// <summary>
        /// cmds标签的FATHER属性
        /// </summary>
        private string father;
        /// <summary>
        /// dataArea标签下cmd子标签的CMD属性
        /// </summary>
        private string cmd;
        /// <summary>
        /// item子标签的键值列表
        /// </summary>
        List<Part> partList = new List<Part>();

        #region 各属性GET方法
        public string Getname
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Getfather
        {
            get
            {
                return father;
            }
            set
            {
                father = value;
            }
        }
        public string Getcmd
        {
            get
            {
                return cmd;
            }
            set
            {
                cmd = value;
            }
        }
        public List<Part> GetpartList
        {
            get
            {
                return partList;
            }
            set
            {
                partList = value;
            }
        }
        #endregion

        public class Part
        {
            string name;
            string show;
            string child;
            string kind;
            string length;
            string num;

            public Part(string name, string show, string child, string kind, string length, string num)
            {
                this.name = name;
                this.show = show;
                this.child = child;
                this.kind = kind;
                this.length = length;
                this.num = num;
            }
            #region 各属性GET方法
            public string Getname
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            public string Getshow
            {
                get
                {
                    return show;
                }
                set
                {
                    show = value;
                }
            }
            public string Getchild
            {
                get
                {
                    return child;
                }
                set
                {
                    child = value;
                }
            }
            public string Getkind
            {
                get
                {
                    return kind;
                }
                set
                {
                    kind = value;
                }
            }
            public string Getlength
            {
                get
                {
                    return length;
                }
                set
                {
                    length = value;
                }
            }
            public string Getnum
            {
                get
                {
                    return num;
                }
                set
                {
                    num = value;
                }
            }
            #endregion
        }

        /// <summary>
        /// 添加part数据对象到Cmd类的成员partList（partList列表）中
        /// </summary>
        /// 
        public void addPart(string name, string show, string child, string kind, string length, string num)
        {
            Part part = new Part(name, show, child, kind, length, num);
            partList.Add(part);
        }
    }
}
