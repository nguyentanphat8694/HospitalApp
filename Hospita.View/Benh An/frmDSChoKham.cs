using System.Windows.Forms;

namespace Hospital.App
{
    public partial class frmDSChoKham : DevExpress.XtraEditors.XtraForm
    {
        public frmDSChoKham()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            _uChoKham = new UChoKham();
            _uChoKham.Dock = DockStyle.Fill;
            this.Controls.Add(_uChoKham);
        }

        UChoKham _uChoKham = null;
    }
}