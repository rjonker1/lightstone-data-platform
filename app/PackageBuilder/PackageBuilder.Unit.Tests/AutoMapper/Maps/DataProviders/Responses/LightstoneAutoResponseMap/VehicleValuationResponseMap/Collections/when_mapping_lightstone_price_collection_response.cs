using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses.LightstoneAutoResponseMap.VehicleValuationResponseMap.Collections
{
    public class when_mapping_lightstone_price_collection_response : BaseTestHelper
    {
        private IDataField _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IEnumerable<IRespondWithPriceModel>, DataField>(LightstoneAutoResponseMother.Response.VehicleValuation.Prices);
        }

        [Observation]
        public void should_map_price_data_fields()
        {
            _dataField.Type.ShouldEqual(typeof(IRespondWithPriceModel[]).ToString());

            var dataFields = _dataField.DataFields;
            dataFields.Count().ShouldEqual(1);

            var priceModel = dataFields.FirstOrDefault();
            priceModel.Name.ShouldEqual("PriceModel");
            priceModel.Type.ShouldEqual(typeof(PriceModel).ToString());
            priceModel.DataFields.Count().ShouldEqual(2);

            priceModel.DataFields.FirstOrDefault(x => x.Name == "Name").Name.ShouldEqual("Name");
            priceModel.DataFields.FirstOrDefault(x => x.Name == "Name").Type.ShouldEqual(typeof(string).ToString());

            priceModel.DataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            priceModel.DataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(decimal).ToString());
        }
    }
}