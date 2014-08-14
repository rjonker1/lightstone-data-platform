using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository.Infrastructure;
using Lace.Source.Lightstone.Repository.Sql;
using ServiceStack.Redis;

namespace Lace.Source.Lightstone.Repository
{
    public class StatisticsRepository : IReadOnlyRepository<Statistics>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string StatisticsKey = "urn:Statistics";

        public StatisticsRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public Statistics FindWithId(int id)
        {
            throw new NotImplementedException();
        }

        public Statistics FindWithRequest(IHaveLightstoneRequest request)
        {
          throw new NotImplementedException();
        }

        public IEnumerable<Statistics> FindAllWithRequest(IHaveLightstoneRequest request)
        {
            using (_connection)
            {
                using (_cacheClient)
                {
                    var cachedStatistics = _cacheClient.As<Statistics>();
                    var response = cachedStatistics.Lists[StatisticsKey].GetAll();

                    if (response != null)
                    {
                        var stats = response.Where(w => w.Car_ID == request.CarId).ToList();
                        if (stats.Any()) return stats;
                    }

                    var dbResponse =
                        _connection.Query<Statistics>(LighstoneSqlQueries.GetStatisticsQuery(),
                            new {@CarId = request.CarId}).ToList();

                    if (dbResponse.Any())
                    {
                        // StoreStatistics(dbResponse.ToList());
                        _cacheClient.Add(StatisticsKey, dbResponse, DateTime.UtcNow.AddHours(1));
                    }

                    return dbResponse;
                    //var response =
                    //    _cacheClient.GetAll<Statistics>(StatisticsKey).Where(w => w.Value.Car_ID == request.CarId);
                }
            }
        }

        //private void StoreStatistics(IEnumerable<Statistics> statistics)
        //{
        //    var stats = _cacheClient.As<Statistics>();
        //    var res =  Inject(statistics);
        //}

        //public List<T> Inject<T>(IEnumerable<T> entities)
        //    where T : IHaveStatisticsRepository
        //{
        //    var entitiesList = entities.ToList();
        //    entitiesList.ForEach(x => x.Repository = this);
        //    return entitiesList;
        //}
       
    }
}
