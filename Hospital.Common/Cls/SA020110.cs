using System;
using System.Drawing;

namespace Hospital.App
{
    public class SA020110:ObCDHA
    {
        public DateTime ThoiGian {
            get
            {
                if (base.CreateTime.Trim() == "") return MainNTP.MinValue;
                return DateTime.ParseExact(base.CreateTime, "yyyyMMddHHmmss", null);
            }
        }

        public string NgayStr
        {
            get
            {
                return MainNTP.LayThu_VN(Ngay.DayOfWeek) + ", ngày " + Ngay.Day + " tháng " + Ngay.Month + " năm " + Ngay.Year; 
            }
        }
        public string MaBenhNhan
        {
            get
            {
                ObCustomer ob = MainNTP.ObCustomerList.Get(base.MaBN);
                if (ob == null) return "";
                Ten = ob.Ten;
                GioiTinh = ob.Gioitinh == 0 ? "Nam" : "Nữ";
                NamSinh = ob.Namsinh;
                DiaChi = ob.DiaChiFull;
                DienThoai = ob.Dienthoai;
                XQBarCode = ob.XRBarCode;
                Para = ob.TTBenhnhan.Para;
                return ob.Ma;
            }
        }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public int NamSinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public Image XQBarCode { get; set; }
        public string TenDV { get; set; }
        public string TenVungKhaoSat { get; set; }
        public string Para { get; set; }
        public SA020110() { }

        Image GetImageByIdx(int idx)
        {
            Image img = null;

            if (TTChung.Images != null)
            {
                var listIn = TTChung.Images.FindAll(o => o.In);
                if (listIn.Count > idx)
                {
                    img = listIn[idx].Img;
                }
            }

            return img;
        }

        public Image Img1
        {
            get
            {
                return GetImageByIdx(0);
            }
        }

        public Image Img2
        {
            get
            {

                return GetImageByIdx(1);
            }
        }

        public Image Img3
        {
            get
            {
                return GetImageByIdx(2);
            }
        }

        public Image Img4
        {
            get
            {
                return GetImageByIdx(3);
            }
        }
    }
}
