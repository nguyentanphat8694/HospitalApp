using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    [Serializable]
    public class ObPhacDo:ObStatus
    {
        public double Ma { get; set; }
        public DateTime Ngay { get; set; }
        public string Ten { get; set; }
        public int Loai { get; set; }
        public ClsTTPhacDo TTChung { get; set; }

        public ObPhacDo() {
            Ma = 0;
            Ngay = MainNTP.MinValue;
            Ten = "";
            Loai = 0;
            TTChung = new ClsTTPhacDo();
            TrangThai = etrangthai.Đang_chờ.ToString();
            CreateBy = "";
            CreateTime = "";
            UpdateBy = "";
            UpdateTime = "";
            DeleteBy = "";
            DeleteTime = "";
        }

        public ObPhacDo(ObPhacDo ob) {
            Ma = ob.Ma;
            Ngay = ob.Ngay;
            Ten = ob.Ten;
            Loai = ob.Loai;
            TTChung = ob.TTChung;
            TrangThai = ob.TrangThai;
            CreateBy = ob.CreateBy;
            CreateTime = ob.CreateTime;
            UpdateBy = ob.UpdateBy;
            UpdateTime = ob.UpdateTime;
            DeleteBy = ob.DeleteBy;
            DeleteTime = ob.DeleteTime;
        }
    }

    [Serializable]
    public class ClsTTPhacDo
    {
        public List<ClsDichVu> ListDichVu { get; set; }
    }
}
