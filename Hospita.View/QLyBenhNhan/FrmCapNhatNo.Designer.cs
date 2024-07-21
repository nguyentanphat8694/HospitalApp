namespace Hospital.App
{
    partial class FrmCapNhatNo
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.teTongNo = new DevExpress.XtraEditors.ButtonEdit();
            this.lbTongNo = new DevExpress.XtraEditors.LabelControl();
            this.btLuu = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.teTongNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // teTongNo
            // 
            this.teTongNo.Location = new System.Drawing.Point(30, 60);
            this.teTongNo.Name = "teTongNo";
            this.teTongNo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teTongNo.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.teTongNo.Properties.Appearance.Options.UseFont = true;
            this.teTongNo.Properties.Appearance.Options.UseForeColor = true;
            this.teTongNo.Properties.Appearance.Options.UseTextOptions = true;
            this.teTongNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            serializableAppearanceObject1.Options.UseFont = true;
            this.teTongNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Tính tổng tiền", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.teTongNo.Properties.DisplayFormat.FormatString = "n0";
            this.teTongNo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.teTongNo.Properties.EditFormat.FormatString = "n0";
            this.teTongNo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.teTongNo.Properties.Mask.EditMask = "n0";
            this.teTongNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.teTongNo.Size = new System.Drawing.Size(287, 28);
            this.teTongNo.TabIndex = 172;
            this.teTongNo.Leave += new System.EventHandler(this.teTongNo_Leave);
            // 
            // lbTongNo
            // 
            this.lbTongNo.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongNo.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lbTongNo.Location = new System.Drawing.Point(30, 36);
            this.lbTongNo.Name = "lbTongNo";
            this.lbTongNo.Size = new System.Drawing.Size(46, 18);
            this.lbTongNo.TabIndex = 173;
            this.lbTongNo.Text = "Số tiền";
            // 
            // btLuu
            // 
            this.btLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLuu.Appearance.Options.UseFont = true;
            this.btLuu.Location = new System.Drawing.Point(179, 104);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(138, 50);
            this.btLuu.TabIndex = 185;
            this.btLuu.Text = "Lưu dữ liệu";
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // FrmCapNhatNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 183);
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.teTongNo);
            this.Controls.Add(this.lbTongNo);
            this.Name = "FrmCapNhatNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCapNhatNo";
            ((System.ComponentModel.ISupportInitialize)(this.teTongNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit teTongNo;
        private DevExpress.XtraEditors.LabelControl lbTongNo;
        private DevExpress.XtraEditors.SimpleButton btLuu;
    }
}