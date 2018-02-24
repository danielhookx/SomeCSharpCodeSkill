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
    public class RltOfCmd
    {
        Dictionary<string, string> innerParams = new Dictionary<string, string>();

        List<RltOfPart> rltofpart = new List<RltOfPart>();

        #region 各属性GET方法

        public Dictionary<string, string> GetinnerParams
        {
            get
            {
                return innerParams;
            }
            set
            {
                innerParams = value;
            }

        }
        public List<RltOfPart> Getrltofpart
        {
            get
            {
                return rltofpart;
            }
            set
            {
                rltofpart = value;
            }
        }
        #endregion
    }
}
