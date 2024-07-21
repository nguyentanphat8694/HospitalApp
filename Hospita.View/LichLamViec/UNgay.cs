using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.App
{
    public partial class UNgay : DevExpress.XtraEditors.XtraUserControl
    {
        public UNgay()
        {
            InitializeComponent();

            isChiXem = false;
        }

        private string _MaNS = "";
        private DateTime _Ngay = MainNTP.MinValue;
        List<ClsCongViec> listMain = new List<ClsCongViec>();
        bool isDatHen = false;

        public void SetTTLichNgay(string soNgay, string noiDung,bool nghi, int soThu,string maNS,DateTime ngay)
        {
            _MaNS = maNS;
            _Ngay = ngay;
            int maxThu = 9;
            cheNghi.Checked = nghi;
            cheNghi.Text = soNgay;
            lbNoiDung.Text = noiDung;
            lbThu.Visible = soThu < maxThu;
            lbNoiDung.Dock = DockStyle.Fill;
            lbThu.Text = soThu == maxThu -1 ? "CHỦ NHẬT" : "THỨ " + soThu;
            if (soThu < maxThu)
            {
                this.Height += lbThu.Height;
            }

            LoadCongViecByNgay();
        }

        public void SetTTLichDatHen(bool nghi, string maNS, DateTime ngay)
        {
            _MaNS = maNS;
            _Ngay = ngay;
            isDatHen = true;

            cheNghi.Checked = nghi;

            cheNghi.Visible = false;
            //btnThemCongViec.Visible = false;
            //btnXemLichNgay.Visible = false;
            lbThu.Visible = true;


            lbThu.Text = GetTenThu(ngay);
            this.Height += lbThu.Height;

            lbNoiDung.Dock = DockStyle.Fill;

            LoadCongViecByNgay();
            
        }

        public bool isChiXem
        {
            set
            {
                cheNghi.Properties.ReadOnly = value;
                //btnThemCongViec.Enabled = !value;
            }
        }

        private string GetTenThu(DateTime ngay)
        {
            return ngay.DayOfWeek == DayOfWeek.Monday ? "Thứ 2"
                : ngay.DayOfWeek == DayOfWeek.Tuesday ? "Thứ 3"
                : ngay.DayOfWeek == DayOfWeek.Wednesday ? "Thứ 4"
                : ngay.DayOfWeek == DayOfWeek.Thursday ? "Thứ 5"
                : ngay.DayOfWeek == DayOfWeek.Friday ? "Thứ 6"
                : ngay.DayOfWeek == DayOfWeek.Saturday ? "Thứ 7"
                : "Chủ Nhật";
        }

        private void LoadCongViecByNgay()
        {
            if (_Ngay == DateTime.MinValue)
                return;

            listMain.Clear();
            KeysListObHenKham keysListHTK = NTPObHenKham.GetListOb(_Ngay.Date, _Ngay.Date);
            //KeysListObDatHen keysListDatHen = NTPObDatHen.GetListObByNgayDenKham(_Ngay.Date, _MaNS);
            //try
            //{

            //Task.Run(() =>
            //{
            ObCustomer bn = null;
            ObHenKham htk = null;
            string ten = "";
            string nd = "";
            if (keysListHTK != null)
            {
                for (int i = 0; i < keysListHTK.Count; i++)
                {
                    htk = keysListHTK[i];

                    if (htk.TrangThai == etrangthai.Đã_hủy.ToString())
                        continue;

                    bn = MainNTP.ObCustomerList.GetKey(htk.MaBN);
                    ten = bn == null ? htk.MaBN : bn.Ten;
                    nd = htk.TTChung.NoiDung.Trim() != "" ? " (" + htk.TTChung.NoiDung + ")" : "";
                    listMain.Add(
                        new ClsCongViec()
                        {
                            Id = htk.Ma.ToString(),
                            ThoiGian = htk.TTChung.GioHK.ToString("HH:mm"),
                            NoiDung = (i + 1).ToString() + ". " + ten + nd,// htk.TTChung.NoiDung
                        });
                }
            }
            //}).ContinueWith((o) =>
            //{
            RefreshData();
            //});
            //}
            //catch
            //{
            //    LoadCongViecByNgay();
            //}



            //gridMain.DataSource = listMain.OrderBy(o => o.ThoiGian);
            //viewMain.RefreshData();
        }

        private void RefreshData()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new NTPRefreshData(RefreshData), new object[] { });
            }
            else
            {
                EnableNghi();

                gridMain.DataSource = listMain.OrderBy(o => o.ThoiGian);
                viewMain.RefreshData();
            }
        }

        private void EnableNghi()
        {
            //cheNghi.Enabled = (listMain.Count <= 0);
        }

        public void SetBG() {
            Color bg = Color.DimGray;
            cheNghi.BackColor = bg;
            lbNoiDung.BackColor = bg;
            cheNghi.Visible = false;
            gridMain.Visible = false;
            lbNoiDung.Visible = true;
            //btnThemCongViec.Visible = false;
            //btnXemLichNgay.Visible = false;
        }

        private void SetBGByNghi(bool isNghi)
        {
            //gridMain.Visible = !isNghi;
            //lbNoiDung.Visible = isNghi;
            //btnThemCongViec.Visible = !isNghi;
            //btnXemLichNgay.Visible = !isNghi;

            Color bgColor = isNghi ? Color.Red : Color.Gainsboro;
            lbThu.BackColor = bgColor;
            cheNghi.BackColor = bgColor;
        }

        public bool IsNghi()
        {
            ObLichLamViec ob = MainNTP.obLichLamViec.GetOb(_MaNS, _Ngay);
            return ob == null ? false : ob.TTChung.Nghi;
        }

        private void cheNghi_CheckedChanged(object sender, EventArgs e)
        {
            if (_MaNS != "")
            {
                ObLichLamViec ob = MainNTP.obLichLamViec.GetOb(_MaNS, _Ngay);
                if (ob == null)
                {
                    ob = new ObLichLamViec();
                    ob.MaNS = _MaNS;
                    ob.Ngay = _Ngay;
                    ob.TTChung.Nghi = cheNghi.Checked;
                    MainNTP.obLichLamViec.AddOb(ob);
                }
                else
                {
                    ob.TTChung.Nghi = cheNghi.Checked;
                    MainNTP.obLichLamViec.UpdateOb(ob);
                }
            }

            SetBGByNghi(cheNghi.Checked);
        }

        private void btnThemCongViec_Click(object sender, EventArgs e)
        {
            if (isDatHen)
                return;

            //new UDatHen().ShowDialog(_MaNS, _Ngay);

            LoadCongViecByNgay();
        }

        private void viewMain_DoubleClick(object sender, EventArgs e)
        {
            //if (isDatHen)
            //    return;

            ClsCongViec cls = (ClsCongViec)viewMain.GetFocusedRow();
            if (cls == null)
                return;

            ObHenKham hk = MainNTP.ObHenKhamList.GetOb(MainNTP.ParseDouble(cls.Id));
            MainNTP.DangKyHTK(hk);


            /*

            ObDatHen ob = MainNTP.obDatHenList.GetOb(MainNTP.ParseDouble(cls.Id));
            if (ob == null)
                return;

            XtraForm frm;
            var uDathen = new UDatHen();
            uDathen.SetTTDatHen(ob);
            MainNTP.ShowDialog(out frm, uDathen, "ĐẶT HẸN");
            LoadCongViecByNgay();
             * */
        }

        private void btnXemLichNgay_Click(object sender, EventArgs e)
        {
            if (isDatHen)
                return;

            //var frm = new FrmLichTongHopNgay();
            //frm.SetDataByNgay(_Ngay);
            //frm.ShowDialog();
        }

        private void viewMain_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

        }
    }
}
