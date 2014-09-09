using System.Linq;
using Lace.Request;
using Lace.Source.Lightstone.Cars;
using Lace.Source.Lightstone.DataObjects;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.RequestBuilder;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeRetrieveCarInformationDetail : IRetrieveCarInformation
    {
        public bool IsSatisfied { get; private set; }
        public CarInfo CarInformation { get; private set; }
        public ILaceRequestCarInformation CarInformationRequest { get; private set; }

        private ILaceRequest _request;
        private IGetCarInfo _getCarInformation;

        public FakeRetrieveCarInformationDetail(ILaceRequest request)
        {
            _request = request;
            CarInformationRequest = new CarInformationRequest(_request.Vehicle.Vin);
        }

        public IRetrieveCarInformation SetupDataSources()
        {
            _getCarInformation = new CarInfoData(new FakeCarInfoRepository(), 
                new FakeVin12CarInfoRepository());
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
            CarInformationRequest.SetCarModelYear(CarInformation.CarId, CarInformation.CarModel, CarInformation.Year);
            return this;
        }
    }
}
