namespace Hospital.App.LichLamViec
{
    partial class FrmChucNangLLV
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
            this.btnDangKy = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuiSMS = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuiSMSAll = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnDangKy
            // 
            this.btnDangKy.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnDangKy.Appearance.Options.UseFont = true;
            this.btnDangKy.Appearance.Options.UseForeColor = true;
            this.btnDangKy.Location = new System.Drawing.Point(48, 42);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(288, 50);
            this.btnDangKy.TabIndex = 186;
            this.btnDangKy.Text = "Đăng ký";
            // 
            // btnGuiSMS
            // 
            this.btnGuiSMS.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiSMS.Appearance.Options.UseFont = true;
            this.btnGuiSMS.Location = new System.Drawing.Point(48, 98);
            this.btnGuiSMS.Name = "btnGuiSMS";
            this.btnGuiSMS.Size = new System.Drawing.Size(288, 50);
            this.btnGuiSMS.TabIndex = 186;
            this.btnGuiSMS.Text = "Gửi SMS";
            // 
            // btnGuiSMSAll
            // 
            this.btnGuiSMSAll.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiSMSAll.Appearance.Options.UseFont = true;
            this.btnGuiSMSAll.Location = new System.Drawing.Point(48, 154);
            this.btnGuiSMSAll.Name = "btnGuiSMSAll";
            this.btnGuiSMSAll.Size = new System.Drawing.Size(288, 50);
            this.btnGuiSMSAll.TabIndex = 186;
            this.btnGuiSMSAll.Text = "Gửi SMS tất cả cùng ngày";
            // 
            // FrmChucNangLLV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 250);
            this.Controls.Add(this.btnGuiSMSAll);
            this.Controls.Add(this.btnGuiSMS);
            this.Controls.Add(this.btnDangKy);
            this.Name = "FrmChucNangLLV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHỨC NĂNG";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDangKy;
        private DevExpress.XtraEditors.SimpleButton btnGuiSMS;
        private DevExpress.XtraEditors.SimpleButton btnGuiSMSAll;
    }
}