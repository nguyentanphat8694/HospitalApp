using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    [Serializable]
    public class ObCTChiDinh:ObStatus
    {
        public double Ma { get; set; }
        public string MaDV { get; set; }
        public double KeyThucHien { get; set; }
        public string BSCreate { get; set; }
        public double KeyCreate { get; set; }
        public double KeyPT { get; set; }
        public double SL { get; set; }
        public double DG { get; set; }
        public double SLBan { get; set; }
        public double SoGiam { get; set; }
        public double ThanhTien {
            get {
                return SL * DG - SoGiam;
            }
        }

        public string sThanhTien
        {
            get
            {
                return ThanhTien.ToString("n0");
            }
        }

        public int LoaiHangHoa { get; set; }// tru kho hay khong tru kho
        public ClsCTChiDinh TTChung { get; set; }
        public DateTime Ngay { get; set; }
        public string MaPK { get; set; }
        public string MaBN { get; set; }
        public int LoaiPhieuTH { get; set; }
        //public string Para { get; set; }
        
        public ObCTChiDinh() {
            Ma = 0;
            MaDV = "";
            KeyThucHien = 0;
            BSCreate = "";
            KeyCreate = 0;
            KeyPT = 0;
            SL = 0;
            DG = 0;
            SLBan = 0;
            SoGiam = 0;
            LoaiHangHoa = -1;
            TTChung = new ClsCTChiDinh();
            Ngay = MainNTP.MinValue;
            MaPK = "";
            MaBN = "";
            LoaiPhieuTH = 0;
        }

        public virtual void SetNew(ObCTChiDinh ob)
        {
            Ma = ob.Ma;
            MaDV = ob.MaDV;
            KeyThucHien = ob.KeyThucHien;
            BSCreate = ob.BSCreate;
            KeyCreate = ob.KeyCreate;
            KeyPT = ob.KeyPT;
            SL = ob.SL;
            DG = ob.DG;
            SLBan = ob.SLBan;
            SoGiam = ob.SoGiam;
            //ThanhTien = ob.ThanhTien;
            LoaiHangHoa = ob.LoaiHangHoa;
            TTChung = ob.TTChung;
            Ngay = ob.Ngay;
            MaPK = ob.MaPK;
            MaBN = ob.MaBN;
            TrangThai = ob.TrangThai;
            CreateBy = ob.CreateBy;
            CreateTime = ob.CreateTime;
            UpdateBy = ob.UpdateBy;
            UpdateTime = ob.UpdateTime;
            DeleteBy = ob.DeleteBy;
            DeleteTime = ob.DeleteTime;
            LoaiPhieuTH = ob.LoaiPhieuTH;
            //var sh = MainNTP.ObSinhHieuList.GetOb(MaBN, Ngay);
            //if (sh != null)
            //{
            //    Para = sh.TTChung.Para;
            //}
        }
        public ObCTChiDinh(ObCTChiDinh ob)
        {
            Ma = ob.Ma;
            MaDV = ob.MaDV;
            KeyThucHien = ob.KeyThucHien;
            BSCreate = ob.BSCreate;
            KeyCreate = ob.KeyCreate;
            KeyPT = ob.KeyPT;
            SL = ob.SL;
            DG = ob.DG;
            SLBan = ob.SLBan;
            SoGiam = ob.SoGiam;
            //ThanhTien = ob.ThanhTien;
            LoaiHangHoa = ob.LoaiHangHoa;
            TTChung = ob.TTChung;
            Ngay = ob.Ngay;
            MaPK = ob.MaPK;
            MaBN = ob.MaBN;
            TrangThai = ob.TrangThai;
            CreateBy = ob.CreateBy;
            CreateTime = ob.CreateTime;
            UpdateBy = ob.UpdateBy;
            UpdateTime = ob.UpdateTime;
            DeleteBy = ob.DeleteBy;
            DeleteTime = ob.DeleteTime;
            LoaiPhieuTH = ob.LoaiPhieuTH;
        }
        public virtual ObCTChiDinh GetOb()
        {
            
            ObCTChiDinh ob = new ObCTChiDinh();
            ob.Ma = this.Ma;
            ob.MaDV = this.MaDV;
            ob.KeyThucHien = this.KeyThucHien;
            ob.BSCreate = this.BSCreate;
            ob.KeyCreate = this.KeyCreate;
            ob.KeyPT = this.KeyPT;
            ob.SL = this.SL;
            ob.DG = this.DG;
            ob.SLBan = this.SLBan;
            ob.SoGiam = this.SoGiam;
            //ob.ThanhTien = this.ThanhTien;
            ob.LoaiHangHoa = this.LoaiHangHoa;
            ob.TTChung = this.TTChung;
            ob.Ngay = this.Ngay;
            ob.MaPK = this.MaPK;
            ob.MaBN = this.MaBN;
            ob.TrangThai = this.TrangThai;
            ob.CreateBy = this.CreateBy;
            ob.CreateTime = this.CreateTime;
            ob.UpdateBy = this.UpdateBy;
            ob.UpdateTime = this.UpdateTime;
            ob.DeleteBy = this.DeleteBy;
            ob.DeleteTime = this.DeleteTime;
            ob.LoaiPhieuTH = this.LoaiPhieuTH;
            return ob;
        }
        public string TenDV {
            get {
                DMDichVu = MainNTP.ObDMDichVuList.Get(MaDV);
                if(DMDichVu==null)
                    DMDichVu = MainNTP.ObDMDichVuList.GetOb(MaDV);
                if (DMDichVu == null)
                    return "";
                return DMDichVu.Ten;
            }
        }
        public string TenDonVi {
            get {
                if (DMDichVu == null || DMDichVu.TTChung == null) return "";
                ObDMDonVi dv = MainNTP.ObDMDonViList.Get(DMDichVu.TTChung.DonVi);
                return dv == null ? "" : dv.Ten;
            }
        }
        public ObDMDichVu DMDichVu { get; set; }
    }
    [Serializable]
    public class ClsCTChiDinh {
        public bool DaKham { get; set; }
        public string LanDung { get; set; }
        public string CachDung { get; set; }
        public string LieuDung { get; set; }
        public bool MuaNgoai { get; set; }
        public bool MienPhi { get; set; }
        public string BacSi { get; set; }


        public bool BT_Mau { get; set; }

        public bool BT_PhuKhoa { get; set; }

        public bool BT_Lab256 { get; set; }
    }
}
