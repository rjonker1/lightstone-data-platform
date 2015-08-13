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
    public class when_mapping_lightstone_image_gauge_collection_response : BaseTestHelper
    {
        private IDataField _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IEnumerable<IRespondWithImageGaugeModel>, DataField>(LightstoneResponseMother.Response.VehicleValuation.ImageGauges);
        }

        [Observation]
        public void should_map_image_gauge_data_fields()
        {
            _dataField.Type.ShouldEqual(typeof(IRespondWithImageGaugeModel[]).ToString());

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(5);

            dataFields.FirstOrDefault(x => x.Name == "MinValue").Name.ShouldEqual("MinValue");
            dataFields.FirstOrDefault(x => x.Name == "MinValue").Type.ShouldEqual(typeof(double?).ToString());

            dataFields.FirstOrDefault(x => x.Name == "MaxValue").Name.ShouldEqual("MaxValue");
            dataFields.FirstOrDefault(x => x.Name == "MaxValue").Type.ShouldEqual(typeof(double?).ToString());

            dataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            dataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double?).ToString());

            dataFields.FirstOrDefault(x => x.Name == "Quarter").Name.ShouldEqual("Quarter");
            dataFields.FirstOrDefault(x => x.Name == "Quarter").Type.ShouldEqual(typeof(double?).ToString());

            dataFields.FirstOrDefault(x => x.Name == "GaugeName").Name.ShouldEqual("GaugeName");
            dataFields.FirstOrDefault(x => x.Name == "GaugeName").Type.ShouldEqual(typeof(string).ToString());
        }
    }
}