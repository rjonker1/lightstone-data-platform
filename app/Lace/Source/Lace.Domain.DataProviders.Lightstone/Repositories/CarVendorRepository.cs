using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.SqlStatements;
using Lace.Domain.DataProviders.Lightstone.Services;
using ServiceStack.Redis;

namespace Lace.Domain.DataProviders.Lightstone.Repositories
{
    public class CarVendorRepository : IReadOnlyRepository<CarVendor>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string CarVendorKey = "urn:Auto_Carstats:CarVendor";

        public CarVendorRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<CarVendor> FindAllWithRequest(IProvideCarInformationForRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarVendor> GetAll()
        {
            using (_connection)
            using (_cacheClient)
            {
                var carVendors = _cacheClient.As<CarVendor>();
                var response = carVendors.Lists[CarVendorKey];

                if (response != null && response.Any())
                    return response;

                var dbResponse = _connection
                    .Query(SelectStatements.GetAllCarVendors)
                    .ToList();

                dbResponse.ForEach(
                    f =>
                        response.Add(new CarVendor(f.CarModelId, f.Car_ID, f.MakeName, f.CarTypeName, f.SaleYear_ID,
                            f.CarModel, f.CarFullName, f.ImageUrlSmall)));

                _cacheClient.Add(CarVendorKey, response, DateTime.UtcNow.AddDays(1));
                return response;
            }
        }


        public IEnumerable<CarVendor> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarVendor> FindByCarIdAndYear(int? carId, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarVendor> FindByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarVendor> FindByMakeAndMetricTypes(int makeId, MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }
    }
}
