using System.Collections.Generic;

namespace Lace.CrossCutting.DataProvider.Car.Repositories
{
    public interface IReadOnlyCarRepository<T>
    {
        IEnumerable<T> Get(string sql, object param, string cacheKey);
        IEnumerable<T> GetAll(string sql, string cacheKey);
    }
}
