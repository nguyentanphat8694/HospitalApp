using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hospital.App
{
    public partial class frmKey : DevExpress.XtraEditors.XtraForm
    {
        public frmKey()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            teIP.Text = MainNTP.IP_ADDRESS;
        }
        public DialogResult rs = DialogResult.Cancel;
        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string pass = "Ntp@123";
        public static string key = "_HOSPITAL_APP_TRANG";
        private void btLogin_Click(object sender, EventArgs e)
        {
            if (teKey.Text.Trim() == "") {
                MessageBox.Show("Vui lòng nhập key đăng ký sử dụng phần mềm");
                return;
            }

            if (teKey.Text.Trim() !=pass)
            {
                MessageBox.Show("Key không đúng. Vui lòng kiểm tra lại.");
                return;
            }
            if (!DBStatic.ConnectDB(DadaConnect.connect_string))
            {
                Application.Exit();
                return;
            }
            ObKey ob = new ObKey();
            ob.IP = key;// teIP.Text;
            ob.Ngay = MainNTP.GetServerDate();
            ob.TTChung.PassWord = pass;
            int kq = NTPObKey.Insert(ob);
            if (kq > 0)
            {
                MessageBox.Show("Đăng ký sử dụng thành công!");
                rs = DialogResult.OK;
                this.Close();
            }
            else {
                MessageBox.Show("Đăng ký thất bại");
            }
        }

        
    }
}