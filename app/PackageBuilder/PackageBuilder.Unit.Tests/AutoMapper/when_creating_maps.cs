using Castle.Windsor;
using PackageBuilder.Api.Installers;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper
{
    public class when_creating_maps : Specification
    {
        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());
        }

        [Observation]
        public void configuration_should_be_valid()
        {
            //Mapper.AssertConfigurationIsValid();
        }
    }
}