using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hospital.App
{
    public partial class USieuAm : DevExpress.XtraEditors.XtraUserControl
    {
        public USieuAm()
        {
            InitializeComponent();
            LoadData();
            InitDisplay();
            LoadControl();
            LoadEvent();
            btXem_Click(null, null);
        }

        /// <summary>
        /// khai báo
        /// </summary>
        List<SA020110> listCDHA = new List<SA020110>();
        

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
                eTableName.DMPK,
                eTableName.DMNhanSu
            };

            MainNTP.GetData(listTable);

            //btXem_Click(null, null);
        }

        void RefreshList(ObRecord ob)
        {
            ObCDHA oo = (ObCDHA)ob.OBUPDATE;
            if (oo == null) return;
            bool kt = KiemTraDanhSach(oo);
            SA020110 or = listCDHA.Find(o => ob.IDOB == o.Ma.ToString());

            if (kt)
            {
                if (or == null)
                {
                    or = new SA020110();
                    listCDHA.Add(or);
                }
                or.SetNew(oo);
            }
            else
            {
                if (or != null)
                    listCDHA.Remove(or);
            }
            RefeshView();
        }

        bool KiemTraDanhSach(ObCDHA ob)
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
                    gridChidinh.DataSource = listCDHA;
                viewChidinh.RefreshData();
            }
        }

        private void LoadEvent() {
            MainNTP.ChangeDBItem.ChangeDB += ChangeDBItem_ChangeDB;
            MainNTP.ObCDHAList.ChangeDB += ObBenhAList_ChangeDB;
        }

        bool KiemTraDS(ObCDHA ob) {
            if (ob.TrangThai == etrangthai.Đã_hủy.ToString()) return false;

            return true;
        }

        /// <summary>
        /// event
        /// </summary>
        void ObBenhAList_ChangeDB(ObRecord _obRecord)
        {
            if (_obRecord == null) return;
            RefreshList(_obRecord);
        }

        object ChangeDBItem_ChangeDB(ObRecord _obRecord)
        {
            if (_obRecord == null) return null;
            if (_obRecord.NameTBL == eTableName.CDHA.ToString())
            {
                RefreshList(_obRecord);
            }
            return _obRecord;
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            listCDHA.Clear();
            KeysListObCDHA keys = NTPObCDHA.GetListOb(deTuNgay.DateTime.Date, deDenNgay.DateTime.Date);
            if (keys != null)
            {
                foreach (var oo in keys)
                {
                    if (oo.TrangThai == etrangthai.Đã_hủy.ToString()) continue;
                    SA020110 dk = new SA020110();
                    dk.SetNew(oo);
                    listCDHA.Add(dk);
                }
            }
            RefeshView();
        }

        public void LayDuLieu(DateTime tuNgay, DateTime denNgay)
        {
            pnlLayDuLieu.Visible = false;

            deTuNgay.DateTime = tuNgay;
            deDenNgay.DateTime = denNgay;

            listCDHA.Clear();
            KeysListObCDHA keys = NTPObCDHA.GetListOb(deTuNgay.DateTime.Date, deDenNgay.DateTime.Date);
            if (keys != null)
            {
                foreach (var oo in keys)
                {
                    if (oo.TrangThai == etrangthai.Đã_hủy.ToString()) continue;
                    SA020110 dk = new SA020110();
                    dk.SetNew(oo);
                    listCDHA.Add(dk);
                }
            }
            RefeshView();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void btHUY_DK_Click(object sender, EventArgs e)
        {

        }

        private void viewChidinh_DoubleClick(object sender, EventArgs e)
        {
            SA020110 ob = (SA020110)viewChidinh.GetFocusedRow();
            if (ob == null) return;
            ObCDHA pt = MainNTP.ObCDHAList.GetOb(ob.Ma);
            if (pt == null) return;
            if (pt.TrangThai == etrangthai.Đã_hủy.ToString()) {
                MessageBox.Show("Phiếu đã hủy");
                return;
            }
            frmSieuAm frm = new frmSieuAm();
            frm.SetModify(pt);
            frm.ShowDialog();
        }

        private void teTim_EditValueChanged(object sender, EventArgs e)
        {
            string sql = "";
            if (teTim.Text.Trim() != "")
            {
                sql = "[MaBenhNhan] like '%" + teTim.Text + "%' OR [Ten] like '%" + teTim.Text + "%' OR [NamSinh] like '%" + teTim.Text + "%'";
            }

            if (sql != "")
            {
                viewChidinh.ActiveFilterString = sql;
            }
            else
            {
                viewChidinh.ClearColumnsFilter();
            }
        }

    }
}