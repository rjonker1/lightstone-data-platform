using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Dto;

namespace PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses
{
    public class LightstoneResponseBuilder
    {
        private int _carId;
        private int _year;
        private string _vin;
        private string _imageUrl;
        private string _quarter;
        private string _carFullName;
        private string _model;
        private IRespondWithValuation _vehicleValuation;
        public IProvideDataFromLightstone Build()
        {
            return new LightstoneResponse(_carId, _year, _vin, _imageUrl, _quarter, _carFullName, _model, _vehicleValuation);
        }

        public LightstoneResponseBuilder With(int carId, int year)
        {
            _carId = carId;
            _year = year;
            return this;
        }

        public LightstoneResponseBuilder With(string vin, string imageUrl, string quarter, string carFullName, string model)
        {
            _vin = vin;
            _imageUrl = imageUrl;
            _quarter = quarter;
            _carFullName = carFullName;
            _model = model;
            return this;
        }

        public LightstoneResponseBuilder With(IRespondWithValuation vehicleValuation)
        {
            _vehicleValuation = vehicleValuation;
            return this;
        } 
    }
}