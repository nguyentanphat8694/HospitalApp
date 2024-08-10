using System.Windows.Forms;

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