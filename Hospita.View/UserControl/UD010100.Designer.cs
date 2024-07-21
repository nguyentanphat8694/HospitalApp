namespace Hospital.App
{
    partial class UD010100
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridDSDichVu = new DevExpress.XtraGrid.GridControl();
            this.viewDSDichVu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.teSearch = new DevExpress.XtraEditors.TextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridDichVu = new DevExpress.XtraGrid.GridControl();
            this.cmsDichVu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnXoaDong = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDichVu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDSDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDichVu)).BeginInit();
            this.cmsDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewDichVu)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1257, 506);
            this.splitContainerControl1.SplitterPosition = 426;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.gridDSDichVu);
            this.groupControl1.Controls.Add(this.teSearch);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(426, 506);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "DANH SÁCH DỊCH VỤ";
            // 
            // gridDSDichVu
            // 
            this.gridDSDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDSDichVu.Location = new System.Drawing.Point(2, 43);
            this.gridDSDichVu.MainView = this.viewDSDichVu;
            this.gridDSDichVu.Name = "gridDSDichVu";
            this.gridDSDichVu.Size = new System.Drawing.Size(422, 461);
            this.gridDSDichVu.TabIndex = 0;
            this.gridDSDichVu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewDSDichVu});
            // 
            // viewDSDichVu
            // 
            this.viewDSDichVu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.viewDSDichVu.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.viewDSDichVu.GridControl = this.gridDSDichVu;
            this.viewDSDichVu.GroupCount = 1;
            this.viewDSDichVu.Name = "viewDSDichVu";
            this.viewDSDichVu.OptionsBehavior.Editable = false;
            this.viewDSDichVu.OptionsBehavior.KeepFocusedRowOnUpdate = false;
            this.viewDSDichVu.OptionsView.ShowGroupPanel = false;
            this.viewDSDichVu.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn3, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.viewDSDichVu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.viewDSDichVu_KeyDown);
            this.viewDSDichVu.DoubleClick += new System.EventHandler(this.viewDSDichVu_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.Caption = "Mã";
            this.gridColumn1.FieldName = "MaDV";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 91;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.Caption = "Tên dịch vụ";
            this.gridColumn2.FieldName = "Ten";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 315;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.Caption = "Nhóm";
            this.gridColumn3.FieldName = "TenNhom";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // teSearch
            // 
            this.teSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.teSearch.Location = new System.Drawing.Point(2, 21);
            this.teSearch.Name = "teSearch";
            this.teSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teSearch.Properties.Appearance.Options.UseFont = true;
            this.teSearch.Size = new System.Drawing.Size(422, 22);
            this.teSearch.TabIndex = 1;
            this.teSearch.EditValueChanged += new System.EventHandler(this.teSearch_EditValueChanged);
            this.teSearch.Click += new System.EventHandler(this.teSearch_Click);
            this.teSearch.Enter += new System.EventHandler(this.teSearch_Enter);
            this.teSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.teSearch_KeyDown);
            this.teSearch.Leave += new System.EventHandler(this.teSearch_Leave);
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.gridDichVu);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(826, 506);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "DỊCH VỤ ĐÃ CHỌN";
            // 
            // gridDichVu
            // 
            this.gridDichVu.ContextMenuStrip = this.cmsDichVu;
            this.gridDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDichVu.Location = new System.Drawing.Point(2, 21);
            this.gridDichVu.MainView = this.viewDichVu;
            this.gridDichVu.Name = "gridDichVu";
            this.gridDichVu.Size = new System.Drawing.Size(822, 483);
            this.gridDichVu.TabIndex = 1;
            this.gridDichVu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewDichVu});
            // 
            // cmsDichVu
            // 
            this.cmsDichVu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnXoaDong});
            this.cmsDichVu.Name = "cmsDichVu";
            this.cmsDichVu.Size = new System.Drawing.Size(126, 26);
            // 
            // mnXoaDong
            // 
            this.mnXoaDong.Name = "mnXoaDong";
            this.mnXoaDong.Size = new System.Drawing.Size(125, 22);
            this.mnXoaDong.Text = "Xóa dòng";
            this.mnXoaDong.Click += new System.EventHandler(this.mnXoaDong_Click);
            // 
            // viewDichVu
            // 
            this.viewDichVu.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewDichVu.Appearance.FooterPanel.Options.UseFont = true;
            this.viewDichVu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.viewDichVu.GridControl = this.gridDichVu;
            this.viewDichVu.Name = "viewDichVu";
            this.viewDichVu.OptionsView.ShowFooter = true;
            this.viewDichVu.OptionsView.ShowGroupPanel = false;
            this.viewDichVu.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.viewDichVu_CellValueChanged);
            this.viewDichVu.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.viewDichVu_CellValueChanging);
            this.viewDichVu.DoubleClick += new System.EventHandler(this.viewDichVu_DoubleClick);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Mã";
            this.gridColumn4.FieldName = "MaDV";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 62;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tên dịch vụ";
            this.gridColumn5.FieldName = "Ten";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 357;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "SL";
            this.gridColumn6.FieldName = "SL";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 48;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Thành tiền";
            this.gridColumn7.DisplayFormat.FormatString = "n0";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "ThanhTien";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThanhTien", "{0:n0}")});
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 127;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Hoàn thành";
            this.gridColumn8.FieldName = "HoanThanh";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 68;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Đã thu";
            this.gridColumn9.FieldName = "DaThu";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 60;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Miễn phí";
            this.gridColumn10.FieldName = "TTChung.MienPhi";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            this.gridColumn10.Width = 84;
            // 
            // UD010100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "UD010100";
            this.Size = new System.Drawing.Size(1257, 506);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDSDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDSDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDichVu)).EndInit();
            this.cmsDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.viewDichVu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridDSDichVu;
        private DevExpress.XtraGrid.Views.Grid.GridView viewDSDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.GridControl gridDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.ContextMenuStrip cmsDichVu;
        private System.Windows.Forms.ToolStripMenuItem mnXoaDong;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        public DevExpress.XtraGrid.Views.Grid.GridView viewDichVu;
        public DevExpress.XtraEditors.TextEdit teSearch;
    }
}
