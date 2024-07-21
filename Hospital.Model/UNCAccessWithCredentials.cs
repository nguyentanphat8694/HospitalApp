using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    public class UNCAccessWithCredentials : IDisposable
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct USE_INFO_2
        {
            internal string ui2_local;
            internal string ui2_remote;
            internal string ui2_password;
            internal uint ui2_status;
            internal uint ui2_asg_type;
            internal uint ui2_refcount;
            internal uint ui2_usecount;
            internal string ui2_username;
            internal string ui2_domainname;
        }
        private bool disposed = false;
        private string sUNCPath;
        private string sUser;
        private string sPassword;
        private string sDomain;
        private int iLastError;
        public int LastError
        {
            get
            {
                return this.iLastError;
            }
        }
        [DllImport("NetApi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern uint NetUseAdd(string UncServerName, uint Level, ref UNCAccessWithCredentials.USE_INFO_2 Buf, out uint ParmError);
        [DllImport("NetApi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern uint NetUseDel(string UncServerName, string UseName, uint ForceCond);
        public void Dispose()
        {
            if (!this.disposed)
            {
                this.NetUseDelete();
            }
            this.disposed = true;
            GC.SuppressFinalize(this);
        }
        public bool NetUseWithCredentials(string UNCPath, string User, string Domain, string Password)
        {
            this.sUNCPath = UNCPath;
            this.sUser = User;
            this.sPassword = Password;
            this.sDomain = Domain;
            return this.NetUseWithCredentials();
        }
        private bool NetUseWithCredentials()
        {
            bool result;
            try
            {
                UNCAccessWithCredentials.USE_INFO_2 uSE_INFO_ = default(UNCAccessWithCredentials.USE_INFO_2);
                uSE_INFO_.ui2_remote = this.sUNCPath;
                uSE_INFO_.ui2_username = this.sUser;
                uSE_INFO_.ui2_domainname = this.sDomain;
                uSE_INFO_.ui2_password = this.sPassword;
                uSE_INFO_.ui2_asg_type = 0u;
                uSE_INFO_.ui2_usecount = 1u;
                uint num2;
                uint num = UNCAccessWithCredentials.NetUseAdd(null, 2u, ref uSE_INFO_, out num2);
                this.iLastError = (int)num;
                result = (num == 0u || num2 == 0u);
            }
            catch
            {
                this.iLastError = Marshal.GetLastWin32Error();
                result = false;
            }
            return result;
        }
        public bool NetUseDelete()
        {
            bool result;
            try
            {
                uint num = UNCAccessWithCredentials.NetUseDel(null, this.sUNCPath, 2u);
                this.iLastError = (int)num;
                result = (num == 0u);
            }
            catch
            {
                this.iLastError = Marshal.GetLastWin32Error();
                result = false;
            }
            return result;
        }
        ~UNCAccessWithCredentials()
        {
            this.Dispose();
        }
    }
}
