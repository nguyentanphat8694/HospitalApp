using System;
using System.Windows.Forms;
using System.Linq;
namespace Hospital.App
{
    public partial class LO010100 : DevExpress.XtraEditors.XtraForm
    {
        public LO010100()
        {
            InitializeComponent();


            MainNTP.NTPICON = new System.Drawing.Icon(Application.StartupPath + @"\icona.ico");
            this.Icon = MainNTP.NTPICON;
            DadaConnect.Khoitaoketnoi();
            if (!DBStatic.ConnectDB(DadaConnect.connect_string))
            {
                Application.Exit();
                return;
            }
            InitDisplay();
            MainNTP.ChangeDBItem.StartRecord();
            MainNTP._Time_Static = MainNTP.GetServerDate().ToString("yyyyMMddHHmmss");
            
            
            //Task t = Task.Run(() =>
            //{
            //    MainNTP.ObCustomerList = NTPObCustomer.GetListOb();
            //}).ContinueWith((i) =>
            //{
                MainNTP.ChangeDBItem.ChangeDB += ChangeDBItem_ChangeDB;
                //MainNTP.ObCustomerList.ChangeDB += ObCustomerList_ChangeDB;
            //});


            
        }

        object ChangeDBItem_ChangeDB(ObRecord _obRecord)
        {
            if (_obRecord == null || _obRecord.NameTBL != eTableName.Customer.ToString() || _obRecord.OBUPDATE == null) return null;
            ObCustomer obNew = (ObCustomer)_obRecord.OBUPDATE;

            if (_obRecord.Action == (int)ActionRec.Insert)
            {
                MainNTP.ObCustomerList.Add(obNew);
            }
            else
            {
                ObCustomer oo = MainNTP.ObCustomerList.FirstOrDefault(o => o.Ma == obNew.Ma);
                if (oo != null)
                {
                    oo.SetOb(obNew);
                    oo.DiaChiFull = MainNTP.GetDiaChi(oo.TTBenhnhan.MaTinh, oo.TTBenhnhan.MaQuan, oo.Diachi);
                }
            }

            return null;
        }

        void ObCustomerList_ChangeDB(ObRecord _obRecord)
        {
            if (_obRecord == null || _obRecord.NameTBL != eTableName.Customer.ToString() ||
                _obRecord.Action != (int)ActionRec.Update || _obRecord.OBUPDATE == null) return;
            ObCustomer obNew = (ObCustomer)_obRecord.OBUPDATE;
            ObCustomer oo = MainNTP.ObCustomerList.ToList().Find(o => o.Ma == obNew.Ma);
            if (oo != null)
            {
                oo.SetOb(obNew);
            }
        }

        void InitDisplay() {
            MainNTP.LoadDefault();
        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btDangnhap_Click(object sender, EventArgs e)
        {
            //if (DateTime.Now.Month > 10 && DateTime.Now.Year >= 2016)
            //{
            //    MessageBox.Show("Vui lòng liên hệ quản trị. Không thể đăng nhập hệ thống");
            //    return;
            //}
            if (tePassWord.Text == "" && teUserName.Text.Trim() == "pk123")
            {
                return;
            }
            MainNTP.User = MainNTP.ObUserList.GetOb(teUserName.Text.Trim());
            if (MainNTP.User == null) {
                lbTB.Text = "Tài khoản không tồn tại!";
                return; }
            if (MainNTP.User.PassWord != tePassWord.Text) {
                lbTB.Text = "Mật khẩu không đúng!";
                return; }
            this.teUserName.Text = "";
            this.tePassWord.Text = "";
            if (cheThayDoiMK.Checked) {
                LO030100 frm = new LO030100();
                frm.ShowDialog(this);
            }
            this.Hide();
            PhanQuyenUser(MainNTP.User.eQuyen);
        }
        void PhanQuyenUser(ePhanquyen quyen)
        {
            this.Hide();
            switch (quyen) {
                case ePhanquyen.Admin: {
                    frmMain frm = new frmMain();
                    frm.FormClosed += frm_FormClosed;
                    frm.ShowDialog();
                    break; }
                case ePhanquyen.Đăng_ký:
                    {
                        //DK000000 frm = new DK000000();
                        FrmMainDangKy frm = new FrmMainDangKy();
                        frm.FormClosed += frm_FormClosed;
                        frm.ShowDialog();
                        break;
                    }
                case ePhanquyen.Thu_tiền:
                    {
                        TT000000 frm = new TT000000();
                        frm.FormClosed += frm_FormClosed;
                        frm.ShowDialog();
                        break;
                    }
                case ePhanquyen.Tiếp_nhận:
                    {
                        FrmMainBenhAn frm = new FrmMainBenhAn();
                        frm.FormClosed += frm_FormClosed;
                        frm.ShowDialog();
                        break;
                    }
                case ePhanquyen.Siêu_Âm:
                    {
                        SA000000 frm = new SA000000();
                        frm.FormClosed += frm_FormClosed;
                        frm.ShowDialog();
                        break;
                    }
                case ePhanquyen.Xét_Nghiệm:
                    {
                        XN000000 frm = new XN000000();
                        frm.FormClosed += frm_FormClosed;
                        frm.ShowDialog();
                        break;
                    }
                case ePhanquyen.Design_report:
                    {
                        RP010100 frm = new RP010100();
                        frm.FormClosed += frm_FormClosed;
                        frm.ShowDialog();
                        break;
                    }
                default: { break; }
            }
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void LO010100_Shown(object sender, EventArgs e)
        {
            //DateTime hanSD = new DateTime(2017, 09, 01);


            //ObKey obKey = NTPObKey.GetObWF_PK(frmKey.key);
            //if (DateTime.Now.Date >= hanSD.Date && (obKey == null || obKey.TTChung == null || obKey.TTChung.PassWord != "@123"))
            //{
            //    this.Hide();
            //    frmKey frm = new frmKey();
            //    frm.ShowDialog(this);
            //    if (frm.rs != DialogResult.OK)
            //    {
            //        Application.Exit();
            //    }
            //    this.Show();
            //}

            MainNTP.ObDichVuTonList.GetListTonByThang(MainNTP._Ngay.Month);
        }
    }
}