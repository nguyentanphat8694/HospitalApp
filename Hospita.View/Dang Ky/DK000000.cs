using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Hospital.App
{
    public partial class DK000000 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DK000000()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            InitDisplay();

        }

        frmDangKy frmDangKy = null;
        frmDSDangKy frmDanhSachDangKy = null;
        frmDSChoThuTien frmChoThuTien = null;
        frmDSDaThu frmDanhSach = null;
        frmNhapkho frmKho = null;
        frmDSHenKham frmHK = null;
        void InitDisplay()
        {
            DevExpress.XtraBars.Docking2010.DocumentManager manager = new DevExpress.XtraBars.Docking2010.DocumentManager();
            manager.MdiParent = this;
            manager.View = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView();

        }
        void LoadControl()
        {
            LoadControlDangKy();
            LoadControlDanhSachDangKy();
            LoadControlHK();
            LoadControlChoThuTien();
            LoadControlDanhSachPhieuThu();
            LoadControlKho();
        }

        void LoadControlDangKy()
        {
            try
            {

                if (frmDangKy == null)
                {
                    frmDangKy = new frmDangKy();
                    frmDangKy.MdiParent = frmDangKy.ActiveForm;
                    frmDangKy.WindowState = FormWindowState.Maximized;
                    frmDangKy.FormClosed += frmDangKy_FormClosed;
                    frmDangKy.Show();
                }
                else frmDangKy.Activate();
            }
            catch
            {
            }
        }

        void LoadControlDanhSachDangKy()
        {
            try
            {
                if (frmDanhSachDangKy == null)
                {
                    frmDanhSachDangKy = new frmDSDangKy();
                    frmDanhSachDangKy.MdiParent = frmDSDangKy.ActiveForm;
                    frmDanhSachDangKy.WindowState = FormWindowState.Maximized;
                    frmDanhSachDangKy.FormClosed += frmDanhSachDangKy_FormClosed;
                    frmDanhSachDangKy.Show();
                }
                else frmDanhSachDangKy.Activate();
            }
            catch
            {
            }
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
                    frmChoThuTien.FormClosed += frmChoThuTien_FormClosed;
                    frmChoThuTien.Show();
                }
                else frmChoThuTien.Activate();
            }
            catch
            {
            }
        }
        void LoadControlKho()
        {
            try
            {
                if (frmKho == null)
                {
                    frmKho = new frmNhapkho();
                    frmKho.MdiParent = frmNhapkho.ActiveForm;
                    frmKho.WindowState = FormWindowState.Maximized;
                    frmKho.FormClosed += frmKho_FormClosed;
                    frmKho.Show();
                }
                else frmKho.Activate();
            }
            catch
            {
            }
        }

        void LoadControlHK()
        {
            try
            {
                if (frmHK == null)
                {
                    frmHK = new frmDSHenKham();
                    frmHK.MdiParent = frmDSHenKham.ActiveForm;
                    frmHK.WindowState = FormWindowState.Maximized;
                    frmHK.FormClosed += frmHK_FormClosed;
                    frmHK.viewHenKham.DoubleClick += viewChidinh_DoubleClick;
                    frmHK.Show();
                }
                else frmHK.Activate();
            }
            catch
            {
            }
        }

        void viewChidinh_DoubleClick(object sender, EventArgs e)
        {
            if (frmHK == null || frmDangKy == null) return;
            ObHenKham ob = (ObHenKham)frmHK.viewHenKham.GetFocusedRow();
            if (ob == null) return;
            if (ob.TrangThai == etrangthai.Đã_đến.ToString())
            {
                MessageBox.Show("Phiếu hẹn đã đăng ký! Không thể đăng ký tiếp!");
                return;
            }
            //frmDangKy.SetHenKham(ob);
        }

        void frmHK_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmHK = null;
        }

        void frmKho_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmKho = null;
        }

        void frmChoThuTien_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChoThuTien = null;
        }
        void LoadControlDanhSachPhieuThu()
        {
            try
            {
                if (frmDanhSach == null)
                {
                    frmDanhSach = new frmDSDaThu();
                    frmDanhSach.MdiParent = frmDSDaThu.ActiveForm;
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

        void frmDanhSach_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDanhSach = null;
        }


        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmDanhSachDangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDanhSachDangKy = null;
        }

        void frmDangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDangKy = null;
        }

        private void btDanhSachDangKy_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlDanhSachDangKy();
        }

        private void DK000000_Shown(object sender, EventArgs e)
        {
            LoadControl();
            frmDangKy.Activate();
            ribbon.Minimized = true;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlDangKy();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlChoThuTien();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlDanhSachPhieuThu();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlKho();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlHK();
        }
    }
}