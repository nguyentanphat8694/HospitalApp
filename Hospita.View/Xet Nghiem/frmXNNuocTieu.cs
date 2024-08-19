using DevExpress.XtraReports.UI;
using Hospital.App.Object;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hospital.App.Xet_Nghiem
{
    public partial class frmXNNuocTieu : DevExpress.XtraEditors.XtraForm
    {
        protected ObCTChiDinh CTChiDinh { get; set; }
        protected ObChiDinh ChiDinh { get; set; }
        protected ObXNNT XNNT { get; set; }
        protected bool IsMauChange { get; set; }
        protected bool IsNewXNNT { get; set; }
        protected UMauBA uBenhAn { get; set; }
        
        public frmXNNuocTieu()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            LoadControl();
            InitDisplay();
        }

        protected void LoadControl()
        {
            uBenhAn = new UMauBA();
            uBenhAn.Dock = DockStyle.Fill;
            pnlMau.Controls.Add(uBenhAn);
        }

        private void InitDisplay()
        {
            lkBacSi.Properties.DataSource = MainNTP.ObDMNhanSuList;
            deNgay.DateTime = MainNTP._Ngay;
            lkBacSi.EditValue = MainNTP.User.TTChung.MaNS;
            deNgay.DateTime = MainNTP._Ngay.Date;
        }

        public void SetNew(ObCTChiDinh ob, string chanDoan)
        {
            IsNewXNNT = true;
            XNNT = null;
            SetBNInfo(ob.MaBN);
            CTChiDinh = ob;
            if (!string.IsNullOrEmpty(chanDoan))
                teChanDoan.Text = chanDoan;
            else
            {
                ChiDinh = MainNTP.ObChiDinhList.GetOb(ob.KeyCreate);
                teChanDoan.Text = ChiDinh.ChanDoan;
            }
            ObDMDichVu dm = MainNTP.ObDMDichVuList.Get(CTChiDinh.MaDV);
            if (dm != null)
                uBenhAn.lkMAU.EditValue = dm.TTChung.Mau;
            SetEnable(false);
            IsMauChange = false;
        }

        public void SetModify(double maXNNT)
        {
            IsNewXNNT = false;
            XNNT = MainNTP.ObCDXNNTList.GetOb(maXNNT);
            if (XNNT != null)
            {
                uBenhAn.lkMAU.Properties.ReadOnly = !string.IsNullOrEmpty(XNNT.MaMau);
                teSoPhieu.Text = XNNT.Ma.ToString();
                SetBNInfo(XNNT.MaBN);
                CTChiDinh = MainNTP.ObCTChiDinhList.GetOb(XNNT.KeyCTChiDinh);
                if (CTChiDinh != null)
                {
                    ChiDinh = MainNTP.ObChiDinhList.GetOb(CTChiDinh.KeyCreate);
                    if (ChiDinh != null)
                    {
                        teChanDoan.Text = ChiDinh.ChanDoan;
                    }
                }
                IsMauChange = false;
            }
        }

        protected void SetBNInfo(string maBN)
        {
            if (!NTPValidate.IsEmpty(maBN))
            {
                var bn = MainNTP.ObCustomerList.GetOb(teMaBN.Text);
                if (bn != null)
                {
                    teMaBN.Text = maBN;
                    teHoTen.Text = bn.Ten;
                    teNam.Text = bn.Namsinh.ToString();
                    cheNam.Checked = bn.Gioitinh == 0;
                    teDiaChi.Text = bn.DiaChiFull;
                }
            }
        }

        #region Event Handler
        private void btLuuBenhAn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InPhieuSieuAm();
        }

        private void btHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Huy();
        }

        private void btExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion

        void InPhieuSieuAm()
        {
            try
            {
                Save(false);
            }
            catch { }
            if (XNNT == null) return;

            //SA020110 cls = new SA020110();
            //ObCDHA obIn = new ObCDHA(obCur);
            //if (obIn.TTChung == null) obIn.TTChung = new ClsTTCDHA();
            //if (obIn.TTChung.Images == null) obIn.TTChung.Images = new List<ObImage>();
            //obIn.TTChung.Images.Clear();
            //obIn.TTChung.Images = uImages.Images.FindAll(o => o.In);
            //int n = obIn.TTChung.Images.Count;
            //cls.SetNew(obCur);
            //cls.TenVungKhaoSat = uBenhAn.lkMAU.Text.ToUpper();
            //var bn = cls.MaBenhNhan;
            //RP020100 rp = new RP020100();
            //string rp_name = n == 0 ? e_REPORTNTP.Sieu_Am_0_Anh.ToString() :
            //    n <= 2 ? e_REPORTNTP.Sieu_Am_2_Anh.ToString() :
            //    n <= 3 ? e_REPORTNTP.Sieu_Am_3_Anh.ToString() :
            //    n <= 4 ? e_REPORTNTP.Sieu_Am_4_Anh.ToString() :
            //    e_REPORTNTP.Sieu_Am.ToString();
            //rp.SetData(rp_name, new List<SA020110>() { cls });
            //rp.ShowPreviewDialog();
        }

        bool Save(bool isShowMessage = true)
        {
            if (!SaveCDXNNT()) return false;
            UpdateCTChiDinh();
            if (isShowMessage)
                MessageBox.Show("Phiếu XN nước tiểu của bệnh nhân " + teHoTen.Text.ToUpper() + " đã được lưu");
            if (!uBenhAn.lkMAU.Properties.ReadOnly)
                uBenhAn.lkMAU.Properties.ReadOnly = true;
            SetEnable(true);
            return true;
        }

        bool SaveCDXNNT()
        {
            var ob = GetObXNNT();
            if (IsNewXNNT)
            {
                ob.Ma = MainNTP.ObCDXNNTList.GetID();
                ob.Action = ActionRec.Update;
                if (!MainNTP.ObCDXNNTList.AddOb(ob))
                    return false;
                teSoPhieu.Text = ob.Ma.ToString();
            }
            else
            {
                if (!MainNTP.ObCDXNNTList.UpdateOb(ob))
                    return false;
            }
            XNNT = ob;
            IsNewXNNT = false;
            return true;
        }

        bool UpdateCTChiDinh()
        {
            if (ChiDinh == null)
                ChiDinh = MainNTP.ObChiDinhList.GetOb(CTChiDinh.KeyCreate);
            if (ChiDinh != null)
            {
                ChiDinh.TrangThai = etrangthai.Đang_điều_trị.ToString();
                ChiDinh.ChanDoan = teChanDoan.Text;
                MainNTP.ObChiDinhList.UpdateOb(ChiDinh);
            }

            CTChiDinh.TrangThai = etrangthai.Hoàn_thành.ToString();
            CTChiDinh.KeyThucHien = XNNT.Ma;
            CTChiDinh.LoaiPhieuTH = (int)eLoaiPhieuTH.XNNT;
            CTChiDinh.TTChung.BacSi = MainNTP.GetStringFromObject(lkBacSi.EditValue);
            MainNTP.ObCTChiDinhList.UpdateOb(CTChiDinh);
            return true;
        }

        ObXNNT GetObXNNT()
        {
            var xnnt = new ObXNNT()
            {
                Ma = MainNTP.ParseDouble(teSoPhieu.Text),
                Ngay = deNgay.DateTime,
                MaBN = teMaBN.Text,
                ChanDoan = teChanDoan.Text,
                KeyCTChiDinh = CTChiDinh.Ma,
                BSThucHien = lkBacSi.EditValue.ToString(),
                MaMau = uBenhAn.lkMAU.EditValue == null ? "" : uBenhAn.lkMAU.EditValue.ToString(),
                NoiDungMau = uBenhAn.rtxtNOIDUNG.RtfText,
                KetLuan = Main_Text.GetText(new List<string>() { "KẾT LUẬN:" }, uBenhAn.rtxtNOIDUNG.Text),
            };
            return xnnt;
        }

        void SetEnable(bool tr)
        {
            btIn.Enabled = tr;
            btHuy.Enabled = tr;
        }

        bool Huy()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return true;
            XNNT.TrangThai = etrangthai.Đã_hủy.ToString();
            if (MainNTP.ObCDXNNTList.UpdateOb(XNNT, etrangthai.Đã_hủy))
            {
                ObCTChiDinh ct = CTChiDinh;
                if (ct != null)
                {
                    ct.TrangThai = etrangthai.Đang_chờ.ToString();
                    ct.KeyThucHien = 0;
                    ct.LoaiPhieuTH = 0;
                    ct.TTChung.BacSi = "";
                    MainNTP.ObCTChiDinhList.UpdateOb(ct);
                }
                MessageBox.Show("Phiếu siêu âm của bệnh nhân " + teHoTen.Text.ToUpper() + " đã được hủy");
                this.Close();
                return true;
            }
            return false;
        }

        private void frmXNNuocTieu_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var isChange = KiemTraThayDoi();
                if (isChange)
                {
                    if (MessageBox.Show("Dữ liệu đã thay đổi.\nBạn có muốn lưu không?", "Cảnh bảo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        Save(false);
                    else
                    {
                        e.Cancel = false;
                        return;
                    }
                }
                e.Cancel = true;
            }
            catch
            {
                e.Cancel = false;
            }
        }

        bool KiemTraThayDoi()
        {
            var ob = XNNT;
            var isChange = ob.BSThucHien != lkBacSi.EditValue.ToString();
            isChange = isChange || ob.Ngay != deNgay.DateTime;
            isChange = isChange || !string.Equals(ob.ChanDoan, teChanDoan.Text);
            isChange = isChange || !string.Equals(ob.NoiDungMau, uBenhAn.rtxtNOIDUNG.RtfText);
            return isChange;

        }
    }
}
