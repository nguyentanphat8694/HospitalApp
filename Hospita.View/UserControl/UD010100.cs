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
    public partial class UD010100 : DevExpress.XtraEditors.XtraUserControl
    {
        public UD010100()
        {
            InitializeComponent();
            LoadData();
            InitDisplay();
        }
        string searchText = "Tìm Mã hoặc Tên dịch vụ";
        List<ClsDichVu> listDSDichVu = new List<ClsDichVu>();
        public List<ClsDichVu> listDichVu = new List<ClsDichVu>();
        List<ClsDichVu> listUpdate = new List<ClsDichVu>();
        List<ClsDichVu> listDelete = new List<ClsDichVu>();
        public string ChanDoan = "";
        void LoadData() {
            List<eTableName> list = new List<eTableName>();
            list.Add(eTableName.DMDichVu);
            list.Add(eTableName.DMNhomDichVu);

            MainNTP.GetData(list);
        }

        void InitDisplay() {
            foreach (var item in MainNTP.ObDMDichVuList)
            {
                if (item.Loai == (int)eLoaiHH.Dịch_vụ && !NTPUserSetting.NhomKham.Any(o=>o==item.TTChung.Nhom))
                {
                    ClsDichVu cls = new ClsDichVu();
                    cls.MaDV = item.Ma;
                    cls.Ten = item.Ten;
                    ObDMNhomDichVu nhom = MainNTP.ObDMNhomDichVuList.Get(item.TTChung.Nhom);
                    if (nhom != null)
                        cls.TenNhom = nhom.Ten;
                    listDSDichVu.Add(cls);
                }
            }

            gridDSDichVu.DataSource = listDSDichVu;
            viewDSDichVu.RefreshData();

            teSearch.Text = searchText;
        }

        void SetDichVu()
        {
            if (viewDSDichVu.IsGroupRow(viewDSDichVu.FocusedRowHandle))
            {
                return;
            }

            ClsDichVu cls = (ClsDichVu)viewDSDichVu.GetFocusedRow();
            if (cls == null) return;

            if (listDichVu.Any(o => o.MaDV == cls.MaDV)) {
                MessageBox.Show("Dịch vụ "+cls.Ten + " đã được chỉ định.");
                return;
            }
            ObDMDichVu dm = MainNTP.ObDMDichVuList.Get(cls.MaDV);
            if (dm != null)
                cls.DG = dm.TTChung.DG;
            cls.SL = 1;
            cls.Action = ActionRec.Insert;
            listDichVu.Add(cls);
            if (gridDichVu.DataSource == null)
                gridDichVu.DataSource = listDichVu;
            viewDichVu.RefreshData();

            teSearch.Text = "";
            viewDSDichVu.FocusedRowHandle = -1;
            teSearch.Focus();
        }

        public void SetDichVu(List<ObCTChiDinh> list)
        {
            listDichVu.Clear();
            foreach (var item in list)
            {
                ClsDichVu c2 = new ClsDichVu();
                c2.SetNew(item);
                c2.Action = ActionRec.None;
                ObDMDichVu dm = MainNTP.ObDMDichVuList.Get(c2.MaDV);
                if (dm != null)
                    c2.Ten = dm.Ten;
                listDichVu.Add(c2);
            }
            
            if (gridDichVu.DataSource == null)
                gridDichVu.DataSource = listDichVu;
            viewDichVu.RefreshData();
        }

        public void RefreshDichVu(ObCTChiDinh ob)
        {
            if (ob == null) return;
            ClsDichVu c2 = listDichVu.Find(o => o.Ma == ob.Ma);
            if (c2 != null)
            {
                c2.SetNew(ob);
                c2.Action = ActionRec.None;
                ObDMDichVu dm = MainNTP.ObDMDichVuList.Get(c2.MaDV);
                if (dm != null)
                    c2.Ten = dm.Ten;
            }
        }

        public void Clear() {
            listDichVu.Clear();
            gridDichVu.DataSource = listDichVu;
            viewDichVu.RefreshData();
        }

        public bool Save(DateTime _Ngay,double keyCreate,string maBN)
        {
            MainNTP.UpdateCellValueChanging(viewDichVu);
            foreach (var item in listDichVu)
            {
                if (item.Action == ActionRec.Insert)
                {
                    ObCTChiDinh ob = new ObCTChiDinh();
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
                ObCTChiDinh os = listDelete[i];
                if (os == null) continue;
                os.TrangThai = etrangthai.Đã_hủy.ToString();
                if (MainNTP.ObCTChiDinhList.DeleteOb(os,etrangthai.Đã_hủy))
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
            //teSearch.Text = "";
            //viewDichVu.ExpandAllGroups();
        }

        private void teSearch_Leave(object sender, EventArgs e)
        {
            if (teSearch.Text.Trim() == "")
                teSearch.Text = searchText;
        }

        private void mnXoaDong_Click(object sender, EventArgs e)
        {
            ClsDichVu cls = (ClsDichVu)viewDichVu.GetFocusedRow();
            if (cls == null) return;
            if (!NTPValidate.IsEmpty(cls.MaPK)) {
                MessageBox.Show("Dịch vụ khám. Không thể xóa!");
                return;
            }
            if (cls.Ma > 0) {
                ObCTChiDinh ct = MainNTP.ObCTChiDinhList.GetOb(cls.Ma);
                if (ct != null) {
                    if (ct.TrangThai == etrangthai.Hoàn_thành.ToString()) {
                        MessageBox.Show("Dịch vụ " + cls.Ten + " đã thực hiện. Không thể xóa!");
                        return;
                    }
                    if (ct.KeyPT>0)
                    {
                        MessageBox.Show("Dịch vụ " + cls.Ten + " đã thu tiền. Không thể xóa!");
                        return;
                    }
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ " + cls.Ten.ToUpper() + "?", "Cảnh bảo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    listDelete.Add(cls);
                }
            }
            
            viewDichVu.DeleteSelectedRows();

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

        bool KiemTraDanhSachCho(ObCTChiDinh ob)
        {
            string sv = ob.TenDV;
            if (ob.DMDichVu == null) return false;
            if (!NTPUserSetting.NhomSA.Any(o => o == ob.DMDichVu.TTChung.Nhom)) return false;
            if (ob.KeyThucHien > 0) return false;
            if (ob.TrangThai == etrangthai.Đã_hủy.ToString()) return false;
            if (!NTPUserSetting.ThutienSau)
                if (ob.KeyPT <= 0) return false;
            return true;
        }

        private void viewDichVu_DoubleClick(object sender, EventArgs e)
        {
            if (frmBenhAn.isShowSieuAm)
            {
                MessageBox.Show("Bạn đang thực hiện phiếu siêu âm. Vui lòng thoát phiếu siêu âm để tiếp tục");
                return;
            }

            ClsDichVu cls = (ClsDichVu)viewDichVu.GetFocusedRow();
            if (cls == null) return;

            frmSieuAm frm = null;

            if (cls.KeyThucHien <= 0)
            {
                ObCTChiDinh ct = MainNTP.ObCTChiDinhList.GetOb(cls.Ma);
                if (ct == null)
                {
                    MessageBox.Show("Vui lòng lưu bệnh án trước khi thực hiện dịch vụ này!");
                    return;
                }

                if (!KiemTraDanhSachCho(ct))
                {
                    return;
                }

                BA010110 or = new BA010110();
                or.SetNew(cls);
                or.ChanDoan = this.ChanDoan;

                frm = new frmSieuAm();
                frm.SetNew(or);
                frm.Show(this);
                frmBenhAn.isShowSieuAm = true;
                return;
            }

            if (cls.LoaiPhieuTH == (int)eLoaiPhieuTH.Sieu_Am) {

                ObCDHA ob = MainNTP.ObCDHAList.GetOb(cls.KeyThucHien);
                if (ob == null)
                {
                    return;
                }

                frm = new frmSieuAm();
                frm.SetModify(ob);
                frm.Show();
                frmBenhAn.isShowSieuAm = true;
            }
        }

        private void teSearch_Enter(object sender, EventArgs e)
        {
            teSearch.Text = "";
            viewDichVu.ExpandAllGroups();
        }
    }
}
