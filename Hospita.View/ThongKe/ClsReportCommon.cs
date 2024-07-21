using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    public class ClsReportCommon<T> where T : class,new()
    {
        public string tieuDeNgay { get; set; }
        public List<T> Datas { get; set; }
        public string NgayStr
        {
            get
            {
                DateTime Ngay = MainNTP._Ngay;
                return MainNTP.LayThu_VN(Ngay.DayOfWeek) + ", ngày " + Ngay.Day + " tháng " + Ngay.Month + " năm " + Ngay.Year;
            }
        }
    }
}
