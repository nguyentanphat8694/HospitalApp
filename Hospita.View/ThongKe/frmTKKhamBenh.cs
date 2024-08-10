using System.Windows.Forms;

namespace Hospital.App
{
    public partial class frmTKKhamBenh : DevExpress.XtraEditors.XtraForm
    {
        public frmTKKhamBenh()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            _uChoKham = new UTKKhamBenh();
            _uChoKham.Dock = DockStyle.Fill;
            this.Controls.Add(_uChoKham);
        }

        UTKKhamBenh _uChoKham = null;
    }
}