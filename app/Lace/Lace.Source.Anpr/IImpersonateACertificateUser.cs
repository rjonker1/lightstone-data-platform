﻿using System.Security.Principal;

namespace Lace.Source.Anpr
{
    public interface IImpersonateACertificateUser
    {
        bool ImpersonateAUser(string userName, string domain, string password);
        void UndoImpersonation();
    }
}
