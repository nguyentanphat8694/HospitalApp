using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace Hospital.App
{
    public partial class UPhieuXetNghiem : DevExpress.XtraEditors.XtraUserControl
    {
        public UPhieuXetNghiem()
        {
            InitializeComponent();
            LoadData();
            InitDisplay();
            LoadControl();
            loadEvents();
        }

        UDSChoXN _uChoXN = null;
        UDSPhieuXN _uDaXN = null;

        List<ObCTXetNghiem> listDichVu = new List<ObCTXetNghiem>();
        ObPhieuXetNghiem obCur = null;
        bool Modify = false;
        
        ObPhieuXetNghiem PhieuXetNghiem
        {
            get
            {
                ObPhieuXetNghiem ob = (!Modify || obCur == null) ? new ObPhieuXetNghiem() : new ObPhieuXetNghiem(obCur);
                ob.Ma = MainNTP.ParseDouble(teSoPhieu.Text);
                ob.BSThucHien = lkBacSi.EditValue.ToString();
                ob.NgayTra = deNgayTra.DateTime;
                ob.MaBN = teMaBN.Text;
                ob.Ngay = deNgay.DateTime;
                ob.TTChung.ObCTXetNghiems = new List<ObCTXetNghiem>(listDichVu);

                return ob;
            }
            set
            {
                teSoPhieu.Text = value.Ma.ToString();
                teMaBN.Text = value.MaBN;
                lkBacSi.EditValue = value.BSThucHien;
                teMaBN.Text = value.MaBN;
                deNgay.DateTime = value.Ngay;
                deNgayTra.DateTime = value.NgayTra;
                listDichVu = new List<ObCTXetNghiem>(value.TTChung.ObCTXetNghiems);
                if (listDichVu.Count > 0) {
                    idKeyCTChiDinh = listDichVu[0].KeyCTChiDinh;
                }
                RefrestView();
                SetEnable(true);
            }
        }

        void RefrestView() {
            if (this.InvokeRequired) {
                this.Invoke(new NTPRefreshData(RefrestView), new object[] { });
            }
            else {
                gridDanhSach.DataSource = listDichVu;
                viewDanhSach.RefreshData();
            }
        }

        bool ReadOnly
        {
            set
            {
                deNgay.Properties.ReadOnly = value;
                lkBacSi.Properties.ReadOnly = value;
                btLuuBenhAn.Enabled = !value;
            }
        }

        private void LoadControl()
        {
            _uChoXN = new UDSChoXN();
            _uChoXN.Dock = DockStyle.Fill;
            pageMau.Controls.Add(_uChoXN);

            _uChoXN.setXN_Mau(gridMau, viewMau);
            _uChoXN.setXN_PhuKhoa(gridPhuKhoa, viewPhuKhoa);
            _uChoXN.setXN_Lab256(gridLab256, view256);

            _uChoXN.LayDuLieu(deTuNgay.DateTime, deDenNgay.DateTime);


            _uDaXN = new UDSPhieuXN();
            _uDaXN.Dock = DockStyle.Fill;
            pnlDSBatThuong.Controls.Add(_uDaXN); 

        }

        void FilterXN_Mau()
        {
            string sql = "[LoaiXN_Lab256] = 1";

            viewMau.ActiveFilterString = sql;
        }

        private void loadEvents()
        {
            _uChoXN.viewDanhSach.DoubleClick += viewDanhSach_DoubleClick;
            _uDaXN.viewChidinh.DoubleClick += viewChidinh_DoubleClick;
        }

        void viewDanhSach_DoubleClick(object sender, EventArgs e)
        {

        }

        void viewChidinh_DoubleClick(object sender, EventArgs e)
        {
            XN020110 ob = (XN020110)_uDaXN.viewChidinh.GetFocusedRow();
            if (ob == null) return;
            ObPhieuXetNghiem pt = MainNTP.ObPhieuXetNghiemList.GetOb(ob.Ma);
            if (pt == null) return;
            if (pt.TrangThai == etrangthai.Đã_hủy.ToString())
            {
                MessageBox.Show("Phiếu đã hủy");
                return;
            }
            SetModify(pt);
        }

        private void InitDisplay()
        {
            lkBacSi.Properties.DataSource = MainNTP.ObDMNhanSuList;
            lkBacSi.EditValue = MainNTP.User.TTChung.MaNS;
            deNgayTra.DateTime = MainNTP._Ngay;

            deTuNgay.DateTime = deDenNgay.DateTime = MainNTP._Ngay;
        }

        private void LoadData()
        {
            deNgay.DateTime = MainNTP._Ngay;

            List<eTableName> listTable = new List<eTableName> {
                eTableName.Customer,
                eTableName.DMDichVu,
                eTableName.DMNhanSu,
                eTableName.DMXetNghiem,
                eTableName.DMNhomXetNghiem
            };

            MainNTP.GetData(listTable);
        }

        double idKeyCTChiDinh = -1;

        public void SetNew(TT010110 ob) {
            listDichVu = new List<ObCTXetNghiem>();
            Modify = false;
            teMaBN.Text = ob.MaBN;
            idKeyCTChiDinh = -1;

            foreach (var item in ob.listCTChiDinh)
            {
                idKeyCTChiDinh = item.Ma;
                List<ObDMXetNghiem> key = MainNTP.ObDMXetNghiemList.Get_MaDV(item.MaDV);
                if (key == null) continue;
                foreach (var xn in key)
                {
                    ObCTXetNghiem cls = new ObCTXetNghiem();
                    cls.KeyCTChiDinh = item.Ma;
                    cls.MaBN = ob.MaBN;
                    cls.MaDV = item.MaDV;
                    cls.MaXN = xn.Ma;
                    cls.CSBT = cls.SetCSBT(cheNam.Checked);
                    cls.BinhThuong = true;
                    listDichVu.Add(cls);
                }
            }
            RefrestView();
            SetEnable(false);
        }

        void SetEnable(bool tr) {
            btInChiDinh.Enabled = tr;
            btHuy.Enabled = tr;
        }

        public void SetModify(ObPhieuXetNghiem ob) {
            PhieuXetNghiem = ob;
            Modify = true;
            obCur = ob;
        }

        bool KiemTraHopLe() {
            if (NTPValidate.IsEmpty(teMaBN.Text))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân");
                return false;
            }

            if (lkBacSi.EditValue == null || lkBacSi.EditValue.ToString() == "")
            {
                MessageBox.Show("Vui lòng chọn bác sĩ");
                return false;
            }
            return true;
        }

        bool SaveXetNghiem()
        {
            ObPhieuXetNghiem ob = PhieuXetNghiem;
            if (!Modify)
            {
                ob.Ma = MainNTP.ObPhieuXetNghiemList.GetID();
                ob.Action = ActionRec.Update;
                ob.TrangThai = etrangthai.Đang_điều_trị.ToString();
                if (!MainNTP.ObPhieuXetNghiemList.AddOb(ob))
                    return false;
                teSoPhieu.Text = ob.Ma.ToString();
            }
            else
            {
                if (!MainNTP.ObPhieuXetNghiemList.UpdateOb(ob))
                    return false;
            }

            //List<double> listKeyCTChiDinh = new List<double>();

            //var batThuong = ob.TTChung.ObCTXetNghiems.Any(o => !string.IsNullOrEmpty(o.KetQua));
            //foreach (var item in ob.TTChung.ObCTXetNghiems)
            //{
            //    if (!listKeyCTChiDinh.Any(o=>o == item.KeyCTChiDinh))
            //    {
            //        listKeyCTChiDinh.Add(item.KeyCTChiDinh);

            //        var obCTCD = MainNTP.ObCTChiDinhList.GetOb(item.KeyCTChiDinh);
            //        if (obCTCD != null)
            //        {
            //            obCTCD.TTChung.BT_Mau = batThuong;
            //            obCTCD.TTChung.BT_PhuKhoa = batThuong;
            //            obCTCD.TTChung.BT_Lab256 = batThuong;
            //        }
            //    }
            //}

            obCur = ob;
            Modify = true;

            return true;
        }

        bool UpdateCTChiDinh() {
            for (int i = 0; i < obCur.TTChung.ObCTXetNghiems.Count; i++)
            {
                ObCTXetNghiem xn = obCur.TTChung.ObCTXetNghiems[i];
                ObCTChiDinh item = MainNTP.ObCTChiDinhList.Get(xn.KeyCTChiDinh);
                if (item != null && item.KeyThucHien <= 0)
                {
                    item.KeyThucHien = obCur.Ma;
                    item.LoaiPhieuTH = (int)eLoaiPhieuTH.Xet_Nghiem;
                    //item.TTChung.BT_Lab256 = false;
                    //item.TTChung.BT_Mau = false;
                    //item.TTChung.BT_PhuKhoa = false;
                    MainNTP.ObCTChiDinhList.UpdateOb(item);
                }
            }
            return true;
        }

        bool Save() {
            if (!KiemTraHopLe()) return false;
            if (!SaveXetNghiem()) return false;
            UpdateCTChiDinh();
            MessageBox.Show("Phiếu xét nghiệm của bệnh nhân " + teHoTen.Text.ToUpper() + " đã được lưu");
            SetEnable(true);
            return true;
        }

        bool Huy() {
            if (obCur == null) return false;

            if (MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return true;
            // Hủy bệnh án
            obCur.TrangThai = etrangthai.Đã_hủy.ToString();
            if (MainNTP.ObPhieuXetNghiemList.UpdateOb(obCur, etrangthai.Đã_hủy))
            {
                // huy CTChidinh
                foreach (var item in listDichVu)
                {
                    ObCTChiDinh ct = MainNTP.ObCTChiDinhList.GetOb(item.KeyCTChiDinh);
                    if (ct != null)
                    {
                        ct.TrangThai = etrangthai.Đang_chờ.ToString();
                        ct.KeyThucHien = 0;
                        ct.LoaiPhieuTH = 0;
                        MainNTP.ObCTChiDinhList.UpdateOb(ct);
                    }
                }
                
                MessageBox.Show("Phiếu xét nghiệm của bệnh nhân " + teHoTen.Text.ToUpper() + " đã được hủy");
                return true;
            }
            return false;
        }

        void In() {
            if (obCur == null) return;
            XN020110 cls = new XN020110();
            cls.SetNew(obCur);
            RP020100 rp = new RP020100();
            rp.SetData(e_REPORTNTP.Xet_Nghiem.ToString(), new List<XN020110>() { cls });
            rp.ShowPreviewDialog();
        }

        bool TinhCSBT(ObCTXetNghiem ob) {
            ObDMXetNghiem dm = MainNTP.ObDMXetNghiemList.Get(ob.MaXN);
            if (dm == null) return true;
            if (dm.TTChung.ChiSoBinhThuong.Trim() != "") {
                if (dm.TTChung.ChiSoBinhThuong.Contains(ob.KetQua) || ob.KetQua.Contains(dm.TTChung.ChiSoBinhThuong))
                    return true;
                return false;
            }
            double kq = MainNTP.ParseDouble(ob.KetQua);
            if (kq == 0) return true;
            if (cheNam.Checked) {
                return (dm.TTChung.NamDuoi < kq && kq < dm.TTChung.NamTren);
            }
            return (dm.TTChung.NuDuoi < kq && kq < dm.TTChung.NuTren);
        }

        void UpdateBinhThuong_Lab256()
        {
            MainNTP.UpdateCellValueChanging(view256);
            TT010110 cls = (TT010110)view256.GetFocusedRow();
            if (cls == null || cls.listCTChiDinh.Count <= 0) return;

            ObCTChiDinh ct = MainNTP.ObCTChiDinhList.GetOb(cls.listCTChiDinh[0].Ma);
            if (ct == null) return;

            if (ct.KeyThucHien > 0)
            {
                MessageBox.Show("Bệnh nhân " + cls.Ten + " có kết quả bất thường. Không thể nhập kết quả bình thường cho bệnh nhân này.");
                cls.BT_Lab256 = false;
                view256.RefreshData();
                
                return;
            }

            ct.TTChung.BT_Lab256 = cls.BT_Lab256;

            MainNTP.ObCTChiDinhList.UpdateOb(ct);
        }

        void UpdateBinhThuong_Mau()
        {
            MainNTP.UpdateCellValueChanging(viewMau);
            TT010110 cls = (TT010110)viewMau.GetFocusedRow();
            if (cls == null || cls.listCTChiDinh.Count <= 0) return;

            ObCTChiDinh ct = MainNTP.ObCTChiDinhList.GetOb(cls.listCTChiDinh[0].Ma);
            if (ct == null) return;

            if (ct.KeyThucHien > 0)
            {
                MessageBox.Show("Bệnh nhân " + cls.Ten + " có kết quả bất thường. Không thể nhập kết quả bình thường cho bệnh nhân này.");
                cls.BT_Mau = false;
                view256.RefreshData();

                return;
            }

            ct.TTChung.BT_Mau = cls.BT_Mau;

            MainNTP.ObCTChiDinhList.UpdateOb(ct);
        }

        void UpdateBinhThuong_PhuKhoa()
        {
            MainNTP.UpdateCellValueChanging(viewPhuKhoa);
            TT010110 cls = (TT010110)viewPhuKhoa.GetFocusedRow();
            if (cls == null || cls.listCTChiDinh.Count <= 0) return;

            ObCTChiDinh ct = MainNTP.ObCTChiDinhList.GetOb(cls.listCTChiDinh[0].Ma);
            if (ct == null) return;

            if (ct.KeyThucHien > 0)
            {
                MessageBox.Show("Bệnh nhân " + cls.Ten + " có kết quả bất thường. Không thể nhập kết quả bình thường cho bệnh nhân này.");
                cls.BT_PhuKhoa = false;
                view256.RefreshData();

                return;
            }

            ct.TTChung.BT_PhuKhoa = cls.BT_PhuKhoa;

            MainNTP.ObCTChiDinhList.UpdateOb(ct);
        }

        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btLuuBenhAn_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            Huy();
        }

        private void btInChiDinh_Click(object sender, EventArgs e)
        {
            In();
        }

        private void teMaBN_EditValueChanged(object sender, EventArgs e)
        {
            if (NTPValidate.IsEmpty(teMaBN.Text)) return;
            ObCustomer bn = MainNTP.ObCustomerList.GetOb(teMaBN.Text);
            if (bn == null) return;
            teHoTen.Text = bn.Ten;
            teNam.Text = bn.Namsinh.ToString();
            cheNam.Checked = bn.Gioitinh == 0;
            teDiaChi.Text = bn.DiaChiFull;
        }

        private void viewDanhSach_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (viewDanhSach.FocusedColumn != colKetQua) return;
            ObCTXetNghiem ob = (ObCTXetNghiem)viewDanhSach.GetFocusedRow();
            if (ob == null) return;
            if (ob.KetQua.Trim() != "")
            {
                ob.BinhThuong = TinhCSBT(ob);
                ob.Valid = true;
                viewDanhSach.RefreshData();
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
        }

        private void viewDanhSach_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //if (cheDaXuLy.Checked)
            //{
            //    groupKQ.AppearanceCaption.ForeColor = Color.Blue;
            //    timeBatThuong.Stop();
            //}
            //else
            //{
            //    if (listDichVu.Any(o => !o.BinhThuong))
            //        timeBatThuong.Start();
            //}
        }

        private void timeBatThuong_Tick(object sender, EventArgs e)
        {
            if (groupKQ.AppearanceCaption.ForeColor == Color.Blue)
                groupKQ.AppearanceCaption.ForeColor = Color.Red;
            else groupKQ.AppearanceCaption.ForeColor = Color.Blue;
        }

        private void cheDaXuLy_CheckedChanged(object sender, EventArgs e)
        {
            viewDanhSach_RowStyle(null, null);
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            _uChoXN.LayDuLieu(deTuNgay.DateTime, deDenNgay.DateTime);
            _uDaXN.LayDuLieu(deTuNgay.DateTime, deDenNgay.DateTime);
        }

        private void cheBatThuong_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void mnThemDong_Click(object sender, EventArgs e)
        {
            listDichVu.Add(new ObCTXetNghiem() { KeyCTChiDinh = idKeyCTChiDinh });
            gridDanhSach.DataSource = listDichVu;
            viewDanhSach.RefreshData();
        }

        private void mnXoaDong_Click(object sender, EventArgs e)
        {
            viewDanhSach.DeleteSelectedRows();
        }

        private void view256_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            UpdateBinhThuong_Lab256();
        }

        private void viewPhuKhoa_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            UpdateBinhThuong_PhuKhoa();
        }

        private void viewMau_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            UpdateBinhThuong_Mau();
        }

        private void viewMau_DoubleClick(object sender, EventArgs e)
        {
            TT010110 cls = (TT010110)viewMau.GetFocusedRow();
            if (cls == null || cls.listCTChiDinh.Count <= 0) return;

            if (cls.listCTChiDinh[0].TTChung.BT_Lab256 || cls.listCTChiDinh[0].TTChung.BT_Mau || cls.listCTChiDinh[0].TTChung.BT_PhuKhoa)
            {
                MessageBox.Show("Bệnh nhân " + cls.Ten + " có kết quả bình thường. Không thể nhập kết quả bất thường cho bệnh nhân này.");
                return;
            }

            List<ObCTChiDinh> listTemp = new List<ObCTChiDinh>();
            double idThucHien = 0;

            foreach (var item in cls.listCTChiDinh)
            {
                if (NTPUserSetting.NhomXN_Mau.Any(o => o == item.DMDichVu.TTChung.Nhom))
                {
                    if (item.KeyThucHien > 0)
                    {
                        idThucHien = item.KeyThucHien;
                    }

                    listTemp.Add(item);
                }
            }

            TT010110 clsTemp = new TT010110(cls);
            clsTemp.listCTChiDinh = new List<ObCTChiDinh>();
            clsTemp.listCTChiDinh.AddRange(listTemp);

            ObPhieuXetNghiem phieu = MainNTP.ObPhieuXetNghiemList.GetOb(idThucHien);
            if (phieu == null)
            {
                SetNew(clsTemp);
            }
            else
            {
                SetModify(phieu);
            }

        }

        private void viewPhuKhoa_DoubleClick(object sender, EventArgs e)
        {
            TT010110 cls = (TT010110)viewPhuKhoa.GetFocusedRow();
            if (cls == null || cls.listCTChiDinh.Count <= 0) return;

            if (cls.listCTChiDinh[0].TTChung.BT_Lab256 || cls.listCTChiDinh[0].TTChung.BT_Mau || cls.listCTChiDinh[0].TTChung.BT_PhuKhoa)
            {
                MessageBox.Show("Bệnh nhân " + cls.Ten + " có kết quả bình thường. Không thể nhập kết quả bất thường cho bệnh nhân này.");
                return;
            }

            List<ObCTChiDinh> listTemp = new List<ObCTChiDinh>();
            double idThucHien = 0;

            foreach (var item in cls.listCTChiDinh)
            {
                if (NTPUserSetting.NhomXN_PhuKhoa.Any(o => o == item.DMDichVu.TTChung.Nhom))
                {
                    if (item.KeyThucHien > 0)
                    {
                        idThucHien = item.KeyThucHien;
                    }

                    listTemp.Add(item);
                }
            }

            TT010110 clsTemp = new TT010110(cls);
            clsTemp.listCTChiDinh = new List<ObCTChiDinh>();
            clsTemp.listCTChiDinh.AddRange(listTemp);

            ObPhieuXetNghiem phieu = MainNTP.ObPhieuXetNghiemList.GetOb(idThucHien);
            if (phieu == null)
            {
                SetNew(clsTemp);
            }
            else
            {
                SetModify(phieu);
            }
        }

        private void view256_DoubleClick(object sender, EventArgs e)
        {
            TT010110 cls = (TT010110)view256.GetFocusedRow();
            if (cls == null || cls.listCTChiDinh.Count <= 0) return;

            if (cls.listCTChiDinh[0].TTChung.BT_Lab256 || cls.listCTChiDinh[0].TTChung.BT_Mau || cls.listCTChiDinh[0].TTChung.BT_PhuKhoa)
            {
                MessageBox.Show("Bệnh nhân " + cls.Ten + " có kết quả bình thường. Không thể nhập kết quả bất thường cho bệnh nhân này.");
                return;
            }

            List<ObCTChiDinh> listTemp = new List<ObCTChiDinh>();
            double idThucHien = 0;

            foreach (var item in cls.listCTChiDinh)
            {
                if (NTPUserSetting.NhomXN_Lab256.Any(o => o == item.DMDichVu.TTChung.Nhom))
                {
                    if (item.KeyThucHien > 0)
                    {
                        idThucHien = item.KeyThucHien;
                    }

                    listTemp.Add(item);
                }
            }

            TT010110 clsTemp = new TT010110(cls);
            clsTemp.listCTChiDinh = new List<ObCTChiDinh>();
            clsTemp.listCTChiDinh.AddRange(listTemp);

            ObPhieuXetNghiem phieu = MainNTP.ObPhieuXetNghiemList.GetOb(idThucHien);
            if (phieu == null)
            {
                SetNew(clsTemp);
            }
            else
            {
                SetModify(phieu);
            }
        }

        private void teTim_EditValueChanged(object sender, EventArgs e)
        {
            string sql = "";
            if (teTim.Text.Trim() != "")
            {
                sql = "[MaBenhNhan] like '%" + teTim.Text + "%' OR [Ten] like '%" + teTim.Text + "%' OR [NamSinh] like '%" + teTim.Text + "%'";
            }

            if (sql != "")
            {
                viewMau.ActiveFilterString = sql;
                view256.ActiveFilterString = sql;
                viewPhuKhoa.ActiveFilterString = sql;
                _uDaXN.viewChidinh.ActiveFilterString = sql;
            }
            else
            {
                viewMau.ClearColumnsFilter();
                view256.ClearColumnsFilter();
                viewPhuKhoa.ClearColumnsFilter();
                _uDaXN.viewChidinh.ClearColumnsFilter();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Color mau = Color.Crimson;
            _uDaXN.SetMau(mau);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Color mau = Color.Magenta;
            _uDaXN.SetMau(mau);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Color mau = Color.Blue;
            _uDaXN.SetMau(mau);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Color mau = Color.Red;
            _uDaXN.SetMau(mau);
        }

        private void viewMau_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            TT010110 cls = (TT010110)viewMau.GetRow(e.RowHandle);
            if (cls == null)
            {
                return;
            }

            if (!cls.BT_Mau)
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }

        private void viewPhuKhoa_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            TT010110 cls = (TT010110)viewPhuKhoa.GetRow(e.RowHandle);
            if (cls == null)
            {
                return;
            }

            if (!cls.BT_PhuKhoa)
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }

        private void view256_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            TT010110 cls = (TT010110)view256.GetRow(e.RowHandle);
            if (cls == null)
            {
                return;
            }

            if (!cls.BT_Lab256)
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }
    }
}