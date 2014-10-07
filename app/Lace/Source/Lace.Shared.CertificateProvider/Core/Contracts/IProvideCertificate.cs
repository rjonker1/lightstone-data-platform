namespace Lace.Shared.CertificateProvider.Core.Contracts
{
    public interface IProvideCertificate
    {
        IDefineTheCertificate Certificate { get; }
        bool IsSuccessfull { get; }
        void GenerateCertificate();
        //void UndoCertificateImpersonation();
    }
}
