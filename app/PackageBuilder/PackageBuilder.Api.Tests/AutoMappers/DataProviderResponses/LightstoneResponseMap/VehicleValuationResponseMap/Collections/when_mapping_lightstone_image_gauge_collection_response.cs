using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.DataProviderResponses.LightstoneResponseMap.VehicleValuationResponseMap.Collections
{
    public class when_mapping_lightstone_image_gauge_collection_response : when_mapping_responses
    {
        private IDataField _dataField;

        public override void Observe()
        {
            base.Observe();

            _dataField = Mapper.Map<IEnumerable<IRespondWithImageGaugeModel>, IDataField>(LightstoneResponseMother.Response.VehicleValuation.ImageGauges);
        }

        [Observation]
        public void should_map_image_gauge_data_fields()
        {
            _dataField.Name.ShouldEqual("ImageGauges");
            _dataField.Type.ShouldEqual(typeof(List<IRespondWithImageGaugeModel>));

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(5);

            dataFields.FirstOrDefault(x => x.Name == "MinValue").Name.ShouldEqual("MinValue");
            dataFields.FirstOrDefault(x => x.Name == "MinValue").Type.ShouldEqual(typeof(double?));

            dataFields.FirstOrDefault(x => x.Name == "MaxValue").Name.ShouldEqual("MaxValue");
            dataFields.FirstOrDefault(x => x.Name == "MaxValue").Type.ShouldEqual(typeof(double?));

            dataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            dataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double?));

            dataFields.FirstOrDefault(x => x.Name == "Quarter").Name.ShouldEqual("Quarter");
            dataFields.FirstOrDefault(x => x.Name == "Quarter").Type.ShouldEqual(typeof(double?));

            dataFields.FirstOrDefault(x => x.Name == "GaugeName").Name.ShouldEqual("GaugeName");
            dataFields.FirstOrDefault(x => x.Name == "GaugeName").Type.ShouldEqual(typeof(string));
        }
    }
}