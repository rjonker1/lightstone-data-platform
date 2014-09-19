using Lace.Source.Anpr.Definitions;
using Lace.Source.Anpr.Models;
namespace Lace.Source.Anpr.Repository.Factory
{
    public interface ISetupRepository
    {
        IReadOnlyRepository<BaseStation> BaseStationRepository();
        IReadOnlyRepository<Certificate> CertifcateRepository();
    }
}