using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.Valuations
{
    public class ConfidenceModelBuilder
    {
        private string _carType;
        private int _year;
        private double _value;

        public IRespondWithConfidenceModel Build()
        {
            return new ConfidenceModel(_carType, _year, _value);
        }

        public ConfidenceModelBuilder With(string carType)
        {
            _carType = carType;
            return this;
        }

        public ConfidenceModelBuilder With(int year)
        {
            _year = year;
            return this;
        }

        public ConfidenceModelBuilder With(double value)
        {
            _value = value;
            return this;
        }
    }
}