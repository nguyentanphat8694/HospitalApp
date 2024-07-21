using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    [Serializable]
    public class ObImage
    {
        //public double Ma { get; set; }
        //public int LoaiPhieu { get; set; }// phieu kham, hay phieu CDHA, hay phieu SA
        //public string KeyThucHien { get; set; }
        public string Path { get; set; }
        //public string MaBN { get; set; }
        public int STT { get; set; }
        public bool In { get; set; }

        public ObImage() {
            STT = 0;
            Path = "";
            In = false;
        }
        public ObImage(ObImage ob) {
            STT = ob.STT;
            Path = ob.Path;
            In = ob.In;
        }
        public Image Img
        {
            get
            {
                Image result;
                if (this.Path != "")
                {
                    if (NTPUserSetting.DDLuuAnhSA != "")
                    {
                        using (UNCAccessWithCredentials uNCAccessWithCredentials = new UNCAccessWithCredentials())
                        {
                            if (true)//uNCAccessWithCredentials.NetUseWithCredentials(NTPUserSetting.DDLuuAnhSA, NTPUserSetting.PathServer_User, NTPUserSetting.PathServer_Domain, NTPUserSetting.PathServer_Password))
                            {
                                try
                                {
                                    FileInfo fileInfo = new FileInfo(this.Path);
                                    result = (fileInfo.Exists ? Image.FromFile(this.Path) : null);
                                    return result;
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            FileInfo fileInfo = new FileInfo(this.Path);
                            result = (fileInfo.Exists ? Image.FromFile(this.Path) : null);
                            return result;
                        }
                        catch
                        {
                        }
                    }
                }
                result = this.Img;
                return result;
            }
        }

    }
}
