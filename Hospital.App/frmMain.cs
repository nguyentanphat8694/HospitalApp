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
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            ribbon.ApplicationIcon = MainNTP.NTPICON.ToBitmap();
            this.Icon = MainNTP.NTPICON;
            DevExpress.XtraBars.Docking2010.DocumentManager manager = new DevExpress.XtraBars.Docking2010.DocumentManager();
            manager.MdiParent = this;
            manager.View = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView();
        }

        
        Frm_DMDichVu frm1 = null;
        private void btDMDichVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm1 == null)
            {
                frm1 = new Frm_DMDichVu();
                frm1.MdiParent = Frm_DMDichVu.ActiveForm;
                //frm1.WindowState = FormWindowState.Maximized;
                frm1.FormClosed += frm1_FormClosed;
                frm1.Show();
            }
            else frm1.Activate();
        }

        void frm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm1 = null;
        }

        Frm_DMUser frm2 = null;
        private void btDMNguoiDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm2 == null)
            {
                frm2 = new Frm_DMUser();
                frm2.MdiParent = Frm_DMUser.ActiveForm;
                frm2.WindowState = FormWindowState.Maximized;
                frm2.FormClosed += frm2_FormClosed;
                frm2.Show();
            }
            else frm2.Activate();
        }

        void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm2 = null;
        }

        Frm_DMTSo frm3 = null;
        private void btThamSo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm3 == null)
            {
                frm3 = new Frm_DMTSo();
                frm3.MdiParent = Frm_DMTSo.ActiveForm;
                frm3.WindowState = FormWindowState.Maximized;
                frm3.FormClosed += frm3_FormClosed;
                frm3.Show();
            }
            else frm3.Activate();
        }

        void frm3_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm3 = null;
        }

        private void btDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        Frm_DMNhanSu frm4 = null;
        private void btDMNhanSu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm4 == null)
            {
                frm4 = new Frm_DMNhanSu();
                frm4.MdiParent = Frm_DMNhanSu.ActiveForm;
                frm4.WindowState = FormWindowState.Maximized;
                frm4.FormClosed += frm4_FormClosed;
                frm4.Show();
            }
            else frm4.Activate();
        }

        void frm4_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm4=null;
        }

        Frm_DMPK frm5 = null;
        private void btDMPhongKham_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm5 == null)
            {
                frm5 = new Frm_DMPK();
                frm5.MdiParent = Frm_DMPK.ActiveForm;
                frm5.WindowState = FormWindowState.Maximized;
                frm5.FormClosed += frm5_FormClosed;
                frm5.Show();
            }
            else frm5.Activate();
        }

        void frm5_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm5 = null;
        }

        Frm_DMNhomDichVu frm6 = null;
        private void btDMNhom_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm6 == null)
            {
                frm6 = new Frm_DMNhomDichVu();
                frm6.MdiParent = Frm_DMNhomDichVu.ActiveForm;
                frm6.WindowState = FormWindowState.Maximized;
                frm6.FormClosed += frm6_FormClosed;
                frm6.Show();
            }
            else frm6.Activate();
        }

        void frm6_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm6 = null;
        }

        Frm_DMICD frm7 = null;
        private void btDMCID_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm7 == null)
            {
                frm7 = new Frm_DMICD();
                frm7.MdiParent = Frm_DMICD.ActiveForm;
                frm7.WindowState = FormWindowState.Maximized;
                frm7.FormClosed += frm7_FormClosed;
                frm7.Show();
            }
            else frm7.Activate();
        }

        void frm7_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm7 = null;
        }

        Frm_DMDonVi frm8 = null;
        private void btDMDonVi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm8 == null)
            {
                frm8 = new Frm_DMDonVi();
                frm8.MdiParent = Frm_DMDonVi.ActiveForm;
                frm8.WindowState = FormWindowState.Maximized;
                frm8.FormClosed += frm8_FormClosed;
                frm8.Show();
            }
            else frm8.Activate();
        }

        void frm8_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm8 = null;
        }

        Frm_DMKho frm9 = null;
        private void btDMKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm9 == null)
            {
                frm9 = new Frm_DMKho();
                frm9.MdiParent = Frm_DMKho.ActiveForm;
                frm9.WindowState = FormWindowState.Maximized;
                frm9.FormClosed += frm9_FormClosed;
                frm9.Show();
            }
            else frm9.Activate();
        }

        void frm9_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm9 = null;
        }

        Frm_DMMau frm10 = null;
        private void btDMMau_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm10 == null)
            {
                frm10 = new Frm_DMMau();
                frm10.MdiParent = Frm_DMMau.ActiveForm;
                frm10.WindowState = FormWindowState.Maximized;
                frm10.FormClosed += frm10_FormClosed;
                frm10.Show();
            }
            else frm10.Activate();
        }

        void frm10_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm10 = null;
        }

        frmDangKy frm11 = null;
        private void btDangKy_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm11 == null)
            {
                frm11 = new frmDangKy();
                frm11.MdiParent = frmDangKy.ActiveForm;
                frm11.WindowState = FormWindowState.Maximized;
                frm11.FormClosed += frm11_FormClosed;
                frm11.Show();
            }
            else frm11.Activate();
        }

        void frm11_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm11 = null;
        
        }

        frmDSChoKham frm12 = null;
        private void btBenhAn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm12 == null)
            {
                frm12 = new frmDSChoKham();
                frm12.MdiParent = frmDSChoKham.ActiveForm;
                frm12.WindowState = FormWindowState.Maximized;
                frm12.FormClosed += frm12_FormClosed;
                frm12.Show();
            }
            else frm12.Activate();
        }

        void frm12_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm12 = null;
        }

        frmDSChoThuTien frm13 = null;
        private void btThuTien_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm13 == null)
            {
                frm13 = new frmDSChoThuTien();
                frm13.MdiParent = frmDSChoThuTien.ActiveForm;
                frm13.WindowState = FormWindowState.Maximized;
                frm13.FormClosed += frm13_FormClosed;
                frm13.Show();
            }
            else frm13.Activate();
        }

        void frm13_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm13 = null;
        }

        CD010100 frm14 = null;
        private void btCDHA_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm14 == null)
            {
                frm14 = new CD010100();
                frm14.MdiParent = CD010100.ActiveForm;
                frm14.WindowState = FormWindowState.Maximized;
                frm14.FormClosed += frm14_FormClosed;
                frm14.Show();
            }
            else frm14.Activate();
        }

        void frm14_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm14 = null;
        }

        private void btThayDoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            new LO030100().ShowDialog();
        }


        Frm_DMXetNghiem frm15 = null;
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm15 == null)
            {
                frm15 = new Frm_DMXetNghiem();
                frm15.MdiParent = Frm_DMXetNghiem.ActiveForm;
                frm15.WindowState = FormWindowState.Maximized;
                frm15.FormClosed += frm15_FormClosed;
                frm15.Show();
            }
            else frm15.Activate();
        }

        void frm15_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm15 = null;
        }

        Frm_DMNhomXetNghiem frm16 = null;

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm16 == null)
            {
                frm16 = new Frm_DMNhomXetNghiem();
                frm16.MdiParent = Frm_DMNhomXetNghiem.ActiveForm;
                frm16.WindowState = FormWindowState.Maximized;
                frm16.FormClosed += frm16_FormClosed;
                frm16.Show();
            }
            else frm16.Activate();
        }

        void frm16_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm16 = null;
        }

        
        private void btReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            new RP010100().Show();
        }

        frmLichLamViec frm17 = null;
        void LoadControlLichLamViec()
        {
            if (frm17 == null)
            {
                frm17 = new frmLichLamViec();
                frm17.MdiParent = frmLichLamViec.ActiveForm;
                frm17.WindowState = FormWindowState.Maximized;
                frm17.FormClosed += frm17_FormClosed;
                frm17.Show();
            }
            else frm17.Activate();
        }

        
        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlLichLamViec();
        }

        void frm17_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm17 = null;
        }

        Frm_DMTinh frm18 = null;

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm18 == null)
            {
                frm18 = new Frm_DMTinh();
                frm18.MdiParent = Frm_DMTinh.ActiveForm;
                frm18.WindowState = FormWindowState.Maximized;
                frm18.FormClosed += frm18_FormClosed;
                frm18.Show();
            }
            else frm18.Activate();
        }

        void frm18_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm18 = null;
        }

        Frm_DMQuan frm19 = null;
        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frm19 == null)
            {
                frm19 = new Frm_DMQuan();
                frm19.MdiParent = Frm_DMQuan.ActiveForm;
                frm19.WindowState = FormWindowState.Maximized;
                frm19.FormClosed += frm19_FormClosed;
                frm19.Show();
            }
            else frm19.Activate();
        }

        void frm19_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm19 = null;
        }

        frmDangKy frmDangKy = null;
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

        void frmDangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDangKy = null;
        }

        frmDSChoKham frmChoKham = null;
        void LoadControlChoKham()
        {
            try
            {
                if (frmChoKham == null)
                {
                    frmChoKham = new frmDSChoKham();
                    frmChoKham.MdiParent = frmDSChoKham.ActiveForm;
                    frmChoKham.WindowState = FormWindowState.Maximized;
                    frmChoKham.FormClosed += frmChoKham_FormClosed;
                    frmChoKham.Show();
                }
                else frmChoKham.Activate();
            }
            catch
            {
            }
        }

        void frmChoKham_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChoKham = null;
        }

        frmDSDaKham frmDanhSach = null;
        void LoadControlDanhSach()
        {
            try
            {
                if (frmDanhSach == null)
                {
                    frmDanhSach = new frmDSDaKham();
                    frmDanhSach.MdiParent = frmDSDaKham.ActiveForm;
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

        frmDSChoSA frmChoSA = null;
        void LoadControlChoSA()
        {
            try
            {
                if (frmChoSA == null)
                {
                    frmChoSA = new frmDSChoSA();
                    frmChoSA.MdiParent = frmDSChoSA.ActiveForm;
                    frmChoSA.WindowState = FormWindowState.Maximized;
                    frmChoSA.FormClosed += frmChoSA_FormClosed;
                    frmChoSA.Show();
                }
                else frmChoSA.Activate();
            }
            catch
            {
            }
        }

        void frmChoSA_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChoSA = null;
        }

        frmDSSieuAm frmDSSA = null;
        void LoadControlDanhSachSA()
        {
            try
            {
                if (frmDSSA == null)
                {
                    frmDSSA = new frmDSSieuAm();
                    frmDSSA.MdiParent = frmDSSieuAm.ActiveForm;
                    frmDSSA.WindowState = FormWindowState.Maximized;
                    frmDSSA.FormClosed += frmDSSA_FormClosed;
                    frmDSSA.Show();
                }
                else frmDSSA.Activate();
            }
            catch
            {
            }
        }

        void frmDSSA_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDSSA = null;
        }

        frmDSChoXN frmChoXN = null;
        void LoadControlChoXN()
        {
            try
            {
                if (frmChoXN == null)
                {
                    frmChoXN = new frmDSChoXN();
                    frmChoXN.MdiParent = frmDSChoXN.ActiveForm;
                    frmChoXN.WindowState = FormWindowState.Maximized;
                    frmChoXN.FormClosed += frmChoXN_FormClosed;
                    frmChoXN.Show();
                }
                else frmChoXN.Activate();
            }
            catch
            {
            }
        }

        void frmChoXN_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChoXN = null;
        }

        frmDSPhieuXN frmDSXN = null;
        void LoadControlDanhSachXN()
        {
            try
            {
                if (frmDSXN == null)
                {
                    frmDSXN = new frmDSPhieuXN();
                    frmDSXN.MdiParent = frmDSPhieuXN.ActiveForm;
                    frmDSXN.WindowState = FormWindowState.Maximized;
                    frmDSXN.FormClosed += frmDSXN_FormClosed;
                    frmDSXN.Show();
                }
                else frmDSXN.Activate();
            }
            catch
            {
            }
        }

        void frmDSXN_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDSXN = null;
        }

        frmDSDangKy frmDSDangKy = null;
        void LoadControlDSDangKy()
        {
            try
            {
                if (frmDSDangKy == null)
                {
                    frmDSDangKy = new frmDSDangKy();
                    frmDSDangKy.MdiParent = frmDSDangKy.ActiveForm;
                    frmDSDangKy.WindowState = FormWindowState.Maximized;
                    frmDSDangKy.FormClosed += frmDSDangKy_FormClosed;
                    frmDSDangKy.Show();
                }
                else frmDSDangKy.Activate();
            }
            catch
            {
            }
        }

        void frmDSDangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDSDangKy = null;
        }

        frmDSHenKham frmDSHenKham = null;
        void LoadControlDSHenKham()
        {
            try
            {
                if (frmDSHenKham == null)
                {
                    frmDSHenKham = new frmDSHenKham();
                    frmDSHenKham.MdiParent = frmDSHenKham.ActiveForm;
                    frmDSHenKham.WindowState = FormWindowState.Maximized;
                    frmDSHenKham.FormClosed += frmDSHenKham_FormClosed;
                    frmDSHenKham.viewHenKham.DoubleClick += viewHenKham_DoubleClick;
                    frmDSHenKham.Show();
                }
                else frmDSHenKham.Activate();
            }
            catch
            {
            }
        }

        void viewHenKham_DoubleClick(object sender, EventArgs e)
        {
            if (frmDSHenKham == null) return;
            if (frmDangKy == null)
            {
                LoadControlDangKy();
            }
            ObHenKham ob = (ObHenKham)frmDSHenKham.viewHenKham.GetFocusedRow();
            if (ob == null) return;
            if (ob.TrangThai == etrangthai.Đã_đến.ToString())
            {
                MessageBox.Show("Phiếu hẹn đã đăng ký! Không thể đăng ký tiếp!");
                return;
            }

            //frmDangKy.SetHenKham(ob);
        }

        void frmDSHenKham_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDSHenKham = null;
        }

        frmNhapkho frmNhapKho = null;
        void LoadControlNhapKho()
        {
            try
            {
                if (frmNhapKho == null)
                {
                    frmNhapKho = new frmNhapkho();
                    frmNhapKho.MdiParent = frmNhapkho.ActiveForm;
                    frmNhapKho.WindowState = FormWindowState.Maximized;
                    frmNhapKho.FormClosed += frmNhapKho_FormClosed;
                    frmNhapKho.Show();
                }
                else frmNhapKho.Activate();
            }
            catch
            {
            }
        }

        void frmNhapKho_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmNhapKho = null;
        }

        frmDSChoThuTien frmDSChoThuTien = null;
        void LoadControlChoThuTien()
        {
            try
            {
                if (frmDSChoThuTien == null)
                {
                    frmDSChoThuTien = new frmDSChoThuTien();
                    frmDSChoThuTien.MdiParent = frmDSChoThuTien.ActiveForm;
                    frmDSChoThuTien.WindowState = FormWindowState.Maximized;
                    frmDSChoThuTien.FormClosed += frmDSChoThuTien_FormClosed;
                    frmDSChoThuTien.Show();
                }
                else frmDSChoThuTien.Activate();
            }
            catch
            {
            }
        }

        void frmDSChoThuTien_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDSChoThuTien = null;
        }

        frmDSDaThu frmDSDaThu = null;
        void LoadControlDaThuTien()
        {
            try
            {
                if (frmDSDaThu == null)
                {
                    frmDSDaThu = new frmDSDaThu();
                    frmDSDaThu.MdiParent = frmDSDaThu.ActiveForm;
                    frmDSDaThu.WindowState = FormWindowState.Maximized;
                    frmDSDaThu.FormClosed += frmDSDaThu_FormClosed;
                    frmDSDaThu.Show();
                }
                else frmDSDaThu.Activate();
            }
            catch
            {
            }
        }

        void frmDSDaThu_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDSDaThu = null;
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlDangKy();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlDSDangKy();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlDSHenKham();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlNhapKho();
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlChoKham();
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlDanhSach();
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlChoSA();
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlDanhSachSA();
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlChoXN();
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlDanhSachXN();
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlChoThuTien();
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlDaThuTien();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            //LoadControlLichLamViec();
            //LoadControlDangKy();
            //LoadControlChoKham();
            //LoadControlDanhSach();
            //LoadControlDanhSachSA();
            //frmChoKham.Activate();
            ribbon.Minimized = true;
        }

        Frm_DMNgheNghiep Frm_DMNgheNghiep = null;
        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Frm_DMNgheNghiep == null)
            {
                Frm_DMNgheNghiep = new Frm_DMNgheNghiep();
                Frm_DMNgheNghiep.MdiParent = Frm_DMNgheNghiep.ActiveForm;
                Frm_DMNgheNghiep.WindowState = FormWindowState.Maximized;
                Frm_DMNgheNghiep.FormClosed += Frm_DMNgheNghiep_FormClosed;
                Frm_DMNgheNghiep.Show();
            }
            else Frm_DMNgheNghiep.Activate();
        }

        void Frm_DMNgheNghiep_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_DMNgheNghiep = null;
        }

        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            string conn = @"Server=" + "ADMIN-PC" + ";Initial Catalog=" + "BSTRANG" + ";User ID=" + "sa" + ";Password=" + "123456789" + ";";

            bool rs = MeKong_DBStatic.ConnectDB(conn);
            if (!rs)
            {
                MessageBox.Show("Không thể kết nối");
                return;
            }


            List<ObCustomer> listBenhNhan = MeKongData.BenhNhan.GetListOb();
            MessageBox.Show("Load dữ liệu thành công");
            if (listBenhNhan != null)
            {
                foreach (var item in listBenhNhan)
                {
                    try
                    {
                        NTPObCustomer.Insert(item);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}