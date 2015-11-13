using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Finance;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany
{
    public class LightstoneBmwFinanceResponseBuilder
    {
        private IEnumerable<IRespondWithBmwFinance> _finances;
        public IProvideDataFromBmwFinance Build()
        {
            return new BmwFinanceResponse(_finances);
        }

        public LightstoneBmwFinanceResponseBuilder With(params IRespondWithBmwFinance[] finances)
        {
            _finances = finances;
            return this;
        }
    }
}