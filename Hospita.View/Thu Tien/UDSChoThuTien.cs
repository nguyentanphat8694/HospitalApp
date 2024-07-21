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
    public partial class UDSChoThuTien : DevExpress.XtraEditors.XtraUserControl
    {
        public UDSChoThuTien()
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
        List<TT010110> listChiDinh = new List<TT010110>();


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

        void RefreshListChiDinh(ObRecord ob)
        {
            ObCTChiDinh oo = (ObCTChiDinh)ob.OBUPDATE;
            if (oo == null) return;
            SetCTChiDinh(oo);
            RefrestView();
        }

        void RefrestView() {
            if (this.InvokeRequired)
            {
                this.Invoke(new NTPRefreshData(RefrestView), new object[] { });
            }
            else
            {
                if (gridDanhSach.DataSource == null)
                    gridDanhSach.DataSource = listChiDinh;
                viewDanhSach.RefreshData();
            }
        }

        void SetCTChiDinh(ObCTChiDinh oo) {
            TT010110 pt = listChiDinh.Find(o => o.MaBN == oo.MaBN);
            if (KiemTraDanhSachCho(oo))
            {
                if (pt == null)
                {
                    pt = new TT010110();
                    pt.SetNew(oo);
                    listChiDinh.Add(pt);
                }
                ObCTChiDinh dv = pt.listCTChiDinh.Find(o => o.Ma == oo.Ma);
                if (dv == null)
                    pt.listCTChiDinh.Add(oo);
                else dv.SetNew(oo);
            }
            else if (pt != null)
            {
                ObCTChiDinh dv = pt.listCTChiDinh.Find(o => o.Ma == oo.Ma);
                if (dv != null)
                    pt.listCTChiDinh.Remove(dv);
            }

            if (pt != null && pt.listCTChiDinh.Count == 0)
                listChiDinh.Remove(pt);
        }

        private void LoadEvent()
        {
            MainNTP.ChangeDBItem.ChangeDB += ChangeDBItem_ChangeDB;
            MainNTP.ObCTChiDinhList.ChangeDB += ObChiDinhList_ChangeDB;
        }

        bool KiemTraDanhSachCho(ObCTChiDinh ob)
        {
            if (ob.TTChung.MienPhi) return false;
            if (ob.KeyPT > 0) return false;
            if (ob.TrangThai == etrangthai.Đã_hủy.ToString()) return false;
            return true;
        }

        /// <summary>
        /// event
        /// </summary>
        void ObChiDinhList_ChangeDB(ObRecord _obRecord)
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
            if (keysList == null) return;
            foreach (var oo in keysList)
            {
                SetCTChiDinh(oo);
            }

            RefrestView();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {

        }

        private void viewDanhSach_DoubleClick(object sender, EventArgs e)
        {
            TT010110 cls = (TT010110)viewDanhSach.GetFocusedRow();
            if (cls == null) return;
            frmPhieuThu frm = new frmPhieuThu();
            frm.SetNew(cls);
            frm.ShowDialog();
        }
    }
}