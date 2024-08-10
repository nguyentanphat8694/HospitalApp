using System;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Hospital.App
{
    public partial class TT000000 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public TT000000()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            InitDisplay();

        }

        frmDSChoThuTien frmChoThuTien = null;
        frmDSDaThu frmDanhSach = null;

        void InitDisplay()
        {
            DevExpress.XtraBars.Docking2010.DocumentManager manager = new DevExpress.XtraBars.Docking2010.DocumentManager();
            manager.MdiParent = this;
            manager.View = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView();

        }
        void LoadControl()
        {
            LoadControlChoThuTien();
            LoadControlDanhSach();
        }

        void LoadControlChoThuTien()
        {
            try
            {
                if (frmChoThuTien == null)
                {
                    frmChoThuTien = new frmDSChoThuTien();
                    frmChoThuTien.MdiParent = frmDSChoThuTien.ActiveForm;
                    frmChoThuTien.WindowState = FormWindowState.Maximized;
                    frmChoThuTien.FormClosed += frmDangKy_FormClosed;
                    frmChoThuTien.Show();
                }
                else frmChoThuTien.Activate();
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
                    frmDanhSach = new frmDSDaThu();
                    frmDanhSach.MdiParent = frmDSDaThu.ActiveForm;
                    frmDanhSach.WindowState = FormWindowState.Maximized;
                    frmDanhSach.FormClosed += frmDangKy_FormClosed;
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
        void frmDanhSachDangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDanhSach = null;
        }

        void frmDangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChoThuTien = null;
        }

        private void btDanhSachDangKy_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlChoThuTien();
        }

        private void DK000000_Shown(object sender, EventArgs e)
        {
            LoadControl();
            frmChoThuTien.Activate();
            ribbon.Minimized = true;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlDanhSach();
        }
    }
}