﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.SqlStatements;
using Lace.Domain.DataProviders.Lightstone.Services;
using ServiceStack.Redis;

namespace Lace.Domain.DataProviders.Lightstone.Repositories
{
    public class MunicipalityRepository : IReadOnlyRepository<Municipality>
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        private const string MunicipaliiesKey = "urn:Auto_Carstats:Municipality";


        public MunicipalityRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IEnumerable<Municipality> FindAllWithRequest(IHaveCarInformation request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Municipality> GetAll()
        {
            //using (_connection)
            using (_cacheClient)
            {
                var cacheMuncipalities = _cacheClient.As<Municipality>();
                var response = cacheMuncipalities.Lists[MunicipaliiesKey];

                if (response.DoesExistInTheCache())
                    return response;

                var dbResponse = _connection
                    .Query<Municipality>(SelectStatements.GetAllTheMuncipalities)
                    .ToList();

                if (!response.CanAddItemsToCache().HasValue)
                    return dbResponse;

                dbResponse.ForEach(f => response.Add(f));
                dbResponse.AddItemsToCache(_cacheClient, MunicipaliiesKey, DateTime.UtcNow.AddDays(1));
                return dbResponse;
            }
        }

        public IEnumerable<Municipality> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Municipality> FindByMakeAndMetricTypes(int makeId, MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Municipality> FindByCarIdAndYear(int? carId, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Municipality> FindByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }
    }
}
