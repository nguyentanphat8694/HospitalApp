using System.Collections.Generic;

namespace Hospital.App.ReportModel
{
    public class MRDonThuoc
    {
        public string HoTen { get; set; }
        public string Para { get; set; }
        public string DiaChi { get; set; }
        public string NamSinh { get; set; }
        public string DT { get; set; }
        public string ChanDoan { get; set; }
        public string Note { get; set; }
        public List<MThuoc> DonThuoc { get; set; }
        public string NgayTao { get; set; }
    }
}
