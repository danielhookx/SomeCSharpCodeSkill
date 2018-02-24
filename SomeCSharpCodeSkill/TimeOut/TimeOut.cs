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
using System.Threading;
using System.Threading.Tasks;

namespace TimeOut
{
    public class TimeOut
    {
        public class EndJudgedEventArgs : EventArgs
        {
            public int index { get; set; }
            public Boolean istimeout { get; set; }
            public object[] msg { get; set; }
            public EndJudgedEventArgs(int index, Boolean isTO, params object[] msg)
            {
                this.index = index;
                this.istimeout = isTO;
                this.msg = msg;
            }
        }

        public delegate void TimeOutJudgedEventHandler(object sender, EndJudgedEventArgs arg);
        public event TimeOutJudgedEventHandler EndJudged;

        public delegate void CatchedSigalEventHandler(object sender, EndJudgedEventArgs arg);
        public event CatchedSigalEventHandler CatchedSignal;

        public AutoResetEvent mTimeoutSignal { get; set; } //time out signal
        private delegate Boolean CallbackDelegate(TimeSpan time);

        private object[] message = null;
        private Boolean DisposeFlg = false;

        private TimeSpan time;
        private int index;

        public TimeOut(int index, TimeSpan time)
        {
            this.time = time;
            this.index = index;
            mTimeoutSignal = new AutoResetEvent(false);
        }

        private Boolean TimeOutClick(TimeSpan time)
        {
            if (!this.mTimeoutSignal.WaitOne(time, false))
            {
                //time out
                return true;
            }
            return false;
        }

        private void On_EndJudged(EndJudgedEventArgs arg)
        {
            if (EndJudged != null)
            {
                EndJudged(this, arg);
            }
        }

        private void On_CatchedSignal(EndJudgedEventArgs arg)
        {
            if (CatchedSignal != null)
            {
                CatchedSignal(this, arg);
            }
        }

        public void Dispose()
        {
            this.DisposeFlg = true;
        }

        public void ReSetClick()
        {
            this.DisposeFlg = false;
            mTimeoutSignal.Reset();
            CallbackDelegate dele;
            dele = TimeOutClick;
            dele.BeginInvoke(time, new AsyncCallback(delegate (IAsyncResult iar)
            {
                Boolean result = dele.EndInvoke(iar);
                if (DisposeFlg)
                {
                    this.Dispose();
                    return;
                }
                if (result == true)
                {
                    EndJudgedEventArgs arg = new EndJudgedEventArgs(index, true, message);
                    //time out event
                    On_EndJudged(arg);
                }
                else
                {
                    EndJudgedEventArgs arg = new EndJudgedEventArgs(index, false, message);
                    On_CatchedSignal(arg);
                }
            }), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void SetMessage(params object[] msg)
        {
            this.message = msg;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetSignal()
        {
            mTimeoutSignal.Set();
        }
    }
}
