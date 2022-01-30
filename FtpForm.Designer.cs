namespace FtpService
{
    partial class FtpForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HostnameTxt = new System.Windows.Forms.TextBox();
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PortTxt = new System.Windows.Forms.TextBox();
            this.PathListTxt = new System.Windows.Forms.TextBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ResponseTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LastBackupLbl = new System.Windows.Forms.Label();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HostnameTxt
            // 
            this.HostnameTxt.Location = new System.Drawing.Point(12, 58);
            this.HostnameTxt.Name = "HostnameTxt";
            this.HostnameTxt.PlaceholderText = "sftp://";
            this.HostnameTxt.Size = new System.Drawing.Size(157, 23);
            this.HostnameTxt.TabIndex = 0;
            this.HostnameTxt.TextChanged += new System.EventHandler(this.HostnameTxt_TextChanged);
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.Location = new System.Drawing.Point(175, 58);
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.PlaceholderText = "filan";
            this.UsernameTxt.Size = new System.Drawing.Size(157, 23);
            this.UsernameTxt.TabIndex = 1;
            this.UsernameTxt.TextChanged += new System.EventHandler(this.UsernameTxt_TextChanged);
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Location = new System.Drawing.Point(338, 58);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.Size = new System.Drawing.Size(157, 23);
            this.PasswordTxt.TabIndex = 2;
            this.PasswordTxt.TextChanged += new System.EventHandler(this.PasswordTxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hostname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Port";
            // 
            // PortTxt
            // 
            this.PortTxt.Location = new System.Drawing.Point(502, 58);
            this.PortTxt.Name = "PortTxt";
            this.PortTxt.PlaceholderText = "21";
            this.PortTxt.Size = new System.Drawing.Size(78, 23);
            this.PortTxt.TabIndex = 6;
            this.PortTxt.TextChanged += new System.EventHandler(this.PortTxt_TextChanged);
            // 
            // PathListTxt
            // 
            this.PathListTxt.Location = new System.Drawing.Point(12, 124);
            this.PathListTxt.Multiline = true;
            this.PathListTxt.Name = "PathListTxt";
            this.PathListTxt.PlaceholderText = "C:/Users/Geocad/Desktop;C:/;D:/directory";
            this.PathListTxt.Size = new System.Drawing.Size(568, 117);
            this.PathListTxt.TabIndex = 8;
            this.PathListTxt.TextChanged += new System.EventHandler(this.PathListTxt_TextChanged);
            // 
            // StartBtn
            // 
            this.StartBtn.ForeColor = System.Drawing.Color.Blue;
            this.StartBtn.Location = new System.Drawing.Point(459, 350);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(118, 37);
            this.StartBtn.TabIndex = 9;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.ForeColor = System.Drawing.Color.Red;
            this.StopBtn.Location = new System.Drawing.Point(335, 350);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(118, 37);
            this.StopBtn.TabIndex = 10;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Path\'s (Absolute path delimited by ;)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Response";
            // 
            // ResponseTxt
            // 
            this.ResponseTxt.Location = new System.Drawing.Point(13, 272);
            this.ResponseTxt.Multiline = true;
            this.ResponseTxt.Name = "ResponseTxt";
            this.ResponseTxt.ReadOnly = true;
            this.ResponseTxt.Size = new System.Drawing.Size(568, 47);
            this.ResponseTxt.TabIndex = 13;
            this.ResponseTxt.TextChanged += new System.EventHandler(this.ResponseTxt_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 335);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Last backup: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 361);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "Status: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(260, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Backup data";
            // 
            // LastBackupLbl
            // 
            this.LastBackupLbl.AutoSize = true;
            this.LastBackupLbl.Location = new System.Drawing.Point(93, 335);
            this.LastBackupLbl.Name = "LastBackupLbl";
            this.LastBackupLbl.Size = new System.Drawing.Size(0, 15);
            this.LastBackupLbl.TabIndex = 17;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Location = new System.Drawing.Point(93, 361);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(0, 15);
            this.StatusLbl.TabIndex = 18;
            // 
            // SaveBtn
            // 
            this.SaveBtn.ForeColor = System.Drawing.Color.Lime;
            this.SaveBtn.Location = new System.Drawing.Point(478, 87);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(99, 23);
            this.SaveBtn.TabIndex = 19;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // FtpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 401);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.StatusLbl);
            this.Controls.Add(this.LastBackupLbl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ResponseTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.PathListTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PortTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.UsernameTxt);
            this.Controls.Add(this.HostnameTxt);
            this.Name = "FtpForm";
            this.Text = "Geocad Backup";
            this.Load += new System.EventHandler(this.FtpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox HostnameTxt;
        private TextBox UsernameTxt;
        private TextBox PasswordTxt;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox PortTxt;
        private TextBox PathListTxt;
        private Button StartBtn;
        private Button StopBtn;
        private Label label5;
        private Label label6;
        private TextBox ResponseTxt;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label LastBackupLbl;
        private Label StatusLbl;
        private Button SaveBtn;
    }
}