using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hospital.App
{
    public partial class UMainSA : DevExpress.XtraEditors.XtraUserControl
    {
        public UMainSA()
        {
            InitializeComponent();

            deTuNgay.DateTime = deDenNgay.DateTime = MainNTP._Ngay;

            _UChoSA = new UChoSA();
            _UChoSA.Dock = DockStyle.Fill;
            pageChoSA.Controls.Add(_UChoSA);

            _uDaSA = new USieuAm();
            _uDaSA.Dock = DockStyle.Fill;
            pagePhieuSA.Controls.Add(_uDaSA);

            btXem_Click(null, null);
        }

        UChoSA _UChoSA = null;
        USieuAm _uDaSA = null;

        private void btXem_Click(object sender, EventArgs e)
        {
            _UChoSA.LayDuLieu(deTuNgay.DateTime, deDenNgay.DateTime);
            _uDaSA.LayDuLieu(deTuNgay.DateTime, deDenNgay.DateTime);
        }
    }
}
