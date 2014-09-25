using Lace.Certificate.Models;
namespace Lace.Certificate.Repository.Factory
{
    public interface ISetupRepository
    {
        IReadOnlyRepository<BaseStation> BaseStationRepository();
        IReadOnlyRepository<Definitions.CoOrdinateCertificate> CertifcateRepository();
    }
}