using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObDichVuTon : ObservableCollection<ObDichVuTon>
    {

        public void GetListTonByThang(int thang)
        {
            this.Clear();

            List<ObDichVuTon> list = NTPObSLTon.GetListTonByThang(thang);
            if (list != null)
            {
                foreach (var item in list)
                {
                    this.Add(item);
                }
            }
        }
    }
}
