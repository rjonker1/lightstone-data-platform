using System.Data;
using Lace.Source.Anpr.Definitions;
using Lace.Source.Anpr.Models;
using ServiceStack.Redis;

namespace Lace.Source.Anpr.Repository.Factory
{
    public class RepositoryFactory : ISetupRepository
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _redisClient;
        private readonly string _certficateConfiguration;

        public RepositoryFactory(IDbConnection connection, IRedisClient redisClient)
        {
            _connection = connection;
            _redisClient = redisClient;
        }

        public RepositoryFactory(string certficateConfiguration)
        {
            _certficateConfiguration = certficateConfiguration;
        }

        public IReadOnlyRepository<BaseStation> BaseStationRepository()
        {
            return new BaseStationRepository(_connection, _redisClient);
        }

        public IReadOnlyRepository<Certificate> CertifcateRepository()
        {
            return new CertificateRepository(_certficateConfiguration);
        }
    }
}
