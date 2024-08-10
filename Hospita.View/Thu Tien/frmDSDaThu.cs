using System.Windows.Forms;

namespace Hospital.App
{
    public partial class frmDSDaThu : DevExpress.XtraEditors.XtraForm
    {
        public frmDSDaThu()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;

            uDSDaThu = new UDSDaThu();
            uDSDaThu.Dock = DockStyle.Fill;
            this.Controls.Add(uDSDaThu);
        }

        public UDSDaThu uDSDaThu = null;
    }
}