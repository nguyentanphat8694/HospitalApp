using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.App
{
    public class TT010110:ObCTChiDinh
    {
        public string TrangThaiThu { get; set; }

        public DateTime ThoiGian {
            get
            {
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
                Para = ob.TTBenhnhan.Para;
                return ob.Ma;
            }
        }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public int NamSinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string NoiDung { get; set; }
        public string Para { get; set; }
        public string NDChiDinh { get {
            string str = "";
            foreach (var item in listCTChiDinh) {
                str += "- " + item.TenDV + "(" + item.SL + "). ";
            }
            return str;
        } }
        public TT010110() {
            listCTChiDinh = new List<ObCTChiDinh>();
        }
        public TT010110(ObCTChiDinh ob)
        {
            TrangThaiThu = "";
            base.SetNew(ob);

        }
        public List<ObCTChiDinh> listCTChiDinh { get; set; }

        public int LoaiXN_Mau
        {
            get
            {
                if (listCTChiDinh == null || listCTChiDinh.Count == 0)
                    return 0;

                if (listCTChiDinh.Any(o => NTPUserSetting.NhomXN_Mau.Any(p => p == o.DMDichVu.TTChung.Nhom)))
                {
                    return 1;
                }

                return 0;
            }

        }

        public int LoaiXN_Lab256
        {
            get
            {
                if (listCTChiDinh == null || listCTChiDinh.Count == 0)
                    return 0;

                if (listCTChiDinh.Any(o => NTPUserSetting.NhomXN_Lab256.Any(p => p == o.DMDichVu.TTChung.Nhom)))
                {
                    return 1;
                }

                return 0;
            }

        }

        public int LoaiXN_PhuKhoa
        {
            get
            {
                if (listCTChiDinh == null || listCTChiDinh.Count == 0)
                    return 0;

                if (listCTChiDinh.Any(o => NTPUserSetting.NhomXN_PhuKhoa.Any(p => p == o.DMDichVu.TTChung.Nhom)))
                {
                    return 1;
                }

                return 0;
            }

        }

        public bool BT_Mau { get; set; }
        public bool BT_Lab256 { get; set; }
        public bool BT_PhuKhoa { get; set; }
    }
}
