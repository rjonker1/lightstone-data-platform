using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository.Infrastructure;
using Lace.Source.Lightstone.Repository.Sql;
using ServiceStack.Redis;

namespace Lace.Source.Lightstone.Repository.ForModel
{
    public class Vin12CarInfoRepository : IReadOnlyRepository<CarInfo>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string CarKey = "urn:Auto_Carstats:Vin12CarInfo:{0}:{1}";

        public Vin12CarInfoRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }


        public IEnumerable<CarInfo> FindAllWithRequest(Request.ILaceRequestCarInformation request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarInfo> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarInfo> FindByMakeAndMetricTypes(int makeId, Metrics.MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarInfo> FindByCarIdAndYear(int? carId, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarInfo> FindByVin(string vinNumber)
        {
            using (_connection)
            {
                using (_cacheClient)
                {
                    var key = string.Format(CarKey, vinNumber, 0);
                    var cachedCar = _cacheClient.As<CarInfo>();
                    var response = cachedCar.Lists[key];

                    if (response != null && response.Any())
                        return response;

                    var dbResponse =
                        _connection.Query<CarInfo>(SelectStatements.GetCarInformationByVin12, new { @Vin = vinNumber })
                            .ToList();

                    dbResponse.ForEach(f => response.Add(f));
                    _cacheClient.Add(key, response, DateTime.UtcNow.AddDays(1));
                    return dbResponse;
                }
            }
        }
    }
}
