using AutoMapper;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper
{
    public class when_creating_maps : BaseTestHelper
    {
        public override void Observe()
        {

        }

        [Observation]
        public void configuration_should_be_valid()
        {
            //Mapper.AssertConfigurationIsValid();
        }
    }
}