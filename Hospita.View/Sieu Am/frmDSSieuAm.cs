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
    public partial class frmDSSieuAm : DevExpress.XtraEditors.XtraForm
    {
        public frmDSSieuAm()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            _uChoKham = new USieuAm();
            _uChoKham.Dock = DockStyle.Fill;
            this.Controls.Add(_uChoKham);
        }

        USieuAm _uChoKham = null;
    }
}