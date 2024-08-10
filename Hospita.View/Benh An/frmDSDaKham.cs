using System.Windows.Forms;

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