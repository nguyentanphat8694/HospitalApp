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
    public partial class CD020100 : DevExpress.XtraEditors.XtraForm
    {
        public CD020100()
        {
            InitializeComponent();
            LoadData();
            LoadControl();
            InitDisplay();
        }
        public UD010100 uChiDinh = null;
        double maBA = 0;
        ObChiDinh obChiDinh = null;
        List<ClsDichVu> listPK = new List<ClsDichVu>();
        bool Init = false;
        void LoadData() {
            List<eTableName> listTable = new List<eTableName> { 
                eTableName.DMDichVu,
                eTableName.DMNhomDichVu,
                eTableName.Customer,
                eTableName.DMNhanSu,
                eTableName.DMPK
            };

            MainNTP.GetData(listTable);
        }

        void LoadControl() {
            uChiDinh = new UD010100();
            uChiDinh.Dock = DockStyle.Fill;
            pnlMiddle.Controls.Add(uChiDinh);
        }

        void InitDisplay() {
            lkBacSi.Properties.DataSource = MainNTP.ObDMNhanSuList;
            lkBacSi.EditValue = MainNTP.User.TTChung.MaNS;
            deNgay.DateTime = MainNTP._Ngay;

            foreach (var item in MainNTP.ObDMPKList)
            {
                var it = new DevExpress.XtraEditors.Controls.CheckedListBoxItem();
                ClsDichVu cls = new ClsDichVu();
                cls.MaPK = item.Ma;
                it.Value = cls;
                it.Description = item.Ten;
                ObDMDichVu dm = MainNTP.ObDMDichVuList.Get(item.TTChung.MaDV);
                if (dm != null)
                    cls.MaDV = dm.Ma;
                clbPhongKham.Items.Add(it);
            }
            clbPhongKham.Refresh();
        }

        public void SetModify(ObChiDinh ob) {
            Init = true;
            teMaBN.Text = ob.MaBN;
            obChiDinh = ob;
            KeysListObCTChiDinh listCD = NTPObCTChiDinh.GetListOb(ob.Ma, (int)eLoaiHH.Dịch_vụ);
            if (listCD != null)
            {
                for (int i = 0; i < clbPhongKham.Items.Count; i++)
                {
                    ClsDichVu cls = (ClsDichVu)clbPhongKham.Items[i].Value;
                    ObCTChiDinh c2 = listCD.ToList().Find(o => o.MaPK != "" && o.MaPK == cls.MaPK);
                    if (c2!=null)
                    {
                        cls.Ma = c2.Ma;
                        clbPhongKham.SetItemChecked(i, true);
                    }
                }
                clbPhongKham.Refresh();
                uChiDinh.SetDichVu(listCD.ToList().FindAll(o => o.MaPK.Trim() == ""));
            }
            Init = false;
        }
        void Mapping_PK() {
            listPK.Clear();
            for (int i = 0; i < clbPhongKham.Items.Count; i++)
            {
                
                ClsDichVu cObj = (ClsDichVu)clbPhongKham.Items[i].Value;
                if(cObj==null)continue;
                ObDMDichVu dm = MainNTP.ObDMDichVuList.Get(cObj.MaDV);
                if(dm==null)continue;
                if (cObj.Ma > 0)
                {
                    if (!clbPhongKham.GetItemChecked(i))
                    {
                        ObCTChiDinh obct = MainNTP.ObCTChiDinhList.GetOb(cObj.Ma);
                        if (obct != null)
                        {
                            obct.TrangThai = etrangthai.Đã_hủy.ToString();
                            MainNTP.ObCTChiDinhList.DeleteOb(obct, etrangthai.Đã_hủy);
                        }
                    }
                }
                else {
                    if (clbPhongKham.GetItemChecked(i))
                    {
                        ObCTChiDinh ob = new ObCTChiDinh();
                        ob.Ngay = deNgay.DateTime.Date;
                        ob.MaDV = dm.Ma;
                        ob.LoaiHangHoa = dm.Loai;
                        ob.SL = 1;
                        ob.DG = dm.TTChung.DG;
                        ob.KeyCreate = obChiDinh.Ma;
                        //ob.ThanhTien = (ob.SL * ob.DG);
                        ob.TrangThai = etrangthai.Đang_chờ.ToString();
                        ob.MaBN = teMaBN.Text;
                        ob.Ma = MainNTP.ObCTChiDinhList.GetID();
                        ob.MaPK = cObj.MaPK;
                        MainNTP.ObCTChiDinhList.AddOb(ob);
                    }
                }

                
            }

        }
        /// <summary>
        /// event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CD020100_Shown(object sender, EventArgs e)
        {
            
        }

        private void teMaBN_EditValueChanged(object sender, EventArgs e)
        {
            if (NTPValidate.IsEmpty(teMaBN.Text)) return;
            ObCustomer bn = MainNTP.ObCustomerList.GetOb(teMaBN.Text);
            if (bn == null) return;
            teHoTen.Text = bn.Ten;
            teNam.Text = bn.Namsinh.ToString();
            cheNam.Checked = bn.Gioitinh == 0;
            teDiaChi.Text = bn.Diachi;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            Mapping_PK();
            if (uChiDinh.Save(deNgay.DateTime.Date, obChiDinh.Ma, teMaBN.Text)) {
                MessageBox.Show("Thay đổi chỉ định thành công");
                this.Close();
            }
        }

        private void clbPhongKham_ItemChecking(object sender, DevExpress.XtraEditors.Controls.ItemCheckingEventArgs e)
        {
            if (Init) return;
            var cls = clbPhongKham.Items[e.Index];
            if (cls == null) return;
            ClsDichVu c2 = (ClsDichVu)cls.Value;
            if (c2 == null || c2.Ma<=0) return;
            ObCTChiDinh ct = MainNTP.ObCTChiDinhList.GetOb(c2.Ma);
            if (ct == null) return;
            if (ct.TrangThai == etrangthai.Hoàn_thành.ToString())
            {
                MessageBox.Show("Dịch vụ " + c2.Ten + " đã thực hiện. Không thể xóa!");
                e.Cancel = true;
                return;
            }
            if (ct.KeyPT > 0)
            {
                MessageBox.Show("Dịch vụ " + c2.Ten + " đã thu tiền. Không thể xóa!");
                e.Cancel = true;
                return;
            }
        }

        private void clbPhongKham_SelectedIndexChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.Controls.CheckedListBoxItem item = (DevExpress.XtraEditors.Controls.CheckedListBoxItem)clbPhongKham.SelectedItem;
            if (item == null)
            {
                return;
            }

            for (int i = 0; i < clbPhongKham.Items.Count; i++)
            {
                if (clbPhongKham.Items[i].Value == item.Value)
                {
                    continue;
                }

                clbPhongKham.SetItemChecked(i, false);
            }

            clbPhongKham.Refresh();
        }
    }
}