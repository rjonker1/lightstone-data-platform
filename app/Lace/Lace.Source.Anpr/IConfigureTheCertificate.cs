namespace Lace.Source.Anpr
{
    public interface IConfigureTheCertificate
    {
        IDefineTheCertificate[] Certificates { get; }

        IConfigureTheCertificate LoadCertificates();
        IDefineTheCertificate GetCertificate();
    }
}
