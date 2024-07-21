using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    public class XN020110:ObPhieuXetNghiem
    {
        public DateTime ThoiGian {
            get {
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
        public string Para { get; set; }
        public bool BatThuong {
            get {
                if (TTChung.ObCTXetNghiems == null) {
                    return false;
                }


                return TTChung.ObCTXetNghiems.Any(o => o.MaXN != "" && !o.BinhThuong);
            }
        }
        public XN020110(ObPhieuXetNghiem ob)
        {
            base.SetNew(ob);

        }
        public XN020110() { }

        public List<ObCTXetNghiem> listChiTiet
        {
            get
            {
                return TTChung.ObCTXetNghiems;
            }
        }
    }
}
