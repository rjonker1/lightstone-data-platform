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
    public class when_mapping_to_a_single_data_field : BaseTestHelper
    {
        private IDataField _dataField;
        public override void Observe()
        {
            _dataField = Mapper.Map<DataProviderFieldItemDto, DataField>(DataFieldDtoMother.SpecificInformation);
        }

        [Observation]
        public void should_map_all_properties()
        {
            _dataField.Name.ShouldEqual("SpecificInformation");
            _dataField.Label.ShouldEqual("Label");
            _dataField.Definition.ShouldEqual("Definition");
            _dataField.CostOfSale.ShouldEqual(10);
            _dataField.IsSelected.Value.ShouldBeTrue();
            _dataField.Industries.Count().ShouldEqual(0);
            _dataField.DataFields.Count().ShouldEqual(6);
            //_dataField.Type.ToString().ShouldEqual("System.String");
        }
    }
}