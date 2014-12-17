using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.DataProviderResponses.LightstoneResponseMap.VehicleValuationResponseMap.Collections
{
    public class when_mapping_lightstone_estimated_value_collection_response : when_not_persisting_entities
    {
        private IDataField _dataField;

        public override void Observe()
        {
            base.Observe();

            _dataField = Mapper.Map<IEnumerable<IRespondWithEstimatedValueModel>, IDataField>(LightstoneResponseMother.Response.VehicleValuation.EstimatedValue);
        }

        [Observation]
        public void should_map_estimated_value_data_fields()
        {
            _dataField.Name.ShouldEqual("EstimatedValue");
            _dataField.Type.ShouldEqual(typeof(List<IRespondWithEstimatedValueModel>));

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(5);

            dataFields.FirstOrDefault(x => x.Name == "EstimatedValue").Name.ShouldEqual("EstimatedValue");
            dataFields.FirstOrDefault(x => x.Name == "EstimatedValue").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "EstimatedLow").Name.ShouldEqual("EstimatedLow");
            dataFields.FirstOrDefault(x => x.Name == "EstimatedLow").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "EstimatedHigh").Name.ShouldEqual("EstimatedHigh");
            dataFields.FirstOrDefault(x => x.Name == "EstimatedHigh").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "ConfidenceValue").Name.ShouldEqual("ConfidenceValue");
            dataFields.FirstOrDefault(x => x.Name == "ConfidenceValue").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "ConfidenceLevel").Name.ShouldEqual("ConfidenceLevel");
            dataFields.FirstOrDefault(x => x.Name == "ConfidenceLevel").Type.ShouldEqual(typeof(string));
        }
    }
}