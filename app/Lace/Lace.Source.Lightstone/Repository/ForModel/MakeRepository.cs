﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.Request;
using Lace.Source.Lightstone.Metrics;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository.Infrastructure;
using Lace.Source.Lightstone.Repository.Sql;
using ServiceStack.Redis;

namespace Lace.Source.Lightstone.Repository.ForModel
{
    public class MakeRepository : IReadOnlyRepository<Make>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string MakeKey = "urn:Auto_Carstats:Make";

        public MakeRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<Make> FindAllWithRequest(ILaceRequestCarInformation request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Make> GetAll()
        {
            using (_connection)
            {
                using (_cacheClient)
                {
                    var makes = _cacheClient.As<Make>();
                    var response = makes.Lists[MakeKey];

                    if (response != null && response.Any())
                        return response;

                    var dbResponse = _connection
                        .Query<Make>(SelectStatements.GetAllTheMakes)
                        .ToList();

                    dbResponse.ForEach(f => response.Add(f));
                    _cacheClient.Add(MakeKey, response);
                    return dbResponse;

                }
            }
        }


        public IEnumerable<Make> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Make> FindByMakeAndMetricTypes(int makeId, MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Make> FindByCarIdAndYear(int? carId, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Make> FindByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }
    }
}
