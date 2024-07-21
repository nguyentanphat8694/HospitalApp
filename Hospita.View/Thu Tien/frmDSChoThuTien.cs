using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace Hospital.App
{
    public partial class frmDSChoThuTien : DevExpress.XtraEditors.XtraForm
    {
        public frmDSChoThuTien()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;

            uDSChoThuTien = new UDSChoThuTien();
            uDSChoThuTien.Dock = DockStyle.Fill;
            this.Controls.Add(uDSChoThuTien);
        }

        public UDSChoThuTien uDSChoThuTien = null;
    }
}