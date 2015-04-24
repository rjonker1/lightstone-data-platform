using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.Domain.DataProviders.Lightstone.Repositories
{
    public class MakeRepository : IReadOnlyRepository<Make>
    {
        //SelectStatements.GetAllTheMakes
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string MakeKey = "urn:Auto_Carstats:Make";

        public MakeRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<Make> Get(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Make> GetAll(string sql)
        {
            using (_cacheClient)
            {
                var makes = _cacheClient.As<Make>();
                var response = makes.Lists[MakeKey];

                if (response.DoesExistInTheCache())
                    return response;

                var dbResponse = _connection
                    .Query<Make>(sql)
                    .ToList();

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                dbResponse.ForEach(f => response.Add(f));
                dbResponse.AddItemsToCache(_cacheClient, MakeKey, DateTime.UtcNow.AddDays(1));
                return dbResponse;
            }
        }
    }
}
