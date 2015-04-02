using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Test.Helper.Builders.Sources.Lightstone;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeMunicipalityRepository : IReadOnlyRepository<Municipality>
    {
        public IEnumerable<Municipality> FindAllWithRequest(IHaveCarInformation request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Municipality> GetAll()
        {
            return MuncipalityDataBuilder.ForAllMunicipalities();
        }

        public IEnumerable<Municipality> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Municipality> FindByMakeAndMetricTypes(int makeId,
            MetricTypes[] metricTypes)
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
