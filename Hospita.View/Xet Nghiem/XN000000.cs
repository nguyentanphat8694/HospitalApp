using System;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Hospital.App
{
    public partial class XN000000 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public XN000000()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            InitDisplay();

        }

        frmDSChoXN frmChoKham = null;
        frmDSPhieuXN frmDanhSach = null;

        void InitDisplay()
        {
            DevExpress.XtraBars.Docking2010.DocumentManager manager = new DevExpress.XtraBars.Docking2010.DocumentManager();
            manager.MdiParent = this;
            manager.View = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView();

        }
        void LoadControl()
        {
            LoadControlChoKham();
            LoadControlDanhSach();
        }

        void LoadControlChoKham()
        {
            try
            {
                if (frmChoKham == null)
                {
                    frmChoKham = new frmDSChoXN();
                    frmChoKham.MdiParent = frmDSChoXN.ActiveForm;
                    frmChoKham.WindowState = FormWindowState.Maximized;
                    frmChoKham.FormClosed += frmDangKy_FormClosed;
                    frmChoKham.Show();
                }
                else frmChoKham.Activate();
            }
            catch
            {
            }
        }

        void LoadControlDanhSach()
        {
            try
            {
                if (frmDanhSach == null)
                {
                    frmDanhSach = new frmDSPhieuXN();
                    frmDanhSach.MdiParent = frmDSPhieuXN.ActiveForm;
                    frmDanhSach.WindowState = FormWindowState.Maximized;
                    frmDanhSach.FormClosed += frmDanhSach_FormClosed;
                    frmDanhSach.Show();
                }
                else frmDanhSach.Activate();
            }
            catch
            {
            }
        }




        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmDanhSach_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDanhSach = null;
        }

        void frmDangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChoKham = null;
        }

        private void btDanhSachDangKy_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlChoKham();
        }

        private void DK000000_Shown(object sender, EventArgs e)
        {
            LoadControl();
            frmChoKham.Activate();
            ribbon.Minimized = true;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlDanhSach();
        }
    }
}