namespace Lace.Certificate
{
    public interface IImpersonateACertificateUser
    {
        bool ImpersonateAUser(string userName, string domain, string password);
        void UndoImpersonation();
    }
}
