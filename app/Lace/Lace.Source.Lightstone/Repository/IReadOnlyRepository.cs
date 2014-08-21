using System.Collections.Generic;
using Lace.Request;
using Lace.Source.Lightstone.Metrics;

namespace Lace.Source.Lightstone.Repository
{
    public interface IReadOnlyRepository<T>
    {
        //T FindWithId(int id);
        //T FindWithRequest(ILaceRequestCarInformation request);
        IEnumerable<T> FindAllWithRequest(ILaceRequestCarInformation request);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindByMake(int makeId);
        IEnumerable<T> FindByMakeAndMetricTypes(int makeId, MetricTypes[] metricTypes);
        IEnumerable<T> FindByCarIdAndYear(int? carId, int year);
        IEnumerable<T> FindByVin(string vinNumber);
    }
}
