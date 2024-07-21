using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using DevExpress.XtraReports.UI;

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