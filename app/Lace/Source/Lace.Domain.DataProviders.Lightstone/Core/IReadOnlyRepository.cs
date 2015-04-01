using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Services;

namespace Lace.Domain.DataProviders.Lightstone.Core
{
    public interface IReadOnlyRepository<T>
    {
        IEnumerable<T> FindAllWithRequest(IHaveCarInformation request);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindByMake(int makeId);
        IEnumerable<T> FindByMakeAndMetricTypes(int makeId, MetricTypes[] metricTypes);
        IEnumerable<T> FindByCarIdAndYear(int? carId, int year);
        IEnumerable<T> FindByVin(string vinNumber);
    }
}
