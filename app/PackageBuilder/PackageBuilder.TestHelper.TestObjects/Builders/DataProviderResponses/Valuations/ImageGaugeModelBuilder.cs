using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.Valuations
{
    public class ImageGaugeModelBuilder
    {
        private double? _minValue;
        private double? _maxValue;
        private double? _value;
        private double? _quarter;
        private string _gaugeName;

        public IRespondWithImageGaugeModel Build()
        {
            return new ImageGaugeModel(_minValue, _maxValue, _value, _quarter, _gaugeName);
        }

        public ImageGaugeModelBuilder With(double? minValue, double? maxValue, double? value, double? quarter)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _value = value;
            _quarter = quarter;
            return this;
        }

        public ImageGaugeModelBuilder With(string gaugeName)
        {
            _gaugeName = gaugeName;
            return this;
        }
    }
}