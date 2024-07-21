using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace Hospital.App
{
    public partial class UDangKy : DevExpress.XtraEditors.XtraUserControl
    {
        public UDangKy()
        {
            InitializeComponent();
            LoadData();
            InitDisplay();
            LoadControl();
        }
        //UTimBN uTimBN = null;
        UChoKham _uChoKham = null;
        UDaKham _uDaKham = null;
        UBenhNhan _uBenhNhan = null;
        UChoSA _uChoSA = null;
        USieuAm _uDaSA = null;
        UDSDangKy _uDSDangKy = null;

        UD010100 UChiDinh = new UD010100();
        DateTime NgayKham = MainNTP._Ngay;
        List<ClsDichVu> listDachon = new List<ClsDichVu>();
        List<ClsDichVu> listPK = new List<ClsDichVu>();
        bool Modify_SH = false;
        ObHenKham obHK = null;
        bool isBenhNhanNew = true;
        ObCustomer obBenhNhanCur = null;
        ObSinhHieu SinhHieu
        {
            get
            {
                ObSinhHieu ob = new ObSinhHieu();
                ob.MaBN = teMa.Text;
                ob.Ngay = NgayKham;
                ob.TTChung = new ClsTTSinhHieu();
                ob.TTChung.Mach = teMach.Text;
                ob.TTChung.NhietDo = teNhietDo.Text;
                ob.TTChung.HAMax = teHA_Max.Text;
                ob.TTChung.HAMin = teHA_Min.Text;
                ob.TTChung.NhipTho = teNhipTho.Text;
                ob.TTChung.ChieuCao = teCC.Text;
                ob.TTChung.CanNang = teCN.Text;
                ob.TTChung.BMI = teBMI.Text;
                ob.CreateBy = MainNTP.User.UserName;
                ob.CreateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
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

        ObCustomer BenhNhan
        {
            get
            {
                ObCustomer ob = obBenhNhanCur != null && obBenhNhanCur.Ma != "" ? new ObCustomer(obBenhNhanCur) : new ObCustomer();
                ob.Ngay = NgayKham;
                ob.Ma = teMa.Text;
                ob.Ten = teHoTen.Text;
                ob.Gioitinh = radGioiTinh.SelectedIndex;
                ob.Namsinh = MainNTP.ParseInt(teNam.Text);
                ob.Dienthoai = teDienThoai.Text;
                ob.Diachi = teDiaChi.Text;
                ob.TTBenhnhan.MaTinh = lkTinhThanh.EditValue == null ? "" : lkTinhThanh.EditValue.ToString();
                ob.TTBenhnhan.MaQuan = lkQuanHuyen.EditValue == null ? "" : lkQuanHuyen.EditValue.ToString();
                ob.TTBenhnhan.NgheNghiep = lkNgheNghiep.EditValue == null ? "" : lkNgheNghiep.EditValue.ToString();
                ob.TTBenhnhan.Para = tePara.Text;
                return ob;
            }
            set
            {
                teMa.Text = value.Ma;
                teHoTen.Text = value.Ten;
                radGioiTinh.SelectedIndex = value.Gioitinh;
                teNam.Text = value.Namsinh > 0 ? value.Namsinh.ToString() : "";
                teDienThoai.Text = value.Dienthoai;
                teDiaChi.Text = value.Diachi;
                lkTinhThanh.EditValue = value.TTBenhnhan.MaTinh;
                lkQuanHuyen.EditValue = value.TTBenhnhan.MaQuan;
                lkNgheNghiep.EditValue = value.TTBenhnhan.NgheNghiep;
                obBenhNhanCur = value;
                tePara.Text = value.TTBenhnhan.Para;
            }
        }

        ObChiDinh ChiDinh
        {
            get
            {
                ObChiDinh ob = new ObChiDinh();
                ob.MaBN = teMa.Text;
                ob.Ngay = NgayKham;
                ob.CreateBy = MainNTP.User.UserName;
                ob.CreateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
                ob.TrangThai = etrangthai.Đang_chờ.ToString();
                return ob;
            }
            set { }
        }

        ObCTChiDinh getCTChiDinh(ClsDichVu cls, double KeyCreate)
        {

            ObCTChiDinh ob = new ObCTChiDinh();
            ob.Ngay = NgayKham;
            ObDMDichVu dm = MainNTP.ObDMDichVuList.Get(cls.MaDV);
            if (dm == null) dm = MainNTP.ObDMDichVuList.GetOb(cls.MaDV);
            ob.MaDV = cls.MaDV;
            ob.LoaiHangHoa = dm.Loai;
            ob.SL = cls.SL;
            ob.DG = dm.TTChung.DG;
            ob.KeyCreate = KeyCreate;
            //ob.ThanhTien = cls.ThanhTien;
            ob.MaPK = cls.MaPK;
            ob.TrangThai = etrangthai.Đang_chờ.ToString();
            ob.MaBN = teMa.Text;
            ob.TTChung.MienPhi = cls.TTChung.MienPhi;
            return ob;
        }

        private void ShowBenhAn(ObCustomer benhNhan)
        {
            FrmPhieuKhamChung frm = new FrmPhieuKhamChung();
            frm.ShowDialog();
        }

        private void LoadControl()
        {
            UChiDinh.Dock = DockStyle.Fill;
            UChiDinh.teSearch.KeyDown += teSearch_KeyDown;
            pnlMiddle.Controls.Add(UChiDinh);

            _uBenhNhan = new UBenhNhan();
            _uBenhNhan.Dock = DockStyle.Fill;
            _uBenhNhan.viewDanhsach.Click += (object sender, EventArgs e) =>
                                                {
                                                    ObCustomer obBenhNhan = (ObCustomer)_uBenhNhan.viewDanhsach.GetFocusedRow();
                                                    if (obBenhNhan == null) return;
                                                    BenhNhan = obBenhNhan;
                                                    isBenhNhanNew = false;
                                                    //ShowBenhAn(obBenhNhan);
                                                };

            _uBenhNhan.viewSA.Click += (object sender, EventArgs e) =>
                                                {
                                                    SA020110 cls = (SA020110)_uBenhNhan.viewSA.GetFocusedRow();
                                                    if (cls == null)
                                                        return;

                                                    ObCustomer obBenhNhan = MainNTP.ObCustomerList.GetOb(cls.MaBN);
                                                    if (obBenhNhan == null) return;
                                                    //ShowBenhAn(obBenhNhan);
                                                    BenhNhan = obBenhNhan;
                                                    isBenhNhanNew = false;
                                                };

            pageDSBenhNhan.Controls.Add(_uBenhNhan);

            if (MainNTP.User.eQuyen != ePhanquyen.Tiếp_nhận)
            {
                pageChoKham.PageVisible = false;
                pageDaKham.PageVisible = false;
                pageChoSA.PageVisible = false;
                pageDaSA.PageVisible = false;
            }
            _uChoKham = new UChoKham();
            _uChoKham.Dock = DockStyle.Fill;
            pageChoKham.Controls.Add(_uChoKham);

            _uDaKham = new UDaKham();
            _uDaKham.Dock = DockStyle.Fill;
            pageDaKham.Controls.Add(_uDaKham);

            _uChoSA = new UChoSA();
            _uChoSA.Dock = DockStyle.Fill;
            pageChoSA.Controls.Add(_uChoSA);

            _uDaSA = new USieuAm();
            _uDaSA.Dock = DockStyle.Fill;
            pageDaSA.Controls.Add(_uDaSA);

            //_uDSDangKy = new UDSDangKy();
            //_uDSDangKy.Dock = DockStyle.Fill;
            //pageDSDangKy.Controls.Add(_uDSDangKy);




            //uTimBN = new UTimBN( MainNTP.ObCustomerList.ToList());
            //uTimBN.Dock = DockStyle.Fill;
            //uTimBN.SelectChange += uTimBN_SelectChange;
            //pnlTim.Controls.Add(uTimBN);
        }

        void teSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (UChiDinh.teSearch.Text.Trim() == "" && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab))
            {
                btDangKy.Focus();
            }
        }

        void uTimBN_SelectChange(object sender)
        {
            if (sender == null || sender.GetType() != typeof(ObCustomer))
            {
                return;
            }

            BenhNhan = (ObCustomer)sender;
            isBenhNhanNew = false;
            btDangKy.Focus();
        }

        private void LoadData()
        {
            List<eTableName> listTable = new List<eTableName>();
            listTable.Add(eTableName.DMPK);
            listTable.Add(eTableName.Customer);
            listTable.Add(eTableName.DMTinh);
            listTable.Add(eTableName.DMQuan);
            listTable.Add(eTableName.DMNgheNghiep);

            MainNTP.GetData(listTable);
        }

        private void InitDisplay()
        {
            deNgayDK.DateTime = MainNTP._Ngay;
            MainNTP.ObDMTinhList.Add(new ObDMTinh() { Ma = "", Ten = "" });
            MainNTP.ObDMQuanList.Add(new ObDMQuan() { Ma = "", Ten = "", MaTinh = "" });
            lkTinhThanh.Properties.DataSource = MainNTP.ObDMTinhList;
            lkQuanHuyen.Properties.DataSource = MainNTP.ObDMQuanList;
            lkNgheNghiep.Properties.DataSource = MainNTP.ObDMNgheNghiepList;

            foreach (var item in MainNTP.ObDMPKList)
            {
                var it = new DevExpress.XtraEditors.Controls.CheckedListBoxItem();
                it.Value = item.Ma;
                it.Description = item.Ten;
                clbPhongKham.Items.Add(it);
            }
            clbPhongKham.Refresh();
            Clear();
        }

        public void TinhBMI()
        {
            double Chieucao = MainNTP.ParseDouble(teCC.Text);
            double Cannang = MainNTP.ParseDouble(teCN.Text);
            if (Chieucao == 0 || Cannang == 0) { teBMI.Text = ""; return; }
            double d = (double)Cannang / (((double)Chieucao / 100) * ((double)Chieucao / 100));
            teBMI.Text = d.ToString("n0");
        }

        void Clear()
        {
            BenhNhan = new ObCustomer();
            SinhHieu = new ObSinhHieu();

            Modify_SH = false;
            for (int i = 0; i < clbPhongKham.Items.Count; i++)
            {
                clbPhongKham.SetItemChecked(i, false);
            }
            clbPhongKham.Refresh();
            UChiDinh.Clear();
            teHoTen.Focus();
            listDachon.Clear();
            listPK.Clear();
            obHK = null;
            radGioiTinh.SelectedIndex = 1;
            isBenhNhanNew = true;
            obBenhNhanCur = null;
            teMa.Text = MainNTP.ObCustomerList.GetID();
            tabDSBenhAn.SelectedTabPage = pageChoKham;
        }

        void MappingData()
        {
            listPK.Clear();
            listDachon.Clear();
            ObDMPK pk;
            ClsDichVu c2;
            for (int i = 0; i < clbPhongKham.Items.Count; i++)
            {
                if (clbPhongKham.GetItemChecked(i))
                {
                    pk = MainNTP.ObDMPKList.Get(clbPhongKham.Items[i].Value.ToString());
                    c2 = new ClsDichVu();
                    c2.MaDV = pk.TTChung.MaDV;
                    c2.TTChung.MienPhi = pk.TTChung.MienPhi;
                    c2.SL = 1;
                    c2.MaPK = pk.Ma;
                    listPK.Add(c2);
                }
            }
            listDachon.AddRange(UChiDinh.listDichVu);
        }

        public void SetHenKham(ObHenKham ob)
        {
            Clear();
            obHK = ob;
            ObCustomer bn = MainNTP.ObCustomerList.Get(ob.MaBN);
            BenhNhan = bn;
            isBenhNhanNew = false;
        }

        bool KiemTra()
        {
            if (NTPValidate.IsEmpty(teHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên");
                return false;
            }

            if (NTPValidate.IsEmpty(teNam.Text))
            {
                MessageBox.Show("Vui lòng nhập năm sinh");
                return false;
            }

            if (listDachon.Count <= 0 && listPK.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để đăng ký");
                return false;
            }

            //foreach (ClsDichVu c2 in listPK)
            //{
            //    if (teMa.Text.Trim() != "" && NTPObCTChiDinh.GetObWF_PK(MainNTP._Ngay.Date, c2.MaPK, teMa.Text) != null)
            //    {
            //        ObDMPK pk = MainNTP.ObDMPKList.Get(c2.MaPK);
            //        if (pk == null) continue;
            //        MessageBox.Show("Bệnh nhân " + teHoTen.Text.ToUpper() + " đã đăng ký phòng khám " + pk.Ten + ". Không thể tiếp tục.");
            //        return false;
            //    }
            //}

            /*
            if (Modify_SH)
            {
                if (NTPValidate.IsEmpty(teMach.Text)) { MessageBox.Show("Vui lòng nhập Mạch"); return false; }
                if (NTPValidate.IsEmpty(teNhietDo.Text)) { MessageBox.Show("Vui lòng nhập Nhiệt độ"); return false; }
                if (NTPValidate.IsEmpty(teHA_Max.Text)) { MessageBox.Show("Vui lòng nhập Huyết áp"); return false; }
                if (NTPValidate.IsEmpty(teHA_Min.Text)) { MessageBox.Show("Vui lòng nhập Huyết áp"); return false; }
                if (NTPValidate.IsEmpty(teNhipTho.Text)) { MessageBox.Show("Vui lòng nhập Nhịp thở"); return false; }
                if (NTPValidate.IsEmpty(teCC.Text)) { MessageBox.Show("Vui lòng nhập Chiều cao"); return false; }
                if (NTPValidate.IsEmpty(teCN.Text)) { MessageBox.Show("Vui lòng nhập Cân nặng"); return false; }
            }

            */

            return true;
        }

        ObCustomer SaveBenhNhan()
        {
            ObCustomer ob = BenhNhan;
            if (isBenhNhanNew)
            {
                if (NTPObCustomer.TestExistPK(ob.Ma))
                {
                    ob.Ma = MainNTP.ObCustomerList.GetID();
                    if (NTPObCustomer.TestExistPK(ob.Ma))
                    {
                        MessageBox.Show("Mã BN bị trùng");
                        return null;
                    }
                }
                teMa.Text = ob.Ma;
                if (MainNTP.ObCustomerList.AddOb(ob))
                    return ob;

            }
            else if (MainNTP.ObCustomerList.UpdateOb(ob))
                return ob;
            return null;
        }

        bool SaveSinhHieu()
        {
            ObSinhHieu ob = SinhHieu;
            ObSinhHieu obNgay = MainNTP.ObSinhHieuList.GetOb(teMa.Text, MainNTP._Ngay.Date);
            if (obNgay != null)
            {
                ob.Ma = obNgay.Ma;
                MainNTP.ObSinhHieuList.UpdateOb(ob);
            }
            else
            {
                ob.Ma = MainNTP.ObSinhHieuList.GetID();
                return MainNTP.ObSinhHieuList.AddOb(ob);
            }

            return true;
        }

        ObChiDinh SaveChiDinh()
        {
            ObChiDinh ob = ChiDinh;
            ob.Ma = MainNTP.ObChiDinhList.GetID();
            if (MainNTP.ObChiDinhList.AddOb(ob))
                return ob;
            return null;
        }

        bool SaveDichVu(double keyCreate)
        {
            foreach (var item in listDachon)
            {
                ObCTChiDinh ob = getCTChiDinh(item, keyCreate);
                ob.Ma = MainNTP.ObCTChiDinhList.GetID();
                MainNTP.ObCTChiDinhList.AddOb(ob);
            }
            return true;
        }

        public bool Save()
        {
            MappingData();
            if (!KiemTra())
                return false;
            DBStatic.ConnectDB(DadaConnect.connect_string);
            try
            {
                ObCustomer bn = SaveBenhNhan();
                if (bn == null) return false;
                SaveSinhHieu();
                listDachon.AddRange(listPK);
                ObChiDinh obCD = SaveChiDinh();
                SaveDichVu(obCD.Ma);
                if (obHK != null)
                {
                    obHK.TrangThai = etrangthai.Đã_đến.ToString();
                    MainNTP.ObHenKhamList.UpdateOb(obHK);
                }
                MessageBox.Show("Bệnh nhân " + teHoTen.Text.ToUpper() + " đã được đăng ký!");
                Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không thể đăng ký bệnh nhân " + teHoTen.Text.ToUpper());
                return false;
            }
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void teMa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                BN010100 frm = new BN010100();
                frm.ShowDialog(this);
                if (frm.obCur != null)
                {
                    BenhNhan = frm.obCur;
                    isBenhNhanNew = false;
                }
            }
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

        private void btExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btDangKy_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void teMach_EditValueChanged(object sender, EventArgs e)
        {
            if (!Modify_SH) Modify_SH = true;
        }

        private void teNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void lkTinhThanh_EditValueChanged(object sender, EventArgs e)
        {
            lkQuanHuyen.EditValue = null;
            if (lkTinhThanh.EditValue != null)
            {
                lkQuanHuyen.Properties.DataSource = MainNTP.ObDMQuanList.ToList().FindAll(o => o.MaTinh == lkTinhThanh.EditValue.ToString());
            }
        }

        private void cheTimMa_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void teTimMa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void clbPhongKham_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void clbPhongKham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DevExpress.XtraEditors.Controls.CheckedListBoxItem item = (DevExpress.XtraEditors.Controls.CheckedListBoxItem)clbPhongKham.SelectedItem;
                if (item == null)
                {
                    return;
                }

                if (tabDSBenhAn.SelectedTabPage != pageChiDinh) {
                    tabDSBenhAn.SelectedTabPage = pageChiDinh;
                }

                if (item.CheckState == CheckState.Checked)
                {
                    UChiDinh.teSearch.Focus();
                    return;
                }

                for (int i = 0; i < clbPhongKham.Items.Count; i++)
                {
                    if (clbPhongKham.Items[i].Value == item.Value)
                    {
                        clbPhongKham.SetItemChecked(i, true);
                    }
                    else
                    {
                        clbPhongKham.SetItemChecked(i, false);
                    }
                }

                clbPhongKham.Refresh();
            }
        }

        private void clbPhongKham_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.Controls.CheckedListBoxItem item = (DevExpress.XtraEditors.Controls.CheckedListBoxItem)clbPhongKham.SelectedItem;
            if (item == null)
            {
                return;
            }

            for (int i = 0; i < clbPhongKham.Items.Count; i++)
            {
                if (clbPhongKham.Items[i].Value == item.Value)
                {
                    continue;
                }

                clbPhongKham.SetItemChecked(i, false);
            }

            clbPhongKham.Refresh();
        }

        private void frmDangKy_Shown(object sender, EventArgs e)
        {
            //teHoTen.Focus();
        }

        private void btDangKy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save();
            }
        }

        private void deNgayDK_EditValueChanged(object sender, EventArgs e)
        {
            NgayKham = deNgayDK.DateTime;
        }
    }
}