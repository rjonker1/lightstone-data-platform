using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneAuto
{
    public class LightstoneAutoResponseBuilder
    {
        private int _carId;
        private int _year;
        private string _vin;
        private string _imageUrl;
        private string _quarter;
        private string _carFullName;
        private string _model;
        private IRespondWithValuation _vehicleValuation;
        public IProvideDataFromLightstoneAuto Build()
        {
            return new LightstoneAutoResponse(_carId, _year, _vin, _imageUrl, _quarter, _carFullName, _model, _vehicleValuation);
        }

        public LightstoneAutoResponseBuilder With(int carId, int year)
        {
            _carId = carId;
            _year = year;
            return this;
        }

        public LightstoneAutoResponseBuilder With(string vin, string imageUrl, string quarter, string carFullName, string model)
        {
            _vin = vin;
            _imageUrl = imageUrl;
            _quarter = quarter;
            _carFullName = carFullName;
            _model = model;
            return this;
        }

        public LightstoneAutoResponseBuilder With(IRespondWithValuation vehicleValuation)
        {
            _vehicleValuation = vehicleValuation;
            return this;
        } 
    }
}