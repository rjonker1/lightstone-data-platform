using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany
{
    public class LightstoneBusinessDirectorResponseBuilder
    {
        private IEnumerable<IProvideDirector> _directors;
        public IProvideDataFromLightstoneBusinessDirector Build()
        {
            return new LightstoneBusinessDirectorResponse(_directors);
        }

        public LightstoneBusinessDirectorResponseBuilder With(params IProvideDirector[] directors)
        {
            _directors = directors;
            return this;
        }
    }
}