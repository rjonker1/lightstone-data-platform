using System.Collections.Generic;

namespace Lace.CrossCutting.DataProvider.Car.Repositories
{
    public interface IReadOnlyCarRepository<T>
    {
        IEnumerable<T> FindByCarIdAndYear(int? carId, int year);
        IEnumerable<T> FindByVin(string vinNumber);
    }
}
