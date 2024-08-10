using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hospital.App
{
    public partial class UDaKham : DevExpress.XtraEditors.XtraUserControl
    {
        public UDaKham()
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
        List<BA020110> listBenhAn = new List<BA020110>();


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

            btXem_Click(null, null);
        }

        void RefreshList(ObRecord ob)
        {
            ObBenhAn oo = (ObBenhAn)ob.OBUPDATE;
            if (oo == null) return;

            bool kt = KiemTraDanhSach(oo);
            BA020110 or = listBenhAn.Find(o => ob.IDOB == o.Ma.ToString());
            string dichVuThuoc = "";
            if (kt)
            {
                if (or == null)
                {
                    or = new BA020110();
                    listBenhAn.Add(or);
                }
                or.SetNew(oo);
                ObCTChiDinh cd = MainNTP.ObCTChiDinhList.GetOb(oo.KeyCTChiDinh);

                if (cd != null)
                {
                    ObChiDinh obCD = MainNTP.ObChiDinhList.GetOb(cd.KeyCreate);
                    if (obCD != null)
                    {
                        or.ChanDoanChinh = obCD.ChanDoan;
                    }
                    or.DichVuChiDinh = MainNTP.GetDichVuChiDinh(NTPObCTChiDinh.GetListOb(cd.KeyCreate, (int)eLoaiHH.Dịch_vụ));
                    dichVuThuoc = MainNTP.GetThuocByBenhAn(or.Ma);
                    if (dichVuThuoc != "")
                    {
                        or.DichVuChiDinh += "\n" + dichVuThuoc;
                    }
                }
            }
            else
            {
                if (or != null)
                    listBenhAn.Remove(or);
            }

            RefeshView();
        }

        bool KiemTraDanhSach(ObBenhAn ob) {

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
                    gridChidinh.DataSource = listBenhAn;
                viewChidinh.RefreshData();
            }
        }

        private void LoadEvent() {
            MainNTP.ChangeDBItem.ChangeDB += ChangeDBItem_ChangeDB;
            MainNTP.ObBenhAnList.ChangeDB += ObBenhAList_ChangeDB;
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
            if (_obRecord.NameTBL == eTableName.BenhAn.ToString())
            {
                RefreshList(_obRecord);
            }
            return _obRecord;
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            listBenhAn.Clear();
            KeysListObBenhAn keys = NTPObBenhAn.GetListOb(deTuNgay.DateTime.Date, deDenNgay.DateTime.Date);
            if (keys != null)
            {
                ObCTChiDinh cd = null;
                string dichVuThuoc = "";
                foreach (var oo in keys)
                {
                    if (!KiemTraDanhSach(oo))
                        continue;
                    BA020110 dk = new BA020110();
                    dk.SetNew(oo);
                    cd = MainNTP.ObCTChiDinhList.GetOb(oo.KeyCTChiDinh);
                    if (cd != null)
                    {
                        ObChiDinh obCD = MainNTP.ObChiDinhList.GetOb(cd.KeyCreate);
                        if (obCD != null)
                        {
                            dk.ChanDoanChinh = obCD.ChanDoan;
                        }

                        dk.DichVuChiDinh = MainNTP.GetDichVuChiDinh(NTPObCTChiDinh.GetListOb(cd.KeyCreate, (int)eLoaiHH.Dịch_vụ));
                        dichVuThuoc = MainNTP.GetThuocByBenhAn(dk.Ma);
                        if (dichVuThuoc != "")
                        {
                            dk.DichVuChiDinh += "\n" + dichVuThuoc;
                        }
                    }
                    listBenhAn.Add(dk);
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
            BA020110 ob = (BA020110)viewChidinh.GetFocusedRow();
            if (ob == null) return;
            ObBenhAn pt = MainNTP.ObBenhAnList.GetOb(ob.Ma);
            if (pt == null) return;
            if (pt.TrangThai == etrangthai.Đã_hủy.ToString()) {
                MessageBox.Show("Phiếu đã hủy");
                return;
            }
            frmBenhAn frm = new frmBenhAn();
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