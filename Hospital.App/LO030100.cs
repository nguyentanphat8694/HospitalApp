using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Net;
namespace Hospital.App
{
    public partial class LO030100 : DevExpress.XtraEditors.XtraForm
    {
        public LO030100()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            DBStatic.ConnectDB(DadaConnect.connect_string);
            InitDisplay();
        }

        void InitDisplay() {
            if (MainNTP.ObUserList == null)
                MainNTP.ObUserList = NTPObUser.GetListOb();
            if (MainNTP.User == null)
                return;
            teUserName.Text = MainNTP.User.UserName;

        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btDongY_Click(object sender, EventArgs e)
        {
            if (tePassWord.Text != MainNTP.User.PassWord) {
                lbTB.Text = "Mậu khẩu cũ không đúng!";
                return;
            }

            if (tePass1.Text != tePass2.Text) {
                lbTB.Text = "Mậu khẩu mới không khớp!";
                return;
            }

            ObUser ob = MainNTP.ObUserList.GetOb(teUserName.Text);
            if (ob == null) return;
            ob.PassWord = tePass2.Text;
            MainNTP.ObUserList.UpdateOb(ob.UserName, ob);
            MainNTP.User.PassWord = tePass2.Text;
            lbTB.Text = null;
            MessageBox.Show("Bạn đã thay đổi mật khẩu thành công!");
            this.Close();
        }
    }
}