using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraReports.UI;
using Hospital.App.UserControl;

namespace Hospital.App
{
    public partial class frmBenhAn : DevExpress.XtraEditors.XtraForm
    {
        public frmBenhAn()
        {
            InitializeComponent();
            showMessageHTK = false;
            this.Icon = MainNTP.NTPICON;
            LoadData();
            InitDisplay();
            LoadControl();
            LoadEvent();
            showMessageHTK = true;
        }

        public static bool isShowSieuAm = false;

        double tamUng = 0;
        double conLai = 0;
        double daThu = 0;
        double chuaThu = 0;

        double chiPhiCu = 0;
        double noCu = 0;

        bool Modify_SH = false;
        bool Modify = false;
        bool tinhNgayHTK = true;
        bool showMessageHTK = true;
        bool previewFull = false;

        ObBenhAn obCur = null;
        ObSinhHieu obSinhHieu = null;
        ObChiDinh obChiDinh = null;
        ObPhieuThuoc obThuoc = null;
        ObCTChiDinh obCTChiDinh = null;
        ObHenKham obHK = null;

        KeysListObCTChiDinh keyListObCTChiDinh = null;
        KeysListObCTChiDinh keyListObCTThuoc = null;

        UD010100 uChiDinh = null;
        UT010100 uToaThuoc = null;
        UMauBA uBenhAn = null;
        UGoTat uChanDoan = null;
        UGoTat uLoiDan = null;
        UGoTat uNDHTK = null;
        UNhatKy _uNhatKy = null;

        public const int LoaiICD_ICD = 1;
        public const int LoaiICD_LoiDan = 2;
        public const int LoaiICD_HTK = 3;

        //UDSChoKham uDSChoKham = null;

        ObBenhAn BenhAn {
            get {
                ObBenhAn ob = (!Modify || obCur == null) ? new ObBenhAn() : new ObBenhAn(obCur);
                ob.Ma = MainNTP.ParseDouble(teSoPhieu.Text);
                ob.BSThucHien = lkBacSi.EditValue.ToString();
                ob.ChanDoanChinh = teChanDoan.Text;
                ob.KeyCTChiDinh = obCTChiDinh.Ma;
                ob.MaBN = teMaBN.Text;
                ob.Ngay = deNgay.DateTime;
                ob.TTChung.MaMau = uBenhAn.lkMAU.EditValue == null ? "" : uBenhAn.lkMAU.EditValue.ToString();
                ob.TTChung.NoiDungMau = uBenhAn.rtxtNOIDUNG.RtfText;
                ob.TTChung.LoiDan = teLoiDan.Text;
                if (obChiDinh != null)
                {
                    ob.TTChung.NgayChiDinh = obChiDinh.Ngay;
                }

                ob.TTChung.TuoiThai2 = teNgayDuSanh.Text;
                ob.TTChung.iTuoiThai2 = teSoTuoiThai.Value;
                ob.TTChung.sDonViTuoiThai2 = cboTuoiThai.Text;
                ob.TTChung.NgayDuSanh2 = deNgayDuSanh.DateTime;

                return ob;
            }
            set {
                teSoPhieu.Text = value.Ma.ToString();
                teMaBN.Text = value.MaBN;
                lkBacSi.EditValue = value.BSThucHien;
                teChanDoan.Text = value.ChanDoanChinh;
                teMaBN.Text = value.MaBN;
                deNgay.DateTime = value.Ngay;
                uBenhAn.lkMAU.EditValue = value.TTChung.MaMau;
                uBenhAn.rtxtNOIDUNG.RtfText = value.TTChung.NoiDungMau;
                teLoiDan.Text = value.TTChung.LoiDan;

                teNgayDuSanh.Text = value.TTChung.TuoiThai2;
                teSoTuoiThai.Value = value.TTChung.iTuoiThai2;
                cboTuoiThai.Text = value.TTChung.sDonViTuoiThai2;
                deNgayDuSanh.DateTime = value.TTChung.NgayDuSanh2;
            }
        }

        ObSinhHieu SinhHieu
        {
            get
            {
                ObSinhHieu ob = obSinhHieu;
                ob.MaBN = teMaBN.Text;
                ob.Ngay = deNgay.DateTime;
                ob.TTChung = new ClsTTSinhHieu();
                ob.TTChung.Mach = teMach.Text;
                ob.TTChung.NhietDo = teNhietDo.Text;
                ob.TTChung.HAMax = teHA_Max.Text;
                ob.TTChung.HAMin = teHA_Min.Text;
                ob.TTChung.NhipTho = teNhipTho.Text;
                ob.TTChung.ChieuCao = teCC.Text;
                ob.TTChung.CanNang = teCN.Text;
                ob.TTChung.BMI = teBMI.Text;
                ob.TTChung.Para = tePara.Text;
                return ob;
            }
            set
            {
                teMach.Text = value.TTChung.Mach;
                teNhietDo.Text = value.TTChung.NhietDo;
                teHA_Max.Text = value.TTChung.HAMax;
                teHA_Min.Text = value.TTChung.HAMin;
                teNhipTho.Text = value.TTChung.NhipTho;
                teCC.Text = value.TTChung.ChieuCao;
                teCN.Text = value.TTChung.CanNang;
                teBMI.Text = value.TTChung.BMI;
                tePara.Text = value.TTChung.Para;
            }
        }

        ObHenKham HenKham {
            get {
                ObHenKham ob = new ObHenKham();
                if (obHK != null){
                    ob.SetNew(obHK);
                }
                ob.MaBN = teMaBN.Text;
                //ob.MaBA = obCur.Ma;
                ob.Ngay = MainNTP._Ngay;
                ob.NgayDenKham = deNgayDen.DateTime;
                ob.TTChung.NoiDung = teNDHenKham.Text;
                ob.TTChung.SoNgay = cboSoNgay.Text;
                ob.ChanDoan = teChanDoan.Text;
                ob.TTChung.GioHK = deGio.Time;
                ob.TTChung.nNgay = (int)teSoNgay.Value;
                ob.TTChung.IDCTChiDinh = obCTChiDinh.Ma.ToString();
                return ob;
            }
            set {
                obHK = value;
                cheHenTK.Checked = value.Ma > 0;
                teSoNgay.Value = value.TTChung.nNgay;
                cboSoNgay.Text = value.TTChung.SoNgay;
                deNgayDen.DateTime = value.NgayDenKham;
                teNDHenKham.Text = value.TTChung.NoiDung;
                deGio.Time = value.TTChung.GioHK;
                
            }
        }
        private void LoadData()
        {
            List<eTableName> listTable = new List<eTableName> {
                eTableName.DMDichVu,
                eTableName.DMNhomDichVu,
                eTableName.Customer,
                eTableName.DMPK,
                eTableName.DMNhanSu,
                eTableName.DMICD,
            };

            MainNTP.GetData(listTable);
        }

        private void InitDisplay()
        {
            lkBacSi.Properties.DataSource = MainNTP.ObDMNhanSuList;
            deNgay.DateTime = MainNTP._Ngay;


            lkBacSi.EditValue = MainNTP.User.TTChung.MaNS;
            deNgay.DateTime = MainNTP._Ngay.Date;

            deNgayDen.DateTime = MainNTP._Ngay;
            var uKhamSan = new UKhamSan();
            uKhamSan.Dock = DockStyle.Left;
            uKhamSan.Location = new System.Drawing.Point(240, 0);
            scrollControlCTChiDinh.Controls.Add(uKhamSan);
        }

        private void LoadControl()
        {
            uChiDinh = new UD010100();
            uChiDinh.Dock = DockStyle.Fill;
            pageChiDinh.Controls.Add(uChiDinh);

            uToaThuoc = new UT010100();
            uToaThuoc.Dock = DockStyle.Fill;
            pageKeToa.Controls.Add(uToaThuoc);

            _uNhatKy = new UNhatKy();
            _uNhatKy.Dock = DockStyle.Fill;
            pnlNhatKy.Controls.Add(_uNhatKy);
            _uNhatKy.btToanManHinh.ItemClick += (object sender, DevExpress.XtraBars.ItemClickEventArgs e) =>
            {
                int h = 305;
                if (previewFull)
                {
                    container.SplitterPosition = h;
                    previewFull = false;
                }
                else
                {
                    container.SplitterPosition = 0;
                    previewFull = true;
                }
            };

            uBenhAn = new UMauBA();
            uBenhAn.Dock = DockStyle.Fill;
            pnlMauBA.Controls.Add(uBenhAn);

            //uDSChoKham = new UDSChoKham();
            //uDSChoKham.Dock = DockStyle.Fill;
            //pnlDSChoKham.Controls.Add(uDSChoKham);
            //uDSChoKham.viewDanhSach.DoubleClick += viewDanhSach_DoubleClick;

            uChanDoan = new UGoTat(MainNTP.ObDMICDList.Where(o => o.Loai == LoaiICD_ICD || o.Loai == -1).Select(o => new ClsGoTat { Ma = o.Ma, Ten = o.Ten }).ToList());
            uChanDoan.Dock = DockStyle.Fill;
            pnlChanDoan.Controls.Add(uChanDoan);
            uChanDoan.SelectChange += (object sender) =>
            {
                if (sender == null || sender.GetType() != typeof(ClsGoTat))
                {
                    return;
                }

                if (teChanDoan.Text.Trim() != "")
                {
                    teChanDoan.Text += ", ";
                }
                teChanDoan.Text += ((ClsGoTat)sender).Ten;
                teChanDoan.Focus();

                uChiDinh.ChanDoan = teChanDoan.Text;
            };

            uLoiDan = new UGoTat(MainNTP.ObDMICDList.Where(o => o.Loai == LoaiICD_LoiDan).Select(o => new ClsGoTat { Ma = o.Ma, Ten = o.Ten }).ToList());
            uLoiDan.Dock = DockStyle.Fill;
            uLoiDan.loai = LoaiICD_LoiDan;
            pnlLoiDan.Controls.Add(uLoiDan);
            uLoiDan.SelectChange += (object sender) =>
            {
                if (sender == null || sender.GetType() != typeof(ClsGoTat))
                {
                    return;
                }

                if (teLoiDan.Text.Trim() != "")
                {
                    teLoiDan.Text += ", ";
                }
                teLoiDan.Text += ((ClsGoTat)sender).Ten;
                teLoiDan.Focus();
            };

            uNDHTK = new UGoTat(MainNTP.ObDMICDList.Where(o => o.Loai == LoaiICD_HTK).Select(o => new ClsGoTat { Ma = o.Ma, Ten = o.Ten }).ToList());
            uNDHTK.Dock = DockStyle.Fill;
            uNDHTK.loai = LoaiICD_HTK;
            pnlHenTaiKham.Controls.Add(uNDHTK);
            uNDHTK.SelectChange += (object sender) =>
            {
                if (sender == null || sender.GetType() != typeof(ClsGoTat))
                {
                    return;
                }

                if (teNDHenKham.Text.Trim() != "")
                {
                    teNDHenKham.Text += ", ";
                }
                teNDHenKham.Text += ((ClsGoTat)sender).Ten;
                teNDHenKham.Focus();
            };
            
        }

        private void LoadEvent()
        {
            uChiDinh.viewDichVu.RowStyle += viewDichVu_RowStyle;
            uToaThuoc.viewDichVu.RowStyle += viewDichVu_RowStyle;
            uChiDinh.viewDichVu.DataSourceChanged += viewDichVu_DataSourceChanged;
            uToaThuoc.viewDichVu.DataSourceChanged += viewDichVu_DataSourceChanged;
            MainNTP.ObChiDinhList.ChangeDB += ObChiDinhList_ChangeDB;
            MainNTP.ObCTChiDinhList.ChangeDB += ObCTChiDinhList_ChangeDB;
        }

        void ObCTChiDinhList_ChangeDB(ObRecord _obRecord)
        {
            if (_obRecord.OBUPDATE != null)
            {
                uChiDinh.RefreshDichVu(_obRecord.OBUPDATE as ObCTChiDinh);
            }
        }

        void ObChiDinhList_ChangeDB(ObRecord _obRecord)
        {
            if (_obRecord.OBUPDATE != null)
            {
                teChanDoan.Text = (_obRecord.OBUPDATE as ObChiDinh).ChanDoan;
            }
        }


        void viewDichVu_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            TinhTongTien();
        }

        void viewDichVu_DataSourceChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        public void Clear()
        {
            Modify_SH = false;
            Modify = false;
            obCur = null;
            obSinhHieu = null;
            obChiDinh = null;
            obThuoc = null;
            obCTChiDinh = null;
            obHK = null;
            Modify = false;
            HenKham = new ObHenKham();
            BenhAn = new ObBenhAn();
            uChiDinh.SetDichVu(new List<ObCTChiDinh>());
            uToaThuoc.SetDichVu(new KeysListObCTChiDinh());

            deNgay.DateTime = MainNTP._Ngay;
            lkBacSi.EditValue = MainNTP.User.TTChung.MaNS;
            cboSoNgay.SelectedIndex = 0;
        }

        void TinhNgayDuSanh(string maBN)
        {
            int soTuan = 0;
            int soNgay = 0;
            MainNTP.TinhNgayDuSanh(maBN, ref soTuan, ref soNgay);

            if (soTuan == 0 && soNgay == 0)
            {
                teNgayDuSanh.Text = "";
            }
            else
            {
                if (Modify)
                {
                    //if (teNgayDuSanh.Text.Trim() == "")
                    //{
                    //    teNgayDuSanh.Text = MainNTP.TinhNgaySADauTien(maBN);                        
                    //}

                    //if (teChanDoan.Text.Trim() != "")
                    //{
                    //    teChanDoan.Text += ", ";
                    //}

                    //teChanDoan.Text += "Thai " + soTuan + " tuần " + soNgay + " ngày";

                    //if (teSoTuoiThai.Value <= 0)
                    //{
                    //    decimal soN = (decimal)soNgay / 10;
                    //    teSoTuoiThai.Value = soTuan + soN;
                    //}
                }
                else
                {

                    teNgayDuSanh.Text = MainNTP.TinhNgaySADauTien(maBN); 

                    if (teChanDoan.Text.Trim() != "")
                    {
                        teChanDoan.Text += ", ";
                    }

                    teChanDoan.Text += "Thai " + soTuan + " tuần " + soNgay + " ngày";

                    decimal soN = (decimal)soNgay / 10;
                    //Todo Tuoi thai lon hon 100
                    var tuoiThai = soTuan + soN > 100 ? 100 : soTuan + soN;
                    teSoTuoiThai.Value = tuoiThai;
                }
            }
        }

        void TinhTuoiThai()
        {
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

            deNgayDuSanh.DateTime = ngayKinhCuoi.AddDays(280);
            //deNgayKinhCuoi.DateTime = ngayKinhCuoi;
        }

        public void SetNew(ObCTChiDinh dv) {

            try
            {

                showMessageHTK = false;
                teMaBN.Text = dv.MaBN;

                #region Sinh hieu
                obSinhHieu = MainNTP.ObSinhHieuList.GetOb(dv.MaBN, dv.Ngay);
                if (obSinhHieu == null)
                {
                    obSinhHieu = new ObSinhHieu();
                    obSinhHieu.Action = ActionRec.Insert;
                }
                else obSinhHieu.Action = ActionRec.Update;
                SinhHieu = obSinhHieu;
                #endregion
                #region Nhật ký khám
                _uNhatKy.SetLichSuKham(teMaBN.Text);
                //KeysListObBenhAn keysNhatKy = NTPObBenhAn.GetListOb(dv.MaBN);
                //if (keysNhatKy != null)
                //{
                //    gridNhatKy.DataSource = keysNhatKy.ToList().FindAll(o => o.TrangThai != etrangthai.Đã_hủy.ToString());
                //    viewNhatKy.RefreshData();
                //}
                //else
                //{
                //    gridNhatKy.DataSource = null;
                //    viewNhatKy.RefreshData();
                //}
                #endregion
                #region obCTChiDinh
                obCTChiDinh = dv;
                #endregion
                #region obChiDinh - CTChiDinh
                obChiDinh = MainNTP.ObChiDinhList.GetOb(dv.KeyCreate);
                keyListObCTChiDinh = MainNTP.ObCTChiDinhList.GetListOb(dv.KeyCreate, (int)eLoaiHH.Dịch_vụ);
                if (keyListObCTChiDinh != null)
                {
                    //if (teChanDoan.Text.Trim() == "")
                    //{
                    //    foreach (var item in keyListObCTChiDinh)
                    //    {
                    //        if (item.KeyThucHien > 0 && item.LoaiPhieuTH == (int)eLoaiPhieuTH.Sieu_Am)
                    //        {
                    //            ObCDHA cdha = MainNTP.ObCDHAList.GetOb(item.KeyThucHien);
                    //            if (cdha != null)
                    //            {
                    //                if (teChanDoan.Text.Trim() != "")
                    //                    teChanDoan.Text += "\n";
                    //                teChanDoan.Text += cdha.ChanDoan;
                    //            }
                    //        }
                    //    }
                    //}
                    uChiDinh.SetDichVu(keyListObCTChiDinh.ToList());
                }
                #endregion
                ObDMDichVu dm = MainNTP.ObDMDichVuList.Get(dv.MaDV);
                if (dm != null)
                {
                    uBenhAn.lkMAU.EditValue = dm.TTChung.Mau;
                }

                //KeysListObHenKham listHK = NTPObHenKham.GetListObByMaBN(teMaBN.Text);
                //if (listHK != null && listHK.Count > 0)
                //{
                //    DateTime maxNgay = listHK.Max(o=>o.Ngay);
                //    ObHenKham hk = listHK.FirstOrDefault(o => o.Ngay == maxNgay);
                //    if (hk != null)
                //    {
                //        teNDHenKham.Text = hk.TTChung.NoiDung;
                //    }
                //}
                SetEnable(false);
                TinhNgayDuSanh(teMaBN.Text);
                cheHenTK.Checked = true;
                //teSoNgay.Value = 4;
                showMessageHTK = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xãy ra lỗi, Vui lòng thử lại" + ex.ToString());
                this.Close();
            }
        }

        public void SetModify(ObBenhAn ob)
        {
            try
            {
                showMessageHTK = false;
                Modify = true;
                BenhAn = ob;
                obCur = new ObBenhAn(ob);
                #region Sinh hieu
                obSinhHieu = MainNTP.ObSinhHieuList.GetOb(ob.MaBN, ob.Ngay);
                if (obSinhHieu == null)
                {
                    obSinhHieu = new ObSinhHieu();
                    obSinhHieu.Action = ActionRec.Insert;
                }
                else obSinhHieu.Action = ActionRec.Update;
                SinhHieu = obSinhHieu;
                #endregion
                #region Nhật ký khám
                _uNhatKy.SetLichSuKham(teMaBN.Text);
                //KeysListObBenhAn keysNhatKy = NTPObBenhAn.GetListOb(ob.MaBN);
                //if (keysNhatKy != null)
                //{
                //    gridNhatKy.DataSource = keysNhatKy.ToList().FindAll(o => o.TrangThai != etrangthai.Đã_hủy.ToString());
                //    viewNhatKy.RefreshData();
                //}
                #endregion
                #region obCTChiDinh

                obCTChiDinh = MainNTP.ObCTChiDinhList.GetOb(ob.KeyCTChiDinh);
                #endregion
                #region obChiDinh - CTChiDinh
                loadChiDinh();
                #endregion
                #region obThuoc - CTChiDinh
                KeysListObPhieuThuoc keysPT = NTPObPhieuThuoc.GetListOb_MaBA(ob.Ma, (int)eLoaiPhieuTH.Kham_Benh);
                if (keysPT != null && keysPT.Count > 0)
                {
                    obThuoc = keysPT[0];
                    keyListObCTThuoc = MainNTP.ObCTChiDinhList.GetListOb(obThuoc.Ma, (int)eLoaiHH.Thuốc);
                    uToaThuoc.SetDichVu(keyListObCTThuoc);
                }
                #endregion

                #region HenKham
                ObHenKham hk = NTPObHenKham.GetObWF_MaBA(ob.Ma);
                if (hk != null)
                    HenKham = hk;
                #endregion
                TinhNgayDuSanh(teMaBN.Text);
                showMessageHTK = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã xãy ra lỗi, Vui lòng thử lại " + ex.ToString());
                this.Close();
            }
        }

        void loadChiDinh()
        {
            obChiDinh = MainNTP.ObChiDinhList.GetOb(obCTChiDinh.KeyCreate);
            if (obChiDinh != null)
            {
                teChanDoan.Text = obChiDinh.ChanDoan;
                keyListObCTChiDinh = MainNTP.ObCTChiDinhList.GetListOb(obCTChiDinh.KeyCreate, (int)eLoaiHH.Dịch_vụ);
                if (keyListObCTChiDinh != null)
                {
                    /*
                    foreach (var item in keyListObCTChiDinh)
                    {
                        if (item.KeyThucHien > 0 && item.LoaiPhieuTH == (int)eLoaiPhieuTH.Sieu_Am)
                        {
                            ObCDHA cdha = MainNTP.ObCDHAList.GetOb(item.KeyThucHien);
                            if (cdha != null)
                            {
                                if (teChanDoan.Text.Trim() != "")
                                    teChanDoan.Text += "\r\n";
                                teChanDoan.Text += cdha.ChanDoan;
                            }
                        }
                    }
                    */
                    uChiDinh.SetDichVu(keyListObCTChiDinh.ToList());
                }
            }
        }
        void SetEnable(bool tr)
        {
            btInChiDinh.Enabled = tr;
            btInToaThuoc.Enabled = tr;
            btHuy.Enabled = tr;
        }
        public void TinhBMI()
        {
            double Chieucao = MainNTP.ParseDouble(teCC.Text);
            double Cannang = MainNTP.ParseDouble(teCN.Text);
            if (Chieucao == 0 || Cannang == 0) { teBMI.Text = ""; return; }
            double d = (double)Cannang / (((double)Chieucao / 100) * ((double)Chieucao / 100));
            teBMI.Text = d.ToString("n0");
        }

        bool KiemTraHopLe() {
            if (NTPValidate.IsEmpty(teMaBN.Text)) {
                MessageBox.Show("Vui lòng chọn bệnh nhân");
                return false;
            }

            if (lkBacSi.EditValue == null || lkBacSi.EditValue.ToString() == "") {
                MessageBox.Show("Vui lòng chọn bác sĩ");
                return false;
            }

            if (cheHenTK.Checked && (deNgayDen.DateTime.Date == MainNTP.MinValue.Date || teSoNgay.Value <= 0)) {
                MessageBox.Show("Vui lòng chọn ngày hẹn tái khám");
                return false;
            }

            return true;
        }

        bool SaveSinhHieu() {
            if (!Modify_SH) return true;
            if (obSinhHieu.Action == ActionRec.Insert)
            {
                obSinhHieu = SinhHieu;
                obSinhHieu.Ma = MainNTP.ObSinhHieuList.GetID();
                MainNTP.ObSinhHieuList.AddOb(obSinhHieu);
            }
            else {
                obSinhHieu = SinhHieu;
                MainNTP.ObSinhHieuList.UpdateOb(obSinhHieu);
            }
            return true;
        }

        bool UpdateChiDinh(double maBA) {
            //update chi dinh
            ObChiDinh cd = MainNTP.ObChiDinhList.GetOb(obChiDinh.Ma);
            if (cd != null)
            {
                cd.MaBA = maBA;
                cd.TrangThai = etrangthai.Đang_điều_trị.ToString();
                cd.ChanDoan = teChanDoan.Text;
                MainNTP.ObChiDinhList.UpdateOb(cd);
            }
            return true;
        }

        bool UpdateCTChiDinh(double maBA) {

            // update thuc hien
            uChiDinh.Save(deNgay.DateTime.Date, obChiDinh.Ma, teMaBN.Text);
            ObCTChiDinh ct = MainNTP.ObCTChiDinhList.GetOb(obCTChiDinh.Ma);
            if (ct != null)
            {
                ct.TrangThai = etrangthai.Hoàn_thành.ToString();
                ct.KeyThucHien = maBA;
                ct.LoaiPhieuTH = (int)eLoaiPhieuTH.Kham_Benh;
                ct.TTChung.BacSi = MainNTP.GetStringFromObject(lkBacSi.EditValue);
                MainNTP.ObCTChiDinhList.UpdateOb(ct);
            }
            return true;
        }

        string GeTrangThaiThuoc()
        {
            if (uToaThuoc.listDichVu != null && uToaThuoc.listDichVu.Count > 0)
            {
                return etrangthai.Đang_chờ.ToString();
            }

            return etrangthai.Đã_hủy.ToString();
        }
        void UpdateThuoc(double maBA) {

            if (uToaThuoc.listDichVu.Count == 0) {

                if (obThuoc != null)
                {
                    obThuoc.TrangThai = etrangthai.Đã_hủy.ToString();
                    MainNTP.obPhieuThuocList.UpdateOb(obThuoc);
                }

                return;
            }

            if (obThuoc == null)
            {
                obThuoc = new ObPhieuThuoc();
                obThuoc.ChanDoan = teChanDoan.Text;
                obThuoc.MaBA = maBA;
                obThuoc.MaBN = teMaBN.Text;
                obThuoc.Ngay = deNgay.DateTime;
                obThuoc.Ma = MainNTP.obPhieuThuocList.GetID();
                obThuoc.Loai = (int)eLoaiPhieuTH.Kham_Benh;
                obThuoc.TrangThai = GeTrangThaiThuoc();
                MainNTP.obPhieuThuocList.AddOb(obThuoc);
            }
            else 
            {
                obThuoc.ChanDoan = teChanDoan.Text;
                obThuoc.MaBA = maBA;
                obThuoc.MaBN = teMaBN.Text;
                obThuoc.Ngay = deNgay.DateTime;
                obThuoc.Loai = (int)eLoaiPhieuTH.Kham_Benh;
                obThuoc.TrangThai = GeTrangThaiThuoc();
                MainNTP.obPhieuThuocList.UpdateOb(obThuoc);
            }

            return;
        }
        void UpdateCTThuoc(double maBA)
        {
            if (obThuoc == null) return;

            // update thuc hien
            uToaThuoc.Save(deNgay.DateTime.Date, obThuoc.Ma, teMaBN.Text, lkBacSi.EditValue.ToString());
        }
        bool SaveBenhAn(ObBenhAn ob)
        {
            
            if (!Modify)
            {
                ob.Action = ActionRec.Update;
                if (!MainNTP.ObBenhAnList.AddOb(ob))
                    return false;
                Modify = true;
                teSoPhieu.Text = ob.Ma.ToString();
            }
            else
            {
                if (!MainNTP.ObBenhAnList.UpdateOb(ob))
                    return false;
            }
            obCur = ob;
            return true;
        }
        bool SaveHenKham(double maBA) {
            ObHenKham ob = HenKham;
            if (cheHenTK.Checked)
            {
                if (ob.Ma > 0)
                {
                    MainNTP.ObHenKhamList.UpdateOb(ob);
                }
                else
                {
                    ob.MaBA = maBA;
                    ob.Ma = MainNTP.ObHenKhamList.GetID();
                    ob.TrangThai = etrangthai.Chưa_đến.ToString();
                    MainNTP.ObHenKhamList.AddOb(ob);
                    obHK = ob;
                }
            }
            else {
                if (ob.Ma > 0) {
                    ob.TrangThai = etrangthai.Đã_hủy.ToString();
                    MainNTP.ObHenKhamList.UpdateOb(ob);
                }
            }
            return true;
        }

        void UpdateBenhNhan()
        {
            ObCustomer bn = MainNTP.ObCustomerList.GetOb(teMaBN.Text);
            if (bn != null) {
                bn.TTBenhnhan.TongTamUng = MainNTP.ParseDouble(teTongTamUng.Text);
                bn.TTBenhnhan.KhachHangNo = MainNTP.ParseDouble(teTongNo.Text);
                MainNTP.ObCustomerList.UpdateOb(bn);

            }
        }
        bool Save() {
            
            try
            {
                if (!KiemTraHopLe())
                    return false;
                SaveSinhHieu();
                ObBenhAn ob = BenhAn;
                if (!Modify)
                {
                    ob.Ma = MainNTP.ObBenhAnList.GetID();
                }

                UpdateChiDinh(ob.Ma);
                UpdateCTChiDinh(ob.Ma);
                UpdateThuoc(ob.Ma);
                UpdateCTThuoc(ob.Ma);
                SaveHenKham(ob.Ma);
                SaveBenhAn(ob);
                UpdateBenhNhan();
                SetEnable(true);
                loadChiDinh();
                GetTKBenhNhan(false, false, true);

                MessageBox.Show("Bệnh án của bệnh nhân " + teHoTen.Text.ToUpper() + " đã được lưu");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã xãy ra sự cố về vấn đề kết nối mạng.\nChúng tôi sẽ thoát khỏi ứng dụng. Vui lòng khởi động lại ứng dụng.\nXin cảm ơn!");
                Application.Exit();
                
            }
            return true;
        }

        bool Huy() {
            if (obCur == null) return false;
            if (obThuoc != null && obThuoc.TrangThai != etrangthai.Đã_hủy.ToString()) {
                MessageBox.Show("Đã kê toa thuốc. Không thế xóa bệnh án này!");
                return false;
            }

            if (MessageBox.Show("Vui lòng xác nhận bạn đã kiểm tra lại SỐ TIỀN NỢ của bệnh nhân.\r\n Bạn có chắc chắn muốn hủy phiếu này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return true;

            // Hủy bệnh án
            obCur.TrangThai = etrangthai.Đã_hủy.ToString();
            if (MainNTP.ObBenhAnList.UpdateOb(obCur, etrangthai.Đã_hủy))
            {
                // Huy phieu chỉ định
                ObChiDinh cd = MainNTP.ObChiDinhList.GetOb(obChiDinh.Ma);
                if (cd != null)
                {
                    cd.MaBA = 0;
                    cd.TrangThai = etrangthai.Đang_chờ.ToString();
                    obChiDinh.ChanDoan = "";
                    MainNTP.ObChiDinhList.UpdateOb(cd);
                }
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
                MessageBox.Show("Bệnh án của bệnh nhân " + teHoTen.Text.ToUpper() + " đã được hủy");
                this.Close();
                return true;
            }
            return false;
        }

        void InChiDinh() {
            if (obCur == null) return;
            BA020110 cls = new BA020110();
            cls.SetNew(obCur);
            RP020100 rp = new RP020100();
            rp.SetData(e_REPORTNTP.Phieu_chi_dinh.ToString(), new List<BA020110>() { cls });
            rp.ShowPreviewDialog();
        }

        void InToaThuoc() {
            if (obCur == null) return;
            BA020110 cls = new BA020110();
            cls.SetNew(obCur);
            RP020100 rp = new RP020100();
            rp.SetData(e_REPORTNTP.Phieu_thuoc.ToString(), new List<BA020110>() { cls });
            rp.ShowPreviewDialog();
        }

        void InGiayVaoVien()
        {
            if (obCur == null) return;
            BA020110 cls = new BA020110();
            cls.SetNew(obCur);
            RP020100 rp = new RP020100();
            rp.SetData(e_REPORTNTP.Giay_Vao_Vien.ToString(), new List<BA020110>() { cls });
            rp.ShowPreviewDialog();
        }

        void TinhNgayHenTK() {

            tinhNgayHTK = true;

            if (cboSoNgay.SelectedIndex == 0)
            {
                deNgayDen.DateTime = MainNTP._Ngay.AddDays((int)teSoNgay.Value);
            }
            else if (cboSoNgay.SelectedIndex == 1)
            {
                deNgayDen.DateTime = MainNTP._Ngay.AddDays((int)teSoNgay.Value * 7);
            }
            else
            {
                deNgayDen.DateTime = MainNTP._Ngay.AddMonths((int)teSoNgay.Value);
            }

            tinhNgayHTK = false;
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
            teDienThoai.Text = bn.Dienthoai;

            teTongTamUng.Text = bn.TTBenhnhan.TongTamUng.ToString("n0");
            teTongNo.Text = bn.TTBenhnhan.KhachHangNo.ToString("n0");
            
            GetTKBenhNhan(true,true,true);
        }

        private void btLuuBenhAn_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void teMach_EditValueChanged(object sender, EventArgs e)
        {
            if (!Modify_SH) Modify_SH = true;
        }

        private void teCC_EditValueChanged(object sender, EventArgs e)
        {
            if (!Modify_SH) Modify_SH = true;
            TinhBMI();
        }

        private void teCN_EditValueChanged(object sender, EventArgs e)
        {
            if (!Modify_SH) Modify_SH = true;
            TinhBMI();
        }

        private void btInChiDinh_Click(object sender, EventArgs e)
        {
            InChiDinh();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            Huy();
        }

        private void cheHenTK_CheckedChanged(object sender, EventArgs e)
        {
            if (cheHenTK.Checked && (lkBacSi.EditValue == null || lkBacSi.EditValue.ToString() == "")) {
                MessageBox.Show("Vui lòng chọn bác sĩ hẹn khám");
                lkBacSi.Focus();
                return;
            }
            deNgayDen.Properties.ReadOnly = teNDHenKham.Properties.ReadOnly = cboSoNgay.Properties.ReadOnly = !cheHenTK.Checked;
            teSoNgay.Enabled = cheHenTK.Checked;
            deGio.Properties.ReadOnly = !cheHenTK.Checked;
        }

        private void cboSoNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhNgayHenTK();
        }

        private void btInToaThuoc_Click(object sender, EventArgs e)
        {
            
        }

        private void btInGiayVV_Click(object sender, EventArgs e)
        {
            InGiayVaoVien();
        }

        private void deNgayDen_EditValueChanged(object sender, EventArgs e)
        {
            if (lkBacSi.EditValue == null) return;

            if (showMessageHTK)
            {
                ObLichLamViec ob = MainNTP.obLichLamViec.GetOb(lkBacSi.EditValue.ToString(), deNgayDen.DateTime.Date);
                if (ob != null && ob.TTChung.Nghi)
                {
                    if (MessageBox.Show("Ngày " + deNgayDen.DateTime.ToString("dd/MM/yyyy") + " là ngày nghỉ. Bạn có muốn hẹn ngày này không?", "Nhắc nhở", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        deNgayDen.DateTime = MainNTP._Ngay;
                        return;
                    }
                }
            }

            if (!tinhNgayHTK)
            {
                int soNgay = (deNgayDen.DateTime.Date - MainNTP._Ngay.Date).Days;
                if (soNgay < 0)
                {
                    return;
                }
                showMessageHTK = false;
                cboSoNgay.SelectedIndex = 0;
                showMessageHTK = true;
                teSoNgay.Value = soNgay;
            }
        }

        private void teSoNgay_ValueChanged(object sender, EventArgs e)
        {
            TinhNgayHenTK();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void viewDanhSach_DoubleClick(object sender, EventArgs e)
        {
            //BA010110 cls = (BA010110)uDSChoKham.viewDanhSach.GetFocusedRow();
            //if (cls == null) return;
            //Clear();
            //SetNew(cls);
        }

        private void viewTT_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void teTT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        void GetTKBenhNhan(bool loadTK, bool loadPT, bool loadCT)
        {
            /*
            KeysListObTKBenhNhan TK = null;
            KeysListObPhieuThu PT = null;
            KeysListObCTChiDinh DV = null;

            if (loadTK)
            {
                TK = NTPObTKBenhNhan.GetListOb(teMaBN.Text);
                tamUng = TK != null && TK.Count > 0 ? TK.ToList().FindAll(o => o.TrangThai != etrangthai.Đã_hủy.ToString() && o.TrangThai != etrangthai.Đã_hạch_toán.ToString()).Sum(o => o.ThanhTien) : 0;
            }
            if (loadPT)
            {
                //PT = NTPObPhieuThu.GetListOb(teMaBN.Text);
                //daThu = PT != null && PT.Count > 0 ? PT.ToList().FindAll(o => o.TrangThai != etrangthai.Đã_hủy.ToString()).Sum(o => o.TTChung.ThanhToan) : 0;
            }
            if (loadCT)
            {
                DV = NTPObCTChiDinh.GetListOb(teMaBN.Text);
                chuaThu = DV != null && DV.Count > 0 ? DV.ToList().FindAll(o => o.TrangThai != etrangthai.Đã_hủy.ToString() && o.KeyPT <= 0).Sum(o => o.ThanhTien) : 0;
            }

            conLai = tamUng - chuaThu;
            teTongTamUng.Text = tamUng.ToString("n0");
            teTongNo.Text = Math.Abs(conLai).ToString("n0");
            if (conLai < 0)
            {
                lbTongNo.Text = "KH Nợ";
            }
            else
            {
                lbTongNo.Text = "Nợ KH";
            }
             * */
            
        }

        void TinhTongTien()
        {
            teTT.Text = (uChiDinh.listDichVu.Sum(o => o.ThanhTien) + uToaThuoc.listDichVu.Sum(o => o.ThanhTien)).ToString("n0");
            //teTongNo.Text = conLai - MainNTP.ParseDouble(teTT.Text);
        }

        void LapPhieuTamUng()
        {
            FrmTamUng frm = new FrmTamUng();
            frm.SetTTBenhNhan(teMaBN.Text, Guid.Empty);
            frm.ShowDialog();
            GetTKBenhNhan(true, false, false);
        }

        private void btnLapPhieuTU_Click(object sender, EventArgs e)
        {
            
        }

        private void btLuuBenhAn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Huy();
        }

        private void btInChiDinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InChiDinh();
        }

        private void btInGiayVV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InGiayVaoVien();
        }

        private void btnLapPhieuTU_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LapPhieuTamUng();
        }

        private void btCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void teTongTamUng_Leave(object sender, EventArgs e)
        {
            teTongTamUng.Text = MainNTP.ParseDouble(teTongTamUng.Text).ToString("n0");
        }

        private void teTongNo_Leave(object sender, EventArgs e)
        {
            teTongNo.Text = MainNTP.ParseDouble(teTongNo.Text).ToString("n0");
        }
        
        private void teTT_EditValueChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                TinhTongKHNo();
            }
        }

        private void TinhTongKHNo()
        {
            teTongThu.Text = (noCu + MainNTP.ParseDouble(teTT.Text) - chiPhiCu).ToString("n0");
        }

        private void teTongNo_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void teSoTuoiThai_ValueChanged(object sender, EventArgs e)
        {
            TinhTuoiThai();
        }

        private void frmBenhAn_Shown(object sender, EventArgs e)
        {
            if (chiPhiCu <= 0 && Modify)
            {
                chiPhiCu = MainNTP.ParseDouble(teTT.Text);
            }

            if (noCu <= 0)
            {
                noCu = MainNTP.ParseDouble(teTongNo.Text);
            }

            TinhTongKHNo();

            flag = true;
        }

        bool flag = false;

        private void labelControl20_Click(object sender, EventArgs e)
        {

        }
    }
}