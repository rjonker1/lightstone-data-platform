using System.Collections.Generic;

namespace Lace.CrossCutting.DataProviderCommandSource.Car.Repositories
{
    public interface IReadOnlyCarRepository<T>
    {
        IEnumerable<T> FindByCarIdAndYear(int? carId, int year);
        IEnumerable<T> FindByVin(string vinNumber);
    }
}
