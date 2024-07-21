namespace Hospital.App
{
    partial class frmKey
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.teIP = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.teKey = new DevExpress.XtraEditors.TextEdit();
            this.btExit = new DevExpress.XtraEditors.SimpleButton();
            this.btLogin = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.teIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teKey.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // teIP
            // 
            this.teIP.Location = new System.Drawing.Point(89, 40);
            this.teIP.Name = "teIP";
            this.teIP.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teIP.Properties.Appearance.Options.UseFont = true;
            this.teIP.Properties.ReadOnly = true;
            this.teIP.Size = new System.Drawing.Size(242, 30);
            this.teIP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Key";
            // 
            // teKey
            // 
            this.teKey.Location = new System.Drawing.Point(89, 76);
            this.teKey.Name = "teKey";
            this.teKey.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teKey.Properties.Appearance.Options.UseFont = true;
            this.teKey.Properties.PasswordChar = '*';
            this.teKey.Size = new System.Drawing.Size(242, 30);
            this.teKey.TabIndex = 1;
            // 
            // btExit
            // 
            this.btExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btExit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btExit.Appearance.Options.UseFont = true;
            this.btExit.Appearance.Options.UseForeColor = true;
            this.btExit.Location = new System.Drawing.Point(89, 112);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(112, 42);
            this.btExit.TabIndex = 13;
            this.btExit.Text = "THOÁT";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btLogin
            // 
            this.btLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogin.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btLogin.Appearance.Options.UseFont = true;
            this.btLogin.Appearance.Options.UseForeColor = true;
            this.btLogin.Location = new System.Drawing.Point(219, 112);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(112, 42);
            this.btLogin.TabIndex = 12;
            this.btLogin.Text = "ĐĂNG KÝ";
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // frmKey
            // 
            this.AcceptButton = this.btLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 201);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.teKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.teIP);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG KÝ SỬ DỤNG PHẦN MỀM";
            ((System.ComponentModel.ISupportInitialize)(this.teIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teKey.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit teIP;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit teKey;
        private DevExpress.XtraEditors.SimpleButton btExit;
        private DevExpress.XtraEditors.SimpleButton btLogin;
    }
}