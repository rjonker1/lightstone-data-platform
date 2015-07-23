using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.AutoMapper.DataFields
{
    public class when_mapping_to_a_single_data_field_dto : MemoryTestDataBaseHelper
    {
        private DataProviderFieldItemDto _dto;
        public override void Observe()
        {
            RefreshDb();

            SaveAndFlush(IndustryMother.All);

            _dto = Mapper.Map<DataField, DataProviderFieldItemDto>(DataFieldMother.SpecificInformation as DataField);
        }

        [Observation]
        public void should_map_all_properties()
        {
            _dto.Name.ShouldEqual("SpecificInformation");
            _dto.Label.ShouldEqual("Label");
            _dto.Definition.ShouldEqual("Definition");
            _dto.CostOfSale.ShouldEqual(10d);
            _dto.IsSelected.Value.ShouldBeTrue();
            _dto.Industries.Count().ShouldEqual(3);
            _dto.DataFields.Count().ShouldEqual(6);
            _dto.Type.ShouldEqual("System.String");
        }
    }
}