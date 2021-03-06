﻿using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneAuto
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