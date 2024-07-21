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
