using System.Linq;
using AutoMapper;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataFields
{
    public class when_mapping_to_a_single_data_field_dto : when_persisting_entities_to_db
    {
        private DataProviderFieldItemDto _dto;
        public override void Observe()
        {
            base.Observe();

            Container.Install(new ServiceLocatorInstaller(), new RepositoryInstaller(), new AutoMapperInstaller());

            SaveAndFlush(IndustryMother.All);

            _dto = Mapper.Map<IDataField, DataProviderFieldItemDto>(DataFieldMother.SpecificInformation);
        }

        [Observation]
        public void should_map_all_properties()
        {
            _dto.Name.ShouldEqual("SpecificInformation");
            _dto.Label.ShouldEqual("Label");
            _dto.Definition.ShouldEqual("Definition");
            _dto.Price.ShouldEqual(10d);
            _dto.IsSelected.Value.ShouldBeTrue();
            _dto.Industries.Count().ShouldEqual(3);
            _dto.DataFields.Count().ShouldEqual(6);
            _dto.Type.ShouldEqual("System.String");
        }
    }
}