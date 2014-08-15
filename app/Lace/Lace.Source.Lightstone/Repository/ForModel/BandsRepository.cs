using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.Request;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository.Infrastructure;
using Lace.Source.Lightstone.Repository.Sql;
using ServiceStack.Redis;

namespace Lace.Source.Lightstone.Repository.ForModel
{
    public class BandsRepository : IReadOnlyRepository<Band>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string BandsKey = "urn:Bands";

        public BandsRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }
        
        public IEnumerable<Band> FindAllWithRequest(ILaceRequestCarInformation request)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Band> GetAll()
        {
            using (_connection)
            {
                using (_cacheClient)
                {
                    var cacheBands = _cacheClient.As<Band>();
                    var response = cacheBands.Lists[BandsKey];

                    if (response != null && response.Any())
                        return response;

                    var dbResponse = _connection
                        .Query<Band>(SelectStatements.GetAllTheBands)
                        .ToList();

                    dbResponse.ForEach(f => response.Add(f));

                    _cacheClient.Add(BandsKey, response);
                    return dbResponse;
                }
            }
        }
    }
}
