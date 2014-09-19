using System;
using System.Collections.Generic;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeMunicipalityRepository : IReadOnlyRepository<Municipality>
    {
        public IEnumerable<Municipality> FindAllWithRequest(global::Lace.Request.IProvideCarInformationForRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Municipality> GetAll()
        {
            return Builders.Sources.Lightstone.MuncipalityDataBuilder.ForAllMunicipalities();
        }

        public IEnumerable<Municipality> FindByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Municipality> FindByMakeAndMetricTypes(int makeId,
            Source.Lightstone.Metrics.MetricTypes[] metricTypes)
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
