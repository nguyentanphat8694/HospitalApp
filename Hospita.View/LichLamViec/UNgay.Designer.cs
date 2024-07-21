namespace Hospital.App
{
    partial class UNgay
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
            this.lbNoiDung = new DevExpress.XtraEditors.LabelControl();
            this.lbThu = new DevExpress.XtraEditors.LabelControl();
            this.gridMain = new DevExpress.XtraGrid.GridControl();
            this.viewMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.rlkNguoiThucHien = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemComboBox6 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemLookUpEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cheNghi = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkNguoiThucHien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cheNghi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNoiDung
            // 
            this.lbNoiDung.Appearance.BackColor = System.Drawing.Color.White;
            this.lbNoiDung.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoiDung.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lbNoiDung.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbNoiDung.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbNoiDung.Location = new System.Drawing.Point(89, 40);
            this.lbNoiDung.Name = "lbNoiDung";
            this.lbNoiDung.Size = new System.Drawing.Size(48, 21);
            this.lbNoiDung.TabIndex = 14;
            this.lbNoiDung.Text = "rer";
            this.lbNoiDung.Visible = false;
            // 
            // lbThu
            // 
            this.lbThu.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbThu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThu.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbThu.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbThu.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbThu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbThu.Location = new System.Drawing.Point(0, 0);
            this.lbThu.Name = "lbThu";
            this.lbThu.Size = new System.Drawing.Size(507, 25);
            this.lbThu.TabIndex = 16;
            this.lbThu.Text = "THỨ 2";
            // 
            // gridMain
            // 
            this.gridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMain.Location = new System.Drawing.Point(2, 2);
            this.gridMain.MainView = this.viewMain;
            this.gridMain.Name = "gridMain";
            this.gridMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlkNguoiThucHien,
            this.repositoryItemMemoEdit7,
            this.repositoryItemComboBox6,
            this.repositoryItemLookUpEdit7,
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemCheckEdit6});
            this.gridMain.Size = new System.Drawing.Size(503, 178);
            this.gridMain.TabIndex = 131;
            this.gridMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewMain});
            // 
            // viewMain
            // 
            this.viewMain.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.viewMain.Appearance.HeaderPanel.Options.UseFont = true;
            this.viewMain.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.viewMain.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.viewMain.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.viewMain.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.viewMain.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.viewMain.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White;
            this.viewMain.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.viewMain.AppearancePrint.FooterPanel.Options.UseBackColor = true;
            this.viewMain.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.viewMain.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.viewMain.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.viewMain.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.viewMain.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.viewMain.ColumnPanelRowHeight = 32;
            this.viewMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1});
            this.viewMain.GridControl = this.gridMain;
            this.viewMain.IndicatorWidth = 20;
            this.viewMain.Name = "viewMain";
            this.viewMain.OptionsBehavior.Editable = false;
            this.viewMain.OptionsCustomization.AllowFilter = false;
            this.viewMain.OptionsNavigation.EnterMoveNextColumn = true;
            this.viewMain.OptionsView.EnableAppearanceEvenRow = true;
            this.viewMain.OptionsView.RowAutoHeight = true;
            this.viewMain.OptionsView.ShowColumnHeaders = false;
            this.viewMain.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.viewMain.OptionsView.ShowGroupPanel = false;
            this.viewMain.OptionsView.ShowIndicator = false;
            this.viewMain.OptionsView.ShowViewCaption = true;
            this.viewMain.ViewCaption = "BỆNH HẸN KHÁM";
            this.viewMain.DoubleClick += new System.EventHandler(this.viewMain_DoubleClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "ThoiGian";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 297;
            // 
            // gridColumn1
            // 
            this.gridColumn1.ColumnEdit = this.repositoryItemMemoEdit7;
            this.gridColumn1.FieldName = "NoiDung";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 863;
            // 
            // repositoryItemMemoEdit7
            // 
            this.repositoryItemMemoEdit7.Name = "repositoryItemMemoEdit7";
            // 
            // rlkNguoiThucHien
            // 
            this.rlkNguoiThucHien.AutoHeight = false;
            this.rlkNguoiThucHien.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkNguoiThucHien.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten", "Name2")});
            this.rlkNguoiThucHien.DisplayMember = "Ten";
            this.rlkNguoiThucHien.Name = "rlkNguoiThucHien";
            this.rlkNguoiThucHien.NullText = "";
            this.rlkNguoiThucHien.ShowFooter = false;
            this.rlkNguoiThucHien.ShowHeader = false;
            this.rlkNguoiThucHien.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rlkNguoiThucHien.ValueMember = "Ma";
            // 
            // repositoryItemComboBox6
            // 
            this.repositoryItemComboBox6.AutoHeight = false;
            this.repositoryItemComboBox6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox6.Name = "repositoryItemComboBox6";
            // 
            // repositoryItemLookUpEdit7
            // 
            this.repositoryItemLookUpEdit7.AutoHeight = false;
            this.repositoryItemLookUpEdit7.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit7.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ma", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten", "Name2")});
            this.repositoryItemLookUpEdit7.DisplayMember = "Ten";
            this.repositoryItemLookUpEdit7.Name = "repositoryItemLookUpEdit7";
            this.repositoryItemLookUpEdit7.NullText = "";
            this.repositoryItemLookUpEdit7.ShowFooter = false;
            this.repositoryItemLookUpEdit7.ShowHeader = false;
            this.repositoryItemLookUpEdit7.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.repositoryItemLookUpEdit7.ValueMember = "Ma";
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.DisplayMember = "Ten";
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.NullText = "";
            this.repositoryItemGridLookUpEdit1.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.repositoryItemGridLookUpEdit1.PopupFormMinSize = new System.Drawing.Size(420, 0);
            this.repositoryItemGridLookUpEdit1.ShowFooter = false;
            this.repositoryItemGridLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.repositoryItemGridLookUpEdit1.ValueMember = "Ma";
            this.repositoryItemGridLookUpEdit1.View = this.gridView2;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Mã";
            this.gridColumn12.FieldName = "Ma";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 176;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Tên thuốc";
            this.gridColumn13.FieldName = "Ten";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            this.gridColumn13.Width = 548;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Hàm lượng";
            this.gridColumn14.FieldName = "Gocthuoc";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 370;
            // 
            // repositoryItemCheckEdit6
            // 
            this.repositoryItemCheckEdit6.AutoHeight = false;
            this.repositoryItemCheckEdit6.Name = "repositoryItemCheckEdit6";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cheNghi);
            this.panelControl1.Controls.Add(this.lbNoiDung);
            this.panelControl1.Controls.Add(this.gridMain);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 25);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(507, 182);
            this.panelControl1.TabIndex = 133;
            // 
            // cheNghi
            // 
            this.cheNghi.Location = new System.Drawing.Point(3, 3);
            this.cheNghi.Name = "cheNghi";
            this.cheNghi.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.cheNghi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cheNghi.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.cheNghi.Properties.Appearance.Options.UseBackColor = true;
            this.cheNghi.Properties.Appearance.Options.UseFont = true;
            this.cheNghi.Properties.Appearance.Options.UseForeColor = true;
            this.cheNghi.Properties.Caption = "01";
            this.cheNghi.Size = new System.Drawing.Size(49, 23);
            this.cheNghi.TabIndex = 133;
            this.cheNghi.CheckedChanged += new System.EventHandler(this.cheNghi_CheckedChanged);
            // 
            // UNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.lbThu);
            this.Name = "UNgay";
            this.Size = new System.Drawing.Size(507, 207);
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkNguoiThucHien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cheNghi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbNoiDung;
        private DevExpress.XtraEditors.LabelControl lbThu;
        public DevExpress.XtraGrid.GridControl gridMain;
        public DevExpress.XtraGrid.Views.Grid.GridView viewMain;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkNguoiThucHien;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit7;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit7;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit6;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit cheNghi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;

    }
}
