using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TimeOut;
using ParseDataFlows;
using System.Diagnostics;

namespace UseForm
{
    public partial class Form1 : Form
    {
        TimeOut.TimeOut timeOut;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TimeOut_inti();
            ParseDataFlow_init();

        }

        #region Time Out

        private void TimeOut_inti()
        {
            //init TimeOut
            timeOut = new TimeOut.TimeOut(0, new TimeSpan(0, 0, 0, 5));
            timeOut.EndJudged += TimeOut_EndJudged;
            timeOut.CatchedSignal += TimeOut_CatchedSignal;
        }

        private void TimeOut_CatchedSignal(object sender, TimeOut.TimeOut.EndJudgedEventArgs arg)
        {
            if (arg.msg != null && arg.msg.Count() == 1 &&
                typeof(string) == arg.msg[0].GetType() && !string.IsNullOrEmpty(((string)arg.msg[0])))
            {
                this.Invoke(new Action(() =>
                {
                    this.Result_lb.Text = "Not timed out :" + ((string)arg.msg[0]);
                }));
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    this.Result_lb.Text = "Not timed out";
                }));
            }
        }

        private void TimeOut_EndJudged(object sender, TimeOut.TimeOut.EndJudgedEventArgs arg)
        {
            this.Invoke(new Action(() => {
                this.Result_lb.Text = "Out of Time";
            }));
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            this.Result_lb.Text = "Waiting...";
            timeOut.ReSetClick();
        }

        private void Set_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Message_txb.Text))
            {
                string str = this.Message_txb.Text;
                timeOut.SetMessage(str);
            }
            timeOut.SetSignal();
        }
        #endregion

        #region ParseDataFlows
        private void ParseDataFlow_init()
        {
            ReadXml readxml = new ReadXml();
            readxml.getCfgXml();
        }

        private void Do_btn_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            this.RuleNumb_lb.Text = "RuleNumb:" + ReadXml.rulesList.Count;
            foreach (RulesModel rules in ReadXml.rulesList)
            {
                if (rules.Getfather.Equals("NULL"))
                {
                    MsgDisp dd = new MsgDisp(msg, rules);
                    RltOfCmd rr = dd.disp();
                    Debug.WriteLine(msg);
                    try
                    {
                        ParseDetial(rr);
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.ToString());
                    }

                }
            }
        }

        private void ParseDetial(RltOfCmd rr)
        {
            if (rr == null)
            {
                return;
            }
            else
            {
                foreach (RltOfPart p_rop in rr.Getrltofpart)
                {
                    //进入下一层
                    if (p_rop.GethaveChild == true)
                    {
                        ParseDetial(p_rop.GetchildObj);
                    }
                    else
                    {
                        string rlt = string.Empty;
                        rlt += p_rop.Getname;
                        rlt += p_rop.Getnum;
                        rlt += p_rop.Getlength;
                        rlt += p_rop.Getcontxt;
                    }
                }
            }
        }

        #endregion

    }
}