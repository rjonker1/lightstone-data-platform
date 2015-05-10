using System.Data;
using Lace.CrossCutting.DataProvider.Certificate.Core.Contracts;
using Lace.CrossCutting.DataProvider.Certificate.Core.Models;
using Lace.CrossCutting.DataProvider.Certificate.Infrastructure.Dto;
using Lace.CrossCutting.DataProvider.Certificate.Repositories;

namespace Lace.CrossCutting.DataProvider.Certificate.Infrastructure.Factory
{
    public class RepositoryFactory : ISetupCertificateRepository
    {
        private readonly IDbConnection _connection;
        private readonly string _certficateConfiguration;

        public RepositoryFactory(IDbConnection connection,string certficateConfiguration)
        {
            _connection = connection;
            _certficateConfiguration = certficateConfiguration;
        }


        public RepositoryFactory(string certficateConfiguration)
        {
            _certficateConfiguration = certficateConfiguration;
        }

        public IReadOnlyRepository<BaseStation> BaseStationRepository()
        {
            return new BaseStationRepository(_connection);
        }

        public IReadOnlyRepository<CoOrdinateCertificate> CertifcateRepository()
        {
            return new CertificateRepository(_certficateConfiguration);
        }
    }
}
