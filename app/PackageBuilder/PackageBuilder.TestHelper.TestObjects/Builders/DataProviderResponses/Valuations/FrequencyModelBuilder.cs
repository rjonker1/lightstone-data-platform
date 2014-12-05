using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.Valuations
{
    public class FrequencyModelBuilder
    {
        private string _carType;
        private int _year;
        private double _value;

        public IRespondWithFrequencyModel Build()
        {
            return new FrequencyModel(_carType, _year, _value);
        }

        public FrequencyModelBuilder With(string carType)
        {
            _carType = carType;
            return this;
        }

        public FrequencyModelBuilder With(int year)
        {
            _year = year;
            return this;
        }

        public FrequencyModelBuilder With(double value)
        {
            _value = value;
            return this;
        }
    }
}