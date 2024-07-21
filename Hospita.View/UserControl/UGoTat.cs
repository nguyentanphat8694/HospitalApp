using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hospital.App
{
    public partial class UGoTat : DevExpress.XtraEditors.XtraUserControl
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

        List<ClsGoTat> listSrc = new List<ClsGoTat>();

        public UGoTat()
        {
            InitializeComponent();
        }

        public bool idxClick = true;
        public int loai = 1;

        public UGoTat(List<ClsGoTat> list)
        {
            InitializeComponent();

            listSrc.Clear();
            foreach (var item in list)
            {
                listSrc.Add(item);
            }

            gridMain.DataSource = listSrc;
            viewMain.RefreshData();
        }

        public void GetValue()
        {
            ClsGoTat cls = (ClsGoTat)viewMain.GetFocusedRow();
            if (cls == null)
            {
                ThemICD();
            }
            else
            {
                ppMain.Text = "";
                _SelectChange(cls);
            }
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
                sql = " [Ten] like '%" + ppMain.Text + "%'";
            
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

        private void ppMain_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                if (ppCtrMain.Visible)
                {
                    ppMain_Click(null, null);
                }

                ThemICD();
            }
        }

        void ThemICD()
        {
            ObDMICD ob = new ObDMICD();
            ob.Ma = DateTime.Now.ToString("ddMMyyHHmmss");
            ob.Ten = ppMain.Text.Trim();
            ob.Loai = loai;
            MainNTP.ObDMICDList.AddOb(ob);
            ClsGoTat cls = new ClsGoTat()
            {
                Ma = ob.Ma,
                Ten = ob.Ten,
            };

            listSrc.Add(cls);

            ppMain.Text = "";
            viewMain.RefreshData();
            _SelectChange(cls);
        }

    }
}
