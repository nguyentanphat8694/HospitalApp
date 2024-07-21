using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;

namespace Hospital.App
{
    public partial class UImages : DevExpress.XtraEditors.XtraUserControl
    {
        public UImages()
        {
            InitializeComponent();
        }

        public bool isChange = false;

        public List<UImage> listImg = new List<UImage>();
        public void AddImg(Image img,bool isIn = false, int w = 100, int h = 100)
        {
            UImage ui = new UImage(listImg.Count + 1, img, w, h);
            ui.cheIn.Checked = isIn;
            listImg.Add(ui);
        }

        public List<ObImage> Images
        {
            get
            {
                List<ObImage> list = new List<ObImage>();
                foreach (var control in pnlMain.Controls)
                {
                    var item = (UImage)control;
                    ObImage ob = new ObImage();
                    ob.STT = MainNTP.ParseInt(item.lbSTT.Text);
                    ob.In = item.cheIn.Checked;
                    if (NTPValidate.IsEmpty(ob.Path))
                        ob.Path = MainNTP.SaveImage(NTPUserSetting.DDLuuAnhSA, item.picImage.Image, eLoaiPhieuTH.Sieu_Am.ToString(), MainNTP._Ngay.Date);
                    list.Add(ob);
                }
                return list;
            }
            set
            {
                if (value == null) return;
                listImg.Clear();
                foreach (var item in value)
                {

                    if (item.Img != null)
                        AddImg(item.Img,item.In);
                }
                Display();
            }
        }

        void Display()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new NTPRefreshData(Display), new object[] { });
            }
            else
            {
                int x = 5, y = 5;
                int w = pnlMain.Width;
                int soCot = MainNTP.ParseInt(cbSo.Text);
                int w_img = (w - (x + x + 15) - ((soCot - 1) * x)) / soCot;
                List<Control> cl = new List<Control>();
                int stt = 1;
                foreach (var c2 in listImg)
                {
                    var item = new UImage(stt++, c2.picImage.Image, w_img, w_img);
                    item.cheIn.Checked = c2.cheIn.Checked;
                    item.btDelete.Click += btDelete_Click;
                    item.picImage.DoubleClick += picImage_DoubleClick;
                    item.cheIn.Click += cheIn_Click;
                    item.Location = new Point(x, y);
                    cl.Add(item);
                    x += item.Width + 5;
                    if (x + item.Width >= pnlMain.Size.Width) { x = 5; y += item.Height + 5; }
                }
                pnlMain.Controls.Clear();
                pnlMain.Controls.AddRange(cl.ToArray());
                listImg.Clear();
                foreach (var item in cl)
                {
                    listImg.Add((UImage)item);
                }
            }
        }

        void cheIn_Click(object sender, EventArgs e)
        {
            isChange = true;
        }

        void picImage_DoubleClick(object sender, EventArgs e)
        {
            //PictureEdit ui = (PictureEdit)sender;
            Control ctr = (Control)sender;
            UImage img = ctr.Parent as UImage;
            UImage ui = new UImage(MainNTP.ParseInt(img.lbSTT.Text), img.picImage.Image);
            ui.Dock = DockStyle.Fill;
            XtraForm frm = new XtraForm();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Width = 600;
            frm.Height = 600;
            frm.Controls.Add(ui);
            frm.ShowDialog();
        }

        void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ảnh này không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            Control ctr = (Control)sender;
            UImage img = ctr.Parent as UImage;
            var img2 = listImg.Find(o => o.lbSTT.Text == img.lbSTT.Text);
            if (img2 != null)
                listImg.Remove(img2);
            Display();

            isChange = true;
        }

        private void btPaste_Click(object sender, EventArgs e)
        {
            try
            {
                Image img = Clipboard.GetImage();
                if (img == null)
                    return;
                AddImg(img);
            }
            catch
            {
                MessageBox.Show("Không đúng format image");
            }

        }

        public void AddImgToList(Image img)
        {
            AddImg(img);
            Display();
        }

        private void cbSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void pnlMain_Click(object sender, EventArgs e)
        {

        }

        private void picHA_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
