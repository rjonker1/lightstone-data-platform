using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses.LightstoneResponseMap.VehicleValuationResponseMap.Collections
{
    public class when_mapping_lightstone_price_collection_response : BaseTestHelper
    {
        private IDataField _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IEnumerable<IRespondWithPriceModel>, DataField>(LightstoneResponseMother.Response.VehicleValuation.Prices);
        }

        [Observation]
        public void should_map_price_data_fields()
        {
            _dataField.Name.ShouldEqual("Prices");
            _dataField.Type.ShouldEqual(typeof(List<IRespondWithPriceModel>).ToString());

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(2);

            dataFields.FirstOrDefault(x => x.Name == "Name").Name.ShouldEqual("Name");
            dataFields.FirstOrDefault(x => x.Name == "Name").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            dataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(decimal).ToString());
        }
    }
}