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
    public partial class UDSChoXN : DevExpress.XtraEditors.XtraUserControl
    {
        public UDSChoXN()
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
        List<string> listNhomDV = new List<string>();
        //List<string> listMau = new List<string>();
        //List<string> listPhuKhoa = new List<string>();
        //List<string> listLab256 = new List<string>();

        List<TT010110> listMau = new List<TT010110>();
        List<TT010110> listPhuKhoa = new List<TT010110>();
        List<TT010110> listLab256 = new List<TT010110>();

        DevExpress.XtraGrid.GridControl gridMau;
        DevExpress.XtraGrid.Views.Grid.GridView viewMau;

        DevExpress.XtraGrid.GridControl gridPhuKhoa;
        DevExpress.XtraGrid.Views.Grid.GridView viewPhuKhoa;

        DevExpress.XtraGrid.GridControl gridLab256;
        DevExpress.XtraGrid.Views.Grid.GridView viewLab256;

        public void setXN_Mau(DevExpress.XtraGrid.GridControl grid, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            gridMau = grid;
            viewMau = view;
        }

        public void setXN_PhuKhoa(DevExpress.XtraGrid.GridControl grid, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            gridPhuKhoa = grid;
            viewPhuKhoa = view;
        }

        public void setXN_Lab256(DevExpress.XtraGrid.GridControl grid, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            gridLab256 = grid;
            viewLab256 = view;
        }


        bool Thu_tien_sau = NTPUserSetting.ThutienSau;

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
                eTableName.DMDichVu,
                eTableName.DMNhomDichVu
            };

            MainNTP.GetData(listTable);

            listNhomDV = NTPUserSetting.NhomXN;
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
                //if (gridDanhSach.DataSource == null)
                //    gridDanhSach.DataSource = listChiDinh;
                //viewDanhSach.RefreshData();

                gridMau.DataSource = listMau;
                viewMau.RefreshData();

                //if (gridMau.DataSource == null)
                gridPhuKhoa.DataSource = listPhuKhoa;
                viewPhuKhoa.RefreshData();

                //if (gridMau.DataSource == null)
                gridLab256.DataSource = listLab256;
                viewLab256.RefreshData();

            }
        }

        void setDSTheoNhom(ObCTChiDinh oo, List<TT010110> list)
        {
            TT010110 or = list.Find(o => oo.Ma == o.Ma);
            bool kt = KiemTraDanhSachCho(oo);
            if (kt)
            {
                if (or == null)
                {
                    or = new TT010110();
                    list.Add(or);
                }
                or.SetNew(oo);

                or.listCTChiDinh = new List<ObCTChiDinh>() { oo };

                or.BT_Mau = oo.TTChung.BT_Mau;
                or.BT_Lab256 = oo.TTChung.BT_Lab256;
                or.BT_PhuKhoa = oo.TTChung.BT_PhuKhoa;
            }
            else
            {
                if (or != null)
                    list.Remove(or);
            }
        }

        void SetCTChiDinh(ObCTChiDinh oo) {

            string ten = oo.TenDV;

            if (oo.DMDichVu == null)
            {
                return;
            }

            if (NTPUserSetting.NhomXN_Mau.Any(o => o == oo.DMDichVu.TTChung.Nhom))
            {
                setDSTheoNhom(oo, listMau);
            }
            else if (NTPUserSetting.NhomXN_PhuKhoa.Any(o => o == oo.DMDichVu.TTChung.Nhom))
            {
                setDSTheoNhom(oo, listPhuKhoa);
            }
            else if (NTPUserSetting.NhomXN_Lab256.Any(o => o == oo.DMDichVu.TTChung.Nhom))
            {
                setDSTheoNhom(oo, listLab256);
            }

            //TT010110 pt = listChiDinh.Find(o => o.MaBN == oo.MaBN);
            //if (KiemTraDanhSachCho(oo))
            //{
            //    if (pt == null)
            //    {
            //        pt = new TT010110();
            //        pt.SetNew(oo);
            //        listChiDinh.Add(pt);
            //    }

            //    ObChiDinh obChiDinh = MainNTP.ObChiDinhList.GetOb(oo.KeyCreate);
            //    if (obChiDinh != null) {
            //        pt.BT_Lab256 = obChiDinh.TTChung.BT_Lab256;
            //        pt.BT_Mau = obChiDinh.TTChung.BT_Mau;
            //        pt.BT_PhuKhoa = obChiDinh.TTChung.BT_PhuKhoa;
            //    }

            //    ObCTChiDinh dv = pt.listCTChiDinh.Find(o => o.Ma == oo.Ma);
            //    if (dv == null)
            //        pt.listCTChiDinh.Add(oo);
            //    else dv.SetNew(oo);
            //}
            //else if (pt != null)
            //{
            //    ObCTChiDinh dv = pt.listCTChiDinh.Find(o => o.Ma == oo.Ma);
            //    if (dv != null)
            //        pt.listCTChiDinh.Remove(dv);
            //}

            //if (pt != null && pt.listCTChiDinh.Count == 0)
            //    listChiDinh.Remove(pt);
            
        }

        private void LoadEvent()
        {
            MainNTP.ChangeDBItem.ChangeDB += ChangeDBItem_ChangeDB;
            MainNTP.ObCTChiDinhList.ChangeDB += ObChiDinhList_ChangeDB;
        }

        bool KiemTraDanhSachCho(ObCTChiDinh ob)
        {
            string sv = ob.TenDV;
            if (ob.DMDichVu == null) return false;
            if (!listNhomDV.Any(o => o == ob.DMDichVu.TTChung.Nhom)) return false;
            //if (ob.KeyThucHien > 0) return false;
            if (ob.TrangThai == etrangthai.Đã_hủy.ToString()) return false;
            if (ob.Ngay < deTuNgay.DateTime.Date || ob.Ngay > deDenNgay.DateTime.Date) return false;
            if (!Thu_tien_sau)
                if (ob.KeyPT <= 0) return false;
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

        public void LayDuLieu(DateTime tuNgay, DateTime denNgay)
        {
            deTuNgay.DateTime = tuNgay;
            deDenNgay.DateTime = denNgay;

            listChiDinh.Clear();
            KeysListObCTChiDinh keysList = MainNTP.ObCTChiDinhList.GetListOb(tuNgay.Date, denNgay.Date);
            if (keysList == null) return;
            foreach (var oo in keysList)
            {
                SetCTChiDinh(oo);
            }

            RefrestView();
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
            
        }
    }
}