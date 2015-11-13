using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataFields
{
    public class when_mapping_to_a_single_data_field_override : BaseTestHelper
    {
        private IDataFieldOverride _dataFieldOverride;
        public override void Observe()
        {
            _dataFieldOverride = Mapper.Map<DataProviderFieldItemDto, DataFieldOverride>(DataFieldDtoMother.SpecificInformation);
        }

        [Observation]
        public void should_map_all_properties()
        {
            _dataFieldOverride.Name.ShouldEqual("SpecificInformation");
            _dataFieldOverride.CostOfSale.ShouldEqual(10d);
            _dataFieldOverride.DataFieldOverrides.Count().ShouldEqual(7);
        }
    }
}