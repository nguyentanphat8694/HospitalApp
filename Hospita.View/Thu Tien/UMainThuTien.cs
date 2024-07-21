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
    public partial class UMainThuTien : DevExpress.XtraEditors.XtraUserControl
    {
        public UMainThuTien()
        {
            InitializeComponent();

            uDSChoThuTien = new UDSChoThuTien();
            uDSChoThuTien.Dock = DockStyle.Fill;
            pageChoThu.Controls.Add(uDSChoThuTien);

            uDSDaThu = new UDSDaThu();
            uDSDaThu.Dock = DockStyle.Fill;
            pageDaThu.Controls.Add(uDSDaThu);
        }

        private UDSChoThuTien uDSChoThuTien = null;
        private UDSDaThu uDSDaThu = null;
    }
}