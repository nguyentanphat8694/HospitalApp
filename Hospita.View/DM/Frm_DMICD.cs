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
    public partial class Frm_DMICD : DevExpress.XtraEditors.XtraForm
    {
        public Frm_DMICD()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
        }
        List<ObDMICD> listDel = new List<ObDMICD>();
        public List<ObDMICD> listSrc = new List<ObDMICD>();
        List<ObDMICD[]> listUpd = new List<ObDMICD[]>();

        private void Frm_DMICD_Load(object sender, EventArgs e)
        {
            ReloadData();
            FillData();
        }
        public bool ReloadData()
        {
            DBStatic.ConnectDB(DadaConnect.connect_string);
            List<eTableName> listT = new List<eTableName> { 
                eTableName.DMICD
            };
            MainNTP.GetData(listT);
            return true;
        }
        #region CAC HAM XU LY DATA
        void FillData()
        {
            if (MainNTP.ObDMICDList == null) return;
            listSrc.Clear();
            foreach (ObDMICD ob in MainNTP.ObDMICDList)
            {
                ob._Action = ActionRec.None;
                listSrc.Add(new ObDMICD(ob));
            }
            itemThemdong.Visible = true;
            AddNewRow(false);

        }

        void AddNewRow(bool focus)
        {
            ObDMICD ob = new ObDMICD();
            ob._Action = ActionRec.Insert;
            listSrc.Add(ob);
            gridDanhmuc.DataSource = listSrc;
            viewDanhmuc.RefreshData();
            if (focus)
            {
                viewDanhmuc.FocusedRowHandle = viewDanhmuc.RowCount - 1;
                viewDanhmuc.FocusedColumn = colMa;
            }
        }

        void DeleteRows()
        {
            ObDMICD ob = (ObDMICD)viewDanhmuc.GetRow(viewDanhmuc.FocusedRowHandle);
            if (ob == null) return;
            viewDanhmuc.DeleteSelectedRows();

            if (ob._Action == ActionRec.Update)
            {
                ObDMICD[] os = listUpd.Find(o => o[1] == ob);
                os[0]._Action = ActionRec.Delete;
                listDel.Add(os[0]);
            }
            else if (ob._Action == ActionRec.None)
            {
                ob._Action = ActionRec.Delete;
                listDel.Add(ob);
            }
            viewDanhmuc.RefreshData();

            btSave.Enabled = true;
        }

        bool SaveChanged()
        {
            if (!btSave.Enabled) return true;
            if (!DBStatic.ConnectDB(DadaConnect.connect_string)) return false;
            foreach (ObDMICD ob in listSrc)
            {
                if (ob.Ma == "") continue;
                if (ob._Action == ActionRec.Insert)
                {
                    if (MainNTP.ObDMICDList.AddOb(ob)) ob._Action = ActionRec.None;
                }
                if (ob._Action == ActionRec.Update)
                {
                    ObDMICD[] os = listUpd.Find(o => (ob == o[1]));
                    if (os == null) continue;
                    if (MainNTP.ObDMICDList.UpdateOb(os[0].Ma, ob))
                    {
                        ob._Action = ActionRec.None;
                        listUpd.Remove(os);
                    }
                }
            }
            for (int i = 0; i < listDel.Count; i++)
            {
                if (MainNTP.ObDMICDList.DeleteOb(listDel[i]))
                {
                    listDel.RemoveAt(i); i--;
                }
            }
            btSave.Enabled = listSrc.Any(o => o.Ma != "" && o._Action != ActionRec.None) || listDel.Count > 0;
            /*DBStatic.DisConnectDB(main_QLyPhongkham._DataInfo);*/
            return true;
        }
        #endregion

        private void viewDanhmuc_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ObDMICD ob = (ObDMICD)viewDanhmuc.GetRow(viewDanhmuc.FocusedRowHandle);
            if (ob == null) return;
            if (colMa == e.Column)
            {
                if (listSrc.Any(o => o.Ma == ob.Ma && ob != o) && ob.Ma != "")
                {
                    MessageBox.Show("Mã " + ob.Ma + " của đối tượng bị trùng.");
                    viewDanhmuc.SelectCell(e.RowHandle, e.Column);
                    return;
                }
            }
            if (ob._Action != ActionRec.Insert)
            {

                ob._Action = ActionRec.Update;
            }

            if (viewDanhmuc.FocusedRowHandle == viewDanhmuc.RowCount - 1 && ob.Ma != "")
            {
                AddNewRow(false);
            }
            btSave.Enabled = true;
        }

        private void viewDanhmuc_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ObDMICD ob = (ObDMICD)viewDanhmuc.GetRow(viewDanhmuc.FocusedRowHandle);
            if (ob != null && ob._Action == ActionRec.None)
            {
                listUpd.Add(new ObDMICD[] { new ObDMICD(ob), ob });
            }
        }
        public void SetVisable()
        {
            btSave.Enabled = false;
            menuGrid.Visible = false;
            viewDanhmuc.OptionsBehavior.Editable = false;
            viewHoahongNS.OptionsBehavior.Editable = false;
        }

        private void btCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveChanged();
        }

        private void itemThemdong_Click(object sender, EventArgs e)
        {
            AddNewRow(false);
        }

        private void xóaDòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteRows();
        }
    }
}