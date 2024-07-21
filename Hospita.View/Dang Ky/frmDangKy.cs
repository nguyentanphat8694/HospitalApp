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
    public partial class frmDangKy : DevExpress.XtraEditors.XtraForm
    {
        public frmDangKy()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            _uChoKham = new UDangKy();
            _uChoKham.Dock = DockStyle.Fill;
            this.Controls.Add(_uChoKham);
        }

        UDangKy _uChoKham = null;
    }
}