using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hospital.App
{
    public partial class UDSDaThu : DevExpress.XtraEditors.XtraUserControl
    {
        public UDSDaThu()
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
        List<TT020110> listPhieuThu = new List<TT020110>();


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
            ObPhieuThu oo = (ObPhieuThu)ob.OBUPDATE;
            if (oo == null) return;
            bool kt = KiemTraDanhSach(oo);
            TT020110 or = listPhieuThu.Find(o => ob.IDOB == o.Ma.ToString());
            if (kt)
            {
                if (or == null)
                {
                    or = new TT020110();
                    listPhieuThu.Add(or);
                }
                or.SetNew(oo);
            }
            else
            {
                if (or != null)
                    listPhieuThu.Remove(or);
            }
            RefeshView();
        }

        bool KiemTraDanhSach(ObPhieuThu ob)
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
                    gridChidinh.DataSource = listPhieuThu;
                viewChidinh.RefreshData();
            }
        }

        private void LoadEvent() {
            MainNTP.ChangeDBItem.ChangeDB += ChangeDBItem_ChangeDB;
            MainNTP.ObPhieuThuList.ChangeDB += ObChiDinhList_ChangeDB;
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
            if (_obRecord.NameTBL == eTableName.PhieuThu.ToString())
            {
                RefreshList(_obRecord);
            }
            return _obRecord;
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            listPhieuThu.Clear();
            KeysListObPhieuThu keys = NTPObPhieuThu.GetListOb(deTuNgay.DateTime.Date, deDenNgay.DateTime.Date);
            if (keys != null)
            {
                foreach (var oo in keys)
                {
                    if (oo.TrangThai == etrangthai.Đã_hủy.ToString()) continue;
                    TT020110 dk = new TT020110();
                    dk.SetNew(oo);
                    listPhieuThu.Add(dk);
                }
            }
            RefeshView();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {

        }

        private void btHUY_DK_Click(object sender, EventArgs e)
        {

        }

        private void viewChidinh_DoubleClick(object sender, EventArgs e)
        {
            TT020110 ob = (TT020110)viewChidinh.GetFocusedRow();
            if (ob == null) return;
            ObPhieuThu pt = MainNTP.ObPhieuThuList.GetOb(ob.Ma);
            if (pt == null) return;
            if (pt.TrangThai == etrangthai.Đã_hủy.ToString()) {
                MessageBox.Show("Phiếu đã hủy");
                return;
            }
            frmPhieuThu frm = new frmPhieuThu();
            frm.SetModify(pt);
            frm.ShowDialog();
        }

    }
}