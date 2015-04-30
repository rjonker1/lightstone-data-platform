using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Core.Models;
using Lace.CrossCutting.DataProvider.Car.Infrastructure.Dto;
using Lace.CrossCutting.DataProvider.Car.UnitOfWork;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.CrossCutting.DataProvider.Car.Infrastructure
{
    public class GetCarInformation : IRetrieveCarInformation
    {
        public bool IsSatisfied { get; private set; }
        public CarInformation CarInformation { get; private set; }
        public IHaveCarInformation CarInformationRequest { get; private set; }

        private IGetCarInformation _getCarInformation;
        private readonly ISetupCarRepository _repositories;

        public GetCarInformation(string vinNumber, ISetupCarRepository repositories)
        {
            _repositories = repositories;
            CarInformationRequest = new CarInformationRequest(vinNumber);
        }

        public GetCarInformation(int carId, ISetupCarRepository repositories)
        {
            _repositories = repositories;
            CarInformationRequest = new CarInformationRequest(carId);
        }

        public IRetrieveCarInformation SetupDataSources()
        {
            _getCarInformation = new CarInformationWorker(_repositories.CarInformationRepository(),
                _repositories.Vin12CarInformationRepository());
            return this;
        }

        public IRetrieveCarInformation BuildCarInformation()
        {
            IsSatisfied = _getCarInformation.Cars.Any();

            CarInformation = IsSatisfied ? _getCarInformation.Cars.FirstOrDefault() : new CarInformation();
            return this;
        }

        public IRetrieveCarInformation GenerateData()
        {
            _getCarInformation.GetCarInformation(CarInformationRequest);
            return this;
        }

        public IRetrieveCarInformation BuildCarInformationRequest()
        {
            if (CarInformation == null) return this;

            CarInformationRequest.SetCarModelYearMake(CarInformation.CarId, CarInformation.CarModel, CarInformation.Year, CarInformation.MakeId);
            return this;
        }
    }
}
