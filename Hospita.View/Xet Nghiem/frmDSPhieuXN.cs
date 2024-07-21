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
    public partial class frmDSPhieuXN : DevExpress.XtraEditors.XtraForm
    {
        public frmDSPhieuXN()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            _uChoKham = new UDSPhieuXN();
            _uChoKham.Dock = DockStyle.Fill;
            this.Controls.Add(_uChoKham);
        }

        UDSPhieuXN _uChoKham = null;
    }
}