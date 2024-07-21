using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    public class BA010110:ObCTChiDinh
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
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public int NamSinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string NoiDung { get; set; }
        public string DichVuChiDinh { get; set; }
        public string Para { get; set; }
        public string ChanDoan { get; set; }

        public BA010110() { }

        public string BSThucHien { 
            get {
                if (KeyThucHien > 0)
                {
                    if (NTPValidate.IsEmpty(MaPK))
                    {
                        ObCDHA cdha = MainNTP.ObCDHAList.GetOb(KeyThucHien);
                        if (cdha != null)
                            return cdha.BSThucHien;
                    }
                    else
                    {
                        ObBenhAn ba = MainNTP.ObBenhAnList.GetOb(KeyThucHien);
                        if (ba != null)
                            return ba.BSThucHien;
                    }
                }
                return "";
            }
            set { }
        }

        public string TenBSThucHien {
            get {
                if (NTPValidate.IsEmpty(BSThucHien)) return "";
                ObDMNhanSu ns = MainNTP.ObDMNhanSuList.Get(BSThucHien);
                if (ns != null) return ns.Ten;
                return BSThucHien;
            }
        }
    }
}
