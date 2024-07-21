using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.App
{
    [Serializable]
    public class Cls_ReportNTP
    {
        string _TenReport;
        public string TenReport { get { return _TenReport; } set { _TenReport = value; } }
        bool _CHON;
        public bool CHON { get { return _CHON; } set { _CHON = value; } }
        public Cls_ReportNTP()
        {
            TenReport = "";
            _CHON = false;
        }
        public Cls_ReportNTP(Cls_ReportNTP ob)
        {
            TenReport = ob.TenReport;
            _CHON = ob._CHON;
        }
    }
    public enum e_REPORTNTP
    {
        Benh_An,
        Sieu_Am,
        Phieu_Thu,
        Xet_Nghiem,
        Sieu_Am_2_Anh,
        Sieu_Am_4_Anh,
        Giay_Vao_Vien,
        Phieu_chi_dinh,
        Phieu_thuoc,
        Sieu_Am_3_Anh,
        Sieu_Am_0_Anh,
        BC_KhamBenh_BenhNhan,
        BC_KhamBenh_BacSi,
        BC_KhamBenh_DichVu,
    }
}
