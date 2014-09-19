using System.Collections.Generic;
using System.Linq;
using Lace.Request;
using Lace.Source.Lightstone.Metrics;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;
using Lace.Test.Helper.Builders.Sources.Lightstone;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeCarRepository : IReadOnlyRepository<Car>
    {
        public IEnumerable<Car> FindAllWithRequest(IProvideCarInformationForRequest request)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Car> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Car> FindByMake(int makeId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Car> FindByMakeAndMetricTypes(int makeId, MetricTypes[] metricTypes)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Car> FindByCarIdAndYear(int? carId, int year)
        {
            return CarDataBuilder.ForCarsOnly().Where(w => w.Car_ID == carId);
        }

        public IEnumerable<Car> FindByVin(string vinNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
