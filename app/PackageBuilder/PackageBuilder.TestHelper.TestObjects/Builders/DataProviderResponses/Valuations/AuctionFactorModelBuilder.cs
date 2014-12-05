using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.Valuations
{
    public class AuctionFactorModelBuilder
    {
        private string _make;
        private decimal _value;

        public IRespondWithAuctionFactorModel Build()
        {
            return new AuctionFactorModel(_make, _value);
        }

        public AuctionFactorModelBuilder With(string make)
        {
            _make = make;
            return this;
        }

        public AuctionFactorModelBuilder With(decimal value)
        {
            _value = value;
            return this;
        }
    }
}