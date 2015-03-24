using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataFields
{
    public class when_mapping_to_a_single_data_field_override_collection : Specification
    {
        private IEnumerable<IDataFieldOverride> _dataFieldOverrides;
        public override void Observe()
        {
            var container = new WindsorContainer();

            container.Install(new ServiceLocatorInstaller(), new RepositoryInstaller(), new AutoMapperInstaller());

            _dataFieldOverrides = Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataFieldOverride>>(new[] { DataFieldDtoMother.SpecificInformation, DataFieldDtoMother.CarFullname, DataFieldDtoMother.CategoryCode, DataFieldDtoMother.Colour });
        }

        [Observation]
        public void should_map_all_properties()
        {
            _dataFieldOverrides.Count().ShouldEqual(4);
            _dataFieldOverrides.First(x => x.Name == "SpecificInformation").DataFieldOverrides.Count().ShouldEqual(6);
        }
    }
}