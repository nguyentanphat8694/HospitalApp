using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hospital.App
{
    public partial class frmDSHenKham : DevExpress.XtraEditors.XtraForm
    {
        public frmDSHenKham()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            deTuNgay.DateTime = deDenNgay.DateTime = MainNTP._Ngay;
            btXem_Click(null, null);
        }

        List<HK010210> listHK = new List<HK010210>();

        void RefreshView()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new NTPRefreshData(RefreshView), new object[] { });
            }
            else
            {
                if (gridHenKham.DataSource == null)
                    gridHenKham.DataSource = listHK;
                viewHenKham.RefreshData();
            }
        }

        void TinhNgay() {
            deTuNgay.DateTime = MainNTP._Ngay;
            if (cboSoNgay.SelectedIndex == 0)
                deDenNgay.DateTime = deTuNgay.DateTime.AddDays((int)teSoNgay.Value);
            else if (cboSoNgay.SelectedIndex == 1)
                deDenNgay.DateTime = deTuNgay.DateTime.AddDays(((int)teSoNgay.Value * 7));
            else if (cboSoNgay.SelectedIndex == 2)
                deDenNgay.DateTime = deTuNgay.DateTime.AddMonths((int)teSoNgay.Value);
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            listHK.Clear();
            KeysListObHenKham keys = null;
            if (teChanDoan.Text.Trim() != "")
                keys = NTPObHenKham.GetListOb(teChanDoan.Text.Trim());
            else keys = NTPObHenKham.GetListOb(deTuNgay.DateTime.Date, deDenNgay.DateTime.Date);
            if (keys != null)
            {
                foreach (var oo in keys)
                {
                    HK010210 dk = new HK010210();
                    dk.SetNew(oo);
                    listHK.Add(dk);
                }
            }
            RefreshView();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void teChanDoan_EditValueChanged(object sender, EventArgs e)
        {
            string sql="";
            if (teChanDoan.Text.Trim() != "")
                sql = "ChanDoan like '%" + teChanDoan.Text.Trim() + "%'";
            if (sql != "")
                viewHenKham.ActiveFilterString = sql;
            else viewHenKham.ClearColumnsFilter();
        }

        private void teSoNgay_ValueChanged(object sender, EventArgs e)
        {
            TinhNgay();
        }

        private void cboSoNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhNgay();
        }

        private void btDangKy_Click(object sender, EventArgs e)
        {
            HK010210 cls = (HK010210)viewHenKham.GetFocusedRow();
            if (cls == null)
                return;

            MainNTP.DangKyHTK(cls);
        }
    }
}