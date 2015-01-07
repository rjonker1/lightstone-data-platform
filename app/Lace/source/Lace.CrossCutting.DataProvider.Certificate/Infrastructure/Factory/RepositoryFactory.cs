using System.Data;
using Lace.CrossCutting.DataProviderCommandSource.Certificate.Core.Contracts;
using Lace.CrossCutting.DataProviderCommandSource.Certificate.Core.Models;
using Lace.CrossCutting.DataProviderCommandSource.Certificate.Infrastructure.Dto;
using Lace.CrossCutting.DataProviderCommandSource.Certificate.Repositories;
using ServiceStack.Redis;

namespace Lace.CrossCutting.DataProviderCommandSource.Certificate.Infrastructure.Factory
{
    public class RepositoryFactory : ISetupCertificateRepository
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _redisClient;
        private readonly string _certficateConfiguration;

        public RepositoryFactory(IDbConnection connection, IRedisClient redisClient,string certficateConfiguration)
        {
            _connection = connection;
            _redisClient = redisClient;
            _certficateConfiguration = certficateConfiguration;
        }


        public RepositoryFactory(string certficateConfiguration)
        {
            _certficateConfiguration = certficateConfiguration;
        }

        public IReadOnlyRepository<BaseStation> BaseStationRepository()
        {
            return new BaseStationRepository(_connection, _redisClient);
        }

        public IReadOnlyRepository<CoOrdinateCertificate> CertifcateRepository()
        {
            return new CertificateRepository(_certficateConfiguration);
        }
    }
}
