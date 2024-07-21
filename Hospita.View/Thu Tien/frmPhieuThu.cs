using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace Hospital.App
{
    public partial class frmPhieuThu : DevExpress.XtraEditors.XtraForm
    {
        public frmPhieuThu()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            LoadData();
            InitDisplay();
            LoadControl();
        }
        List<ObCTChiDinh> listDichVu = null;
        ObPhieuThu obCur = null;
        bool Modify = false;
        List<ObTKBenhNhan> TK = null;

        ObPhieuThu PhieuThu {
            get {
                if (obCur == null)
                    obCur = new ObPhieuThu();
                obCur.Ngay = deNgay.DateTime;
                obCur.GiamTong = MainNTP.ParseDouble(teSoGiam.Text);
                obCur.MaBN = teMaBN.Text;
                obCur.NguoiThu = lkNguoiThu.EditValue.ToString();
                obCur.TTChung.ThanhToan = MainNTP.ParseDouble(teThanhToan.Text);
                obCur.TrangThai = etrangthai.Đã_thu.ToString();
                obCur.TTChung.KHTra = MainNTP.ParseDouble(teKHTra.Text);
                return obCur;
            }
            set {
                obCur = value;
                if (obCur == null) return;
                teSoPhieu.Text = value.Ma.ToString();
                teMaBN.Text = obCur.MaBN;
                deNgay.DateTime = obCur.Ngay;
                lkNguoiThu.EditValue = obCur.NguoiThu;
                teSoGiam.Text = obCur.GiamTong.ToString();
                teThanhToan.Text = obCur.TTChung.ThanhToan.ToString();
                teKHTra.Text = obCur.TTChung.KHTra.ToString();
            }
        }

        bool ReadOnly {
            set {
                deNgay.Properties.ReadOnly = value;
                lkNguoiThu.Properties.ReadOnly = value;
                teSoGiam.Properties.ReadOnly = value;
                teThanhToan.Properties.ReadOnly = value;
                btLuu.Enabled = !value;
                contextMenuStrip1.Enabled = !value;
            }
        }

        void SetEnable(bool tr)
        {
            btIn.Enabled = tr;
            btHuy.Enabled = tr;
        }

        private void LoadControl()
        {

        }

        private void InitDisplay()
        {
            lkNguoiThu.Properties.DataSource = MainNTP.ObDMNhanSuList;
            lkNguoiThu.EditValue = MainNTP.User.TTChung.MaNS;
        }

        private void LoadData()
        {
            deNgay.DateTime = MainNTP._Ngay;

            List<eTableName> listTable = new List<eTableName> {
                eTableName.Customer,
                eTableName.DMPK,
                eTableName.DMDichVu,
                eTableName.DMNhanSu,
                eTableName.DMDonVi,
            };

            MainNTP.GetData(listTable);
        }

        void TinhThanhTien() {
            if (listDichVu == null) return;
            double thanhToan = MainNTP.ParseDouble(teTongCP.Text) - MainNTP.ParseDouble(teSoGiam.Text) - MainNTP.ParseDouble(teTamUng.Text);
            teThanhToan.Text = (thanhToan).ToString("n0");
            double tienThoi = MainNTP.ParseDouble(teKHTra.Text) - thanhToan;
            teTienThoi.Text = tienThoi.ToString("n0");
        }

        public void SetNew(TT010110 cls) {
            DBStatic.ConnectDB(DadaConnect.connect_string);
            teMaBN.Text = cls.MaBN;
            if (listDichVu == null) listDichVu = new List<ObCTChiDinh>();
            foreach (var item in cls.listCTChiDinh)
            {
                listDichVu.Add(new ObCTChiDinh(item));
            }
            Modify = false;
            if (listDichVu == null) return;
            gridDanhSach.DataSource = listDichVu;
            viewDanhSach.RefreshData();
            teTongCP.Text = listDichVu.Sum(o => o.SL * o.DG).ToString("n0");
            TinhThanhTien();
            SetEnable(false);

            KeysListObTKBenhNhan listTK = NTPObTKBenhNhan.GetListOb(teMaBN.Text);
            if (listTK != null)
            {
                TK = listTK.ToList().FindAll(o => o.TrangThai != etrangthai.Đã_hủy.ToString() && o.TrangThai != etrangthai.Đã_hạch_toán.ToString());
            }
            double tamUng = TK != null && TK.Count > 0 ? TK.Sum(o => o.ThanhTien) : 0;

            teTamUng.Text = tamUng.ToString("n0");
        }

        public void SetModify(ObPhieuThu ob) {
            PhieuThu = ob;
            ReadOnly = true;
            Modify = true;
            DBStatic.ConnectDB(DadaConnect.connect_string);
            
            KeysListObCTChiDinh key = NTPObCTChiDinh.GetListOb_KeyPT(ob.Ma);
            if (key == null) return;
            listDichVu = key.ToList();
            gridDanhSach.DataSource = listDichVu;
            viewDanhSach.RefreshData();
            teTongCP.Text = listDichVu.Sum(o => o.SL * o.DG).ToString("n0");
            TinhThanhTien();

            KeysListObTKBenhNhan listTK = NTPObTKBenhNhan.GetListOb(teMaBN.Text);
            if (listTK != null)
            {
                TK = listTK.ToList().FindAll(o => o.TrangThai == etrangthai.Đã_hạch_toán.ToString() && o.KeyPT == ob.Ma);
            }
            double tamUng = TK != null && TK.Count > 0 ? TK.Sum(o => o.ThanhTien) : 0;

            teTamUng.Text = tamUng.ToString("n0");
        }

        bool KiemTraHopLe() {

            if (NTPValidate.IsEmpty(teMaBN.Text)) {
                MessageBox.Show("Vui lòng chọn bệnh nhân");
                return false;
            }

            if (lkNguoiThu.EditValue == null || NTPValidate.IsEmpty(lkNguoiThu.EditValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn người thu");
                return false;
            }

            if (listDichVu==null || listDichVu.Count==0)
            {
                MessageBox.Show("Không có dịch vụ để thu");
                return false;
            }

            foreach (var item in listDichVu)
            {
                ObDMDichVu dm = MainNTP.ObDMDichVuList.Get(item.MaDV);
                if (dm == null || dm.Loai == (int)eLoaiHH.Dịch_vụ) continue;
                double slTon = KeysListObSLTon.GetSLTon(item.MaDV);
                if (slTon < item.SL) {
                    MessageBox.Show("Số lượng tồn không đủ bán(" + slTon + "<" + item.SL + ")");
                    return false;
                }
            }

            return true;
        }

        void SaveCTChiDinh() {
            for(int i=0;i<listDichVu.Count;i++)
            {
                ObCTChiDinh item = listDichVu[i];
                item.KeyPT = obCur.Ma;
                MainNTP.ObCTChiDinhList.UpdateOb(item);
            }
            
        }

        bool Save() {
            if (!KiemTraHopLe())
                return false;
            ObPhieuThu ob = PhieuThu;
            if (ob == null)
                return false;
            if (!Modify) {
                ob.Ma = NTPObPhieuThu.GetNextID();
                MainNTP.ObPhieuThuList.AddOb(ob);
                obCur = ob;
                teSoPhieu.Text = ob.Ma.ToString();
            }
            else {
                MainNTP.ObPhieuThuList.UpdateOb(ob);
                obCur = ob;
            }
            SaveCTChiDinh();

            UpdateTKBenhNhan(false);

            MessageBox.Show("Tạo phiếu thu thành công");
            ReadOnly = true;
            SetEnable(true);
            return true;
        }

        void UpdateTKBenhNhan(bool isHuy)
        {
            if (TK != null && TK.Count > 0)
            {
                if (isHuy)
                {
                    foreach (ObTKBenhNhan item in TK)
                    {
                        item.TrangThai = etrangthai.Đã_thu.ToString();
                        item.KeyPT = 0;
                        MainNTP.ObTKBenhNhanList.UpdateOb(item);
                    }
                }
                else
                {
                    foreach (ObTKBenhNhan item in TK)
                    {
                        item.TrangThai = etrangthai.Đã_hạch_toán.ToString();
                        item.KeyPT = obCur.Ma;
                        MainNTP.ObTKBenhNhanList.UpdateOb(item);
                    }
                }
            }
        }

        void Huy() {
            if (obCur == null) return;
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            obCur.TrangThai = etrangthai.Đã_hủy.ToString();
            MainNTP.ObPhieuThuList.UpdateOb(obCur, etrangthai.Đã_hủy);
            foreach (var item in listDichVu)
            {
                item.KeyPT = 0;
                MainNTP.ObCTChiDinhList.UpdateOb(item);
            }

            UpdateTKBenhNhan(true);

            MessageBox.Show("Hủy thành công phiếu thu");
            this.Close();
        }

        void InPhieuThu() {
            if (obCur == null) return;
            TT020110 cls = new TT020110(obCur);
            cls.listDichVu = NTPObCTChiDinh.GetListOb_KeyPT(obCur.Ma);
            RP020100 rp = new RP020100();
            rp.SetData(e_REPORTNTP.Phieu_Thu.ToString(), new List<TT020110>() { cls });
            rp.ShowPreviewDialog();
        }

        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void teKHTra_EditValueChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void teTienThoi_EditValueChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            Huy();
        }

        private void mnXoaDong_Click(object sender, EventArgs e)
        {
            viewDanhSach.DeleteSelectedRows();
        }

        private void btIn_Click(object sender, EventArgs e)
        {
            InPhieuThu();
        }

        private void teSoGiam_EditValueChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }
    }
}