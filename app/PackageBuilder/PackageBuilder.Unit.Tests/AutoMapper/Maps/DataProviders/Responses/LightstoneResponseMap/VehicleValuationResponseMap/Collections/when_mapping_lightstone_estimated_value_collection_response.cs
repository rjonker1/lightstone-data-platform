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
    public class when_mapping_lightstone_estimated_value_collection_response : when_not_persisting_entities
    {
        private IDataField _dataField;

        public override void Observe()
        {
            base.Observe();

            _dataField = Mapper.Map<IEnumerable<IRespondWithEstimatedValueModel>, DataField>(LightstoneResponseMother.Response.VehicleValuation.EstimatedValue);
        }

        [Observation]
        public void should_map_estimated_value_data_fields()
        {
            _dataField.Name.ShouldEqual("EstimatedValue");
            _dataField.Type.ShouldEqual(typeof(List<IRespondWithEstimatedValueModel>).ToString());

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(10);

            dataFields.FirstOrDefault(x => x.Name == "RetailEstimatedValue").Name.ShouldEqual("RetailEstimatedValue");
            dataFields.FirstOrDefault(x => x.Name == "RetailEstimatedValue").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "RetailEstimatedLow").Name.ShouldEqual("RetailEstimatedLow");
            dataFields.FirstOrDefault(x => x.Name == "RetailEstimatedLow").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "RetailEstimatedHigh").Name.ShouldEqual("RetailEstimatedHigh");
            dataFields.FirstOrDefault(x => x.Name == "RetailEstimatedHigh").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "RetailConfidenceValue").Name.ShouldEqual("RetailConfidenceValue");
            dataFields.FirstOrDefault(x => x.Name == "RetailConfidenceValue").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "RetailConfidenceLevel").Name.ShouldEqual("RetailConfidenceLevel");
            dataFields.FirstOrDefault(x => x.Name == "RetailConfidenceLevel").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "TradeEstimatedValue").Name.ShouldEqual("TradeEstimatedValue");
            dataFields.FirstOrDefault(x => x.Name == "TradeEstimatedValue").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "TradeEstimatedLow").Name.ShouldEqual("TradeEstimatedLow");
            dataFields.FirstOrDefault(x => x.Name == "TradeEstimatedLow").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "TradeEstimatedHigh").Name.ShouldEqual("TradeEstimatedHigh");
            dataFields.FirstOrDefault(x => x.Name == "TradeEstimatedHigh").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "TradeConfidenceValue").Name.ShouldEqual("TradeConfidenceValue");
            dataFields.FirstOrDefault(x => x.Name == "TradeConfidenceValue").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "TradeConfidenceLevel").Name.ShouldEqual("TradeConfidenceLevel");
            dataFields.FirstOrDefault(x => x.Name == "TradeConfidenceLevel").Type.ShouldEqual(typeof(string).ToString());
        }
    }
}