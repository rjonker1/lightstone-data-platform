using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Test.Helper.Builders.Sources.Lightstone;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    //public class FakeCarRepository : IReadOnlyRepository<Car>
    //{
    //    public IEnumerable<Car> FindAllWithRequest(IHaveCarInformation request)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public IEnumerable<Car> GetAll()
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public IEnumerable<Car> FindByMake(int makeId)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public IEnumerable<Car> FindByMakeAndMetricTypes(int makeId, MetricTypes[] metricTypes)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public IEnumerable<Car> FindByCarIdAndYear(int? carId, int year)
    //    {
    //        return CarDataBuilder.ForCarsOnly().Where(w => w.Car_ID == carId);
    //    }

    //    public IEnumerable<Car> FindByVin(string vinNumber)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}
}
