using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Hospital.App
{
    public partial class SA000000 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public SA000000()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            InitDisplay();

        }

        frmDSChoSA frmChoKham = null;
        frmDSSieuAm frmDanhSach = null;

        void InitDisplay()
        {
            DevExpress.XtraBars.Docking2010.DocumentManager manager = new DevExpress.XtraBars.Docking2010.DocumentManager();
            manager.MdiParent = this;
            manager.View = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView();

        }
        void LoadControl()
        {
            LoadControlChoKham();
            LoadControlDanhSach();
        }

        void LoadControlChoKham()
        {
            try
            {
                if (frmChoKham == null)
                {
                    frmChoKham = new frmDSChoSA();
                    frmChoKham.MdiParent = frmDSChoSA.ActiveForm;
                    frmChoKham.WindowState = FormWindowState.Maximized;
                    frmChoKham.FormClosed += frmDangKy_FormClosed;
                    frmChoKham.Show();
                }
                else frmChoKham.Activate();
            }
            catch
            {
            }
        }

        void LoadControlDanhSach()
        {
            try
            {
                if (frmDanhSach == null)
                {
                    frmDanhSach = new frmDSSieuAm();
                    frmDanhSach.MdiParent = frmDSSieuAm.ActiveForm;
                    frmDanhSach.WindowState = FormWindowState.Maximized;
                    frmDanhSach.FormClosed += frmDanhSach_FormClosed;
                    frmDanhSach.Show();
                }
                else frmDanhSach.Activate();
            }
            catch
            {
            }
        }




        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmDanhSach_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDanhSach = null;
        }

        void frmDangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChoKham = null;
        }

        private void btDanhSachDangKy_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlChoKham();
        }

        private void DK000000_Shown(object sender, EventArgs e)
        {
            LoadControl();
            frmChoKham.Activate();
            ribbon.Minimized = true;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadControlDanhSach();
        }
    }
}