using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Hospital.App
{
    public partial class UNhapKho : DevExpress.XtraEditors.XtraUserControl
    {
        public UNhapKho()
        {
            InitializeComponent();
            LoadData();
            InitDisplay();
            LoadEvent();
        }

        List<ObNhapKho> listNhapKho = new List<ObNhapKho>();
        List<ObCTNhapKho> listChitiet = new List<ObCTNhapKho>();
        List<ObCTNhapKho> listUpdate = new List<ObCTNhapKho>();
        List<ObCTNhapKho> listDelete = new List<ObCTNhapKho>();
        bool _ShowPP = false;
        bool _Modify = false;

        ObNhapKho NhapKho {
            get {
                ObNhapKho ob = new ObNhapKho();
                ob.Ma = MainNTP.ParseDouble(teSoPN.Text);
                ob.Ngay = deNgay.DateTime.Date;
                ob.Kho = lkKho.EditValue.ToString();
                ob.NguoiNhap = lkNguoiNhap.EditValue.ToString();
                return ob;
            }
            set {
                teSoPN.Text = value.Ma.ToString();
                deNgay.DateTime = value.Ngay;
                lkKho.EditValue = value.Kho;
                lkNguoiNhap.EditValue = value.NguoiNhap;
            }
        }

        void LoadData() {
            DBStatic.ConnectDB(DadaConnect.connect_string);
            List<eTableName> listTable = new List<eTableName> {
                eTableName.DMThuoc,
                eTableName.DMNhomDichVu,
                eTableName.DMKho,
                eTableName.DMNhanSu,
                eTableName.DMDichVu,
            };

            MainNTP.GetData(listTable);
        }

        void InitDisplay() {
            deTuNgay.DateTime = deDenNgay.DateTime = MainNTP._Ngay;
            deNgay.DateTime = MainNTP._Ngay;
            lkKho.Properties.DataSource = MainNTP.ObDMKhoList;
            lkNguoiNhap.Properties.DataSource = MainNTP.ObDMNhanSuList;
            lkNhom.Properties.DataSource = MainNTP.ObDMNhomDichVuList;
            List<ObDMDichVu> list = MainNTP.ObDMThuocList.ToList();
            foreach (var item in MainNTP.ObDMDichVuList)
            {
                if (item.TTChung.HHThuocKho)
                {
                    list.Add(item);
                }
            }
            gridDanhMuc.DataSource = list;
            viewDanhMuc.RefreshData();
            rlkNhom.DataSource = MainNTP.ObDMNhomDichVuList;
            //
            lkNguoiNhap.EditValue = MainNTP.User.TTChung.MaNS;
            lkKho.EditValue = NTPUserSetting.KhoMacDinh;
            btXem_Click(null, null);
        }

        public void LoadEvent(){
            ppDichVu.Popup += ppDichVu_Popup;
            ppDichVu.Closed += ppDichVu_Closed;
        }

        void LayDuLieu() {
            KeysListObNhapKho keys = NTPObNhapKho.GetListOb(deTuNgay.DateTime, deDenNgay.DateTime);
            gridDanhSach.DataSource = keys;
            viewDanhSach.RefreshData();
        }

        void Clear() {
            _Modify = false;
            listChitiet.Clear();
            RefreshviewHangHoa();
            SetNewHangHoa();
        }

        void SetNewHangHoa() {
            ppDichVu.Text = "";
            teTen.Text = "";
            lkNhom.EditValue = null;
            teSL.Text = "";
            //teDGNhap.Text = "";
            //teDGBan.Text = "";
            teSoLo.Text = "";
            ppDichVu.Focus();
        }

        void SetDichVu() {
            ObDMDichVu ob = (ObDMDichVu)viewDanhMuc.GetFocusedRow();
            if (ob == null || NTPValidate.IsEmpty(ob.Ma))
            {
                teTen.Focus();
            }
            else
            {
                ppDichVu.Text = ob.Ma;
                teTen.Text = ob.Ten;
                lkNhom.EditValue = ob.TTChung.Nhom;
                teSL.Focus();
            }
            if (_ShowPP)
            {
                ppDichVu.ClosePopup();
            }
        }

        bool KiemTra() {
            if (lkKho.EditValue == null || NTPValidate.IsEmpty(lkKho.EditValue.ToString()))
                return false;
            if (NTPValidate.IsEmpty(teTen.Text)) return false;
            if (MainNTP.ParseDouble(teSL.Text) <= 0) return false;

            return true;
        }

        void AddDichVu() {
            if(!KiemTra())return;

            ObCTNhapKho ob = new ObCTNhapKho();
            ob.TrangThai = etrangthai.Chờ_duyệt.ToString();
            ob.Action=ActionRec.Insert;
            ob.MaDV = ppDichVu.Text.Trim();
            ob.Ten = teTen.Text;
            //ob.DGNhap = MainNTP.ParseDouble(teDGNhap.Text);
            //ob.DGBan = MainNTP.ParseDouble(teDGBan.Text);
            ob.Ngay = deNgay.DateTime.Date;
            ob.Kho = lkKho.EditValue == null ? "" : lkKho.EditValue.ToString();
            ob.SL=MainNTP.ParseDouble(teSL.Text);
            ob.Solo=teSoLo.Text;
            ob.Nhom = lkNhom.EditValue == null ? "" : lkNhom.EditValue.ToString();
            listChitiet.Add(ob);
            RefreshviewHangHoa();
        }

        void RefreshviewHangHoa()
        {
            if (gridHangHoa.DataSource == null)
                gridHangHoa.DataSource = listChitiet;
            viewHangHoa.RefreshData();
        }

        bool KiemTraHopLe() {
            if (lkNguoiNhap.EditValue == null || NTPValidate.IsEmpty(lkNguoiNhap.EditValue.ToString())) {
                MessageBox.Show("Vui lòng chọn người nhập");
                lkNguoiNhap.Focus();
                return false;
            }
            if (lkKho.EditValue == null || NTPValidate.IsEmpty(lkKho.EditValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn kho");
                lkKho.Focus();
                return false;
            }

            if (listChitiet.Count == 0) {
                MessageBox.Show("Vui lòng thêm dịch vụ để lưu");
                return false;
            }
            return true;
        }

        double SaveNhapKho() {
            double rs = -1;
            ObNhapKho ob = NhapKho;
            if (!_Modify)
            {
                ob.Ma = MainNTP.obNhapKhoList.GetID();
                ob.TrangThai = cheDaDuyet.Checked ? etrangthai.Đã_duyệt.ToString() : etrangthai.Chờ_duyệt.ToString();
                if (MainNTP.obNhapKhoList.AddOb(ob))
                {
                    rs = ob.Ma;
                }
            }
            else {
                ob.TrangThai = cheDaDuyet.Checked ? etrangthai.Đã_duyệt.ToString() : etrangthai.Chờ_duyệt.ToString();
                if (MainNTP.obNhapKhoList.UpdateOb(ob))
                    rs = ob.Ma;
            }
            return rs;
        }

        public bool SaveCTPhieuNhap(double keyCreate)
        {
            foreach (var ob in listChitiet)
            {
                if (ob.Action == ActionRec.Insert)
                {
                    ob.Ma = MainNTP.obCTNhapKhoList.GetID();
                    ob.KeyPhieuNhap = keyCreate;
                    ob.TrangThai = cheDaDuyet.Checked ? etrangthai.Đã_duyệt.ToString() : etrangthai.Chờ_duyệt.ToString();
                    if(MainNTP.obCTNhapKhoList.AddOb(ob)){
                        ob.Action = ActionRec.None;
                    }
                }
                if (ob.Action == ActionRec.Update)
                {
                    ObCTNhapKho os = listUpdate.Find(o => (ob.Ma == o.Ma));
                    if (os == null) continue;
                    if (MainNTP.obCTNhapKhoList.UpdateOb(os))
                    {
                        ob.Action = ActionRec.None;
                        listUpdate.Remove(ob);
                    }
                }
            }
            for (int i = 0; i < listDelete.Count; i++)
            {
                ObCTNhapKho os = listDelete[i];
                if (os == null) continue;
                if (MainNTP.obCTNhapKhoList.DeleteOb(os))
                {
                    listDelete.RemoveAt(i); i--;
                }
            }
            return true;
        }

        bool Save()
        {
            if (!KiemTraHopLe()) return false;
            DBStatic.ConnectDB(DadaConnect.connect_string);
            double rs = SaveNhapKho();
            if (rs > 0) {
                SaveCTPhieuNhap(rs);
                MessageBox.Show("Phiếu nhập kho " + rs + " đã được lưu");
                LayDuLieu();
                Clear();
                return true;
            }

            return false;
        }

        void SetModify(ObNhapKho ob) {
            NhapKho = ob;
            _Modify = true;
            KeysListObCTNhapKho keys = NTPObCTNhapKho.GetListOb(ob.Ma);
            listUpdate.Clear();
            listDelete.Clear();
            listChitiet.Clear();
            if (keys != null) {
                foreach (var item in keys)
                {
                    item.Action = ActionRec.None;
                    ObDMDichVu dm = MainNTP.ObDMDichVuList.Get(item.MaDV);
                    if (dm != null)
                        item.Ten = dm.Ten;
                    listChitiet.Add(item);
                }
            }

            RefreshviewHangHoa();
            //btLuuBenhAn.Enabled = ob.TrangThai != etrangthai.Đã_duyệt.ToString();
        }

        void XoaDong() {

            if (contextMenuStrip1.SourceControl == gridHangHoa)
            {
                ObCTNhapKho ob = (ObCTNhapKho)viewHangHoa.GetFocusedRow();
                if (ob == null) return;
                listDelete.Add(ob);
                //if (ob.TrangThai == etrangthai.Đã_duyệt.ToString())
                //{
                //    MessageBox.Show("Phiếu đã duyệt. Không thể xóa");
                //    return;
                //}
                viewHangHoa.DeleteSelectedRows();
            }
            else
            {
                ObNhapKho ob = (ObNhapKho)viewDanhSach.GetFocusedRow();
                if (ob == null) return;

                XoaPhieuNhapKho(ob);
            }
        }

        void XoaPhieuNhapKho(ObNhapKho ob)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập kho số " + ob.Ma + " không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            MainNTP.obNhapKhoList.DeleteOb(ob);
            for (int i = 0; i > listChitiet.Count; i++)
            {
                ObCTNhapKho ct = listChitiet[i];
                MainNTP.obCTNhapKhoList.DeleteOb(ct);
            }

            MessageBox.Show("Phiếu nhập kho " + ob.Ma + " đã được xóa");
            LayDuLieu();
        }

        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void viewHangHoa_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ObCTNhapKho cls = (ObCTNhapKho)viewHangHoa.GetFocusedRow();
            if (cls == null) return;
            if (cls.Action != ActionRec.Insert)
                cls.Action = ActionRec.Update;
        }
        
        private void viewHangHoa_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ObCTNhapKho cls = (ObCTNhapKho)viewHangHoa.GetFocusedRow();
            if (cls == null) return;
            if (cls.Action == ActionRec.None)
            {
                listUpdate.Add(cls);
            }
        }

        void ppDichVu_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            _ShowPP = false;
        }

        void ppDichVu_Popup(object sender, EventArgs e)
        {
            _ShowPP = true;
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void teSoLo_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void ppDichVu_EditValueChanged(object sender, EventArgs e)
        {
            if (!_ShowPP && !NTPValidate.IsEmpty(ppDichVu.Text))
            {
                ppDichVu.ShowPopup();
            }

            string sql = "";
            if (!NTPValidate.IsEmpty(ppDichVu.Text))
                sql = "[Ma] like '%" + ppDichVu.Text + "%'";
            if (!NTPValidate.IsEmpty(sql))
                viewDanhMuc.ActiveFilterString = sql;
            else viewDanhMuc.ClearColumnsFilter();
        }

        private void ppDichVu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                viewDanhMuc.Focus();
                if (viewDanhMuc.FocusedRowHandle < 0)
                    viewDanhMuc.FocusedRowHandle = 0;
                else viewDanhMuc.FocusedRowHandle += 1;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SetDichVu();
            }
        }

        private void viewDanhMuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetDichVu();
            }
        }

        private void viewDanhMuc_DoubleClick(object sender, EventArgs e)
        {
            SetDichVu();
        }

        private void btLuuBenhAn_Click(object sender, EventArgs e)
        {
            Save();
            try
            {
                MainNTP.ObDichVuTonList.GetListTonByThang(MainNTP._Ngay.Month);
            }
            catch
            {

            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void viewDanhSach_DoubleClick(object sender, EventArgs e)
        {
            ObNhapKho ob = (ObNhapKho)viewDanhSach.GetFocusedRow();
            if (ob == null) return;
            SetModify(ob);
        }

        private void mnXoaDong_Click(object sender, EventArgs e)
        {
            XoaDong();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            AddDichVu();
            SetNewHangHoa();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
        }

        private void teSL_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void btXoaPhieu_Click(object sender, EventArgs e)
        {
            ObNhapKho ob = MainNTP.obNhapKhoList.GetOb(MainNTP.ParseDouble(teSoPN.Text));
            if (ob == null)
            {
                return;
            }

            XoaPhieuNhapKho(ob);
        }

        private void teSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (MainNTP.ParseDouble(teSL.Text) <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng !");
                    teSL.Focus();
                    return;
                }
                AddDichVu();
                SetNewHangHoa();
            }
        }
    }
}