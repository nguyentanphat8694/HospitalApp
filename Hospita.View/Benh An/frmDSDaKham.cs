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
    public partial class frmDSDaKham : DevExpress.XtraEditors.XtraForm
    {
        public frmDSDaKham()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            _uDaKham = new UDaKham();
            _uDaKham.Dock = DockStyle.Fill;
            this.Controls.Add(_uDaKham);
        }

        UDaKham _uDaKham = null;
    }
}