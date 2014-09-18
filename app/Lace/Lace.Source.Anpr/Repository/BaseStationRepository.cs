using System;
using System.Data;
using Lace.Source.Anpr.Models;
using ServiceStack.Redis;

namespace Lace.Source.Anpr.Repository
{
    public class BaseStationRepository : IReadOnlyRepository<BaseStation>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        public BaseStation FindFirstWith(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }
    }
}
