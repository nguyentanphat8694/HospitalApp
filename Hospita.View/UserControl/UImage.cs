using System.Drawing;

namespace Hospital.App
{
    public partial class UImage : DevExpress.XtraEditors.XtraUserControl
    {
        public ObImage obImg = null;
        public UImage(int stt, Image img,int w=100,int h=100)
        {
            InitializeComponent();
            lbSTT.Text = stt.ToString();
            picImage.Image = img;
            this.Width = w;
            this.Height = h;
        }

    }
}
