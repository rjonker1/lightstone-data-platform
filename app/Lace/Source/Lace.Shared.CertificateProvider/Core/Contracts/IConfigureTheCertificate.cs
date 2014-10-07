namespace Lace.Shared.CertificateProvider.Core.Contracts
{
    public interface IConfigureTheCertificate
    {
        IDefineTheCertificate[] Certificates { get; }

        IConfigureTheCertificate LoadCertificates();
        IDefineTheCertificate GetCertificate();
    }
}
