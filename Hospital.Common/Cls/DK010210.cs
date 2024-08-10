using System;

namespace Hospital.App
{
    public class DK010210:ObChiDinh
    {
        public DateTime ThoiGian {
            get {
                return DateTime.ParseExact(base.CreateTime, "yyyyMMddHHmmss", null);
            }
        }

        public string MaBenhNhan {
            get {
                ObCustomer ob = MainNTP.ObCustomerList.Get(base.MaBN);
                if (ob == null) return "";
                Ten = ob.Ten;
                GioiTinh = ob.Gioitinh == 0 ? "Nam" : "Nữ";
                NamSinh = ob.Namsinh;
                DiaChi = ob.DiaChiFull;
                DienThoai = ob.Dienthoai;
                return ob.Ma;
            }
        }

        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public int NamSinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        public DK010210() { }
        public DK010210(ObChiDinh ob) {
            base.SetNew(ob);
        }
    }

    public class HK010210 : ObHenKham
    {
        public DateTime ThoiGian
        {
            get
            {
                if (base.CreateTime.Trim() == "") return MainNTP.MinValue;
                return DateTime.ParseExact(base.CreateTime, "yyyyMMddHHmmss", null);
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
                DiaChi = ob.Diachi;
                DienThoai = ob.Dienthoai;
                return ob.Ma;
            }
        }

        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public int NamSinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string TrangThai2 {
            get {
                if (etrangthai.Đã_đến.ToString()!=base.TrangThai && base.NgayDenKham < MainNTP._Ngay)
                    return etrangthai.Quá_hẹn.ToString();
                return base.TrangThai;
            }
        }
        public HK010210() { }
        public HK010210(ObHenKham ob)
        {
            base.SetNew(ob);
        }
    }
}
