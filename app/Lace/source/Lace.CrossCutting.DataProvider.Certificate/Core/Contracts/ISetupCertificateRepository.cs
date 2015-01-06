using Lace.CrossCutting.DataProviderCommandSource.Certificate.Core.Models;
using Lace.CrossCutting.DataProviderCommandSource.Certificate.Infrastructure.Dto;
using Lace.CrossCutting.DataProviderCommandSource.Certificate.Repositories;

namespace Lace.CrossCutting.DataProviderCommandSource.Certificate.Core.Contracts
{
    public interface ISetupCertificateRepository
    {
        IReadOnlyRepository<BaseStation> BaseStationRepository();
        IReadOnlyRepository<CoOrdinateCertificate> CertifcateRepository();
    }
}