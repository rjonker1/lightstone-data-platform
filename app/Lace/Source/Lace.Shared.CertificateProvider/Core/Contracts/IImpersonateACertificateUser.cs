namespace Lace.Shared.CertificateProvider.Core.Contracts
{
    public interface IImpersonateACertificateUser
    {
        bool ImpersonateAUser(string userName, string domain, string password);
        void UndoImpersonation();
    }
}
