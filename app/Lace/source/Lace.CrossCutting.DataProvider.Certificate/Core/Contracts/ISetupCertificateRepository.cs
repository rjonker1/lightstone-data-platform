using Lace.CrossCutting.DataProvider.Certificate.Core.Models;
using Lace.CrossCutting.DataProvider.Certificate.Infrastructure.Dto;
using Lace.CrossCutting.DataProvider.Certificate.Repositories;

namespace Lace.CrossCutting.DataProvider.Certificate.Core.Contracts
{
    public interface ISetupCertificateRepository
    {
        IReadOnlyRepository<BaseStation> BaseStationRepository();
        IReadOnlyRepository<CoOrdinateCertificate> CertifcateRepository();
    }
}