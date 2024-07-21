namespace Hospital.App
{
    partial class UImages
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btPaste = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.pnlMain = new DevExpress.XtraEditors.XtraScrollableControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btPaste);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.cbSo);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(665, 38);
            this.panelControl1.TabIndex = 0;
            // 
            // btPaste
            // 
            this.btPaste.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPaste.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btPaste.Appearance.Options.UseFont = true;
            this.btPaste.Appearance.Options.UseForeColor = true;
            this.btPaste.Dock = System.Windows.Forms.DockStyle.Right;
            this.btPaste.Location = new System.Drawing.Point(581, 2);
            this.btPaste.Name = "btPaste";
            this.btPaste.Size = new System.Drawing.Size(82, 34);
            this.btPaste.TabIndex = 2;
            this.btPaste.Text = "Dán ảnh";
            this.btPaste.Visible = false;
            this.btPaste.Click += new System.EventHandler(this.btPaste_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số cột hiển thị";
            // 
            // cbSo
            // 
            this.cbSo.EditValue = "2";
            this.cbSo.Location = new System.Drawing.Point(111, 3);
            this.cbSo.Name = "cbSo";
            this.cbSo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSo.Properties.Appearance.Options.UseFont = true;
            this.cbSo.Properties.Appearance.Options.UseTextOptions = true;
            this.cbSo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbSo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSo.Properties.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "7",
            "10"});
            this.cbSo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbSo.Size = new System.Drawing.Size(66, 30);
            this.cbSo.TabIndex = 0;
            this.cbSo.SelectedIndexChanged += new System.EventHandler(this.cbSo_SelectedIndexChanged);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 38);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(665, 354);
            this.pnlMain.TabIndex = 1;
            this.pnlMain.Click += new System.EventHandler(this.pnlMain_Click);
            // 
            // UImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panelControl1);
            this.Name = "UImages";
            this.Size = new System.Drawing.Size(665, 392);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit cbSo;
        private DevExpress.XtraEditors.SimpleButton btPaste;
        private DevExpress.XtraEditors.XtraScrollableControl pnlMain;
    }
}
