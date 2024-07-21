using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{

    public enum eUserSetting
    {
        Duong_dan_luu_anh_SA,
        Thu_tien_sau,
        Cach_dung_thuoc,
        Nhom_kham,
        Nhom_SA,
        Nhom_XN,
        Do_dai_STT_MaBN,
        SL_toi_thieu,
        Nhom_Mau,
        Nhom_PhuKhoa,
        Nhom_Lab256,
        Duong_Dan_Luu_Anh_MaySA
    }

    public class NTPUserSetting {

        public static int SLToiThieu
        {
            get
            {
                ObDMTSo ob = MainNTP.ObDMTSoList.Get(eUserSetting.SL_toi_thieu.ToString());
                if (ob == null) return 10;
                return MainNTP.ParseInt(ob.Ten);
            }
        }

        public static int DoDaiSTTMaBN
        {
            get
            {
                ObDMTSo ob = MainNTP.ObDMTSoList.Get(eUserSetting.Do_dai_STT_MaBN.ToString());
                if (ob == null) return 5;
                return MainNTP.ParseInt(ob.Ten);
            }
        }

        public static string DDLuuAnhSA
        {
            get {
                ObDMTSo ob = MainNTP.ObDMTSoList.Get(eUserSetting.Duong_dan_luu_anh_SA.ToString());
                if (ob == null) return @"E:";
                return ob.Ten;
            }
        }
        public static string PathServer_User
        {
            get
            {
                return "PHONGNT";
            }
        }
        public static string PathServer_Domain
        {
            get
            {
                return "192.168.1.74";
            }
        }

        public static string PathServer_Password {
            get {
                return "12346";
            }
        }

        public static string KhoMacDinh {
            get {
                return "1561";
            }
        }

        public static bool ThutienSau {
            get {
                ObDMTSo ob = MainNTP.ObDMTSoList.Get(eUserSetting.Thu_tien_sau.ToString());
                return ob == null ? false : bool.Parse(ob.Ten.ToString());
            }
        }

        public static List<string> NhomKham {
            get {
                ObDMTSo ob = MainNTP.ObDMTSoList.Get(eUserSetting.Nhom_kham.ToString());
                return ob == null ? new List<string>() : ob.Ten.Split(new string[] { ";" }, StringSplitOptions.None).ToList();
            }
        }
        public static List<string> NhomSA
        {
            get
            {
                ObDMTSo ob = MainNTP.ObDMTSoList.Get(eUserSetting.Nhom_SA.ToString());
                return ob == null ? new List<string>() : ob.Ten.Split(new string[] { ";" }, StringSplitOptions.None).ToList();
            }
        }
        public static List<string> NhomXN
        {
            get
            {
                ObDMTSo ob = MainNTP.ObDMTSoList.Get(eUserSetting.Nhom_XN.ToString());
                return ob == null ? new List<string>() : ob.Ten.Split(new string[] { ";" }, StringSplitOptions.None).ToList();
            }
        }

        static List<string> _NhomXN_Mau = null;
        public static List<string> NhomXN_Mau
        {
            get
            {
                if (_NhomXN_Mau == null)
                {
                    ObDMTSo ob = MainNTP.ObDMTSoList.Get(eUserSetting.Nhom_Mau.ToString());
                    _NhomXN_Mau = ob == null ? new List<string>() : ob.Ten.Split(new string[] { ";" }, StringSplitOptions.None).ToList();
                }

                return _NhomXN_Mau;
            }
        }

        static List<string> _NhomXN_PhuKhoa = null;
        public static List<string> NhomXN_PhuKhoa
        {
            get
            {
                if (_NhomXN_PhuKhoa == null)
                {
                    ObDMTSo ob = MainNTP.ObDMTSoList.Get(eUserSetting.Nhom_PhuKhoa.ToString());
                    _NhomXN_PhuKhoa = ob == null ? new List<string>() : ob.Ten.Split(new string[] { ";" }, StringSplitOptions.None).ToList();
                }

                return _NhomXN_PhuKhoa;
            }
        }

        static List<string> _NhomXN_Lab256 = null;
        public static List<string> NhomXN_Lab256
        {
            get
            {
                if (_NhomXN_Lab256 == null)
                {
                    ObDMTSo ob = MainNTP.ObDMTSoList.Get(eUserSetting.Nhom_Lab256.ToString());
                    _NhomXN_Lab256 = ob == null ? new List<string>() : ob.Ten.Split(new string[] { ";" }, StringSplitOptions.None).ToList();
                }

                return _NhomXN_Lab256;
            }
        }
    }
}
