using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.Request;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository.Infrastructure;
using Lace.Source.Lightstone.Repository.Sql;
using ServiceStack.Common.Extensions;
using ServiceStack.Redis;

namespace Lace.Source.Lightstone.Repository
{
    public class StatisticsRepository : IReadOnlyRepository<Statistics>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string StatisticsKey = "urn:Statistics:{0}:{1}:{2}";

        public StatisticsRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public Statistics FindWithId(int id)
        {
            throw new NotImplementedException();
        }

        public Statistics FindWithRequest(ILaceRequestCarInformation request)
        {
          throw new NotImplementedException();
        }

        public IEnumerable<Statistics> FindAllWithRequest(ILaceRequestCarInformation request)
        {
            using (_connection)
            {
                using (_cacheClient)
                {
                    var key = string.Format(StatisticsKey, request.CarId, request.MakeId, request.Year);
                    var cachedStatistics = _cacheClient.As<Statistics>();
                    var response = cachedStatistics.Lists[key];

                    if (response != null && response.Any())
                        return response;

                    IEnumerable<Statistics> dbResponse =
                        _connection.Query<Statistics>(SelectStatements.GetStatisticsQuery,
                            new
                            {
                                @CarId = request.CarId,
                                @MakeId = request.MakeId,
                                @YearId = request.Year

                            }).ToList();

                    dbResponse.ForEach(f => response.Add(f));
                    // StoreStatistics(dbResponse.ToList());
                    _cacheClient.Add(key, response, DateTime.UtcNow.AddHours(1));
                    return dbResponse;
                }
            }
        }
    }
}
