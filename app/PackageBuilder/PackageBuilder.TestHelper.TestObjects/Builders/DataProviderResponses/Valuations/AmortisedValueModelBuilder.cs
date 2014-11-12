using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto;

namespace PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations
{
    public class AmortisedValueModelBuilder
    {
        private string _year;
        private decimal _value;

        public IRespondWithAmortisedValueModel Build()
        {
            return new AmortisedValueModel(_year, _value);
        }

        public AmortisedValueModelBuilder With(string year)
        {
            _year = year;
            return this;
        }

        public AmortisedValueModelBuilder With(decimal value)
        {
            _value = value;
            return this;
        }
    }
}