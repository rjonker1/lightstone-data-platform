using System.Linq;
using AutoMapper;
using Castle.Windsor;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.TestHelper;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataProviders
{
    public class when_mapping_to_a_single_data_provider_override : Specification
    {
        private IDataProviderOverride _dto;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Kernel.ComponentModelCreated += OverrideHelper.OverrideContainerLifestyle;
            container.Install(new NHibernateInstaller());
            OverrideHelper.OverrideNhibernateCfg(container);

            container.Install(new ServiceLocatorInstaller(), new RepositoryInstaller(), new AutoMapperInstaller());

            _dto = Mapper.Map<DataProviderDto, DataProviderOverride>(DataProviderDtoMother.Ivid);
        }

        [Observation]
        public void should_map_all_fields()
        {
            _dto.Id.ShouldNotBeNull();;
            _dto.CostOfSale.ShouldEqual(10m);
            _dto.DataFieldOverrides.Count().ShouldEqual(2);
            _dto.DataFieldOverrides.FirstOrDefault(x => x.Name == "CarFullname").Name.ShouldNotBeNull();
            _dto.DataFieldOverrides.FirstOrDefault(x => x.Name == "SpecificInformation").DataFieldOverrides.Count().ShouldEqual(6);
            _dto.DataFieldOverrides.FirstOrDefault(x => x.Name == "SpecificInformation").DataFieldOverrides.FirstOrDefault(x => x.Name == "Colour").ShouldNotBeNull();
            _dto.DataFieldOverrides.FirstOrDefault(x => x.Name == "SpecificInformation").DataFieldOverrides.FirstOrDefault(x => x.Name == "EngineNumber").ShouldNotBeNull();
            _dto.DataFieldOverrides.FirstOrDefault(x => x.Name == "SpecificInformation").DataFieldOverrides.FirstOrDefault(x => x.Name == "LicenseNumber").ShouldNotBeNull();
            _dto.DataFieldOverrides.FirstOrDefault(x => x.Name == "SpecificInformation").DataFieldOverrides.FirstOrDefault(x => x.Name == "Odometer").ShouldNotBeNull();
            _dto.DataFieldOverrides.FirstOrDefault(x => x.Name == "SpecificInformation").DataFieldOverrides.FirstOrDefault(x => x.Name == "RegistrationNumber").ShouldNotBeNull();
            _dto.DataFieldOverrides.FirstOrDefault(x => x.Name == "SpecificInformation").DataFieldOverrides.FirstOrDefault(x => x.Name == "VinNumber").ShouldNotBeNull();
        }
    }
}