using System.Collections.Generic;

namespace Lace.Domain.DataProviders.Lightstone.Core
{
    public interface IReadOnlyRepository<T>
    {
        IEnumerable<T> Get(string sql, object param);
        IEnumerable<T> GetAll(string sql);
        //IEnumerable<T> FindAllWithRequest(IHaveCarInformation request);
        //IEnumerable<T> GetAll();
        //IEnumerable<T> FindByMake(int makeId);
        //IEnumerable<T> FindByMakeAndMetricTypes(int makeId, MetricTypes[] metricTypes);
        //IEnumerable<T> FindByCarIdAndYear(int? carId, int year);
        //IEnumerable<T> FindByVin(string vinNumber);
    }
}
