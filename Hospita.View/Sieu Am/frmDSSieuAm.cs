using System.Windows.Forms;

namespace Hospital.App
{
    public partial class frmDSSieuAm : DevExpress.XtraEditors.XtraForm
    {
        public frmDSSieuAm()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            _uChoKham = new USieuAm();
            _uChoKham.Dock = DockStyle.Fill;
            this.Controls.Add(_uChoKham);
        }

        USieuAm _uChoKham = null;
    }
}