namespace Lace.CrossCutting.DataProvider.Certificate.Core.Contracts
{
    public interface IConfigureTheCertificate
    {
        IDefineTheCertificate[] Certificates { get; }

        IConfigureTheCertificate LoadCertificates();
        IDefineTheCertificate GetCertificate();
    }
}
