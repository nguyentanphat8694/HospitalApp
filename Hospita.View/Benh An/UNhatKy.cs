using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Hospital.App
{
    public partial class UNhatKy : DevExpress.XtraEditors.XtraUserControl
    {
        public UNhatKy()
        {
            InitializeComponent();
        }

        List<ClsNhatKy> listNhatKy = new List<ClsNhatKy>();

        public void SetLichSuKham(string maBN)
        {
            listNhatKy.Clear();
            var listTemp = new List<ClsNhatKy>();
            KeysListObCTChiDinh keys = NTPObCTChiDinh.GetListOb(maBN);
            ClsNhatKy cls = null;
            ObCDHA cdha = null;
            ObBenhAn ba = null;
            ObPhieuXetNghiem xn = null;
            if (keys != null)
            {
                foreach (var nk in keys)
                {
                    if (nk.TrangThai == etrangthai.Đã_hủy.ToString() || nk.KeyThucHien <= 0)
                    {
                        continue;
                    }

                    if (nk.LoaiPhieuTH == (int)eLoaiPhieuTH.Sieu_Am || nk.LoaiPhieuTH == (int)eLoaiPhieuTH.CLS)
                    {
                        cdha = NTPObCDHA.GetObWF_PK(nk.KeyThucHien);
                        if (cdha != null)
                        {
                            cls = new ClsNhatKy();
                            cls.TenDV = nk.TenDV;
                            cls.Ngay = cdha.Ngay.ToString("dd/MM/yyyy");
                            cls.dtNgay = cdha.Ngay.Date;
                            cls.LoaiPhieu = (int)eLoaiPhieuTH.Sieu_Am;
                            cls.KeyCTChiDinh = nk.Ma;
                            cls.Data = cdha;
                            listTemp.Add(cls);
                        }
                    }
                    else if (nk.LoaiPhieuTH == (int)eLoaiPhieuTH.Kham_Benh)
                    {
                        ba = NTPObBenhAn.GetObWF_PK(nk.KeyThucHien);
                        if (ba != null)
                        {
                            cls = new ClsNhatKy();
                            cls.TenDV = nk.TenDV;
                            cls.Ngay = ba.Ngay.ToString("dd/MM/yyyy");
                            cls.dtNgay = ba.Ngay.Date;
                            cls.LoaiPhieu = (int)eLoaiPhieuTH.Kham_Benh;
                            cls.KeyCTChiDinh = nk.Ma;
                            cls.Data = ba;
                            listTemp.Add(cls);
                        }
                    }
                    else if (nk.LoaiPhieuTH == (int)eLoaiPhieuTH.Xet_Nghiem)
                    {
                        xn = NTPObPhieuXetNghiem.GetObWF_PK(nk.KeyThucHien);
                        if (xn != null)
                        {
                            cls = new ClsNhatKy();
                            cls.TenDV = nk.TenDV;
                            cls.Ngay = xn.Ngay.ToString("dd/MM/yyyy");
                            cls.dtNgay = xn.Ngay.Date;
                            cls.LoaiPhieu = (int)eLoaiPhieuTH.Xet_Nghiem;
                            cls.KeyCTChiDinh = nk.Ma;
                            cls.Data = xn;
                            listTemp.Add(cls);
                        }
                    }
                }
            }
            var nhatKyThuoc = GetListNhatKyPhieuThuoc(maBN);
            if (nhatKyThuoc.Count > 0)
                listTemp.AddRange(nhatKyThuoc);

            int x = 1;
            ClsNhatKy clsNK = null;
            foreach (var item in listTemp.OrderByDescending(o => o.dtNgay))
            {
                clsNK = listNhatKy.Find(o => o.dtNgay == item.dtNgay);
                if (clsNK == null)
                {
                    item.Ngay = (x < 10 ? ("0" + x.ToString()) : x.ToString()) + ". " + item.Ngay;
                    x++;
                    listNhatKy.Add(item);
                }
                else
                {
                    item.Ngay = clsNK.Ngay;
                    listNhatKy.Add(item);
                }
            }

            gridDSDichVu.DataSource = listNhatKy;
            viewDSDichVu.RefreshData();

            viewDSDichVu.ExpandAllGroups();
        }
        string nameDonThuoc = "Đơn thuốc";
        public List<ClsNhatKy> GetListNhatKyPhieuThuoc(string maBN)
        {
            var rs = new List<ClsNhatKy>();
            var listThuoc = NTPObPhieuThuoc.GetListObByMaBN(maBN);
            foreach(var thuoc in listThuoc)
            {
                var cls = new ClsNhatKy();
                cls.TenDV = nameDonThuoc;
                cls.Ngay = thuoc.Ngay.ToString("dd/MM/yyyy");
                cls.dtNgay = thuoc.Ngay.Date;
                cls.KeyCTChiDinh = thuoc.Ma;
                cls.Data = thuoc;
                rs.Add(cls);
            }
            return rs;
        }

        void SetPrintPreview()
        {
            prKQCLS.PrintingSystem = null;
            var cls = (ClsNhatKy)viewDSDichVu.GetFocusedRow();
            if (cls != null)
            {
                if (cls.LoaiPhieu == (int)eLoaiPhieuTH.Sieu_Am || cls.LoaiPhieu == (int)eLoaiPhieuTH.CLS)
                {
                    ObCDHA data = (ObCDHA)cls.Data;

                    RP020100 rp = Main_View.GetReportSieuAm(data);
                    if (rp != null)
                    {
                        prKQCLS.PrintingSystem = rp.PrintingSystem;
                        rp.CreateDocument(true);
                    }
                }
                else if (cls.LoaiPhieu == (int)eLoaiPhieuTH.Kham_Benh)
                {
                    ObBenhAn data = (ObBenhAn)cls.Data;

                    RP020100 rp = Main_View.GetReportBenhAn(data);
                    if (rp != null)
                    {
                        prKQCLS.PrintingSystem = rp.PrintingSystem;
                        rp.CreateDocument(true);
                    }
                }
                else if (cls.LoaiPhieu == (int)eLoaiPhieuTH.Xet_Nghiem)
                {
                    ObPhieuXetNghiem data = (ObPhieuXetNghiem)cls.Data;

                    RP020100 rp = Main_View.GetReportXetNghiem(data);
                    if (rp != null)
                    {
                        prKQCLS.PrintingSystem = rp.PrintingSystem;
                        rp.CreateDocument(true);
                    }
                }
                else if (string.Equals(cls.TenDV, nameDonThuoc))
                {
                    var rp = Main_View.GetReportPhieuThuoc(cls.Data as ObPhieuThuoc);
                    if (rp != null)
                    {
                        prKQCLS.PrintingSystem = rp.PrintingSystem;
                        rp.CreateDocument(true);
                    }
                }

            }
        }

        private void viewDSDichVu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetPrintPreview();
        }
    }
}
