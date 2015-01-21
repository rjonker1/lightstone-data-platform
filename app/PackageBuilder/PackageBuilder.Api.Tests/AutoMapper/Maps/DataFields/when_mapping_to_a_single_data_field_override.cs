using System.Linq;
using AutoMapper;
using Castle.Windsor;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Dtos.WriteModels;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataFields
{
    public class when_mapping_to_a_single_data_field_override : Specification
    {
        private IDataFieldOverride _dataFieldOverride;
        public override void Observe()
        {
            var container = new WindsorContainer();

            container.Install(new ServiceLocatorInstaller(), new RepositoryInstaller(), new AutoMapperInstaller());

            _dataFieldOverride = Mapper.Map<DataProviderFieldItemDto, DataFieldOverride>(DataFieldDtoMother.SpecificInformation);
        }

        [Observation]
        public void should_map_all_properties()
        {
            _dataFieldOverride.Name.ShouldEqual("SpecificInformation");
            _dataFieldOverride.CostOfSale.ShouldEqual(10d);
            _dataFieldOverride.DataFieldOverrides.Count().ShouldEqual(6);
        }
    }
}