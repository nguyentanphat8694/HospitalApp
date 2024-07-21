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
using System.IO;
using System.Threading.Tasks;

namespace Hospital.App
{
    public partial class USA2 : DevExpress.XtraEditors.XtraUserControl
    {
        public USA2()
        {
            InitializeComponent();

            LoadData();
            InitDisplay();
            LoadControl();
            LoadEvent();
        }

        string soPhieu = "";
        string maBN = "";
        string chanDoan = "";
        string bacSi = "";
        

        bool isChange = false;
        SHPT.Utils.Capture.UCapture capture = null;
        UT010100 uToaThuoc = null;
        ObCTChiDinh obCTChiDinh = null;
        ObPhieuThuoc obThuoc = null;
        KeysListObCTChiDinh keyListObCTThuoc = null;
        UMauBA uBenhAn = null;
        UImages uImages = null;
        ObCDHA obCur = null;
        bool Modify = false;
        KeysListObCDHA keysNhatKy = null;

        public void SetDefault(string _chanDoan, string _bacSi)
        {
            chanDoan = _chanDoan;
            bacSi = _bacSi;
        }

        ObCDHA CDHA
        {
            get
            {
                ObCDHA ob = new ObCDHA();
                if (Modify && obCur != null)
                {
                    ob.SetNew(obCur);
                }
                ob.Ma = MainNTP.ParseDouble(soPhieu);
                ob.BSThucHien = bacSi.ToString();
                ob.ChanDoan = chanDoan;
                ob.KeyCTChiDinh = obCTChiDinh.Ma;
                ob.MaBN = maBN;
                ob.Ngay = deNgay.DateTime;
                ob.KetLuan = Main_Text.GetText(new List<string>() { "KẾT LUẬN:" }, uBenhAn.rtxtNOIDUNG.Text);
                //ob.TTChung.DeNghi = teDeNghi.Text;
                ob.TTChung.Images = new List<ObImage>();
                ob.TTChung.Images.AddRange(uImages.Images);
                ob.TTChung.SAThai = cheSAThai.Checked;
                ob.TTChung.NgayKinhCuoi = deNgayKinhCuoi.DateTime;
                ob.TTChung.NgayDuSanh = cheSAThai.Checked ? deNgayDuSanh.DateTime : MainNTP.MinValue;
                ob.TTChung.MaMau = uBenhAn.lkMAU.EditValue == null ? "" : uBenhAn.lkMAU.EditValue.ToString();
                ob.TTChung.NoiDungMau = uBenhAn.rtxtNOIDUNG.RtfText;
                ob.TTChung.SoTuoiThai = teSoTuoiThai.Value;
                ob.TTChung.TuoiThai = cboTuoiThai.Text;
                ob.MaBA = cheSAThai.Checked ? 1 : 0;
                if (obCTChiDinh != null)
                {
                    ob.TTChung.NgayChiDinh = obCTChiDinh.Ngay;
                }
                return ob;
            }
            set
            {
                soPhieu = value.Ma.ToString();
                maBN = value.MaBN;
                bacSi = value.BSThucHien;
                chanDoan = value.ChanDoan;
                maBN = value.MaBN;
                deNgay.DateTime = value.Ngay;
                //teKetLuan.Text = value.KetLuan;
                //teDeNghi.Text = value.TTChung.DeNghi;
                uImages.Images = value.TTChung.Images;
                cheSAThai.Checked = value.TTChung.SAThai;
                deNgayKinhCuoi.DateTime = value.TTChung.NgayKinhCuoi;
                deNgayDuSanh.DateTime = value.TTChung.NgayDuSanh;
                uBenhAn.lkMAU.EditValue = value.TTChung.MaMau;
                uBenhAn.rtxtNOIDUNG.RtfText = value.TTChung.NoiDungMau;
                teSoTuoiThai.Value = value.TTChung.SoTuoiThai;
                cboTuoiThai.Text = value.TTChung.TuoiThai;
            }
        }
        private void LoadData()
        {
            List<eTableName> listTable = new List<eTableName> {
                eTableName.DMDichVu,
                eTableName.Customer,
                eTableName.DMNhanSu
            };

            MainNTP.GetData(listTable);
        }
        void SetEnable(bool tr)
        {
            btIn.Enabled = tr;
            btHuy.Enabled = tr;
        }
        bool ReadOnly {
            set {
                btHuy.Enabled = !value;
                btLuuBenhAn.Enabled = !value;
            }
        }
        private void InitDisplay()
        {
            //lkBacSi.Properties.DataSource = MainNTP.ObDMNhanSuList;
            deNgay.DateTime = MainNTP._Ngay;
            deNgayDuSanh.DateTime = MainNTP.MinValue;

            //lkBacSi.EditValue = MainNTP.User.TTChung.MaNS;
            deNgay.DateTime = MainNTP._Ngay.Date;
        }

        private void LoadControl()
        {

            //uToaThuoc = new UT010100();
            //uToaThuoc.Dock = DockStyle.Fill;
            //pageKeToa.Controls.Add(uToaThuoc);

            uImages = new UImages();
            uImages.Dock = DockStyle.Fill;
            pnlDSAnh.Controls.Add(uImages);
            uImages.isChange = false;

            uBenhAn = new UMauBA();
            uBenhAn.Dock = DockStyle.Fill;
            pnlMau.Controls.Add(uBenhAn);

            capture = new SHPT.Utils.Capture.UCapture();
            capture.Dock = DockStyle.Fill;
            pnlCapture.Controls.Add(capture);
            this.capture.btCapture.Click += btCapture_Click;

            //_uChoSA = new UChoSA();
            //_uChoSA.Dock = DockStyle.Fill;
            //pageChoThucHien.Controls.Add(_uChoSA);

            //_uDaSA = new USieuAm();
            //_uDaSA.Dock = DockStyle.Fill;
            //pageDaThucHien.Controls.Add(_uDaSA);
        }

        void btCapture_Click(object sender, EventArgs e)
        {
            LayAnh();
        }

        private void LayAnh()
        {
            isChange = true;
            Image imgC = capture.CaptureImg();
            uImages.AddImgToList(imgC);
        }

        private void LoadEvent()
        {
            uBenhAn.lkMAU.EditValueChanged += lkMAU_EditValueChanged;
        }

        void lkMAU_EditValueChanged(object sender, EventArgs e)
        {
            if (uBenhAn.lkMAU.EditValue == null || uBenhAn.lkMAU.Properties.ReadOnly)
                return;

            ObDMMau ob = MainNTP.ObDMMauList.Get(uBenhAn.lkMAU.EditValue.ToString());
            if (ob == null) return;

            //teKetLuan.Text = ob.TTChung.KetLuan;
        }

        void TinhNgayDuSanh(string maBN)
        {
            int soTuan = 0;
            int soNgay = 0;
            MainNTP.TinhNgayDuSanh(maBN, ref soTuan, ref soNgay);

            if (soTuan == 0 && soNgay == 0)
            {
            }
            else
            {
                cheSAThai.Checked = true;
                decimal soN = (decimal)soNgay / 10;
                teSoTuoiThai.Value = soTuan + soN;
            }
        }

        public void SetNew(BA010110 ob)
        {
            maBN = ob.MaBN;
            Modify = false;
            #region obCTChiDinh
            obCTChiDinh = ob;
            
            #endregion
            ObDMDichVu dm = MainNTP.ObDMDichVuList.Get(obCTChiDinh.MaDV);
            if (dm != null)
            {
                uBenhAn.lkMAU.EditValue = dm.TTChung.Mau;
            }
            deNgay.DateTime = MainNTP._Ngay;
            TinhNgayDuSanh(ob.MaBN);
            SetEnable(false);
            isChange = false;
            
        }

        public void SetModify(ObCDHA ob) {
            Modify = true;
            uBenhAn.lkMAU.Properties.ReadOnly = ob.TTChung.MaMau != null && ob.TTChung.MaMau != "";
            CDHA = ob;
            obCur = new ObCDHA(ob);
            #region obCTChiDinh
            obCTChiDinh = MainNTP.ObCTChiDinhList.GetOb(ob.KeyCTChiDinh);
            #endregion

            isChange = false;
        }

        bool KiemTraHopLe() {
            return true;
        }

        bool UpdateCTChiDinh(double maCDHA)
        {
            ObChiDinh cd = MainNTP.ObChiDinhList.GetOb(obCTChiDinh.KeyCreate);
            if (cd != null) {
                cd.TrangThai = etrangthai.Đang_điều_trị.ToString();
                cd.ChanDoan = chanDoan;
                MainNTP.ObChiDinhList.UpdateOb(cd);
            }

            ObCTChiDinh ct = MainNTP.ObCTChiDinhList.GetOb(obCTChiDinh.Ma);
            if (ct != null)
            {
                ct.TrangThai = etrangthai.Hoàn_thành.ToString();
                ct.KeyThucHien = maCDHA;
                ct.LoaiPhieuTH = (int)eLoaiPhieuTH.Sieu_Am;
                ct.TTChung.BacSi = MainNTP.GetStringFromObject(bacSi);
                MainNTP.ObCTChiDinhList.UpdateOb(ct);
            }
            return true;
        }
        void UpdateThuoc(double maBA)
        {
            if (uToaThuoc.listDichVu.Count == 0)
            {
                return;
            }
            if (obThuoc == null)
            {
                obThuoc = new ObPhieuThuoc();
                obThuoc.ChanDoan = chanDoan;
                obThuoc.MaBA = maBA;
                obThuoc.MaBN = maBN;
                obThuoc.Ngay = deNgay.DateTime;
                obThuoc.Ma = MainNTP.obPhieuThuocList.GetID();
                obThuoc.Loai = (int)eLoaiPhieuTH.Sieu_Am;
                MainNTP.obPhieuThuocList.AddOb(obThuoc);
            }
            else
            {
                obThuoc.ChanDoan = chanDoan;
                obThuoc.MaBA = maBA;
                obThuoc.MaBN = maBN;
                obThuoc.Ngay = deNgay.DateTime;
                obThuoc.Loai = (int)eLoaiPhieuTH.Sieu_Am;
                MainNTP.obPhieuThuocList.UpdateOb(obThuoc);
            }
            return;
        }
        void UpdateCTThuoc(double maBA)
        {
            if (obThuoc == null) return;

            // update thuc hien
            uToaThuoc.Save(deNgay.DateTime.Date, obThuoc.Ma, maBN, bacSi.ToString());
        }
        void UpdateHinhAnh() {
            /*
            string dd = NTPUserSetting.DDLuuAnhSA;
            for (int i = 0; i < listHinhAnh.Count; i++) {
                ObImage ob = listHinhAnh[i];
                if (ob.Ma>0)
                {
                    //update
                    MainNTP.obImageList.UpdateOb(ob);
                }
                else {
                    //add
                    ob.Ma = MainNTP.obImageList.GetID();
                    MainNTP.obImageList.AddOb(ob);
                    MainNTP.SaveImage(dd, ob.Img, eLoaiPhieuTH.Sieu_Am.ToString(), MainNTP.GetServerDate());
                }
            }
             */
        }
        

        public bool SaveCDHA()
        {
            ObCDHA ob = CDHA;

            if (!Modify)
            {
                ob.Ma = MainNTP.ObCDHAList.GetID();
                ob.Action = ActionRec.Update;
                if (!MainNTP.ObCDHAList.AddOb(ob))
                    return false;
                soPhieu = ob.Ma.ToString();
            }
            else
            {
                if (!MainNTP.ObCDHAList.UpdateOb(ob))
                    return false;
            }
            obCur = ob;
            Modify = true;
            
            return true;
        }
        bool Save(bool isShowMessage = true) {
            if (!KiemTraHopLe())
                return false;
            if (!SaveCDHA()) return false;
            UpdateCTChiDinh(obCur.Ma);

            ObCustomer bn = MainNTP.ObCustomerList.GetOb(maBN);
            string ten = bn == null ? maBN : bn.Ten;

            if (isShowMessage)
                MessageBox.Show("Phiếu siêu âm của bệnh nhân " + ten.ToUpper() + " đã được lưu");
            if (!uBenhAn.lkMAU.Properties.ReadOnly)
                uBenhAn.lkMAU.Properties.ReadOnly = true;

            SetEnable(true);
            return true;
        }

        bool Huy()
        {
            if (obCur == null) return false;
            if (obThuoc != null && obThuoc.TrangThai != etrangthai.Đã_hủy.ToString())
            {
                MessageBox.Show("Đã kê toa thuốc. Không thế xóa bệnh án này!");
                return false;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return true;
            // Hủy bệnh án
            obCur.TrangThai = etrangthai.Đã_hủy.ToString();
            if (MainNTP.ObCDHAList.UpdateOb(obCur, etrangthai.Đã_hủy))
            {
                // huy CTChidinh
                ObCTChiDinh ct = MainNTP.ObCTChiDinhList.GetOb(obCTChiDinh.Ma);
                if (ct != null)
                {
                    ct.TrangThai = etrangthai.Đang_chờ.ToString();
                    ct.KeyThucHien = 0;
                    ct.LoaiPhieuTH = 0;
                    ct.TTChung.BacSi = "";
                    MainNTP.ObCTChiDinhList.UpdateOb(ct);
                }

                ObCustomer bn = MainNTP.ObCustomerList.GetOb(maBN);
                string ten = bn == null ? maBN : bn.Ten;

                MessageBox.Show("Phiếu siêu âm của bệnh nhân " + ten.ToUpper() + " đã được hủy");
                //this.Close();
                return true;
            }
            return false;
        }

        void InPhieuSieuAm()
        {
            Save(false);
            if (obCur == null) return;

            RP020100 rp = Main_View.GetReportSieuAm(obCur);
            if (rp != null)
            {
                rp.ShowPreviewDialog();
            }

            //SA020110 cls = new SA020110();
            //ObCDHA obIn = new ObCDHA(obCur);
            //obIn.TTChung.Images.Clear();
            //obIn.TTChung.Images = uImages.Images.FindAll(o => o.In);
            //int n = obIn.TTChung.Images.Count;
            //cls.SetNew(obCur);
            //cls.TenVungKhaoSat = uBenhAn.lkMAU.Text.ToUpper();
            //var bn = cls.MaBenhNhan;
            //RP020100 rp = new RP020100();
            //string rp_name = n == 0 ? e_REPORTNTP.Sieu_Am_0_Anh.ToString() :
            //    n == 2 ? e_REPORTNTP.Sieu_Am_2_Anh.ToString() :
            //    n == 3 ? e_REPORTNTP.Sieu_Am_3_Anh.ToString() :
            //    n == 4 ? e_REPORTNTP.Sieu_Am_4_Anh.ToString() :
            //    e_REPORTNTP.Sieu_Am.ToString();
            //rp.SetData(rp_name, new List<SA020110>() { cls });
            //rp.ShowPreviewDialog();
        }

        void TinhTuoiThai() {
            DateTime ngayKinhCuoi = MainNTP.MinValue;

            int soT2 = (int)(teSoTuoiThai.Value * 10) / 10;
            int soN2 = (int)(teSoTuoiThai.Value * 10) % 10;
            int tongN = soT2 * 7 + soN2;

            if (cboTuoiThai.SelectedIndex == 0)//tháng
            {
                ngayKinhCuoi = deNgay.DateTime.AddMonths(-soT2);
            }
            else if (cboTuoiThai.SelectedIndex == 1)//tuần
            {
                ngayKinhCuoi = deNgay.DateTime.AddDays(-tongN);
            }
            else if (cboTuoiThai.SelectedIndex == 2)//ngày
            {
                ngayKinhCuoi = deNgay.DateTime.AddDays(-soT2);
            }

            deNgayKinhCuoi.DateTime = ngayKinhCuoi;
        }

        private void btLuuBenhAn_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            Huy();
        }

        private void btInToaThuoc_Click(object sender, EventArgs e)
        {
            InPhieuSieuAm();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void deNgayKinhCuoi_EditValueChanged(object sender, EventArgs e)
        {
            deNgayDuSanh.DateTime = deNgayKinhCuoi.DateTime.AddDays(280);
        }

        private void cheSAThai_CheckedChanged(object sender, EventArgs e)
        {
            if (deNgayDuSanh.DateTime == MainNTP.MinValue) {
                if (keysNhatKy != null && keysNhatKy.Count > 0) {
                    List<ObCDHA> list = keysNhatKy.ToList().FindAll(o => o.TTChung.SAThai);
                    if (list != null && list.Count > 0)
                    {
                        DateTime max_ngay = list.Max(o => o.Ngay);
                        ObCDHA ob = list.Find(o => o.Ngay == max_ngay);
                        if (ob != null)
                        {
                            int soNgay = (deNgay.DateTime - ob.Ngay).Days;
                            int soTuan = soNgay / 7;
                            teSoTuoiThai.Value = ob.TTChung.SoTuoiThai + soTuan;
                        }
                    }
                }
            }
            //deNgayKinhCuoi.Properties.ReadOnly = !cheSAThai.Checked;
            deNgayDuSanh.Properties.ReadOnly = !cheSAThai.Checked;
            teSoTuoiThai.ReadOnly = !cheSAThai.Checked;
            if (!cheSAThai.Checked) {
                teSoTuoiThai.Value = 0;
                deNgayKinhCuoi.DateTime = MainNTP.MinValue;
                deNgayDuSanh.DateTime = MainNTP.MinValue;
            }
        }

        private void teSoTuoiThai_ValueChanged(object sender, EventArgs e)
        {
            TinhTuoiThai();
        }

        private void cboTuoiThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTuoiThai();
        }

        private void btExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.Close();
        }

        private void btIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InPhieuSieuAm();
        }

        private void btHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Huy();
        }

        private void btLuuBenhAn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btLayAnh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LayAnh();
        }

        private void frmSieuAm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool thoat = false;
                if (!KiemTraThayDoi())
                {
                    thoat = false;
                }
                else
                {

                    if (MessageBox.Show("Dữ liệu đã thay đổi.\nBạn có muốn lưu không?", "Cảnh bảo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        thoat = false;
                    }
                    else
                    {
                        Save(false);
                        thoat = false;
                    }
                }

                if (thoat)
                {
                    e.Cancel = true;
                }
                else
                {
                    capture.Stop();
                    e.Cancel = false;
                }
            }
            catch
            {
                e.Cancel = false;
            }
        }

        bool KiemTraThayDoi()
        {
            if (obCur == null) {
                return true;
            }

            ObCDHA ob = CDHA;

            if (ob.BSThucHien != obCur.BSThucHien) {
                return true;
            }

            if (ob.Ngay != obCur.Ngay)
            {
                return true;
            }

            if (ob.ChanDoan != obCur.ChanDoan)
            {
                return true;
            }

            if (ob.TTChung.SAThai != obCur.TTChung.SAThai)
            {
                return true;
            }

            if (ob.TTChung.SoTuoiThai != obCur.TTChung.SoTuoiThai)
            {
                return true;
            }

            if (ob.TTChung.TuoiThai != obCur.TTChung.TuoiThai)
            {
                return true;
            }

            if (ob.TTChung.MaMau != obCur.TTChung.MaMau)
            {
                return true;
            }

            if (ob.TTChung.NoiDungMau != obCur.TTChung.NoiDungMau)
            {
                return true;
            }

            if (isChange) {
                return true;
            }

            if (uImages.isChange)
            {
                return true;
            }

            return false;
            
        }

        private void frmSieuAm_Shown(object sender, EventArgs e)
        {
            capture.Start();
        }

    }
}