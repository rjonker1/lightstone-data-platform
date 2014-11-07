using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto;

namespace PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations
{
    public class SaleModelBuilder
    {
        private string _salesDate;
        private string _licensingDistrict;
        private string _salesPrice;

        public IRespondWithSaleModel Build()
        {
            return new SaleModel(_salesDate, _licensingDistrict, _salesPrice);
        }

        public SaleModelBuilder With(string salesDate, string licensingDistrict, string salesPrice)
        {
            _salesDate = salesDate;
            _licensingDistrict = licensingDistrict;
            _salesPrice = salesPrice;
            return this;
        }
    }
}