using System.Windows.Forms;

namespace Hospital.App
{
    public partial class frmPhieuXetNghiem : DevExpress.XtraEditors.XtraForm
    {
        public frmPhieuXetNghiem()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            _uChoKham = new UPhieuXetNghiem();
            _uChoKham.Dock = DockStyle.Fill;
            this.Controls.Add(_uChoKham);
        }

        UPhieuXetNghiem _uChoKham = null;

        internal void SetNew(TT010110 cls)
        {
            _uChoKham.SetNew(cls);
        }

        internal void SetModify(ObPhieuXetNghiem pt)
        {
            _uChoKham.SetModify(pt);
        }
    }
}