using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObDMLK:ObservableCollection<ObDMLK>
    {
        public bool AddOb(ObDMLK ob)
        {
            return NTPObDMLK.Insert(ob) != 0;
        }
        public bool UpdateOb(string ma, ObDMLK ob)
        {
            return NTPObDMLK.Update(ma, ob) != 0;
        }
        public bool DeleteOb(ObDMLK ob)
        {
            return NTPObDMLK.Delete(ob) != 0;
        }
        public ObDMLK GetOb(string ma)
        {
            return NTPObDMLK.GetObWF_PK(ma);
        }
    }
}
