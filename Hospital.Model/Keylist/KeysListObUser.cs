using System.Linq;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObUser:ObservableCollection<ObUser>
    {
        public bool AddOb(ObUser ob)
        {
            this.Add(ob);
            return NTPObUser.Insert(ob) > 0;
        }

        public bool UpdateOb(string ma, ObUser ob)
        {
            var obUpdate = this.FirstOrDefault(o => o.UserName == ma);
            if (obUpdate != null) {
                obUpdate.PassWord = ob.PassWord;
            }

            return NTPObUser.Update(ma, ob) > 0;
        }

        public bool DeleteOb(ObUser ob)
        {
            return NTPObUser.Delete(ob) > 0;
        }

        public ObUser GetOb(string ma)
        {
            return NTPObUser.GetObWF_PK(ma);
        }


    }
}
