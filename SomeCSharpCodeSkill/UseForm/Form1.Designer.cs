namespace UseForm
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TimeOutTest_gb = new System.Windows.Forms.GroupBox();
            this.Result_lb = new System.Windows.Forms.Label();
            this.Start_btn = new System.Windows.Forms.Button();
            this.Set_btn = new System.Windows.Forms.Button();
            this.Message_txb = new System.Windows.Forms.TextBox();
            this.ParseDataFlows_gb = new System.Windows.Forms.GroupBox();
            this.Do_btn = new System.Windows.Forms.Button();
            this.RuleNumb_lb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TimeOutTest_gb.SuspendLayout();
            this.ParseDataFlows_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimeOutTest_gb
            // 
            this.TimeOutTest_gb.Controls.Add(this.Message_txb);
            this.TimeOutTest_gb.Controls.Add(this.Set_btn);
            this.TimeOutTest_gb.Controls.Add(this.Start_btn);
            this.TimeOutTest_gb.Controls.Add(this.Result_lb);
            this.TimeOutTest_gb.Location = new System.Drawing.Point(12, 12);
            this.TimeOutTest_gb.Name = "TimeOutTest_gb";
            this.TimeOutTest_gb.Size = new System.Drawing.Size(461, 102);
            this.TimeOutTest_gb.TabIndex = 0;
            this.TimeOutTest_gb.TabStop = false;
            this.TimeOutTest_gb.Text = "TimeOut";
            // 
            // Result_lb
            // 
            this.Result_lb.AutoSize = true;
            this.Result_lb.Location = new System.Drawing.Point(26, 64);
            this.Result_lb.Name = "Result_lb";
            this.Result_lb.Size = new System.Drawing.Size(41, 12);
            this.Result_lb.TabIndex = 0;
            this.Result_lb.Text = "Result";
            // 
            // Start_btn
            // 
            this.Start_btn.Location = new System.Drawing.Point(19, 23);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(75, 23);
            this.Start_btn.TabIndex = 1;
            this.Start_btn.Text = "Start";
            this.Start_btn.UseVisualStyleBackColor = true;
            this.Start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // Set_btn
            // 
            this.Set_btn.Location = new System.Drawing.Point(122, 23);
            this.Set_btn.Name = "Set_btn";
            this.Set_btn.Size = new System.Drawing.Size(75, 23);
            this.Set_btn.TabIndex = 1;
            this.Set_btn.Text = "Set";
            this.Set_btn.UseVisualStyleBackColor = true;
            this.Set_btn.Click += new System.EventHandler(this.Set_btn_Click);
            // 
            // Message_txb
            // 
            this.Message_txb.Location = new System.Drawing.Point(218, 25);
            this.Message_txb.Name = "Message_txb";
            this.Message_txb.Size = new System.Drawing.Size(169, 21);
            this.Message_txb.TabIndex = 2;
            // 
            // ParseDataFlows_gb
            // 
            this.ParseDataFlows_gb.Controls.Add(this.label2);
            this.ParseDataFlows_gb.Controls.Add(this.RuleNumb_lb);
            this.ParseDataFlows_gb.Controls.Add(this.Do_btn);
            this.ParseDataFlows_gb.Location = new System.Drawing.Point(12, 133);
            this.ParseDataFlows_gb.Name = "ParseDataFlows_gb";
            this.ParseDataFlows_gb.Size = new System.Drawing.Size(462, 74);
            this.ParseDataFlows_gb.TabIndex = 3;
            this.ParseDataFlows_gb.TabStop = false;
            this.ParseDataFlows_gb.Text = "ParseDataFlows";
            // 
            // Do_btn
            // 
            this.Do_btn.Location = new System.Drawing.Point(19, 29);
            this.Do_btn.Name = "Do_btn";
            this.Do_btn.Size = new System.Drawing.Size(75, 23);
            this.Do_btn.TabIndex = 0;
            this.Do_btn.Text = "Do";
            this.Do_btn.UseVisualStyleBackColor = true;
            this.Do_btn.Click += new System.EventHandler(this.Do_btn_Click);
            // 
            // RuleNumb_lb
            // 
            this.RuleNumb_lb.AutoSize = true;
            this.RuleNumb_lb.Location = new System.Drawing.Point(133, 34);
            this.RuleNumb_lb.Name = "RuleNumb_lb";
            this.RuleNumb_lb.Size = new System.Drawing.Size(59, 12);
            this.RuleNumb_lb.TabIndex = 1;
            this.RuleNumb_lb.Text = "RuleNumb:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 309);
            this.Controls.Add(this.ParseDataFlows_gb);
            this.Controls.Add(this.TimeOutTest_gb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TimeOutTest_gb.ResumeLayout(false);
            this.TimeOutTest_gb.PerformLayout();
            this.ParseDataFlows_gb.ResumeLayout(false);
            this.ParseDataFlows_gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox TimeOutTest_gb;
        private System.Windows.Forms.Button Set_btn;
        private System.Windows.Forms.Button Start_btn;
        private System.Windows.Forms.Label Result_lb;
        private System.Windows.Forms.TextBox Message_txb;
        private System.Windows.Forms.GroupBox ParseDataFlows_gb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label RuleNumb_lb;
        private System.Windows.Forms.Button Do_btn;
    }
}

