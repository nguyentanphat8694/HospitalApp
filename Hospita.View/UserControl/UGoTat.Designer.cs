namespace Hospital.App
{
    partial class UGoTat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UGoTat));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.ppCtrMain = new DevExpress.XtraEditors.PopupContainerControl();
            this.gridMain = new DevExpress.XtraGrid.GridControl();
            this.viewMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ppMain = new DevExpress.XtraEditors.PopupContainerEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ppCtrMain)).BeginInit();
            this.ppCtrMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppMain.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ppCtrMain
            // 
            this.ppCtrMain.Controls.Add(this.gridMain);
            this.ppCtrMain.Location = new System.Drawing.Point(0, 30);
            this.ppCtrMain.Name = "ppCtrMain";
            this.ppCtrMain.Size = new System.Drawing.Size(432, 260);
            this.ppCtrMain.TabIndex = 4;
            // 
            // gridMain
            // 
            this.gridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMain.Location = new System.Drawing.Point(0, 0);
            this.gridMain.MainView = this.viewMain;
            this.gridMain.Name = "gridMain";
            this.gridMain.Size = new System.Drawing.Size(432, 260);
            this.gridMain.TabIndex = 0;
            this.gridMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewMain});
            // 
            // viewMain
            // 
            this.viewMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1});
            this.viewMain.GridControl = this.gridMain;
            this.viewMain.Name = "viewMain";
            this.viewMain.OptionsBehavior.Editable = false;
            this.viewMain.OptionsView.ShowGroupPanel = false;
            this.viewMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.viewMain_KeyDown);
            this.viewMain.DoubleClick += new System.EventHandler(this.viewMain_DoubleClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên";
            this.gridColumn2.FieldName = "Ten";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 950;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã";
            this.gridColumn1.FieldName = "Ma";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 214;
            // 
            // ppMain
            // 
            this.ppMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppMain.EditValue = "";
            this.ppMain.Location = new System.Drawing.Point(0, 0);
            this.ppMain.Name = "ppMain";
            this.ppMain.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppMain.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            serializableAppearanceObject1.Options.UseFont = true;
            this.ppMain.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Thêm vào Danh mục", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, ((System.Drawing.Image)(resources.GetObject("ppMain.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.ppMain.Properties.LookAndFeel.SkinName = "Blue";
            this.ppMain.Properties.Mask.IgnoreMaskBlank = false;
            this.ppMain.Properties.PopupControl = this.ppCtrMain;
            this.ppMain.Properties.ShowPopupCloseButton = false;
            this.ppMain.Properties.ShowPopupShadow = false;
            this.ppMain.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ppMain.Size = new System.Drawing.Size(435, 24);
            this.ppMain.TabIndex = 3;
            this.ppMain.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ppMain_ButtonClick);
            this.ppMain.TextChanged += new System.EventHandler(this.ppMain_TextChanged);
            this.ppMain.Click += new System.EventHandler(this.ppMain_Click);
            this.ppMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ppMain_KeyDown);
            this.ppMain.Leave += new System.EventHandler(this.ppMain_Leave);
            // 
            // UGoTat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ppCtrMain);
            this.Controls.Add(this.ppMain);
            this.Name = "UGoTat";
            this.Size = new System.Drawing.Size(435, 281);
            ((System.ComponentModel.ISupportInitialize)(this.ppCtrMain)).EndInit();
            this.ppCtrMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppMain.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.PopupContainerControl ppCtrMain;
        public DevExpress.XtraEditors.PopupContainerEdit ppMain;
        private DevExpress.XtraGrid.GridControl gridMain;
        private DevExpress.XtraGrid.Views.Grid.GridView viewMain;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}
