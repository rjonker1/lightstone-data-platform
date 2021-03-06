﻿using System.Collections.Generic;
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
    public class when_mapping_lightstone_estimated_value_collection_response : BaseTestHelper
    {
        private IDataField _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IEnumerable<IRespondWithEstimatedValueModel>, DataField>(LightstoneAutoResponseMother.Response.VehicleValuation.EstimatedValue);
        }

        [Observation]
        public void should_map_estimated_value_data_fields()
        {
            _dataField.Type.ShouldEqual(typeof(IRespondWithEstimatedValueModel[]).ToString());

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(1);

            var estimatedValueModel = dataFields.FirstOrDefault();
            estimatedValueModel.Name.ShouldEqual("EstimatedValueModel");
            estimatedValueModel.Type.ShouldEqual(typeof(EstimatedValueModel).ToString());
            estimatedValueModel.DataFields.Count().ShouldEqual(14);

            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "RetailEstimatedValue").Name.ShouldEqual("RetailEstimatedValue");
            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "RetailEstimatedValue").Type.ShouldEqual(typeof(string).ToString());

            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "RetailEstimatedLow").Name.ShouldEqual("RetailEstimatedLow");
            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "RetailEstimatedLow").Type.ShouldEqual(typeof(string).ToString());

            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "RetailEstimatedHigh").Name.ShouldEqual("RetailEstimatedHigh");
            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "RetailEstimatedHigh").Type.ShouldEqual(typeof(string).ToString());

            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "RetailConfidenceValue").Name.ShouldEqual("RetailConfidenceValue");
            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "RetailConfidenceValue").Type.ShouldEqual(typeof(string).ToString());

            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "RetailConfidenceLevel").Name.ShouldEqual("RetailConfidenceLevel");
            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "RetailConfidenceLevel").Type.ShouldEqual(typeof(string).ToString());

            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "TradeEstimatedValue").Name.ShouldEqual("TradeEstimatedValue");
            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "TradeEstimatedValue").Type.ShouldEqual(typeof(string).ToString());

            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "TradeEstimatedLow").Name.ShouldEqual("TradeEstimatedLow");
            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "TradeEstimatedLow").Type.ShouldEqual(typeof(string).ToString());

            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "TradeEstimatedHigh").Name.ShouldEqual("TradeEstimatedHigh");
            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "TradeEstimatedHigh").Type.ShouldEqual(typeof(string).ToString());

            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "TradeConfidenceValue").Name.ShouldEqual("TradeConfidenceValue");
            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "TradeConfidenceValue").Type.ShouldEqual(typeof(string).ToString());

            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "TradeConfidenceLevel").Name.ShouldEqual("TradeConfidenceLevel");
            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "TradeConfidenceLevel").Type.ShouldEqual(typeof(string).ToString());

            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "AuctionEstimate").Name.ShouldEqual("AuctionEstimate");
            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "AuctionEstimate").Type.ShouldEqual(typeof(string).ToString());

            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "CostLow").Name.ShouldEqual("CostLow");
            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "CostLow").Type.ShouldEqual(typeof(string).ToString());

            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "CostHigh").Name.ShouldEqual("CostHigh");
            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "CostHigh").Type.ShouldEqual(typeof(string).ToString());

            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "CostValue").Name.ShouldEqual("CostValue");
            estimatedValueModel.DataFields.FirstOrDefault(x => x.Name == "CostValue").Type.ShouldEqual(typeof(string).ToString());
        }
    }
}