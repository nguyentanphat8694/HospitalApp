using System.Windows.Forms;

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