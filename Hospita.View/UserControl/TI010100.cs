using System;

namespace Hospital.App
{
    public partial class TI010100 : DevExpress.XtraEditors.XtraUserControl
    {
        public TI010100()
        {
            InitializeComponent();
        }

        private void TI010100_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        DateTime tg = MainNTP.MinValue;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tg == MainNTP.MinValue)
                tg = MainNTP.GetServerDate();
            else tg = tg.AddSeconds(1);
            lbTHOIGIAN.Text = tg.ToString("yyyy/MM/dd HH:mm:ss");
        }
    }
}
