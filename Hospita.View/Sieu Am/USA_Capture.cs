using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Hospital.App
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class USA_Capture : DevExpress.XtraEditors.XtraUserControl
    {
        private WebCamCapture webCamCapture;
        //private WebCamCapture ;
		private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdStop;
        public OpenCVDotNet.UI.SelectPictureBox picSrc;
        public DevExpress.XtraEditors.SimpleButton btCapture;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public Button btConfig;
        public DevExpress.XtraEditors.SimpleButton btChonAnh;
        public DevExpress.XtraEditors.CheckEdit chToananh;
        private Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public USA_Capture()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            this.webCamCapture.CaptureHeight = this.picSrc.Height;
            this.webCamCapture.CaptureWidth = this.picSrc.Width;
            picSrc.SelectionRect = new Rectangle(0, 0, picSrc.Width, picSrc.Height);
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USA_Capture));
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.picSrc = new OpenCVDotNet.UI.SelectPictureBox();
            this.btCapture = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.button1 = new System.Windows.Forms.Button();
            this.chToananh = new DevExpress.XtraEditors.CheckEdit();
            this.btChonAnh = new DevExpress.XtraEditors.SimpleButton();
            this.btConfig = new System.Windows.Forms.Button();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.webCamCapture = new Hospital.App.WebCamCapture();
            ((System.ComponentModel.ISupportInitialize)(this.picSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chToananh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdStart
            // 
            this.cmdStart.Image = ((System.Drawing.Image)(resources.GetObject("cmdStart.Image")));
            this.cmdStart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdStart.Location = new System.Drawing.Point(3, 3);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(52, 24);
            this.cmdStart.TabIndex = 1;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.Enabled = false;
            this.cmdStop.Image = ((System.Drawing.Image)(resources.GetObject("cmdStop.Image")));
            this.cmdStop.Location = new System.Drawing.Point(55, 3);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(52, 24);
            this.cmdStop.TabIndex = 2;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // picSrc
            // 
            this.picSrc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSrc.Location = new System.Drawing.Point(2, 2);
            this.picSrc.Name = "picSrc";
            this.picSrc.ReadOnly = false;
            this.picSrc.SelectionRect = new System.Drawing.Rectangle(0, 0, 513, 375);
            this.picSrc.ShowCross = true;
            this.picSrc.ShowSelection = true;
            this.picSrc.Size = new System.Drawing.Size(519, 378);
            this.picSrc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSrc.TabIndex = 4;
            this.picSrc.TabStop = false;
            this.picSrc.DoubleClick += new System.EventHandler(this.picSrc_DoubleClick);
            // 
            // btCapture
            // 
            this.btCapture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btCapture.Appearance.Font = new System.Drawing.Font("Tahoma", 10.75F, System.Drawing.FontStyle.Bold);
            this.btCapture.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btCapture.Appearance.Options.UseFont = true;
            this.btCapture.Appearance.Options.UseForeColor = true;
            this.btCapture.Location = new System.Drawing.Point(194, 3);
            this.btCapture.Name = "btCapture";
            this.btCapture.Size = new System.Drawing.Size(118, 48);
            this.btCapture.TabIndex = 27;
            this.btCapture.Text = "LẤY ẢNH";
            this.btCapture.Click += new System.EventHandler(this.btCapture_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.button1);
            this.panelControl1.Controls.Add(this.chToananh);
            this.panelControl1.Controls.Add(this.btChonAnh);
            this.panelControl1.Controls.Add(this.btConfig);
            this.panelControl1.Controls.Add(this.cmdStart);
            this.panelControl1.Controls.Add(this.cmdStop);
            this.panelControl1.Controls.Add(this.btCapture);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 382);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(523, 54);
            this.panelControl1.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(3, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 24);
            this.button1.TabIndex = 31;
            this.button1.Text = "AMCap";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chToananh
            // 
            this.chToananh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chToananh.EditValue = true;
            this.chToananh.Location = new System.Drawing.Point(439, 3);
            this.chToananh.Name = "chToananh";
            this.chToananh.Properties.Caption = "Toàn ảnh";
            this.chToananh.Size = new System.Drawing.Size(79, 19);
            this.chToananh.TabIndex = 30;
            this.chToananh.CheckedChanged += new System.EventHandler(this.chToananh_CheckedChanged);
            // 
            // btChonAnh
            // 
            this.btChonAnh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btChonAnh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btChonAnh.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btChonAnh.Appearance.Options.UseFont = true;
            this.btChonAnh.Appearance.Options.UseForeColor = true;
            this.btChonAnh.Location = new System.Drawing.Point(441, 27);
            this.btChonAnh.Name = "btChonAnh";
            this.btChonAnh.Size = new System.Drawing.Size(77, 24);
            this.btChonAnh.TabIndex = 29;
            this.btChonAnh.Text = "Chọn ảnh";
            this.btChonAnh.Click += new System.EventHandler(this.btChonAnh_Click);
            // 
            // btConfig
            // 
            this.btConfig.Location = new System.Drawing.Point(55, 27);
            this.btConfig.Name = "btConfig";
            this.btConfig.Size = new System.Drawing.Size(52, 24);
            this.btConfig.TabIndex = 28;
            this.btConfig.Text = "Config";
            this.btConfig.Click += new System.EventHandler(this.btConfig_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.picSrc);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(523, 382);
            this.panelControl2.TabIndex = 32;
            // 
            // webCamCapture
            // 
            this.webCamCapture.CaptureHeight = 240;
            this.webCamCapture.CaptureWidth = 320;
            this.webCamCapture.FrameNumber = ((ulong)(0ul));
            this.webCamCapture.Location = new System.Drawing.Point(17, 17);
            this.webCamCapture.Name = "WebCamCapture";
            this.webCamCapture.Size = new System.Drawing.Size(342, 252);
            this.webCamCapture.TabIndex = 0;
            this.webCamCapture.TimeToCapture_milliseconds = 100;
            this.webCamCapture.ImageCaptured += new Hospital.App.WebCamCapture.WebCamEventHandler(this.WebCamCapture_ImageCaptured);
            // 
            // USA_Capture
            // 
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "USA_Capture";
            this.Size = new System.Drawing.Size(523, 436);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chToananh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void Form1_Load(object sender, System.EventArgs e)
		{
			// set the image capture size

		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// stop the video capture
			this.webCamCapture.Stop();
		}

		/// <summary>
		/// An image was capture
		/// </summary>
		/// <param name="source">control raising the event</param>
		/// <param name="e">WebCamEventArgs</param>
		private void WebCamCapture_ImageCaptured(object source, WebcamEventArgs e)
		{
			// set the picturebox picture
            ////this.picSrc.Image = e.WebCamImage;
            ShowImage(e.WebCamImage);
		}

        delegate void CallBackShowImg(Image img);
        void ShowImage(Image img)
        {
            if (this.InvokeRequired)
            {
                CallBackShowImg cb = new CallBackShowImg(ShowImage);
                this.Invoke(cb, new object[] { img});
            }
            else
            {
                this.picSrc.Image = img;
            }
        }

        public void Start() {
            if (cmdStop.Enabled) return;
            //if (!cmdStart.Enabled) { Continue(); return; }
            // change the capture time frame
            try
            {
                this.webCamCapture.TimeToCapture_milliseconds = 12;

                // start the video capture. let the control handle the
                // frame numbers.
                this.webCamCapture.Start(0);
                cmdStart.Enabled = false;
                cmdStop.Enabled = true;
            }
            catch { }
        }
		private void cmdStart_Click(object sender, System.EventArgs e)
		{
            Start();
		}

        public void Stop() {

            if (!cmdStop.Enabled) {
                return;
            }
            // stop the video capture
            this.webCamCapture.Stop();
            cmdStart.Enabled = true;
            cmdStop.Enabled = false;
            picSrc.Image = null;
        }
		private void cmdStop_Click(object sender, System.EventArgs e)
		{
            Stop();
		}

        public void Continue() {
            // change the capture time frame
            this.webCamCapture.TimeToCapture_milliseconds = 12;

            // resume the video capture from the stop
            this.webCamCapture.Start(this.webCamCapture.FrameNumber);
            cmdStop.Enabled = true;
        }
		private void cmdContinue_Click(object sender, System.EventArgs e)
		{
            Continue();
        }

        public Image imgC = null;
        public bool _GetAllImg = true;
        private void btCapture_Click(object sender, EventArgs e)
        {
            //if (picSrc.Image == null) { imgC = null; return; }
            //imgC = CaptureImg();
            //if (_GetAllImg)
            //    imgC = this.WebCamCapture.tempImg;
            //else
            //{
            //    Bitmap bm = new Bitmap(picSrc.SelectionRect.Width, picSrc.SelectionRect.Height);
            //    Graphics g = Graphics.FromImage(bm);
            //    g.DrawImage(picSrc.Image, 0, 0, picSrc.SelectionRect, GraphicsUnit.Pixel);

            //    imgC = bm;
            //}
        }
        public Image CaptureImg()
        {
            if (_GetAllImg)
            {
                int qu = 90;
                return MainNTP.CompressImage(webCamCapture.tempImg, qu);
                //return WebCamCapture.tempImg;
            }
            else
            {
                Image img = webCamCapture.tempImg;
                if (img == null) return null;
                double tlW = 0, tlH = 0; bool zo = false;
                Point p = MainNTP.GetRatioImg(picSrc, img, ref tlW, ref tlH, ref zo, picSrc.SelectionRect.Location);
                int w = picSrc.SelectionRect.Width, h = picSrc.SelectionRect.Height, x = picSrc.SelectionRect.X, y = picSrc.SelectionRect.Y;
                w = (int)((double)(w * img.Width) / tlW);
                h = (int)((double)((h * img.Height) / tlH));
                Rectangle rec = new Rectangle(p.X, p.Y, w, h);
                Bitmap bm = new Bitmap(w, h);
                Graphics g = Graphics.FromImage(bm);
                g.DrawImage(img, new Rectangle(0, 0, rec.Width, rec.Height), rec, GraphicsUnit.Pixel);

                int qu = 90;
                return MainNTP.CompressImage(bm, qu);

            }
        }

        private void btConfig_Click(object sender, EventArgs e)
        {
            try
            {
                this.webCamCapture.SendMessage(WebCamCapture.WM_CAP_DLG_VIDEOSOURCE);
                //string pth = Application.StartupPath + "/amcap.exe";
                //System.Diagnostics.Process.Start(pth);
            }
            catch { }
        }

        private void picSrc_DoubleClick(object sender, EventArgs e)
        {
        }

        private void btChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog fo = new OpenFileDialog();
            fo.Filter = "Image Files(*.PNG;*.JPG;*.GIF)|*.PNG;*.JPG;*.GIF|All files (*.*)|*.*";
            if (fo.ShowDialog() == DialogResult.OK) {
                Image img = Image.FromFile(fo.FileName);
                if (img != null) { picSrc.Image = img; webCamCapture.tempImg = img; }
            }
        }

        private void chToananh_CheckedChanged(object sender, EventArgs e)
        {
            _GetAllImg = chToananh.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pth = Application.StartupPath + "/amcap.exe";
            System.Diagnostics.Process.Start(pth);
        }
	}
}

