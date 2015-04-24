using Lace.CrossCutting.DataProvider.Car.Core.Models;
using Lace.CrossCutting.DataProvider.Car.Repositories;

namespace Lace.CrossCutting.DataProvider.Car.Core.Contracts
{
    public interface ISetupCarRepository
    {
        IReadOnlyCarRepository<CarInformation> CarInformationRepository();
        IReadOnlyCarRepository<CarInformation> Vin12CarInformationRepository();
        void Dispose();
    }
}