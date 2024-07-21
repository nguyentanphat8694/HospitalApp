using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace Hospital.App
{
    public partial class UT010100 : DevExpress.XtraEditors.XtraUserControl
    {
        public UT010100()
        {
            InitializeComponent();
            LoadData();
            InitDisplay();
        }
        int slToiThieu = 0;
        string searchText = "Tìm Mã hoặc Tên dịch vụ";
        List<ClsDichVu> listDSDichVu = new List<ClsDichVu>();
        public List<ClsDichVu> listDichVu = new List<ClsDichVu>();
        List<ClsDichVu> listUpdate = new List<ClsDichVu>();
        List<ClsDichVu> listDelete = new List<ClsDichVu>();

        void LoadData() {
            List<eTableName> list = new List<eTableName>();
            list.Add(eTableName.DMThuoc);
            list.Add(eTableName.DMNhomDichVu);
            list.Add(eTableName.PhacDo);
            MainNTP.GetData(list);
        }

        void InitDisplay() {
            slToiThieu = NTPUserSetting.SLToiThieu;
            foreach (var item in MainNTP.ObDMThuocList)
            {
                if (item.Loai == (int)eLoaiHH.Thuốc)
                {
                    ClsDichVu cls = new ClsDichVu();
                    cls.MaDV = item.Ma;
                    cls.Ten = item.Ten;
                    cls.TinhTon = true;
                    ObDMNhomDichVu nhom = MainNTP.ObDMNhomDichVuList.Get(item.Ma);
                    if (nhom != null)
                        cls.TenNhom = nhom.Ten;
                    listDSDichVu.Add(cls);
                }
            }

            gridDSDichVu.DataSource = listDSDichVu;
            viewDSDichVu.RefreshData();

            teSearch.Text = searchText;

            lkPhacDo.Properties.DataSource = MainNTP.obPhacDoList;

            LoadCachDung();
        }
        
        void LoadCachDung() {
            ObDMTSo ob = MainNTP.ObDMTSoList.Get(eUserSetting.Cach_dung_thuoc.ToString());
            if (ob == null) return;
            List<string> ls = ob.Ten.Split(new string[] { ";" }, StringSplitOptions.None).ToList();
            rcboCachDung.Items.AddRange(ls);
        }

        void LoadPhacDo() {
            MainNTP.obPhacDoList = NTPObPhacDo.GetListOb();
            lkPhacDo.Properties.DataSource = MainNTP.obPhacDoList;
        }

        void SetDichVu()
        {
            ClsDichVu cls = (ClsDichVu)viewDSDichVu.GetFocusedRow();
            if (cls == null) return;

            ObDMDichVu dm = MainNTP.ObDMDichVuList.Get(cls.MaDV);
            if (dm != null)
            {
                cls.DG = dm.TTChung.DG;
                cls.TTChung.LanDung = dm.TTChung.LanDung;
                cls.TTChung.LieuDung = dm.TTChung.LieuDung;
                cls.TTChung.CachDung = dm.TTChung.CachDung;
                cls.HoatChat = dm.TTChung.HoatChat;
                cls.HamLuong = dm.TTChung.HamLuong;
                cls.DuongDung = dm.TTChung.DuongDung;
            }
            cls.SL = 1;
            cls.Action = ActionRec.Insert;
            listDichVu.Add(cls);
            if (gridDichVu.DataSource == null)
                gridDichVu.DataSource = listDichVu;
            viewDichVu.RefreshData();
            gridDichVu.Focus();
            viewDichVu.Focus();
            viewDichVu.FocusedRowHandle = viewDichVu.RowCount - 1;
            viewDichVu.FocusedColumn = colSL;            
            viewDichVu.SelectCell(viewDichVu.FocusedRowHandle, colSL);
        }

        public void SetDichVu(KeysListObCTChiDinh list)
        {
            listDichVu.Clear();
            foreach (var item in list)
            {
                ClsDichVu c2 = new ClsDichVu();
                c2.SetNew(item);
                c2.Action = ActionRec.None;
                ObDMDichVu dm = MainNTP.ObDMThuocList.Get(c2.MaDV);
                if (dm != null)
                    c2.Ten = dm.Ten;
                listDichVu.Add(c2);
            }
            
            if (gridDichVu.DataSource == null)
                gridDichVu.DataSource = listDichVu;
            viewDichVu.RefreshData();
        }

        public void Clear() {
            listDichVu.Clear();
        }

        public void SaveCachDung() {
            try
            {
                string cd = "";
                ObDMTSo ob = MainNTP.ObDMTSoList.Get(eUserSetting.Cach_dung_thuoc.ToString());
                if (ob == null)
                {
                    ob = new ObDMTSo();
                    ob.Ma = eUserSetting.Cach_dung_thuoc.ToString();
                    ob.Ten = cd;
                    MainNTP.ObDMTSoList.AddOb(ob);
                }
                List<string> ls = ob.Ten.Split(new string[] { ";" }, StringSplitOptions.None).ToList();
                foreach (var item in listDichVu)
                {
                    if (item.TTChung.CachDung == null || item.TTChung.CachDung.Trim() == "") continue;
                    if (ls.Any(o => o.Trim() == item.TTChung.CachDung.Trim())) continue;
                    ls.Add(item.TTChung.CachDung.Trim());
                }
                foreach (var item in ls)
                {
                    if (cd != "")
                        cd += ";";
                    cd += item;
                }
                ob.Ten = cd;
                MainNTP.ObDMTSoList.UpdateOb(ob.Ma, ob);
            }
            catch { }
            
        }

        public bool Save(DateTime _Ngay, double keyCreate, string maBN,string bacsi)
        {
            SaveCachDung();
            foreach (var item in listDichVu)
            {
                if (item.Action == ActionRec.Insert)
                {
                    ClsDichVu ob = new ClsDichVu();
                    ob.Ngay = _Ngay;
                    ObDMDichVu dm = MainNTP.ObDMDichVuList.Get(item.MaDV);
                    if (dm == null) dm = MainNTP.ObDMDichVuList.GetOb(item.MaDV);
                    ob.MaDV = item.MaDV;
                    ob.LoaiHangHoa = dm.Loai;
                    ob.SL = item.SL;
                    ob.DG = dm.TTChung.DG;
                    ob.KeyCreate = keyCreate;
                    //ob.ThanhTien = item.ThanhTien;
                    ob.TrangThai = etrangthai.Đang_chờ.ToString();
                    ob.MaBN = maBN;
                    ob.Ma = MainNTP.ObCTChiDinhList.GetID();
                    ob.BSCreate = bacsi;
                    ob.TTChung.LanDung = item.TTChung.LanDung;
                    ob.TTChung.CachDung = item.TTChung.CachDung;
                    ob.TTChung.LieuDung = item.TTChung.LieuDung;
                    ob.TTChung.MuaNgoai = item.TTChung.MuaNgoai;
                    if (MainNTP.ObCTChiDinhList.AddOb(ob))
                        item.Action = ActionRec.None;
                }
                if (item.Action == ActionRec.Update)
                {
                    ClsDichVu os = listUpdate.Find(o => (item.Ma == o.Ma));
                    if (os == null) continue;
                    if (MainNTP.ObCTChiDinhList.UpdateOb(os))
                    {
                        item.Action = ActionRec.None;
                        listUpdate.Remove(item);
                    }
                }
            }
            for (int i = 0; i < listDelete.Count; i++)
            {
                if (MainNTP.ObCTChiDinhList.DeleteOb(listDelete[i]))
                {
                    listDelete.RemoveAt(i); i--;
                }
            }
            return true;
        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void teSearch_EditValueChanged(object sender, EventArgs e)
        {
            if (teSearch.Text.Trim() == "")
            {
                viewDSDichVu.ClearColumnsFilter();
                viewDSDichVu.CollapseAllGroups();
            }
            else if (!teSearch.Text.Contains(searchText))
            {
                viewDSDichVu.ExpandAllGroups();
                viewDSDichVu.ActiveFilterString = "[MaDV] like '" + teSearch.Text + "%' OR [Ten] like '%" + teSearch.Text + "%'";

            }
        }

        private void teSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down) {
                viewDSDichVu.Focus();
                if (viewDSDichVu.FocusedRowHandle < 0)
                    viewDSDichVu.FocusedRowHandle = 0;
                else viewDSDichVu.FocusedRowHandle += 1;
            }
            else if (e.KeyCode == Keys.Enter) {
                SetDichVu();
            }
        }

        private void viewDSDichVu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetDichVu();
            }
        }

        private void viewDSDichVu_DoubleClick(object sender, EventArgs e)
        {
            SetDichVu();
        }

        private void teSearch_Click(object sender, EventArgs e)
        {
            teSearch.Text = "";
        }

        private void teSearch_Leave(object sender, EventArgs e)
        {
            if (teSearch.Text.Trim() == "")
                teSearch.Text = searchText;
        }

        private void mnXoaDong_Click(object sender, EventArgs e)
        {
            int[] mangIndex = viewDichVu.GetSelectedRows();
            bool flag = false;
            if (mangIndex != null)
            {
                foreach (var idx in mangIndex)
                {
                    ClsDichVu cls = (ClsDichVu)viewDichVu.GetRow(idx);
                    if (cls == null) continue;
                    if (!NTPValidate.IsEmpty(cls.MaPK))
                    {
                        MessageBox.Show("Dịch vụ khám. Không thể xóa!");
                        continue;
                    }
                    if (cls.Ma > 0)
                    {
                        ObCTChiDinh ct = MainNTP.ObCTChiDinhList.GetOb(cls.Ma);
                        if (ct != null)
                        {
                            if (ct.TrangThai == etrangthai.Hoàn_thành.ToString())
                            {
                                MessageBox.Show("Dịch vụ " + cls.Ten + " đã thực hiện. Không thể xóa!");
                                continue;
                            }
                            if (ct.KeyPT > 0)
                            {
                                MessageBox.Show("Dịch vụ " + cls.Ten + " đã thu tiền. Không thể xóa!");
                                continue;
                            }

                            if (!flag && MessageBox.Show("Bạn có chắc chắn muốn xóa thuốc " + cls.Ten.ToUpper() + "?", "Cảnh bảo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                continue;
                            }

                            flag = true;

                            listDelete.Add(cls);

                        }
                    }
                }

                viewDichVu.DeleteSelectedRows();
            }
        }

        private void viewDichVu_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ClsDichVu cls = (ClsDichVu)viewDichVu.GetFocusedRow();
            if (cls == null) return;
            if (cls.Action != ActionRec.Insert)
                cls.Action = ActionRec.Update;
        }

        private void viewDichVu_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ClsDichVu cls = (ClsDichVu)viewDichVu.GetFocusedRow();
            if (cls == null) return;
            if (cls.Action == ActionRec.None)
            {
                listUpdate.Add(cls);
            }
        }

        private void lưuMớiPhácĐồToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listDichVu.Count == 0) {
                MessageBox.Show("Vui lòng thêm dịch vụ cần tạo phác đồ");
                return;
            }
            frmText frm = new frmText();
            frm.ShowDialog();
            if (frm.ten.Trim() != "")
            {
                ObPhacDo ob = new ObPhacDo();
                ob.Ma = MainNTP.obPhacDoList.GetID();
                ob.Ten = frm.ten;
                ob.Ngay = MainNTP._Ngay;
                ob.Loai = (int)eLoaiHH.Thuốc;
                ob.TTChung.ListDichVu = new List<ClsDichVu>(listDichVu);
                MainNTP.obPhacDoList.AddOb(ob);
                MessageBox.Show("Phác đồ " + " đã được tạo.");
                LoadPhacDo();
            }
        }

        private void cậpNhậtPhácĐồToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lkPhacDo.EditValue == null || lkPhacDo.EditValue.ToString() == "") {
                MessageBox.Show("Vui lòng chọn phác đồ cần cập nhật");
                return;
            }
            if (listDichVu.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm dịch vụ cần tạo phác đồ");
                return;
            }

            ObPhacDo ob = MainNTP.obPhacDoList.GetOb(MainNTP.ParseDouble(lkPhacDo.EditValue.ToString()));
            if (ob == null) return;
            ob.TTChung.ListDichVu = new List<ClsDichVu>(listDichVu);
            MainNTP.obPhacDoList.UpdateOb(ob);
            MessageBox.Show("Phác đồ " + " đã được cập nhật.");
            LoadPhacDo();
        }

        private void xóaPhácĐồToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lkPhacDo.EditValue == null || lkPhacDo.EditValue.ToString() == "")
            {
                MessageBox.Show("Vui lòng chọn phác đồ cần cập nhật");
                return;
            }
            ObPhacDo ob = MainNTP.obPhacDoList.GetOb(MainNTP.ParseDouble(lkPhacDo.EditValue.ToString()));
            if (ob == null) return;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phác đồ " + lkPhacDo.Text + " không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            MainNTP.obPhacDoList.DeleteOb(ob);
            LoadPhacDo();
        }

        private void lkPhacDo_EditValueChanged(object sender, EventArgs e)
        {
            if (lkPhacDo.EditValue == null || lkPhacDo.EditValue.ToString() == "")
                return;

            ObPhacDo ob = MainNTP.obPhacDoList.GetOb(MainNTP.ParseDouble(lkPhacDo.EditValue.ToString()));
            if (ob == null || ob.TTChung.ListDichVu == null) { return; }

            foreach (var item in ob.TTChung.ListDichVu)
            {
                item.Action = ActionRec.Insert;
                listDichVu.Add(item);
            }

            if (gridDichVu.DataSource == null)
                gridDichVu.DataSource = listDichVu;
            viewDichVu.RefreshData();
        }

        private void viewDSDichVu_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            ClsDichVu cls = (ClsDichVu)viewDSDichVu.GetRow(e.RowHandle);
            if (cls == null) return;
            double slTon = cls.SLTon;

            if (slTon == 0)
            {
                e.Appearance.BackColor = Color.Red;
            }
            else  if (cls.SLTon < slToiThieu)
            {
                e.Appearance.BackColor = Color.Pink;
            }

        }

        private void viewDichVu_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void viewDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
        }

        private void viewDichVu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (viewDichVu.FocusedColumn == colSL)
                {
                    //viewDichVu.FocusedColumn = colLanDung;
                    //viewDichVu.SelectCell(viewDichVu.FocusedRowHandle, colLanDung);
                    //teSearch.Text = ""; 
                    teSearch.Focus();

                }
                else if (viewDichVu.FocusedColumn == colLanDung)
                {
                    viewDichVu.FocusedColumn = colLieuDung;
                    viewDichVu.SelectCell(viewDichVu.FocusedRowHandle, colLieuDung);
                }
                else if (viewDichVu.FocusedColumn == colLieuDung)
                {
                    viewDichVu.FocusedColumn = colCachDung;
                    viewDichVu.SelectCell(viewDichVu.FocusedRowHandle, colCachDung);
                }
                else if (viewDichVu.FocusedColumn == colCachDung)
                {
                    //gridDSDichVu.Focus();
                }
            }
            else if (e.KeyCode == Keys.Tab)
            {
                if (viewDichVu.FocusedColumn == colSL)
                {
                    //viewDichVu.FocusedColumn = colLanDung;
                    //viewDichVu.SelectCell(viewDichVu.FocusedRowHandle, colLanDung);
                    //teSearch.Text = "";
                    teSearch.Focus();

                }
            }
        }
    }
}
