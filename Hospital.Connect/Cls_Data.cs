using System.Collections.Generic;

namespace Hospital.App
{
    public class DadaConnect
    {
        //public static string connect_string = @"Server=Dong-PC;Integrated security=SSPI;Database=XN;User ID=sa;Password=123456;";
        //public static string connect_string = @"Server=THANHPHONG-PC\SQLEXPRESS;Integrated security=SSPI;Database=Data_Phanmem;User ID=phong;";
        //public static string connect_string = @"Server=THANHPHONG-PC\SQLEXPRESS;Integrated security=SSPI;Database=SHPT_PhongKham;User ID=phong;";
        //public static string connect_string =@"Server=XUANQUYET;Initial Catalog=MAS_PhongKham;User ID=as;Password=123456;";
        //public static string connect_string = @"Data Source=XUANQUYET;Initial Catalog=SHPT_PhongKham;User ID=shpt;Password=shptsqlrwdata;";
        public static string connect_string = "";
        public static string connect_string_DB = "";
        public static List<ObData_Info> listDataConnect = new List<ObData_Info>();
        public static void Khoitaoketnoi()
        {
            //BS Trang
            //ObData_Info ob = new ObData_Info(@"DESKTOP-N8V9ISA", "QLPK_2019", "sa", "123456");// chị Trang

            //ObData_Info ob = new ObData_Info(@"DESKTOP-N8V9ISA", "HospitalDB", "sa", "123456");
            // phong BS Trang
            //ObData_Info ob = new ObData_Info(@"PHONGNT3-HCM-PC", "HospitalDB", "sa", "NTPhong");
            // phong BS Diep
            ObData_Info ob = new ObData_Info(@"PHONGNT3-HCM-PC", "BSDIEP_20200810", "sa", "NTPhong");
            //BS Diep
            //ObData_Info ob = new ObData_Info(@"SERVER-BSDIEP-2", "BSDIEP_20200810", "sa", "BSDiep@2020");


            //connect_string = @"Server="+ob.Server+";Initial Catalog="+ob.NameDatabase+";User ID="+ob.UserID+";Password="+ob.Password+";";
            //connect_string_DB = @"Server=" + ob.Server + ";Initial Catalog=" + ob.NameDatabase+"2" + ";User ID=" + ob.UserID + ";Password=" + ob.Password + ";";
            connect_string = "Server=localhost\\SQLEXPRESS;Database=QLPK_2019;Trusted_Connection=True;";
            connect_string_DB = "Server=localhost\\SQLEXPRESS;Database=QLPK_20192;Trusted_Connection=True;";
    }
        public class ObData_Info
        {
            string _Server = "", _NameDatabase = "", _UserID = "", _Password = "";
            public string Server { get { return _Server; } set { _Server = value; } }
            public string NameDatabase { get { return _NameDatabase; } set { _NameDatabase = value; } }
            public string UserID { get { return _UserID; } set { _UserID = value; } }
            public string Password { get { return _Password; } set { _Password = value; } }
            public ObData_Info() { }
            public ObData_Info(ObData_Info cls) {
                _Server = cls.Server;
                _NameDatabase = cls.NameDatabase;
                _UserID = cls.UserID;
                _Password = cls.Password;
            }
            public ObData_Info(string _server,string _DB,string _uerID,string _Pass)
            {
                _Server = _server;
                _NameDatabase = _DB;
                _UserID = _uerID;
                _Password = _Pass;
            }
        }
        
    }
}
