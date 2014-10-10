using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Certificate.Core.Contracts;

namespace Lace.CrossCutting.DataProvider.Certificate.Core
{
    public class Impersonator : IImpersonateACertificateUser
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        private const int Logon32LogonInteractive = 2;
        private const int Logon32ProviderDefault = 0;

        private WindowsImpersonationContext _impersonationContext;

        [DllImport("advapi32.dll")]
        private static extern int LogonUserA(string lpszUserName, string lpszDomain, string lpszPassword,
            int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int DuplicateToken(IntPtr hToken, int impersonationLevel, ref IntPtr hNewToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool RevertToSelf();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool CloseHandle(IntPtr handle);

        public bool ImpersonateAUser(string userName, string domain, string password)
        {
            Log.InfoFormat("Impersonating User {0}.", userName);

            var token = IntPtr.Zero;
            var duplicateToken = IntPtr.Zero;

            if (RevertToSelf())
            {
                if (LogonUserA(userName, domain, password, Logon32LogonInteractive,
                    Logon32ProviderDefault, ref token) != 0)
                {
                    if (DuplicateToken(token, 2, ref duplicateToken) != 0)
                    {
                        _impersonationContext = new WindowsIdentity(duplicateToken).Impersonate();
                        if (_impersonationContext != null)
                        {
                            CloseHandle(token);
                            CloseHandle(duplicateToken);
                            return true;
                        }
                    }
                }
            }

            if (token != IntPtr.Zero)
                CloseHandle(token);
            if (duplicateToken != IntPtr.Zero)
                CloseHandle(duplicateToken);

            Log.ErrorFormat("Impersonation for User {0} failed.", userName);
            return false;
        }

        public void UndoImpersonation()
        {
            if (_impersonationContext == null) return;

            _impersonationContext.Undo();
        }
    }
}
