using Lace.CrossCutting.DataProvider.Car.Repositories;
using Lace.Shared.DataProvider.Models;

namespace Lace.CrossCutting.DataProvider.Car.Core.Contracts
{
    public interface ISetupCarRepository
    {
        IReadOnlyCarRepository<CarInformation> CarInformationRepository();
        IReadOnlyCarRepository<CarInformation> Vin12CarInformationRepository();
        void Dispose();
    }
}