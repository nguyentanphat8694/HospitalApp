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
    public partial class FrmCapNhatNo : DevExpress.XtraEditors.XtraForm
    {
        public FrmCapNhatNo()
        {
            InitializeComponent();

            this.Icon = MainNTP.NTPICON;
        }

        ObCustomer obCur;

        public void SetData(ObCustomer ob)
        {
            obCur = ob;
            this.Text = ob.Ten;

            teTongNo.Text = ob.TTBenhnhan.KhachHangNo.ToString("n0");
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (obCur == null) {
                return;
            }

            obCur.TTBenhnhan.KhachHangNo = MainNTP.ParseDouble(teTongNo.Text);
            MainNTP.ObCustomerList.UpdateOb(obCur);

            this.Close();
        }

        private void teTongNo_Leave(object sender, EventArgs e)
        {
            teTongNo.Text = MainNTP.ParseDouble(teTongNo.Text).ToString("n0");
        }
    }
}