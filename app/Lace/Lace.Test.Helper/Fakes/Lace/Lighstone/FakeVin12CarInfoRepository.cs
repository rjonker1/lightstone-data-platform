﻿using System;
using System.Collections.Generic;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeVin12CarInfoRepository : IReadOnlyRepository<CarInfo>
    {
        public IEnumerable<CarInfo> FindAllWithRequest(global::Lace.Request.ILaceRequestCarInformation request)
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

        public IEnumerable<CarInfo> FindByMakeAndMetricTypes(int makeId, Source.Lightstone.Metrics.MetricTypes[] metricTypes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarInfo> FindByCarIdAndYear(int? carId, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarInfo> FindByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }
    }
}
