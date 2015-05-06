using System.Data;
using Lace.Domain.DataProviders.RgtVin.Core.Contracts;
using Lace.Shared.DataProvider.Models;
using ServiceStack.Redis;

namespace Lace.Domain.DataProviders.RgtVin.Repositories.Factory
{
    public class RepositoryFactory : ISetupRepository
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _redisClient;

        public RepositoryFactory(IDbConnection connection, IRedisClient redisClient)
        {
            _connection = connection;
            _redisClient = redisClient;
        }

        public IReadOnlyRepository<Vin> VinRepository()
        {
            return new VinRepository(_connection, _redisClient);
        }
    }
}
