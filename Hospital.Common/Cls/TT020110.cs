using System;

namespace Hospital.App
{
    public class TT020110:ObPhieuThu
    {
        public DateTime ThoiGian {
            get {
                if (base.CreateTime.Trim() == "") return MainNTP.MinValue;
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
        public TT020110(ObPhieuThu ob)
        {
            base.SetNew(ob);

        }
        public KeysListObCTChiDinh listDichVu { get; set; }
        public TT020110() { }
    }
}
