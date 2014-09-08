using System.Linq;
using Lace.Request;
using Lace.Source.Lightstone.Cars;
using Lace.Source.Lightstone.DataObjects;
using Lace.Source.Lightstone.Models;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeRetrieveCarInformationDetail : IRetrieveCarInformation
    {
        public bool IsSatisfied { get; private set; }
        public CarInfo CarInformation { get; private set; }

        private ILaceRequestCarInformation _request;
        private IGetCarInfo _getCarInformation;

        public FakeRetrieveCarInformationDetail(ILaceRequestCarInformation request)
        {
            _request = request;
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
            _getCarInformation.GetCarInfo(_request);
            return this;
        }
    }
}
