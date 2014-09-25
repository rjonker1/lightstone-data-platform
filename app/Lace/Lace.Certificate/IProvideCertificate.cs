namespace Lace.Certificate
{
    public interface IProvideCertificate
    {
        IDefineTheCertificate Certificate { get; }
        bool IsSuccessfull { get; }
        void GenerateCertificate();
        //void UndoCertificateImpersonation();
    }
}
