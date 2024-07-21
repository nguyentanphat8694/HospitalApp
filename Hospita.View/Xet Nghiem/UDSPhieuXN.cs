using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace Hospital.App
{
    public partial class UDSPhieuXN : DevExpress.XtraEditors.XtraUserControl
    {
        public UDSPhieuXN()
        {
            InitializeComponent();
            LoadData();
            InitDisplay();
            LoadControl();
            LoadEvent();
        }
        /// <summary>
        /// khai báo
        /// </summary>
        List<XN020110> listXetNghiem = new List<XN020110>();


        /// <summary>
        /// phương thức
        /// </summary>
        private void LoadControl()
        {

        }

        private void InitDisplay()
        {
            
        }

        private void LoadData()
        {
            deTuNgay.DateTime = deDenNgay.DateTime = MainNTP._Ngay;

            List<eTableName> listTable = new List<eTableName> {
                eTableName.Customer,
                eTableName.DMPK
            };

            MainNTP.GetData(listTable);

            btXem_Click(null, null);
        }

        void RefreshList(ObRecord ob)
        {
            ObPhieuXetNghiem oo = (ObPhieuXetNghiem)ob.OBUPDATE;
            if (oo == null) return;
            bool kt = KiemTraDanhSach(oo);
            XN020110 or = listXetNghiem.Find(o => ob.IDOB == o.Ma.ToString());
            if (kt)
            {
                if (or == null)
                {
                    or = new XN020110();
                    listXetNghiem.Add(or);
                }
                or.SetNew(oo);
            }
            else
            {
                if (or != null)
                    listXetNghiem.Remove(or);
            }
            RefeshView();
        }

        bool KiemTraDanhSach(ObPhieuXetNghiem ob)
        {
            if (ob.TrangThai == etrangthai.Đã_hủy.ToString()) return false;
            return true;
        }

        void RefeshView() {
            if (this.InvokeRequired)
            {
                this.Invoke(new NTPRefreshData(RefeshView), new object[] { });
            }
            else
            {
                if (gridChidinh.DataSource == null)
                    gridChidinh.DataSource = listXetNghiem;
                viewChidinh.RefreshData();
            }
        }

        private void LoadEvent() {
            MainNTP.ChangeDBItem.ChangeDB += ChangeDBItem_ChangeDB;
            MainNTP.ObPhieuXetNghiemList.ChangeDB += ObChiDinhList_ChangeDB;
        }

        /// <summary>
        /// event
        /// </summary>
        void ObChiDinhList_ChangeDB(ObRecord _obRecord)
        {
            if (_obRecord == null) return;
            RefreshList(_obRecord);
        }

        object ChangeDBItem_ChangeDB(ObRecord _obRecord)
        {
            if (_obRecord == null) return null;
            if (_obRecord.NameTBL == eTableName.PhieuXetNghiem.ToString())
            {
                RefreshList(_obRecord);
            }
            return _obRecord;
        }

        public void LayDuLieu(DateTime tuNgay, DateTime denNgay)
        {
            deTuNgay.DateTime = tuNgay;
            deDenNgay.DateTime = denNgay;

            listXetNghiem.Clear();
            KeysListObPhieuXetNghiem keys = NTPObPhieuXetNghiem.GetListOb(tuNgay.Date, denNgay.Date);
            if (keys != null)
            {
                foreach (var oo in keys)
                {
                    if (oo.TrangThai == etrangthai.Đã_hủy.ToString()) continue;
                    XN020110 dk = new XN020110();
                    dk.SetNew(oo);
                    listXetNghiem.Add(dk);
                }
            }
            RefeshView();
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            listXetNghiem.Clear();
            KeysListObPhieuXetNghiem keys = NTPObPhieuXetNghiem.GetListOb(deTuNgay.DateTime.Date, deDenNgay.DateTime.Date);
            if (keys != null)
            {
                foreach (var oo in keys)
                {
                    if (oo.TrangThai == etrangthai.Đã_hủy.ToString()) continue;
                    XN020110 dk = new XN020110();
                    dk.SetNew(oo);
                    listXetNghiem.Add(dk);
                }
            }
            RefeshView();
        }

        public void SetMau(Color mau)
        {
            XN020110 ob = (XN020110)viewChidinh.GetFocusedRow();
            if (ob == null)
            {
                return;
            }

            ob.TTChung.BgColor = mau;
            MainNTP.ObPhieuXetNghiemList.UpdateOb(ob);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
        }

        private void btHUY_DK_Click(object sender, EventArgs e)
        {

        }

        private void viewChidinh_DoubleClick(object sender, EventArgs e)
        {
            return;
            XN020110 ob = (XN020110)viewChidinh.GetFocusedRow();
            if (ob == null) return;
            ObPhieuXetNghiem pt = MainNTP.ObPhieuXetNghiemList.GetOb(ob.Ma);
            if (pt == null) return;
            if (pt.TrangThai == etrangthai.Đã_hủy.ToString()) {
                MessageBox.Show("Phiếu đã hủy");
                return;
            }
            frmPhieuXetNghiem frm = new frmPhieuXetNghiem();
            frm.SetModify(pt);
            frm.ShowDialog();
        }

        private void cheBatThuong_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            if (cheBatThuong.Checked)
                sql = "[BatThuong] ='true'";
            if (cheDaXuLy.Checked)
            {
                if (sql != "")
                    sql += " AND ";
                sql += "[TTChung.DaXuLy] = 'True'";
            }

            if (sql != "")
                viewChidinh.ActiveFilterString = sql;
            else viewChidinh.ClearColumnsFilter();
        }

        public void Filter(bool batThuong, bool daXuLy)
        {
            string sql = "";
            if (batThuong)
                sql = "[BatThuong] ='true'";
            if (daXuLy)
            {
                if (sql != "")
                    sql += " AND ";
                sql += "[TTChung.DaXuLy] = 'True'";
            }

            if (sql != "")
                viewChidinh.ActiveFilterString = sql;
            else viewChidinh.ClearColumnsFilter();
        }

        private void viewChidinh_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            XN020110 cls = (XN020110)viewChidinh.GetRow(e.RowHandle);
            if (cls == null) {
                return;
            }

            e.Appearance.ForeColor = cls.TTChung.BgColor;
        }

    }
}