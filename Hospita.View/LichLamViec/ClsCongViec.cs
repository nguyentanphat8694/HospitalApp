using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    public class ClsCongViec
    {
        public string Id { get; set; }
        public string ThoiGian { get; set; }
        public string NoiDung { get; set; }
        public DateTime Ngay { get; set; }
        public string BacSi { get; set; }
        public string HoTen { get; set; }
        public bool Chon { get; set; }
        public int LoaiDatHen { get; set; }
        public string MaBN { get; set; }
        public string PhongKham { get; set; }
        public string TrangThai { get; set; }
    }
}
