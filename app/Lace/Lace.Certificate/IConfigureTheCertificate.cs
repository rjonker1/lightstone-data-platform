namespace Lace.Certificate
{
    public interface IConfigureTheCertificate
    {
        IDefineTheCertificate[] Certificates { get; }

        IConfigureTheCertificate LoadCertificates();
        IDefineTheCertificate GetCertificate();
    }
}
