using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Property;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneProperty
{
    public class LightstonePropertyResponseBuilder
    {
        private IEnumerable<IRespondWithProperty> _properties;
        public IProvideDataFromLightstoneProperty Build()
        {
            return new LightstonePropertyResponse(_properties);
        }

        public LightstonePropertyResponseBuilder With(params IRespondWithProperty[] properties)
        {
            _properties = properties;
            return this;
        }
    }
}