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
    public class CarVendorRepository : IReadOnlyRepository<CarVendor>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string CarVendorKey = "urn:CarVendor";

        public CarVendorRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<CarVendor> FindAllWithRequest(Request.ILaceRequestCarInformation request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarVendor> GetAll()
        {
            using (_connection)
            {
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
        }
    }
}
