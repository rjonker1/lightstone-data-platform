using System.Linq;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Core.Models;
using Lace.CrossCutting.DataProvider.Car.Infrastructure.Dto;
using Lace.CrossCutting.DataProvider.Car.UnitOfWork;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.CrossCutting.DataProvider.Car.Infrastructure
{
    public class RetrieveCarInformationDetail : IRetrieveCarInformation
    {
        public bool IsSatisfied { get; private set; }
        public CarInfo CarInformation { get; private set; }
        public IHaveCarInformation CarInformationRequest { get; private set; }

        private IGetCarInfo _getCarInformation;
        private readonly ISetupCarRepository _repositories;
        private readonly IHaveVehicle _request;

        public RetrieveCarInformationDetail(IHaveVehicle request, ISetupCarRepository repositories)
        {
            _repositories = repositories;
            _request = request;
            CarInformationRequest = new CarInformationRequest(_request.Vin);
        }

        public IRetrieveCarInformation SetupDataSources()
        {
            _getCarInformation = new CarInfoUnitOfWork(_repositories.CarInfoRepository(),
                _repositories.Vin12CarInfoRepository());
            return this;
        }

        public IRetrieveCarInformation BuildCarInformation()
        {
            IsSatisfied = _getCarInformation.Cars.Any();

            CarInformation = IsSatisfied ? _getCarInformation.Cars.FirstOrDefault() : new CarInfo();
            return this;
        }

        public IRetrieveCarInformation GenerateData()
        {
            _getCarInformation.GetCarInfo(CarInformationRequest);
            return this;
        }

        public IRetrieveCarInformation BuildCarInformationRequest()
        {
            if (CarInformation == null) return this;

            CarInformationRequest.SetCarModelYear(CarInformation.CarId, CarInformation.CarModel, CarInformation.Year);
            return this;
        }
    }
}
