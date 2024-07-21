using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    [Serializable]
    public class ObCustomer
    {
        string _Ma, _Ten, _Diachi,_Dienthoai,_CMND,_Email;
        int _STT,_Ngaysinh, _Thangsinh, _Namsinh, _Gioitinh;
        Cls_TTCustomer _TTBenhnhan;
        DateTime _Ngay, _DTimesNew;
        public string Ma { get { return _Ma; } set { _Ma = value; 
            if (TTBenhnhan != null) 
                TTBenhnhan.MaBN = value; 
        } }
        public string Ten { get { return _Ten; } set { _Ten = value; } }
        public int Ngaysinh { get { return _Ngaysinh; } set { _Ngaysinh = value; } }
        public int Thangsinh { get { return _Thangsinh; } set { _Thangsinh = value; } }
        public int Namsinh { get { return _Namsinh; } set { _Namsinh = value; } }
        public int Gioitinh { get { return _Gioitinh; } set { _Gioitinh = value; } }
        public string Diachi { get { return _Diachi; } set { _Diachi = value; } }
        public string Dienthoai { get { return _Dienthoai; } set { _Dienthoai = value; } }
        public string CMND { get { return _CMND; } set { _CMND = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public int STT { get { return _STT; } set { _STT = value; } }
        public Cls_TTCustomer TTBenhnhan { get { return _TTBenhnhan; } set { _TTBenhnhan = value; } }
        public DateTime Ngay { get { return _Ngay; } set { _Ngay = value; } }
        public DateTime DTimesNew { get { return _DTimesNew; } set { _DTimesNew = value; } }
        public ObCustomer() {
            _Ma = "";
            _Ten = "";
            _Ngaysinh = -1;
            _Thangsinh = -1;
            _Namsinh = -1;
            _Gioitinh = 0;
            _Diachi = "";
            _Dienthoai = "";
            _CMND = "";
            _STT = 0;
            TTBenhnhan = new Cls_TTCustomer();
            _Ngay = DateTime.MinValue;
            _DTimesNew = DateTime.MinValue;
            _Email = "";
        }
        public ObCustomer(ObCustomer cls)
        {
            _Ma = cls.Ma;
            _Ten = cls.Ten;
            _Ngaysinh = cls.Ngaysinh;
            _Thangsinh = cls.Thangsinh;
            _Namsinh = cls.Namsinh;
            _Gioitinh = cls.Gioitinh;
            _Diachi = cls.Diachi;
            _Dienthoai = cls.Dienthoai;
            _CMND = cls.CMND;
            _STT = cls.STT;
            TTBenhnhan = cls.TTBenhnhan;
            _Ngay = cls.Ngay;
            _DTimesNew = cls.DTimesNew;
            _Email = cls.Email;
        }
        public void SetOb(ObCustomer cls)
        {
            _Ma = cls.Ma;
            _Ten = cls.Ten;
            _Ngaysinh = cls.Ngaysinh;
            _Thangsinh = cls.Thangsinh;
            _Namsinh = cls.Namsinh;
            _Gioitinh = cls.Gioitinh;
            _Diachi = cls.Diachi;
            _Dienthoai = cls.Dienthoai;
            _CMND = cls.CMND;
            _STT = cls.STT;
            TTBenhnhan.SetOb(cls.TTBenhnhan);
            _Ngay = cls.Ngay;
            _DTimesNew = cls.DTimesNew;
            _Email = cls.Email;
        }
        public string sGioiTinh {
            get {
                return _Gioitinh == 0 ? "Nam" : "Nữ";
            }
        }
        private string _DiaChiFull = "";
        public string DiaChiFull
        {
            get
            {
                if (_DiaChiFull == "")
                {
                    _DiaChiFull = MainNTP.GetDiaChi(TTBenhnhan.MaTinh, TTBenhnhan.MaQuan, Diachi);
                }

                return _DiaChiFull;
            }
            set
            {
                _DiaChiFull = value;
            }
        }
        public Image XRBarCode
        {
            get
            {
                Bitmap bitmap = new Bitmap(Ma.Length * 28, 100);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Font font = new Font("IDAutomationHC39M", 20);
                    PointF point = new PointF(2f, 2f);
                    SolidBrush black = new SolidBrush(Color.Black);
                    SolidBrush white = new SolidBrush(Color.White);
                    graphics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                    graphics.DrawString(Ma, font, black, point);
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Png);
                    return bitmap;
                }
            }
        }
    }
    [Serializable]
    public class Cls_TTCustomer
    {
        public string MaBN { get; set; }
        string  _Nguoithan;
        Image _Anh;
        public Image Anh { get { return _Anh; } set { _Anh = value; } }
        public string Nguoithan { get { return _Nguoithan; } set { _Nguoithan = value; } }
        public string MaTinh { get; set; }
        public string MaQuan { get; set; }
        public string NgheNghiep { get; set; }
        public double TongTamUng { get; set; }
        public double KhachHangNo { get; set; }
        public string TienSu { get; set; }
        public Cls_TTCustomer() {
            _Nguoithan = "";
            _Anh = null;
            MaTinh = "";
            MaQuan = "";
            NgheNghiep = "";
            TongTamUng = 0;
            KhachHangNo = 0;
            TienSu = "";
            Para = "";
        }
        public Cls_TTCustomer(Cls_TTCustomer cls)
        {
            _Nguoithan = cls.Nguoithan;
            _Anh = cls.Anh;
            MaTinh = cls.MaTinh;
            MaQuan = cls.MaQuan;
            NgheNghiep = cls.NgheNghiep;
            TongTamUng = cls.TongTamUng;
            KhachHangNo = cls.KhachHangNo;
            TienSu = cls.TienSu;
            Para = cls.Para;
        }
        public void SetOb(Cls_TTCustomer cls)
        {
            _Nguoithan = cls.Nguoithan;
            _Anh = cls.Anh;
            MaTinh = cls.MaTinh;
            MaQuan = cls.MaQuan;
            NgheNghiep = cls.NgheNghiep;
            TongTamUng = cls.TongTamUng;
            KhachHangNo = cls.KhachHangNo;
            TienSu = cls.TienSu;
            Para = cls.Para;
        }

        private string _Para = "";
        public string Para
        {
            get
            {
                if ((_Para == null || _Para == "") && MaBN != null)
                {
                    ObSinhHieu ob = NTPObSinhHieu.GetPara(MaBN);
                    if (ob != null && ob.TTChung != null && ob.TTChung.Para != null)
                    {
                        _Para = ob.TTChung.Para;
                    }
                }

                return _Para;
            }
            set
            {
                _Para = value;
            }
        }
    }
}
