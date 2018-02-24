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
    public class RltOfPart
    {
        string name;
        string show;
        string child;
        string kind;
        string length;
        string num;

        string contxt;

        Boolean haveChild = false;

        RltOfCmd childObj;

        public RltOfPart(string name, string show, string child, string kind, string length, string num)
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
        public string Getcontxt
        {
            get
            {
                return contxt;
            }
            set
            {
                contxt = value;
            }
        }
        public Boolean GethaveChild
        {
            get
            {
                return haveChild;
            }
            set
            {
                haveChild = value;
            }
        }
        public RltOfCmd GetchildObj
        {
            get
            {
                return childObj;
            }
            set
            {
                childObj = value;
            }
        }
        #endregion
    }
}
