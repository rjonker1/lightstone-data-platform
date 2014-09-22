using Lace.Source.Anpr.Definitions;

namespace Lace.Source.Anpr.Factory
{
    public interface IProvideCertificate
    {
        Certificate Certificate { get; }
        bool IsSuccessfull { get; }
        void GenerateCertificate();
        //void UndoCertificateImpersonation();
    }
}
