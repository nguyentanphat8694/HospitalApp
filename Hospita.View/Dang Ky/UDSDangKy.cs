using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Hospital.App
{
    public partial class UDSDangKy : DevExpress.XtraEditors.XtraUserControl
    {
        public UDSDangKy()
        {
            InitializeComponent();
            //this.Icon = MainNTP.NTPICON;
            LoadData();
            InitDisplay();
            LoadControl();
            LoadEvent();
        }
        /// <summary>
        /// khai báo
        /// </summary>
        List<DK010210> listChiDinh = new List<DK010210>();


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
            ObChiDinh oo = (ObChiDinh)ob.OBUPDATE;
            if (oo == null) return;
            if (ob.Action == (int)ActionRec.Insert)
            {
                if (!listChiDinh.Any(o => o.Ma.ToString() == ob.IDOB))
                {
                    DK010210 dk = new DK010210();
                    dk.SetNew(oo);
                    listChiDinh.Add(dk);
                }
            }
            else if (ob.Action == (int)ActionRec.Update)
            {

                DK010210 or = listChiDinh.Find(o => ob.IDOB == o.Ma.ToString());
                if (or != null)
                {
                    or.SetNew(oo);
                }
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
                if (gridChidinh.DataSource == null)
                    gridChidinh.DataSource = listChiDinh;
                viewChidinh.RefreshData();
            }
        }
         
        private void LoadEvent() {
            MainNTP.ChangeDBItem.ChangeDB += ChangeDBItem_ChangeDB;
            MainNTP.ObChiDinhList.ChangeDB += ObChiDinhList_ChangeDB;
            MainNTP.ObCustomerList.ChangeDB += ObCustomerList_ChangeDB;
        }

        void ObCustomerList_ChangeDB(ObRecord _obRecord)
        {
            
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
            if (_obRecord.NameTBL == eTableName.ChiDinh.ToString())
            {
                RefreshListChiDinh(_obRecord);
            }
            return _obRecord;
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            listChiDinh.Clear();
            KeysListObChiDinh keys = MainNTP.ObChiDinhList.GetListOb(deTuNgay.DateTime.Date, deDenNgay.DateTime.Date);
            if (keys != null)
            {
                foreach (var oo in keys)
                {
                    DK010210 dk = new DK010210();
                    dk.SetNew(oo);
                    listChiDinh.Add(dk);
                }
            }
            RefreshView();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void btHUY_DK_Click(object sender, EventArgs e)
        {
            DK010210 cls = (DK010210)viewChidinh.GetFocusedRow();
            if (cls == null) return;
            MainNTP.HuyDangKy(MainNTP.ObChiDinhList.GetOb(cls.Ma));
        }

        private void btEDIT_DK_Click(object sender, EventArgs e)
        {
            DK010210 cls = (DK010210)viewChidinh.GetFocusedRow();
            if (cls == null) return;
            if (cls.TrangThai == etrangthai.Đã_hủy.ToString()) {
                MessageBox.Show("Phiếu đã hủy");
                return;
            }
            CD020100 frm = new CD020100();
            frm.SetModify(cls);
            frm.ShowDialog();
        }

        private void btEDIT_THE_Click(object sender, EventArgs e)
        {
            DK010210 cls = (DK010210)viewChidinh.GetFocusedRow();
            if (cls == null) return;
            ObCustomer bn = MainNTP.ObCustomerList.Get(cls.MaBN);
            if (bn == null) return;
            BN020100 frm = new BN020100();
            frm.SetBenhNhan(bn);
            frm.ShowDialog(this);
            viewChidinh.RefreshData();
        }

        private void viewChidinh_DoubleClick(object sender, EventArgs e)
        {
            btEDIT_DK_Click(null, null);
        }

        private void thayĐổiChỉĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btEDIT_DK_Click(null, null);
        }

        private void thayĐổiThôngTinBệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btEDIT_THE_Click(null, null);
        }

        private void hủyĐăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btHUY_DK_Click(null, null);
        }

    }
}