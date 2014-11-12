using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto;

namespace PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations
{
    public class TotalSalesByGenderModelBuilder
    {
        private string _carType;
        private string _band;
        private double _value;

        public IRespondWithTotalSalesByGenderModel Build()
        {
            return new TotalSalesByGenderModel(_carType, _band, _value);
        }

        public TotalSalesByGenderModelBuilder With(string carType, string band)
        {
            _carType = carType;
            _band = band;

            return this;
        }

        public TotalSalesByGenderModelBuilder With(double value)
        {
            _value = value;
            return this;
        }
    }
}