using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Rgt.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Models;
using Lace.Domain.DataProviders.Rgt.Infrastructure.SqlStatements;
using ServiceStack.Redis;

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

        public IEnumerable<CarSpecification> FindWithRequest(IProvideCarInformationForRequest request)
        {
            using (_connection)
            using (_cacheClient)
            {
                var key = string.Format(CarSpecificationsKey, request.CarId);
                var cachedSpecifications = _cacheClient.As<CarSpecification>();
                var response = cachedSpecifications.Lists[key];

                if (response != null && response.Any())
                    return response;

                var dbResponse =
                    _connection.Query<CarSpecification>(SelectStatements.GetCarSpecifications,
                        new {@CarId = request.CarId}).ToList();

                dbResponse.ForEach(f => response.Add(f));
                _cacheClient.Add(key, response, DateTime.UtcNow.AddDays(1));
                return dbResponse;
            }
        }
    }
}
