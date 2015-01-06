using System.Linq;
using Lace.CrossCutting.DataProviderCommandSource.Car.Core.Contracts;
using Lace.CrossCutting.DataProviderCommandSource.Car.Core.Models;
using Lace.CrossCutting.DataProviderCommandSource.Car.Infrastructure.Dto;
using Lace.CrossCutting.DataProviderCommandSource.Car.UnitOfWork;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.CrossCutting.DataProviderCommandSource.Car.Infrastructure
{
    public class RetrieveCarInformationDetail : IRetrieveCarInformation
    {
        public bool IsSatisfied { get; private set; }
        public CarInfo CarInformation { get; private set; }
        public IProvideCarInformationForRequest CarInformationRequest { get; private set; }

        private IGetCarInfo _getCarInformation;
        private readonly ISetupCarRepository _repositories;
        private readonly ILaceRequest _request;

        public RetrieveCarInformationDetail(ILaceRequest request, ISetupCarRepository repositories)
        {
            _repositories = repositories;
            _request = request;
            CarInformationRequest = new CarInformationRequest(_request.Vehicle.Vin);
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
