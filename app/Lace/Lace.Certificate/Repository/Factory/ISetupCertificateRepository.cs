using Lace.Certificate.Models;
namespace Lace.Certificate.Repository.Factory
{
    public interface ISetupCertificateRepository
    {
        IReadOnlyRepository<BaseStation> BaseStationRepository();
        IReadOnlyRepository<Definitions.CoOrdinateCertificate> CertifcateRepository();
    }
}