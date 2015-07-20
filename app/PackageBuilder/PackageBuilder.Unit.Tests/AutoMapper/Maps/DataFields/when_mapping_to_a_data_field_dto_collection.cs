using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataFields
{
    public class when_mapping_to_a_data_field_dto_collection : Specification
    {
        private IEnumerable<DataProviderFieldItemDto> _dtos;
        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new ServiceLocatorInstaller(), new BusInstaller(), new NEventStoreInstaller(), new NHibernateInstaller(), new RepositoryInstaller(), new AutoMapperInstaller());

            OverrideHelper.OverrideNhibernateCfg(container);

            _dtos = Mapper.Map<IEnumerable<DataField>, IEnumerable<DataProviderFieldItemDto>>(new []{ DataFieldMother.CategoryCode, DataFieldMother.CategoryDescription, DataFieldMother.SpecificInformation }.Cast<DataField>());
        }

        [Observation]
        public void should_map_all_properties()
        {
            _dtos.Count().ShouldEqual(3);
            _dtos.First(x => x.Name == "SpecificInformation").DataFields.Count().ShouldEqual(6);
        }
    }
}