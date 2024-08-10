using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
namespace Hospital.App
{
    public partial class Frm_DMDichVu : DevExpress.XtraEditors.XtraForm
    {
        public Frm_DMDichVu()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
        }
        List<ObDMDichVu> listDel = new List<ObDMDichVu>();
        public List<ObDMDichVu> listSrc = new List<ObDMDichVu>();
        List<ObDMDichVu[]> listUpd = new List<ObDMDichVu[]>();

        private void Frm_DMDichVu_Load(object sender, EventArgs e)
        {
            ReloadData();
            FillData();
        }
        public bool ReloadData()
        {
            DBStatic.ConnectDB(DadaConnect.connect_string);

            List<eTableName> listT = new List<eTableName> { 
                eTableName.DMDonVi,
                eTableName.DMNhomDichVu,
                eTableName.DMMau,
            };

            MainNTP.GetData(listT);

            MainNTP.ObDMDichVuList = NTPObDMDichVu.GetListOb();

            //set data
            rlkDonVi.DataSource = MainNTP.ObDMDonViList;
            rlkNhom.DataSource = MainNTP.ObDMNhomDichVuList;
            rlkMau.DataSource = MainNTP.ObDMMauList;
            //lkNhomDichVu.Properties.DataSource = MainNTP.ObDMNhomDichVuList;
            List<ObDMNhomDichVu> listDMNhomDichVu = MainNTP.ObDMNhomDichVuList.ToList();
            listDMNhomDichVu.Insert(0, new ObDMNhomDichVu()
            {
                Ma = "",
                Ten = "Tất cả"
            });
            lkNhomDichVu.Properties.DataSource = listDMNhomDichVu;

            return true;
        }
        #region CAC HAM XU LY DATA
        void FillData()
        {
            if (MainNTP.ObDMDichVuList == null) return;
            listSrc.Clear();
            foreach (ObDMDichVu ob in MainNTP.ObDMDichVuList)
            {
                ob._Action = ActionRec.None;
                listSrc.Add(new ObDMDichVu(ob));
            }
            itemThemdong.Visible = true;
            AddNewRow(false);

        }

        void AddNewRow(bool focus)
        {
            ObDMDichVu ob = new ObDMDichVu()
            {
                _Action = ActionRec.Insert,
                TTChung = new Cls_TTDMDichVu()
                {
                    Nhom = lkNhomDichVu.EditValue != null ? lkNhomDichVu.EditValue.ToString() : ""
                }
            };
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
            ObDMDichVu ob = (ObDMDichVu)viewDanhmuc.GetRow(viewDanhmuc.FocusedRowHandle);
            if (ob == null) return;
            viewDanhmuc.DeleteSelectedRows();

            if (ob._Action == ActionRec.Update)
            {
                ObDMDichVu[] os = listUpd.Find(o => o[1] == ob);
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
            foreach (ObDMDichVu ob in listSrc)
            {
                if (ob.Ma == "") continue;
                if (ob._Action == ActionRec.Insert)
                {
                    if (MainNTP.ObDMDichVuList.AddOb(ob)) ob._Action = ActionRec.None;
                }
                if (ob._Action == ActionRec.Update)
                {
                    ObDMDichVu[] os = listUpd.Find(o => (ob == o[1]));
                    if (os == null) continue;
                    if (MainNTP.ObDMDichVuList.UpdateOb(os[0].Ma, ob))
                    {
                        ob._Action = ActionRec.None;
                        listUpd.Remove(os);
                    }
                }
            }
            for (int i = 0; i < listDel.Count; i++)
            {
                if (MainNTP.ObDMDichVuList.DeleteOb(listDel[i]))
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
            ObDMDichVu ob = (ObDMDichVu)viewDanhmuc.GetRow(viewDanhmuc.FocusedRowHandle);
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
            ObDMDichVu ob = (ObDMDichVu)viewDanhmuc.GetRow(viewDanhmuc.FocusedRowHandle);
            if (ob != null && ob._Action == ActionRec.None)
            {
                listUpd.Add(new ObDMDichVu[] { new ObDMDichVu(ob), ob });
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

        private void lkNhomDichVu_EditValueChanged(object sender, EventArgs e)
        {
            string sql = "";
            if (lkNhomDichVu.EditValue == null || string.IsNullOrEmpty(lkNhomDichVu.EditValue.ToString()))
            {

            }
            else
            {
                sql += "[TTChung.Nhom] like '" + lkNhomDichVu.EditValue.ToString() + "'";
            }

            if (sql != "")
                viewDanhmuc.ActiveFilterString = sql;
            else viewDanhmuc.ClearColumnsFilter();
        }
    }
}