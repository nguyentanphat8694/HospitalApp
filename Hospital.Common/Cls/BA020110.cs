using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    public class BA020110:ObBenhAn
    {
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

        public string NgayStr
        {
            get
            {
                return MainNTP.LayThu_VN(Ngay.DayOfWeek) + ", ngày " + Ngay.Day + " tháng " + Ngay.Month + " năm " + Ngay.Year;
            }
        }

        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public int NamSinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string NoiDung { get; set; }
        public double MaPhieuThuoc { get; set; }
        public double MaPCD { get; set; }
        public BA020110() { }
        public ObChiDinh PhieuChiDinh
        {
            get
            {
                ObCTChiDinh ct = MainNTP.ObCTChiDinhList.GetOb(KeyCTChiDinh);
                if (ct != null)
                {
                    return MainNTP.ObChiDinhList.GetOb(ct.KeyCreate);
                }
                return null;
            }
        }

        public ObPhieuThuoc PhieuThuoc
        {
            get
            {
                KeysListObPhieuThuoc keysPT = NTPObPhieuThuoc.GetListOb_MaBA(Ma, (int)eLoaiPhieuTH.Kham_Benh);
                if (keysPT != null && keysPT.Count > 0)
                {
                    return keysPT[0];
                }
                return null;
            }
        }

        public List<ObCTChiDinh> DSDichVu
        {
            get
            {
                var ob = PhieuChiDinh;
                return ob != null ? ob.DSDichVu.FindAll(o => o.Ma > 0).ToList() : new List<ObCTChiDinh>();
            }
        }

        public List<ObCTChiDinh> DSThuoc
        {
            get
            {
                var ob = PhieuThuoc;
                if (ob != null)
                {
                    return ob.DSDichVu.FindAll(o => o.Ma > 0).ToList();
                }
                return new List<ObCTChiDinh>();
            }
        }

        public string TongChiPhi
        {
            get
            {
                var cd = PhieuChiDinh;
                var th = PhieuThuoc;

                return ((cd != null ? cd.TongChiPhi : 0) + (th != null ? th.TongChiPhi : 0)).ToString("n0");
            }
        }


        public string DichVuChiDinh { get; set; }
    }
}
