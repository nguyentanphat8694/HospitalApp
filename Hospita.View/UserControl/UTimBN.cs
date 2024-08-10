using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hospital.App
{
    public partial class UTimBN : DevExpress.XtraEditors.XtraUserControl
    {

        public delegate void selectChange(object sender);
        public event selectChange SelectChange;
        protected virtual void _SelectChange(object sender)
        {
            if (SelectChange != null)
            {
                SelectChange(sender);
            }
        }

        public UTimBN()
        {
            InitializeComponent();
        }

        public bool idxClick = true;

        public UTimBN(List<ObCustomer> listSrc)
        {
            InitializeComponent();

            gridMain.DataSource = MainNTP.ObCustomerList;
            viewMain.RefreshData();
        }

        public void GetValue()
        {
            ppMain.Text = "";
            _SelectChange((ObCustomer)viewMain.GetFocusedRow());
        }

        public void ppMain_Click(object sender, EventArgs e)
        {
            if (ppMain.Text == "")
                ppMain.Text = "";
            if (idxClick)
            {
                if (!ppCtrMain.Visible)
                {
                    ppMain.ShowPopup();
                    ppMain.Focus();
                }
            }
            idxClick = !idxClick;
        }

        private void ppMain_Leave(object sender, EventArgs e)
        {
            if (ppMain.Text.Trim() == "")
                ppMain.Text = "";
        }

        private void ppMain_TextChanged(object sender, EventArgs e)
        {
            if (ppCtrMain.Visible == false)
            {
                ppMain.ShowPopup();
                ppMain.Focus();
            }

            string sql = "";
            if (ppMain.Text.Trim() != "")
                sql = " [Ma] like '%" + ppMain.Text + "%' OR [Ten] like '%" + ppMain.Text + "%' OR [Dienthoai] like '%" + ppMain.Text + "%' OR [Namsinh] like '%" + ppMain.Text + "%' OR [DiaChiFull] like '%" + ppMain.Text + "%'";
            
            if (sql != "")
                viewMain.ActiveFilterString = sql;
            else viewMain.ClearColumnsFilter();

        }

        private void viewMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetValue();
            }
        }

        private void viewMain_DoubleClick(object sender, EventArgs e)
        {
            GetValue();
        }

        private void ppMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetValue();
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                viewMain.Focus();
            }
        }

    }
}
