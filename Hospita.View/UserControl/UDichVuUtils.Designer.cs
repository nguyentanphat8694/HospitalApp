namespace Hospital.App
{
    partial class UDichVuUtils
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDichVu)).BeginInit();
            this.cmsDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewDichVu)).BeginInit();
            this.SuspendLayout();
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
            this.groupControl2.Size = new System.Drawing.Size(1257, 506);
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
            this.gridDichVu.Size = new System.Drawing.Size(1253, 483);
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
            this.gridColumn4.Width = 123;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tên dịch vụ";
            this.gridColumn5.FieldName = "Ten";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 305;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "SL";
            this.gridColumn6.FieldName = "SL";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 95;
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
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 291;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Hoàn thành";
            this.gridColumn8.FieldName = "HoanThanh";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 135;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Đã thu";
            this.gridColumn9.FieldName = "DaThu";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 119;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Miễn phí";
            this.gridColumn10.FieldName = "TTChung.MienPhi";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            this.gridColumn10.Width = 169;
            // 
            // UDichVuUtils
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Name = "UDichVuUtils";
            this.Size = new System.Drawing.Size(1257, 506);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDichVu)).EndInit();
            this.cmsDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.viewDichVu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
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
    }
}
