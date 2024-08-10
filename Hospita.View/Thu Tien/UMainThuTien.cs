using System.Windows.Forms;

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