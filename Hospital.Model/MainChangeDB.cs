using System.Threading.Tasks;

namespace Hospital.App
{
    public class MainChangeDB
    {
        public delegate object DBChanged(ObRecord _obRecord);
        public void StartRecord()
        {
            DBStatic_DB.ConnectDB(DadaConnect.connect_string_DB);
            MainNTP.ObRecordList = new KeysListObRecord();
            NTPObRecord.GetMaxStart();
            //BackgroundWorker bk = new BackgroundWorker();
            //bk.DoWork += bk_DoWork;
            //bk.RunWorkerAsync();
            //bk.RunWorkerCompleted += bk_RunWorkerCompleted;

            Task.Run(() => {
                while (true)
                {
                    MainNTP.ObRecordList = NTPObRecord.GetMax();
                    if (MainNTP.ObRecordList == null) continue;
                    foreach (var ob in MainNTP.ObRecordList)
                    {
                        _ChangeDB(ob);
                    }
                    System.Threading.Thread.Sleep(5000);
                }
            });
            //

        }

        public event DBChanged ChangeDB;
        protected virtual object _ChangeDB(ObRecord _obRecord)
        {
            if (ChangeDB != null)
            {
                return ChangeDB(_obRecord);
            }
            return null;
        }
    }
}
