using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto;

namespace PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations
{
    public class PriceModelBuilder
    {
        private string _name;
        private decimal _value;

        public IRespondWithPriceModel Build()
        {
            return new PriceModel(_name, _value);
        }

        public PriceModelBuilder With(string name)
        {
            _name = name;
            return this;
        }

        public PriceModelBuilder With(decimal value)
        {
            _value = value;
            return this;
        }
    }
}