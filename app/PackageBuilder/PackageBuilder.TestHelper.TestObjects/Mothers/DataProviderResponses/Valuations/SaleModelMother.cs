﻿using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses.Valuations;

namespace PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses.Valuations
{
    public class SaleModelMother
    {
        public static IRespondWithSaleModel Sale
        {
            get
            {
                return new SaleModelBuilder()
                    .With("", "", "")
                    .Build();
            }
        }
    }
}