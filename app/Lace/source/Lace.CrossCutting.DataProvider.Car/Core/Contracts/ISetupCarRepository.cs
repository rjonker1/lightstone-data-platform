using Lace.CrossCutting.DataProvider.Car.Core.Models;
using Lace.CrossCutting.DataProvider.Car.Repositories;

namespace Lace.CrossCutting.DataProvider.Car.Core.Contracts
{
    public interface ISetupCarRepository
    {
        IReadOnlyCarRepository<CarInfo> CarInfoRepository();
        IReadOnlyCarRepository<CarInfo> Vin12CarInfoRepository();
        void Dispose();
    }
}