using Lace.Shared.CertificateProvider.Core.Models;
using Lace.Shared.CertificateProvider.Infrastructure.Dto;
using Lace.Shared.CertificateProvider.Repositories;

namespace Lace.Shared.CertificateProvider.Core.Contracts
{
    public interface ISetupCertificateRepository
    {
        IReadOnlyRepository<BaseStation> BaseStationRepository();
        IReadOnlyRepository<CoOrdinateCertificate> CertifcateRepository();
    }
}