namespace Lace.Source.Anpr.Factory
{
    public interface IProvideCertificate
    {
        IDefineTheCertificate Certificate { get; }
        bool IsSuccessfull { get; }
        void GenerateCertificate();
        //void UndoCertificateImpersonation();
    }
}
