using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
namespace Hospital.App
{
    public partial class Frm_DMUser : DevExpress.XtraEditors.XtraForm
    {
        public Frm_DMUser()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
        }
        List<ObUser> listDel = new List<ObUser>();
        public List<ObUser> listSrc = new List<ObUser>();
        List<ObUser[]> listUpd = new List<ObUser[]>();
        public List<ePhanquyen> listQUYEN
        {
            get
            {
                List<ePhanquyen> lt = new List<ePhanquyen>();
                int idx = 0; while (true) { try { ePhanquyen ts = (ePhanquyen)idx; if (ts.ToString() == idx.ToString()) break; lt.Add((ePhanquyen)idx++); } catch { break; } }
                return lt;
            }
        }
        private void Frm_User_Load(object sender, EventArgs e)
        {
            ReloadData();
            FillData();
        }
        public bool ReloadData()
        {
            DBStatic.ConnectDB(DadaConnect.connect_string);
            List<eTableName> listT = new List<eTableName> { 
                eTableName.User,
                eTableName.DMNhanSu
            };
            MainNTP.GetData(listT);
            return true;
        }
        #region CAC HAM XU LY DATA
        void FillData()
        {
            if (MainNTP.ObUserList == null) return;
            listSrc.Clear();
            foreach (ObUser ob in MainNTP.ObUserList)
            {
                ob._Action = ActionRec.None;
                listSrc.Add(new ObUser(ob));
            }
            itemThemdong.Visible = true;
            AddNewRow(false);
            //
            rlkNHANSU.DataSource = MainNTP.ObDMNhanSuList;
            cbQUYEN.Items.AddRange(listQUYEN);
        }

        void AddNewRow(bool focus)
        {
            ObUser ob = new ObUser();
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
            ObUser ob = (ObUser)viewDanhmuc.GetRow(viewDanhmuc.FocusedRowHandle);
            if (ob == null) return;
            viewDanhmuc.DeleteSelectedRows();

            if (ob._Action == ActionRec.Update)
            {
                ObUser[] os = listUpd.Find(o => o[1] == ob);
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
            foreach (ObUser ob in listSrc)
            {
                if (ob.UserName == "") continue;
                if (ob._Action == ActionRec.Insert)
                {
                    if (MainNTP.ObUserList.AddOb(ob)) ob._Action = ActionRec.None;
                }
                if (ob._Action == ActionRec.Update)
                {
                    ObUser[] os = listUpd.Find(o => (ob == o[1]));
                    if (os == null) continue;
                    if (MainNTP.ObUserList.UpdateOb(os[0].UserName, ob))
                    {
                        ob._Action = ActionRec.None;
                        listUpd.Remove(os);
                    }
                }
            }
            for (int i = 0; i < listDel.Count; i++)
            {
                if (MainNTP.ObUserList.DeleteOb(listDel[i]))
                {
                    listDel.RemoveAt(i); i--;
                }
            }
            btSave.Enabled = listSrc.Any(o => o.UserName != "" && o._Action != ActionRec.None) || listDel.Count > 0;
            /*DBStatic.DisConnectDB(main_QLyPhongkham._DataInfo);*/
            return true;
        }
        #endregion

        private void viewDanhmuc_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ObUser ob = (ObUser)viewDanhmuc.GetRow(viewDanhmuc.FocusedRowHandle);
            if (ob == null) return;
            if (colMa == e.Column)
            {
                if (listSrc.Any(o => o.UserName == ob.UserName && ob != o) && ob.UserName != "")
                {
                    MessageBox.Show("Mã " + ob.UserName + " của đối tượng bị trùng.");
                    viewDanhmuc.SelectCell(e.RowHandle, e.Column);
                    return;
                }
            }
            if (ob._Action != ActionRec.Insert)
            {

                ob._Action = ActionRec.Update;
            }

            if (viewDanhmuc.FocusedRowHandle == viewDanhmuc.RowCount - 1 && ob.UserName != "")
            {
                AddNewRow(false);
            }
            btSave.Enabled = true;
        }

        private void viewDanhmuc_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ObUser ob = (ObUser)viewDanhmuc.GetRow(viewDanhmuc.FocusedRowHandle);
            if (ob != null && ob._Action == ActionRec.None)
            {
                listUpd.Add(new ObUser[] { new ObUser(ob), ob });
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

        private void viewDanhmuc_DoubleClick(object sender, EventArgs e)
        {
            ObUser ob = (ObUser)viewDanhmuc.GetFocusedRow();
            if (ob == null) return;
            if (viewDanhmuc.FocusedColumn == colNHOM) {
                Frm_DMUser_Nhom frm = new Frm_DMUser_Nhom();
                frm.SetTT(ob);
                frm.ShowDialog(this);
                if (frm.obCur != null) {
                    ob.TTChung.NhomDV = frm.obCur.TTChung.NhomDV;
                }
            }
            viewDanhmuc.RefreshData();
        }
    }
}