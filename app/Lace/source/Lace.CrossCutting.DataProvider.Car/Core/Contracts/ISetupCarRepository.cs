using Lace.CrossCutting.DataProviderCommandSource.Car.Core.Models;
using Lace.CrossCutting.DataProviderCommandSource.Car.Repositories;

namespace Lace.CrossCutting.DataProviderCommandSource.Car.Core.Contracts
{
    public interface ISetupCarRepository
    {
        IReadOnlyCarRepository<CarInfo> CarInfoRepository();
        IReadOnlyCarRepository<CarInfo> Vin12CarInfoRepository();
        void Dispose();
    }
}