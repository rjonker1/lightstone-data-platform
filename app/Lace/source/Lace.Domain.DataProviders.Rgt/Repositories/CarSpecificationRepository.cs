using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.DataProviders.Rgt.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Models;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.Domain.DataProviders.Rgt.Repositories
{
    public class CarSpecificationRepository : IReadOnlyRepository<CarSpecification>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string CarSpecificationsKey = "urn:Auto_Carstats:CarSpecifications:{0}";

        public CarSpecificationRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<CarSpecification> Get(string sql, object param)
        {
            //using (_connection)
            using (_cacheClient)
            {
                var key = string.Format(CarSpecificationsKey, param);
                var cachedSpecifications = _cacheClient.As<CarSpecification>();
                var response = cachedSpecifications.Lists[key];

                if (response.DoesExistInTheCache())
                    return response;

                var dbResponse =
                    _connection.Query<CarSpecification>(sql, param).ToList();

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                dbResponse.ForEach(f => response.Add(f));
                dbResponse.AddItemsToCache(_cacheClient, key, DateTime.UtcNow.AddDays(1));

                return dbResponse;
            }
        }
      
    }
}
