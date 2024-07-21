namespace Hospital.App
{
    partial class TI010100
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
            this.components = new System.ComponentModel.Container();
            this.lbTHOIGIAN = new DevExpress.XtraEditors.TextEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lbTHOIGIAN.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTHOIGIAN
            // 
            this.lbTHOIGIAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTHOIGIAN.EditValue = "02/02/2016 04:35:59";
            this.lbTHOIGIAN.EnterMoveNextControl = true;
            this.lbTHOIGIAN.Location = new System.Drawing.Point(0, 0);
            this.lbTHOIGIAN.Name = "lbTHOIGIAN";
            this.lbTHOIGIAN.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTHOIGIAN.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lbTHOIGIAN.Properties.Appearance.Options.UseFont = true;
            this.lbTHOIGIAN.Properties.Appearance.Options.UseForeColor = true;
            this.lbTHOIGIAN.Properties.Appearance.Options.UseTextOptions = true;
            this.lbTHOIGIAN.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbTHOIGIAN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.lbTHOIGIAN.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lbTHOIGIAN.Properties.ReadOnly = true;
            this.lbTHOIGIAN.Size = new System.Drawing.Size(150, 22);
            this.lbTHOIGIAN.TabIndex = 160;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TI010100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbTHOIGIAN);
            this.Name = "TI010100";
            this.Size = new System.Drawing.Size(150, 31);
            this.Load += new System.EventHandler(this.TI010100_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lbTHOIGIAN.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit lbTHOIGIAN;
        private System.Windows.Forms.Timer timer1;
    }
}
