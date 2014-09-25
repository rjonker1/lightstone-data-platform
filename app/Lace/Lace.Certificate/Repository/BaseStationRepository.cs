using System;
using System.Data;
using System.Linq;
using Lace.Certificate.Models;
using Lace.Certificate.Repository.Infrastructure;
using ServiceStack.Redis;

namespace Lace.Certificate.Repository
{
    public class BaseStationRepository : IReadOnlyRepository<BaseStation>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string CertificateKey = "urn:Anpr_Certificate:x{0}y{1}";


        public BaseStationRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public BaseStation Find(double latitude, double longitude)
        {
            using (_connection)
            using (_cacheClient)
            {
                var key = string.Format(CertificateKey, latitude, longitude);
                var cachedCerts = _cacheClient.As<BaseStation>();
                var response = cachedCerts.Lists[key];

                if (response != null && response.Any())
                    return response.FirstOrDefault();

                var dbResponse = _connection
                    .Query<BaseStation>("spx_returnBaseStation", new {@x = latitude, @y = longitude},
                        commandType: CommandType.StoredProcedure).First();

                if (dbResponse == null)
                    return null;

                response.Add(dbResponse);

                _cacheClient.Add(key, response, DateTime.UtcNow.AddDays(30));
                return dbResponse;
            }
        }

        public BaseStation[] GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
