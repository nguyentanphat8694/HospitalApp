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
    public partial class frmLichLamViec : DevExpress.XtraEditors.XtraForm
    {
        public frmLichLamViec()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            _uChoKham = new ULichLamViec();
            _uChoKham.Dock = DockStyle.Fill;
            this.Controls.Add(_uChoKham);
        }

        ULichLamViec _uChoKham = null;
    }
}