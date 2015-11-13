using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneAuto
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