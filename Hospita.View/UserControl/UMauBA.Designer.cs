namespace Hospital.App
{
    partial class UMauBA
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lkMAU = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtNOIDUNG = new DevExpress.XtraRichEdit.RichEditControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkMAU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.lkMAU);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(684, 31);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(9, 7);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 18);
            this.labelControl2.TabIndex = 219;
            this.labelControl2.Text = "Chọn mẫu";
            // 
            // lkMAU
            // 
            this.lkMAU.EditValue = "";
            this.lkMAU.Location = new System.Drawing.Point(83, 4);
            this.lkMAU.Margin = new System.Windows.Forms.Padding(2);
            this.lkMAU.Name = "lkMAU";
            this.lkMAU.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkMAU.Properties.Appearance.Options.UseFont = true;
            this.lkMAU.Properties.AutoComplete = false;
            this.lkMAU.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "CHỌN MẪU KHÁC", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkMAU.Properties.DisplayMember = "Ten";
            this.lkMAU.Properties.NullText = "";
            this.lkMAU.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lkMAU.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkMAU.Properties.ValueMember = "Ma";
            this.lkMAU.Properties.View = this.gridView1;
            this.lkMAU.Size = new System.Drawing.Size(318, 24);
            this.lkMAU.TabIndex = 218;
            this.lkMAU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lkMAU_ButtonClick);
            this.lkMAU.EditValueChanged += new System.EventHandler(this.lkMAU_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn37});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "Tên";
            this.gridColumn37.FieldName = "Ten";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 0;
            // 
            // rtxtNOIDUNG
            // 
            this.rtxtNOIDUNG.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            this.rtxtNOIDUNG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtNOIDUNG.Location = new System.Drawing.Point(0, 31);
            this.rtxtNOIDUNG.Name = "rtxtNOIDUNG";
            this.rtxtNOIDUNG.Options.MailMerge.KeepLastParagraph = false;
            this.rtxtNOIDUNG.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Visible;
            this.rtxtNOIDUNG.Size = new System.Drawing.Size(684, 455);
            this.rtxtNOIDUNG.TabIndex = 13;
            this.rtxtNOIDUNG.Views.DraftView.Padding = new DevExpress.Portable.PortablePadding(45, 4, 0, 0);
            // 
            // UMauBA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtxtNOIDUNG);
            this.Controls.Add(this.panelControl1);
            this.Name = "UMauBA";
            this.Size = new System.Drawing.Size(684, 486);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkMAU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        public DevExpress.XtraRichEdit.RichEditControl rtxtNOIDUNG;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.GridLookUpEdit lkMAU;
    }
}
