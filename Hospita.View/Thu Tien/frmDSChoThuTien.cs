using System.Windows.Forms;

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