namespace Hospital.App
{
    partial class UImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UImage));
            this.picImage = new DevExpress.XtraEditors.PictureEdit();
            this.lbSTT = new System.Windows.Forms.Label();
            this.btDelete = new DevExpress.XtraEditors.PictureEdit();
            this.cheIn = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btDelete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cheIn.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImage.Location = new System.Drawing.Point(0, 0);
            this.picImage.Name = "picImage";
            this.picImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picImage.Size = new System.Drawing.Size(114, 113);
            this.picImage.TabIndex = 0;
            // 
            // lbSTT
            // 
            this.lbSTT.AutoSize = true;
            this.lbSTT.BackColor = System.Drawing.Color.White;
            this.lbSTT.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSTT.Location = new System.Drawing.Point(3, 1);
            this.lbSTT.Name = "lbSTT";
            this.lbSTT.Size = new System.Drawing.Size(19, 19);
            this.lbSTT.TabIndex = 1;
            this.lbSTT.Text = "1";
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.EditValue = ((object)(resources.GetObject("btDelete.EditValue")));
            this.btDelete.Location = new System.Drawing.Point(0, 93);
            this.btDelete.Name = "btDelete";
            this.btDelete.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.btDelete.Size = new System.Drawing.Size(23, 20);
            this.btDelete.TabIndex = 2;
            // 
            // cheIn
            // 
            this.cheIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cheIn.Location = new System.Drawing.Point(93, 1);
            this.cheIn.Name = "cheIn";
            this.cheIn.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cheIn.Properties.Appearance.Options.UseFont = true;
            this.cheIn.Properties.Caption = "";
            this.cheIn.Size = new System.Drawing.Size(19, 21);
            this.cheIn.TabIndex = 3;
            // 
            // UImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cheIn);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.lbSTT);
            this.Controls.Add(this.picImage);
            this.Name = "UImage";
            this.Size = new System.Drawing.Size(114, 113);
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btDelete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cheIn.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.PictureEdit picImage;
        public DevExpress.XtraEditors.PictureEdit btDelete;
        public System.Windows.Forms.Label lbSTT;
        public DevExpress.XtraEditors.CheckEdit cheIn;
    }
}
