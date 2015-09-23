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
    public class when_mapping_lightstone_image_gauge_collection_response : BaseTestHelper
    {
        private IDataField _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IEnumerable<IRespondWithImageGaugeModel>, DataField>(LightstoneAutoResponseMother.Response.VehicleValuation.ImageGauges);
        }

        [Observation]
        public void should_map_image_gauge_data_fields()
        {
            _dataField.Type.ShouldEqual(typeof(IRespondWithImageGaugeModel[]).ToString());

            var dataFields = _dataField.DataFields;
            dataFields.Count().ShouldEqual(1);

            var imageGaugeModel = dataFields.FirstOrDefault();
            imageGaugeModel.Name.ShouldEqual("ImageGaugeModel");
            imageGaugeModel.Type.ShouldEqual(typeof(ImageGaugeModel).ToString());
            imageGaugeModel.DataFields.Count().ShouldEqual(5);

            imageGaugeModel.DataFields.FirstOrDefault(x => x.Name == "MinValue").Name.ShouldEqual("MinValue");
            imageGaugeModel.DataFields.FirstOrDefault(x => x.Name == "MinValue").Type.ShouldEqual(typeof(double?).ToString());

            imageGaugeModel.DataFields.FirstOrDefault(x => x.Name == "MaxValue").Name.ShouldEqual("MaxValue");
            imageGaugeModel.DataFields.FirstOrDefault(x => x.Name == "MaxValue").Type.ShouldEqual(typeof(double?).ToString());

            imageGaugeModel.DataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            imageGaugeModel.DataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double?).ToString());

            imageGaugeModel.DataFields.FirstOrDefault(x => x.Name == "Quarter").Name.ShouldEqual("Quarter");
            imageGaugeModel.DataFields.FirstOrDefault(x => x.Name == "Quarter").Type.ShouldEqual(typeof(double?).ToString());

            imageGaugeModel.DataFields.FirstOrDefault(x => x.Name == "GaugeName").Name.ShouldEqual("GaugeName");
            imageGaugeModel.DataFields.FirstOrDefault(x => x.Name == "GaugeName").Type.ShouldEqual(typeof(string).ToString());
        }
    }
}