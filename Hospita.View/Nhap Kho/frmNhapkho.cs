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
    public partial class frmNhapkho : DevExpress.XtraEditors.XtraForm
    {
        public frmNhapkho()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            _uChoKham = new UNhapKho();
            _uChoKham.Dock = DockStyle.Fill;
            this.Controls.Add(_uChoKham);
        }

        UNhapKho _uChoKham = null;

        private void frmNhapkho_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MainNTP.ObDichVuTonList.GetListTonByThang(MainNTP._Ngay.Month);
            }
            catch
            {

            }
        }
    }
}