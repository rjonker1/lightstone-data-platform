using System.Data;
using Lace.Domain.DataProviders.Rgt.Core.Contracts;
using Lace.Shared.DataProvider.Models;
using ServiceStack.Redis;

namespace Lace.Domain.DataProviders.Rgt.Repositories.Factory
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

        public IReadOnlyRepository<CarSpecification> CarSpecificationRepository()
        {
            return new CarSpecificationRepository(_connection, _redisClient);
        }
    }
}
