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
    public partial class FrmTamUng : DevExpress.XtraEditors.XtraForm
    {
        public FrmTamUng()
        {
            InitializeComponent();
            LoadData();
            InitDisplay();
        }

        Guid _ID = Guid.Empty;

        void LoadData()
        {
            MainNTP.GetData(new List<eTableName>() { 
                eTableName.DMNhanSu,
                eTableName.DMTinh,
                eTableName.DMQuan,
            });
        }

        void InitDisplay()
        {
            lkNguoiThu.Properties.DataSource = MainNTP.ObDMNhanSuList;
            deNgay.DateTime = MainNTP.GetServerDate().Date;
            lkNguoiThu.EditValue = MainNTP.User.TTChung.MaNS;
            if (MainNTP.User.TTChung.MaNS.Trim() == "")
                lkNguoiThu.Properties.ReadOnly = false;
        }

        public void SetTTBenhNhan(string maBN, Guid ID)
        {
            ObCustomer ob = MainNTP.ObCustomerList.GetOb(maBN);
            if (ob == null)
                return;

            _ID = ID;

            teMaBN.Text = ob.Ma;
            teHoTen.Text = ob.Ten;
            teNam.Text = ob.Namsinh.ToString();
            cheNam.Checked = ob.Gioitinh == 0;
            teDiaChi.Text = ob.DiaChiFull;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (teMaBN.Text.Trim() == "")
            {
                MessageBox.Show("Không tìm thấy thông tin bệnh nhân");
                return;
            }

            if (lkNguoiThu.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn người thu");
                return;
            }

            if (MainNTP.ParseDouble(teThanhTien.Text) <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền cần thu");
                return;
            }

            ObTKBenhNhan ob = _ID == Guid.Empty ? null : MainNTP.ObTKBenhNhanList.GetOb(_ID);
            if (ob == null)
            {
                ob = new ObTKBenhNhan();
                ob.ID = Guid.NewGuid();
                ob.MaBN = teMaBN.Text;
                ob.Action = ActionRec.Insert;
                ob.TrangThai = etrangthai.Đã_thu.ToString();
            }

            ob.Ngay = deNgay.DateTime.Date;
            ob.NguoiThu = lkNguoiThu.EditValue.ToString();
            ob.QuayThu = "";
            ob.ThanhTien = MainNTP.ParseDouble(teThanhTien.Text);

            if (ob.Action == ActionRec.Insert)
            {
                MainNTP.ObTKBenhNhanList.AddOb(ob);
            }
            else
            {
                MainNTP.ObTKBenhNhanList.UpdateOb(ob);
            }

            MessageBox.Show("Lưu phiếu thành công!");
            this.Close();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            ObTKBenhNhan ob = _ID == Guid.Empty ? null : MainNTP.ObTKBenhNhanList.GetOb(_ID);
            if (ob == null)
            {
                MessageBox.Show("Không tìm thấy phiếu");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu này?", "Cảnh bảo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            ob.TrangThai = etrangthai.Đã_hủy.ToString();
            MainNTP.ObTKBenhNhanList.UpdateOb(ob);

            MessageBox.Show("Phiếu đã hủy thành công");
            this.Close();
        }
    }
}