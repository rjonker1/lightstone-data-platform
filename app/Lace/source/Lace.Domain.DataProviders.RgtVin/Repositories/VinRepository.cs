using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm;
using Lace.Domain.DataProviders.RgtVin.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Core.Models;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.SqlStatements;
using ServiceStack.Redis;

namespace Lace.Domain.DataProviders.RgtVin.Repositories
{
    public class VinRepository : IReadOnlyRepository<Vin>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string CarSpecificationsKey = "urn:Auto_Carstats:Vin:{0}";

        public VinRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<Vin> FindWith(string vin)
        {
            using (_connection)
            using (_cacheClient)
            {
                var key = string.Format(CarSpecificationsKey, vin);
                var cachedVins = _cacheClient.As<Vin>();
                var response = cachedVins.Lists[key];

                if (response != null && response.Any())
                    return response;

                var dbResponse =
                    _connection.Query<Vin>(SelectStatements.GetVehicleVin,
                        new {@Vin = vin}).ToList();

                dbResponse.ForEach(f => response.Add(f));
                _cacheClient.Add(key, response, DateTime.UtcNow.AddDays(1));
                return dbResponse;
            }
        }
    }
}
