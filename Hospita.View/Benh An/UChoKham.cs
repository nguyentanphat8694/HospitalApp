using System;
using System.Collections.Generic;

namespace Hospital.App
{
    public partial class UChoKham : DevExpress.XtraEditors.XtraUserControl
    {
        public UChoKham()
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
        List<BA010110> listChiDinh = new List<BA010110>();
        List<string> listNhom = new List<string>();
        bool Thu_tien_sau = NTPUserSetting.ThutienSau;
        /// <summary>
        /// phương thức
        /// </summary>
        private void LoadControl()
        {

        }

        private void InitDisplay()
        {
            listNhom = NTPUserSetting.NhomKham;
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

        void RefreshListChiDinh(ObRecord ob)
        {
            ObCTChiDinh oo = (ObCTChiDinh)ob.OBUPDATE;
            if (oo == null) return;
            bool kt = KiemTraDanhSachCho(oo);
            string dichVuThuoc = "";
            BA010110 or = listChiDinh.Find(o => ob.IDOB == o.Ma.ToString());
            if (kt)
            {
                if (or == null)
                {
                    or = new BA010110();
                    listChiDinh.Add(or);
                }
                or.SetNew(oo);
                or.DichVuChiDinh = MainNTP.GetDichVuChiDinh(NTPObCTChiDinh.GetListOb(oo.KeyCreate,(int)eLoaiHH.Dịch_vụ));
                dichVuThuoc = MainNTP.GetThuocByBenhAn(or.Ma);
                if (dichVuThuoc != "")
                {
                    or.DichVuChiDinh += "\n" + dichVuThuoc;
                }
            }
            else
            {
                if (or != null)
                    listChiDinh.Remove(or);
            }


            RefreshView();
        }

        void RefreshView() {
            if (this.InvokeRequired)
            {
                this.Invoke(new NTPRefreshData(RefreshView), new object[] { });
            }
            else
            {
                if (gridDanhSach.DataSource == null)
                    gridDanhSach.DataSource = listChiDinh;
                viewDanhSach.RefreshData();
            }
        }

        private void LoadEvent()
        {
            MainNTP.ChangeDBItem.ChangeDB += ChangeDBItem_ChangeDB;
            MainNTP.ObCTChiDinhList.ChangeDB +=ObCTChiDinhList_ChangeDB;
        }

        bool KiemTraDanhSachCho(ObCTChiDinh ob)
        {
            if (NTPValidate.IsEmpty(ob.MaPK)) return false;
            if (ob.KeyThucHien > 0) return false;
            if (ob.TrangThai == etrangthai.Đã_hủy.ToString()) return false;
            if (ob.Ngay < deTuNgay.DateTime.Date || ob.Ngay > deDenNgay.DateTime.Date) return false;
            if (ob.TTChung.MienPhi) return true;
            if (!Thu_tien_sau)
                if (ob.KeyPT <= 0) return false;
            
            return true;
        }

        /// <summary>
        /// event
        /// </summary>
        void ObCTChiDinhList_ChangeDB(ObRecord _obRecord)
        {
            if (_obRecord == null) return;
            RefreshListChiDinh(_obRecord);
        }

        object ChangeDBItem_ChangeDB(ObRecord _obRecord)
        {
            if (_obRecord == null) return null;
            if (_obRecord.NameTBL == eTableName.CTChiDinh.ToString())
            {
                RefreshListChiDinh(_obRecord);
            }
            return _obRecord;
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            listChiDinh.Clear();
            KeysListObCTChiDinh keysList = MainNTP.ObCTChiDinhList.GetListOb(deTuNgay.DateTime.Date, deDenNgay.DateTime.Date);
            string dichVuThuoc = "";
            if (keysList != null)
            {
                foreach (var oo in keysList)
                {
                    if (!KiemTraDanhSachCho(oo)) continue;
                    BA010110 dk = new BA010110();
                    dk.SetNew(oo);
                    dk.DichVuChiDinh = MainNTP.GetDichVuChiDinh(keysList, oo.KeyCreate);
                    dichVuThuoc = MainNTP.GetThuocByBenhAn(dk.Ma);
                    if (dichVuThuoc != "")
                    {
                        dk.DichVuChiDinh += "\n" + dichVuThuoc;
                    }
                    listChiDinh.Add(dk);
                }
            }
            RefreshView();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void viewDanhSach_DoubleClick(object sender, EventArgs e)
        {
            BA010110 cls = (BA010110)viewDanhSach.GetFocusedRow();
            if (cls == null) return;
            frmBenhAn frm = new frmBenhAn();
            if (cls.KeyThucHien > 0)
            {
                frm.SetModify(MainNTP.ObBenhAnList.GetOb(cls.KeyThucHien));
            }
            else
            {
                frm.SetNew(cls);
            }
            frm.ShowDialog(this);
        }

        private void mnHuyDangKy_Click(object sender, EventArgs e)
        {
            BA010110 cls = (BA010110)viewDanhSach.GetFocusedRow();
            if (cls == null) return;

            MainNTP.HuyDangKy(MainNTP.ObChiDinhList.GetOb(cls.KeyCreate));
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
                viewDanhSach.ActiveFilterString = sql;
            }
            else
            {
                viewDanhSach.ClearColumnsFilter();
            }
        }
    }
}