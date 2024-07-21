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
    public partial class frmDSChoSA : DevExpress.XtraEditors.XtraForm
    {
        public frmDSChoSA()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            _uChoKham = new UChoSA();
            _uChoKham.Dock = DockStyle.Fill;
            this.Controls.Add(_uChoKham);
        }

        UChoSA _uChoKham = null;
    }
}