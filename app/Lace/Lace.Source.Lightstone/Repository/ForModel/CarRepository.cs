using System.Collections.Generic;
using System.Data;
using Lace.Request;
using Lace.Source.Lightstone.Models;
using ServiceStack.Redis;

namespace Lace.Source.Lightstone.Repository.ForModel
{
    public class CarRepository : IReadOnlyRepository<Car>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string StatisticsKey = "urn:Car:{0}:{1}:{2}";

        public IEnumerable<Car> FindAllWithRequest(ILaceRequestCarInformation request)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Car> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
