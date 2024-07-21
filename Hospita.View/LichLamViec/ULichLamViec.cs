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
    public partial class ULichLamViec : DevExpress.XtraEditors.XtraUserControl
    {
        public ULichLamViec()
        {
            InitializeComponent();
            LoadData();
            InitDisplay();
            LoadThu();
        }

        void LoadData()
        {
            List<eTableName> listT = new List<eTableName> { 
                eTableName.DMNhanSu,
                eTableName.Customer
            };

            MainNTP.GetData(listT);
        }

        void InitDisplay() {

            cbNam.Text = MainNTP._Ngay.Year.ToString();
            cbThang.Text = MainNTP._Ngay.Month < 10 ? "0" + MainNTP._Ngay.Month : MainNTP._Ngay.Month.ToString();
            for (int i = 2016; i < 2100; i++) {
                cbNam.Properties.Items.Add(i.ToString());
            }
            for (int i = 1; i <= 12; i++)
            {
                cbThang.Properties.Items.Add(i < 10 ? "0" + i : i.ToString());
            }

            lkBacSi.Properties.DataSource = MainNTP.ObDMNhanSuList;
            lkBacSi.EditValue = MainNTP.User.TTChung.MaNS;
        }

        int DiemSoNgayChuNhat(DateTime tuNgay, DateTime denNgay)
        {
            int soLan = 0;

            DateTime dd = tuNgay;

            while (dd <= denNgay)
            {
                if (dd.DayOfWeek == DayOfWeek.Sunday)
                    soLan++;

                dd = dd.AddDays(1);
            }
            return soLan;
        }

        public void LoadThu() {

            if (lkBacSi.EditValue == null) {
                MessageBox.Show("Vui lòng chọn bác sĩ");
                return;
            }

            btLayDuLieu.Enabled = false;
            try
            {

                DateTime time = new DateTime(MainNTP.ParseInt(cbNam.Text), MainNTP.ParseInt(cbThang.Text), 01, 00, 00, 00);
                DateTime N01 = tungay(time);
                DateTime time2 = time.AddMonths(1).AddDays(-1);
                DateTime N31 = dengay(time2);
                DateTime day = N01;
                MainNTP.obLichLamViec = NTPObLichLamViec.GetListOb(time, time2);

                if (MainNTP.obLichLamViec == null) MainNTP.obLichLamViec = new KeysListObLichLamViec();
                int x = 0, y = 0;

                List<Control> cl = new List<Control>();
                int n = 1;

                int w = (int)(scMain.Width / 7) - 2;
                int h = (int)((scMain.Height - 25) / DiemSoNgayChuNhat(day, N31)) - 2;

                while (day <= N31)
                {
                    n++;
                    ObLichLamViec ob = MainNTP.obLichLamViec.Get(lkBacSi.EditValue.ToString(), day);
                    var item = new UNgay();
                    item.Width = w;
                    item.Height = h;

                    item.SetTTLichNgay(day.Day < 10 ? "0" + day.Day : day.Day.ToString(),
                        "",
                        (ob == null ? false : ob.TTChung.Nghi),
                        n,
                        MainNTP.GetStringFromObject(lkBacSi.EditValue),
                        day);

                    if (day.Month != time.Month)
                        item.SetBG();

                    item.Location = new Point(x, y);

                    cl.Add(item);
                    x += item.Width + 0;
                    if (x + item.Width >= scMain.Size.Width) { x = 0; y += item.Height + 0; }
                    //
                    day = day.AddDays(1);
                }

                scMain.Controls.Clear();
                scMain.Controls.AddRange(cl.ToArray());
            }
            catch
            {
                btLayDuLieu.Enabled = true;
            }
            finally
            {
                btLayDuLieu.Enabled = true;
            }
        }

        string LayThu_VN(DayOfWeek day) {
            if (day == DayOfWeek.Monday) return "Thứ 2";
            if (day == DayOfWeek.Tuesday) return "Thứ 3";
            if (day == DayOfWeek.Wednesday) return "Thứ 4";
            if (day == DayOfWeek.Thursday) return "Thứ 5";
            if (day == DayOfWeek.Friday) return "Thứ 6";
            if (day == DayOfWeek.Saturday) return "Thứ 7";
            return "CN";
        }

        DateTime tungay(DateTime ngay)
        {
            if (ngay.DayOfWeek == DayOfWeek.Monday) return ngay;
            else if (ngay.DayOfWeek == DayOfWeek.Tuesday) return ngay.AddDays(-1);
            else if (ngay.DayOfWeek == DayOfWeek.Wednesday) return ngay.AddDays(-2);
            else if (ngay.DayOfWeek == DayOfWeek.Thursday) return ngay.AddDays(-3);
            else if (ngay.DayOfWeek == DayOfWeek.Friday) return ngay.AddDays(-4);
            else if (ngay.DayOfWeek == DayOfWeek.Saturday) return ngay.AddDays(-5);
            return ngay.AddDays(-6);

        }
        DateTime dengay(DateTime ngay)
        {
            if (ngay.DayOfWeek == DayOfWeek.Monday) return ngay.AddDays(6);
            else if (ngay.DayOfWeek == DayOfWeek.Tuesday) return ngay.AddDays(5);
            else if (ngay.DayOfWeek == DayOfWeek.Wednesday) return ngay.AddDays(4);
            else if (ngay.DayOfWeek == DayOfWeek.Thursday) return ngay.AddDays(3);
            else if (ngay.DayOfWeek == DayOfWeek.Friday) return ngay.AddDays(2);
            else if (ngay.DayOfWeek == DayOfWeek.Saturday) return ngay.AddDays(1);
            return ngay;

        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            LoadThu();
        }

        private void cbNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}