using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto;

namespace PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations
{
    public class AmortisationFactorBuilder
    {
        private int _year;
        private double _value;

        public IRespondWithAmortisationFactorModel Build()
        {
            return new AmortisationFactorModel(_year, _value);
        }

        public AmortisationFactorBuilder With(int year)
        {
            _year = year;
            return this;
        }

        public AmortisationFactorBuilder With(double value)
        {
            _value = value;
            return this;
        }
    }
}