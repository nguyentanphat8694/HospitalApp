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
    public partial class frmDSChoXN : DevExpress.XtraEditors.XtraForm
    {
        public frmDSChoXN()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            _uChoKham = new UDSChoXN();
            _uChoKham.Dock = DockStyle.Fill;
            this.Controls.Add(_uChoKham);
        }

        UDSChoXN _uChoKham = null;
    }
}