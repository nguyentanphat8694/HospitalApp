using System.Collections.ObjectModel;
using System.Linq;

namespace Hospital.App
{
    public class KeysListObSLTon : ObservableCollection<ObBenhAn>
    {
        public static double GetSLTon(string maDV) {
            if (MainNTP.ObDichVuTonList == null)
            {
                return 0;
            }

            ObDichVuTon ob = MainNTP.ObDichVuTonList.FirstOrDefault(o => o.Ma == maDV);
            return ob == null ? 0 : ob.SLTon;
        }
    }
}
