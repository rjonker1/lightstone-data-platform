using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses
{
    public class LightstoneBusinessCompanyResponseBuilder
    {
        private IEnumerable<IProvideCompany> _companies;
        public IProvideDataFromLightstoneBusinessCompany Build()
        {
            return new LightstoneBusinessCompanyResponse(_companies);
        }

        public LightstoneBusinessCompanyResponseBuilder With(params IProvideCompany[] companies)
        {
            _companies = companies;
            return this;
        }
    }
}