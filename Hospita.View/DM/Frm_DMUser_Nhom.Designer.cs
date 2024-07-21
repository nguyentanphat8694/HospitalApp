namespace Hospital.App
{
    partial class Frm_DMUser_Nhom
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
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btExit = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.gridNHOM = new DevExpress.XtraGrid.GridControl();
            this.viewNHOM = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNHOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewNHOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btExit);
            this.panelControl3.Controls.Add(this.btSave);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 432);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(365, 49);
            this.panelControl3.TabIndex = 172;
            // 
            // btExit
            // 
            this.btExit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btExit.Appearance.Options.UseFont = true;
            this.btExit.Appearance.Options.UseForeColor = true;
            this.btExit.Location = new System.Drawing.Point(12, 5);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(126, 39);
            this.btExit.TabIndex = 1;
            this.btExit.Text = "THOÁT\r\nF9";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btSave.Appearance.Options.UseFont = true;
            this.btSave.Appearance.Options.UseForeColor = true;
            this.btSave.Location = new System.Drawing.Point(227, 5);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(126, 39);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "LƯU PHIẾU\r\nF2";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // gridNHOM
            // 
            this.gridNHOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNHOM.Location = new System.Drawing.Point(0, 0);
            this.gridNHOM.MainView = this.viewNHOM;
            this.gridNHOM.Name = "gridNHOM";
            this.gridNHOM.Size = new System.Drawing.Size(365, 432);
            this.gridNHOM.TabIndex = 173;
            this.gridNHOM.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewNHOM,
            this.gridView2});
            // 
            // viewNHOM
            // 
            this.viewNHOM.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.colCHON});
            this.viewNHOM.GridControl = this.gridNHOM;
            this.viewNHOM.Name = "viewNHOM";
            this.viewNHOM.OptionsView.ColumnAutoWidth = false;
            this.viewNHOM.OptionsView.ShowAutoFilterRow = true;
            this.viewNHOM.OptionsView.ShowDetailButtons = false;
            this.viewNHOM.OptionsView.ShowFooter = true;
            this.viewNHOM.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "NHÓM";
            this.gridColumn2.FieldName = "TEN";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 288;
            // 
            // colCHON
            // 
            this.colCHON.Caption = "Chọn";
            this.colCHON.FieldName = "CHON";
            this.colCHON.Name = "colCHON";
            this.colCHON.Visible = true;
            this.colCHON.VisibleIndex = 0;
            this.colCHON.Width = 47;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25});
            this.gridView2.GridControl = this.gridNHOM;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Mã dịch vụ";
            this.gridColumn22.FieldName = "Ma";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 0;
            this.gridColumn22.Width = 121;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Tên dịch vụ";
            this.gridColumn23.FieldName = "Ten";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 1;
            this.gridColumn23.Width = 348;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Số lượng";
            this.gridColumn24.FieldName = "Soluong";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 2;
            this.gridColumn24.Width = 64;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Thành tiền";
            this.gridColumn25.DisplayFormat.FormatString = "n0";
            this.gridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn25.FieldName = "Tongtien";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Tongtien", "{0:n0}")});
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 3;
            this.gridColumn25.Width = 159;
            // 
            // Frm_DMUser_Nhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 481);
            this.Controls.Add(this.gridNHOM);
            this.Controls.Add(this.panelControl3);
            this.Name = "Frm_DMUser_Nhom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DANH MỤC NHÓM USER";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNHOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewNHOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btExit;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraGrid.GridControl gridNHOM;
        private DevExpress.XtraGrid.Views.Grid.GridView viewNHOM;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colCHON;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
    }
}