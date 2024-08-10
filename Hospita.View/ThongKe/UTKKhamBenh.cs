using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;
using DevExpress.XtraReports.UI;

namespace Hospital.App
{
    public partial class UTKKhamBenh : DevExpress.XtraEditors.XtraUserControl
    {
        public UTKKhamBenh()
        {
            InitializeComponent();

            LoadData();
            InitDisplay();

            deTuNgay.DateTime = deDenNgay.DateTime = MainNTP._Ngay;
            teSearch.Text = searchText;
        }
        //ClsTKKhamBenh clsSL = null;
        List<ClsTKKhamBenh> list = null;
        List<ClsTKKhamBenh> listSDThuoc = null;
        List<ClsTKDichVu> listTKDichVu = null;
        List<ClsTKDichVu> listTKBacSi = null;
        string searchText = "Tìm theo Mã, Họ tên, Năm sinh, Điện thoại, Chẩn đoán, Bác sĩ...";
        string tdNgay = "";
        int w = 80;

        void LoadData() {

            MainNTP.GetData(new List<eTableName>() {
                eTableName.DMNhomDichVu,
            });
        }

        void InitDisplay()
        {
            foreach (var item in MainNTP.ObDMNhomDichVuList)
            {
                var it = new DevExpress.XtraEditors.Controls.CheckedListBoxItem();
                it.Value = item.Ma;
                it.Description = item.Ten;
                clbNhom.Items.Add(it);
            }
            clbNhom.Refresh();
        }

        List<string> GetNhomDaChon() {

            List<string> listNhom = new List<string>();
            for (int i = 0; i < clbNhom.Items.Count; i++)
            {
                if (clbNhom.GetItemChecked(i))
                {
                    listNhom.Add(clbNhom.Items[i].Value.ToString());
                }
            }

            return listNhom;
        }

        void LayDuLieu()
        {
            listSDThuoc = new List<ClsTKKhamBenh>();
            colCTDichVu.Columns.Clear();
            colCTThuoc.Columns.Clear();
            List<string> listNhom = GetNhomDaChon();
            list = new List<ClsTKKhamBenh>();
            listTKDichVu = new List<ClsTKDichVu>();
            listTKBacSi = new List<ClsTKDichVu>();
            ClsTKKhamBenh cls = null;
            ClsTKKhamBenh clsSDThuoc = null;
            ClsTKDichVu clsDichVu = null;
            ClsTKDichVu clsBacSi = null;
            ObCustomer bn = null;
            ObDMNhanSu ns = null;
            ObDMDichVu dv = null;
            //clsSL = new ClsTKKhamBenh();
            List<double> listBAHuy = new List<double>();
            KeysListObCTChiDinh listCD = null;
            KeysListObChiDinh keys = NTPObChiDinh.GetListOb(deTuNgay.DateTime.Date, deDenNgay.DateTime.Date);
            KeysListObPhieuThuoc keysThuoc = NTPObPhieuThuoc.GetListOb(deTuNgay.DateTime.Date, deDenNgay.DateTime.Date);
            double tt = 0;
            bool khongThuocNhom = true;
            string fDate = "dd/MM/yyyy";
            tdNgay = "Từ ngày " + deTuNgay.DateTime.ToString(fDate) + " đến ngày " + deDenNgay.DateTime.ToString(fDate);
            int stt = 1;
            int sttDichVu = 1;
            int sttBacSi = 1;

            ObDMNhanSu nsNULL = new ObDMNhanSu()
            {
                Ma = "",
                Ten = "Không xác định",
            };

            #region chỉ định

            if (keys != null)
            {
                foreach (var phieu in keys)
                {
                    if (phieu.TrangThai == etrangthai.Đã_hủy.ToString() || phieu.MaBA <= 0)
                    {
                        continue;
                    }

                    cls = list.Find(o => o.MaBN == phieu.MaBN);
                    if (cls == null)
                    {
                        cls = new ClsTKKhamBenh();
                        cls.TieuDeNgay = tdNgay;
                        cls.STT = list.Count + 1;
                        cls.MaBN = phieu.MaBN;
                        cls.Ngay = phieu.Ngay.ToString(fDate);
                        cls.ChanDoan = phieu.ChanDoan;
                        bn = MainNTP.ObCustomerList.Get(cls.MaBN);
                        if (bn != null)
                        {
                            cls.HoTen = bn.Ten;
                            cls.NamSinh = bn.Namsinh.ToString();
                            cls.GioiTinh = bn.sGioiTinh;
                            cls.DienThoai = bn.Dienthoai;
                            //cls.DiaChi = bn.DiaChiFull;
                            
                        }
                        list.Add(cls);
                    }

                    listCD = MainNTP.ObCTChiDinhList.GetListOb(phieu.Ma, (int)eLoaiHH.Dịch_vụ);
                    if (listCD != null)
                    {
                        foreach (var cd in listCD)
                        {
                            if (cd.LoaiPhieuTH == (int)eLoaiPhieuTH.Kham_Benh)
                            {
                                cls.KeyPhieuKham = cd.KeyThucHien;
                            }
                            if (cd.TTChung.BacSi == null)
                            {
                                cd.TTChung.BacSi = "";
                            }

                            tt = cheTinhTT.Checked ? cd.SL * cd.DG : cd.SL;

                            if (tt == 0)
                            {
                                continue;
                            }

                            dv = MainNTP.ObDMDichVuList.Get(cd.MaDV);
                            khongThuocNhom = (listNhom.Count > 0 && !listNhom.Any(o => dv != null && o == dv.TTChung.Nhom));
                            if (cd.TTChung.MienPhi || cd.TrangThai == etrangthai.Đã_hủy.ToString() || (khongThuocNhom && cd.MaPK == ""))
                            {
                                continue;
                            }

                            #region thống kê khám bệnh
                            
                            if (cd.MaPK != "") {
                                cls.TienKham += tt;
                                //clsSL.TienKham += cd.SL;
                            }
                            else// if (cd.LoaiHangHoa == (int)eLoaiHH.Dịch_vụ)
                            {
                                cls.TienChiDinh += tt;
                                //clsSL.TienKham += cd.SL;
                                AddBand(cls, true, cd);
                            }
                            //else
                            //{
                            //    cls.TienThuoc += tt;
                            //    AddBand(cls, false, cd);
                            //}

                            cls.TongCong += tt;
                            //clsSL.TienKham += cd.SL;
                            if (!NTPValidate.IsEmpty(cd.TTChung.BacSi))
                            {
                                ns = MainNTP.ObDMNhanSuList.Get(cd.TTChung.BacSi);
                                if (ns != null && !cls.BacSi.Contains(ns.Ten))
                                {
                                    if (cls.BacSi != "")
                                    {
                                        cls.BacSi += "\n";
                                    }

                                    cls.BacSi += ns.Ten;
                                }
                            }
                            else
                            {
                                ns = nsNULL;
                            }
                            #endregion

                            #region thống  kê dịch vụ
                            clsDichVu = listTKDichVu.Find(o => o.Ma == cd.MaDV);
                            if (clsDichVu == null) {
                                clsDichVu = new ClsTKDichVu();
                                clsDichVu.STT = listTKDichVu.Count + 1;
                                clsDichVu.Ma = cd.MaDV;
                                clsDichVu.Ten = dv == null ? cd.MaDV : dv.Ten;
                                clsDichVu.DonGia = dv == null ? 0 : dv.TTChung.DG;
                                listTKDichVu.Add(clsDichVu);
                            }

                            clsDichVu.SoLuong += cd.SL;
                            #endregion

                            #region thống  kê bác sĩ

                            clsBacSi = listTKBacSi.Find(o => o.Ma == cd.MaDV && o.BacSi == cd.TTChung.BacSi);
                            if (clsBacSi == null)
                            {
                                clsBacSi = new ClsTKDichVu();
                                clsBacSi.STT = listTKBacSi.Count + 1;
                                clsBacSi.BacSi = cd.TTChung.BacSi;
                                clsBacSi.TenBacSi = ns == null ? cd.TTChung.BacSi : ns.Ten;
                                clsBacSi.Ma = cd.MaDV;
                                clsBacSi.Ten = dv == null ? cd.MaDV : dv.Ten;
                                clsBacSi.DonGia = dv == null ? 0 : dv.TTChung.DG;
                                listTKBacSi.Add(clsBacSi);
                            }

                            clsBacSi.SoLuong += cd.SL;
                            #endregion
                        }
                    }
                }
            }

            #endregion
            
            #region thuoc

            if (keysThuoc != null)
            {
                foreach (var phieu in keysThuoc)
                {
                    if (phieu.TrangThai == etrangthai.Đã_hủy.ToString() || phieu.MaBA <= 0)
                    {
                        continue;
                    }

                    cls = list.Find(o => o.MaBN == phieu.MaBN);
                    if (cls == null)
                    {
                        cls = new ClsTKKhamBenh();
                        cls.TieuDeNgay = tdNgay;
                        cls.STT = list.Count + 1;
                        cls.MaBN = phieu.MaBN;
                        cls.Ngay = phieu.Ngay.ToString(fDate);
                        cls.ChanDoan = phieu.ChanDoan;
                        bn = MainNTP.ObCustomerList.Get(cls.MaBN);
                        if (bn != null)
                        {
                            cls.HoTen = bn.Ten;
                            cls.NamSinh = bn.Namsinh.ToString();
                            cls.GioiTinh = bn.sGioiTinh;
                            cls.DienThoai = bn.Dienthoai;
                            //cls.DiaChi = bn.DiaChiFull;

                        }
                        list.Add(cls);
                    }

                    clsSDThuoc = listSDThuoc.Find(o => o.MaBN == phieu.MaBN);
                    if (clsSDThuoc == null)
                    {
                        clsSDThuoc = new ClsTKKhamBenh();
                        clsSDThuoc.TieuDeNgay = tdNgay;
                        clsSDThuoc.STT = list.Count + 1;
                        clsSDThuoc.MaBN = phieu.MaBN;
                        clsSDThuoc.Ngay = phieu.Ngay.ToString(fDate);
                        clsSDThuoc.ChanDoan = phieu.ChanDoan;
                        clsSDThuoc.DVChiDinh = "";
                        bn = MainNTP.ObCustomerList.Get(clsSDThuoc.MaBN);
                        if (bn != null)
                        {
                            clsSDThuoc.HoTen = bn.Ten;
                            clsSDThuoc.NamSinh = bn.Namsinh.ToString();
                            clsSDThuoc.GioiTinh = bn.sGioiTinh;
                            clsSDThuoc.DienThoai = bn.Dienthoai;
                            //cls.DiaChi = bn.DiaChiFull;

                        }

                        listSDThuoc.Add(clsSDThuoc);
                    }

                    listCD = MainNTP.ObCTChiDinhList.GetListOb(phieu.Ma, (int)eLoaiHH.Thuốc);
                    if (listCD != null)
                    {
                        foreach (var cd in listCD)
                        {
                            if (cd.TTChung.BacSi == null)
                            {
                                cd.TTChung.BacSi = "";
                            }


                            tt = cheTinhTT.Checked ? cd.SL * cd.DG : cd.SL;
                            if (tt == 0)
                            {
                                continue;
                            }

                            dv = MainNTP.ObDMDichVuList.Get(cd.MaDV);
                            khongThuocNhom = (listNhom.Count > 0 && !listNhom.Any(o => dv != null && o == dv.TTChung.Nhom));
                            if (cd.TTChung.MienPhi || cd.TrangThai == etrangthai.Đã_hủy.ToString() || (khongThuocNhom && cd.MaPK == ""))
                            {
                                continue;
                            }

                           

                            #region thống kê khám bệnh

                            if (cd.MaPK != "")
                            {
                                cls.TienKham += tt;
                            }
                            //else if (cd.LoaiHangHoa == (int)eLoaiHH.Dịch_vụ)
                            //{
                            //    cls.TienChiDinh += tt;
                            //    AddBand(cls, true, cd);
                            //}
                            else
                            {
                                cls.TienThuoc += tt;
                                AddBand(cls, false, cd);
                            }

                            cls.TongCong += tt;
                            if (!NTPValidate.IsEmpty(cd.BSCreate))
                            {
                                ns = MainNTP.ObDMNhanSuList.Get(cd.BSCreate);
                                if (ns != null && !cls.BacSi.Contains(ns.Ten))
                                {
                                    if (cls.BacSi != "")
                                    {
                                        cls.BacSi += "\n";
                                    }

                                    cls.BacSi += ns.Ten;
                                }

                                if (ns != null && !clsSDThuoc.BacSi.Contains(ns.Ten))
                                {
                                    if (clsSDThuoc.BacSi != "")
                                    {
                                        clsSDThuoc.BacSi += "\n";
                                    }

                                    clsSDThuoc.BacSi = ns.Ten;
                                }
                            }
                            else
                            {
                                ns = nsNULL;
                            }
                            #endregion

                            #region thống  kê dịch vụ
                            clsDichVu = listTKDichVu.Find(o => o.Ma == cd.MaDV);
                            if (clsDichVu == null)
                            {
                                clsDichVu = new ClsTKDichVu();
                                clsDichVu.STT = listTKDichVu.Count + 1;
                                clsDichVu.Ma = cd.MaDV;
                                clsDichVu.Ten = dv == null ? cd.MaDV : dv.Ten;
                                clsDichVu.DonGia = dv == null ? 0 : dv.TTChung.DG;
                                listTKDichVu.Add(clsDichVu);
                            }

                            clsDichVu.SoLuong += cd.SL;
                            #endregion

                            #region thống  kê bác sĩ
                            clsBacSi = listTKBacSi.Find(o => o.Ma == cd.MaDV && o.BacSi == cd.TTChung.BacSi);
                            if (clsBacSi == null)
                            {
                                clsBacSi = new ClsTKDichVu();
                                clsBacSi.STT = listTKBacSi.Count + 1;
                                clsBacSi.BacSi = cd.TTChung.BacSi;
                                clsBacSi.TenBacSi = ns == null ? cd.TTChung.BacSi : ns.Ten;
                                clsBacSi.Ma = cd.MaDV;
                                clsBacSi.Ten = dv == null ? cd.MaDV : dv.Ten;
                                clsBacSi.DonGia = dv == null ? 0 : dv.TTChung.DG;
                                listTKBacSi.Add(clsBacSi);
                            }

                            clsBacSi.SoLuong += cd.SL;
                            #endregion

                            #region thống kê sử dụng thuốc

                            if (clsSDThuoc.DVChiDinh != "")
                            {
                                clsSDThuoc.DVChiDinh += "\n";
                            }

                            clsSDThuoc.DVChiDinh += "- " + cd.TenDV + " (" + cd.SL + " - " + cd.sThanhTien + ")";
                            clsSDThuoc.TienThuoc += cd.ThanhTien;

                            #endregion
                        }
                    }
                }
            }

            #endregion

            //list.Add(clsSL);
            gridMain.DataSource = list;

            foreach (DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn item in colCTDichVu.Columns)
            {
                item.Width = w;
            }

            foreach (DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn item in colCTThuoc.Columns)
            {
                item.Width = w;
            }

            colCTDichVu.Width = colCTDichVu.Columns.Count * w;
            colCTThuoc.Width = colCTThuoc.Columns.Count * w;

            viewMain.RefreshData();

            gridSDThuoc.DataSource = listSDThuoc;
            viewSDThuoc.RefreshData();

            if (cheTinhTT.Checked)
            {
                colTongTien.Caption = "TỔNG TIỀN";
                colTienDichVu.Caption = "TIÈN DỊCH VỤ";
                colTienKham.Caption = "TIỀN KHÁM";
                colTienThuoc.Caption = "TIỀN THUỐC";
            }
            else
            {
                colTongTien.Caption = "TỔNG SL";
                colTienDichVu.Caption = "SL DỊCH VỤ";
                colTienKham.Caption = "SL KHÁM";
                colTienThuoc.Caption = "SL THUỐC";
            }
        }

        void AddBand(ClsTKKhamBenh cls, bool isDichVu, ObCTChiDinh cd)
        {
            var colBand = isDichVu ? colCTDichVu : colCTThuoc;
            string loaiHH = isDichVu ? "DV" : "TH";
            bool f1 = false;
            int i = 0;
            for (i = 0; i < colBand.Columns.Count; i++)
            {
                if (colBand.Columns[i].Name == cd.MaDV)
                {
                    f1 = true;
                    break;
                }
            }

            int idx = i + 1;

            if (!f1)
            {

                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                col.Name = cd.MaDV;
                col.Caption = cd.MaDV;
                col.FieldName = loaiHH + idx;
                col.RowCount = 2;

                col.DisplayFormat.FormatString = "n0";
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                col.SummaryItem.DisplayFormat = "{0:n0}";
                col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                col.Visible = true;
                col.VisibleIndex = i;
                col.Width = w;
                colBand.Columns.Add(col);
                AddValue(cls, idx, cd, loaiHH);

            }
            else
            {
                AddValue(cls, idx, cd, loaiHH);
            }
        }

        void AddValue(ClsTKKhamBenh cls, int idx, ObCTChiDinh cd, string loaiHH)
        {
            FieldInfo[] fields = cls.GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            int idxBD = 0;
            int idxKT = 0;
            string name = "";
            foreach (var field in fields)
            {
                idxBD = field.Name.IndexOf('<');
                idxKT = field.Name.IndexOf('>');
                name = field.Name.Substring(idxBD + 1, idxKT - idxBD - 1);
                if (name == loaiHH + idx)
                {
                    double tt = (double)field.GetValue(cls);
                    tt += cheTinhTT.Checked? cd.SL * cd.DG : cd.SL;
                    field.SetValue(cls, tt);

                    //tt = (double)field.GetValue(clsSL);
                    //tt += cd.SL;
                    //field.SetValue(clsSL, tt);

                    return;
                }
            }

        }

        private void btXem_Click(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void btCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.Close();
        }

        private void btXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainNTP.XuatExcel(viewMain);
        }

        private void btInBaoCao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void teSearch_EditValueChanged(object sender, EventArgs e)
        {
            if (teSearch.Text.Trim() == "")
            {
                viewMain.ClearColumnsFilter();
                viewMain.CollapseAllGroups();
            }
            else if (!teSearch.Text.Contains(searchText))
            {
                viewMain.ExpandAllGroups();
                viewMain.ActiveFilterString = "[MaBN] like '" + teSearch.Text + "%'"
                                         + "OR [HoTen] like '%" + teSearch.Text + "%'"
                                         + "OR [ChanDoan] like '%" + teSearch.Text + "%'"
                                         + "OR [BacSi] like '%" + teSearch.Text + "%'"
                                         + "OR [NamSinh] like '%" + teSearch.Text + "%'"
                                         + "OR [DienThoai] like '%" + teSearch.Text + "%'";

            }
        }

        private void teSearch_Leave(object sender, EventArgs e)
        {
            if (teSearch.Text.Trim() == "")
                teSearch.Text = searchText;
        }

        private void teSearch_Enter(object sender, EventArgs e)
        {
            teSearch.Text = "";
        }

        private void btInTheoBenhNhan_Click(object sender, EventArgs e)
        {
            if (list == null) {
                return;
            }
            
            ClsReportCommon<ClsTKKhamBenh> cls = new ClsReportCommon<ClsTKKhamBenh>();
            cls.tieuDeNgay = tdNgay;
            cls.Datas = new List<ClsTKKhamBenh>();
            cls.Datas.AddRange(list);
            RP020100 rp = new RP020100();
            rp.SetData(e_REPORTNTP.BC_KhamBenh_BenhNhan.ToString(), new List<ClsReportCommon<ClsTKKhamBenh>>() { cls });
            rp.ShowPreviewDialog();
        }

        private void btInTheoBacSi_Click(object sender, EventArgs e)
        {
            if (listTKBacSi == null)
            {
                return;
            }

            List<ClsTKDichVu> listIn = new List<ClsTKDichVu>();
            ClsTKDichVu clsIn;
            int stt = 1;
            foreach (var item in listTKBacSi)
            {
                clsIn = listIn.Find(o => o.BacSi == item.BacSi);
                if (clsIn == null)
                {
                    clsIn = new ClsTKDichVu();
                    clsIn.STT = stt++;
                    clsIn.BacSi = item.BacSi;
                    clsIn.TenBacSi = item.TenBacSi;
                    clsIn.DSDichVu = new List<ClsTKDichVu>();
                    listIn.Add(clsIn);
                }
                item.STT = clsIn.DSDichVu.Count + 1;
                clsIn.DSDichVu.Add(item);
            }


            ClsReportCommon<ClsTKDichVu> cls = new ClsReportCommon<ClsTKDichVu>();
            cls.tieuDeNgay = tdNgay;
            cls.Datas = new List<ClsTKDichVu>();
            cls.Datas.AddRange(listIn);
            RP020100 rp = new RP020100();
            rp.SetData(e_REPORTNTP.BC_KhamBenh_BacSi.ToString(), new List<ClsReportCommon<ClsTKDichVu>>() { cls });
            rp.ShowPreviewDialog();
        }

        private void btInTheoDichVu_Click(object sender, EventArgs e)
        {
            if (listTKDichVu == null)
            {
                return;
            }

            ClsReportCommon<ClsTKDichVu> cls = new ClsReportCommon<ClsTKDichVu>();
            cls.tieuDeNgay = tdNgay;
            cls.Datas = new List<ClsTKDichVu>();
            cls.Datas.AddRange(listTKDichVu);
            RP020100 rp = new RP020100();
            rp.SetData(e_REPORTNTP.BC_KhamBenh_DichVu.ToString(), new List<ClsReportCommon<ClsTKDichVu>>() { cls });
            rp.ShowPreviewDialog();
        }

        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {


            if (tabMain.SelectedTabPage == pageTKSuDungThuoc)
            {
                btInTheoBenhNhan.Enabled = false;
                btInTheoBacSi.Enabled = false;
                btInTheoDichVu.Enabled = false;
                teSearch.Enabled = false;
                clbNhom.Enabled = false;
            }
            else
            {
                btInTheoBenhNhan.Enabled = true;
                btInTheoBacSi.Enabled = true;
                btInTheoDichVu.Enabled = true;
                teSearch.Enabled = true;
                clbNhom.Enabled = true;
            }
        }

        private void cheTinhSL_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void viewMain_DoubleClick(object sender, EventArgs e)
        {
            ClsTKKhamBenh cls = (ClsTKKhamBenh)viewMain.GetFocusedRow();
            if (cls == null) return;
            ObBenhAn pt = MainNTP.ObBenhAnList.GetOb(cls.KeyPhieuKham);
            if (pt == null) return;
            if (pt.TrangThai == etrangthai.Đã_hủy.ToString())
            {
                MessageBox.Show("Phiếu đã hủy");
                return;
            }
            frmBenhAn frm = new frmBenhAn();
            frm.SetModify(pt);
            frm.ShowDialog();
        }
    }
}