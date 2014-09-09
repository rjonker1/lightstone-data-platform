using System.Linq;
using Lace.Request;
using Lace.Source.Lightstone.DataObjects;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository.Factory;
using Lace.Source.Lightstone.RequestBuilder;

namespace Lace.Source.Lightstone.Cars
{
    public class RetrieveCarInformationDetail : IRetrieveCarInformation
    {
        public bool IsSatisfied { get; private set; }
        public CarInfo CarInformation { get; private set; }
        public ILaceRequestCarInformation CarInformationRequest { get; private set; }

        private IGetCarInfo _getCarInformation;
        private readonly ISetupRepositoryForModels _repositories;
        private readonly ILaceRequest _request;

        public RetrieveCarInformationDetail(ILaceRequest request, ISetupRepositoryForModels repositories)
        {
            _repositories = repositories;
            _request = request;
            CarInformationRequest = new CarInformationRequest(_request.Vehicle.Vin);
        }

        public IRetrieveCarInformation SetupDataSources()
        {
            _getCarInformation = new CarInfoData(_repositories.CarInfoRepository(),
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
