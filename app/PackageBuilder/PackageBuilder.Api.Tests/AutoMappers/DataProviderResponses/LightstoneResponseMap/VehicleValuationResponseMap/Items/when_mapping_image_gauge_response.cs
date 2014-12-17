using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.DataProviderResponses.LightstoneResponseMap.VehicleValuationResponseMap.Items
{
    public class when_mapping_image_gauge_response : when_not_persisting_entities
    {
        private IEnumerable<IDataField> _dataField;

        public override void Observe()
        {
            base.Observe();

            _dataField = Mapper.Map<IRespondWithImageGaugeModel, IEnumerable<IDataField>>(LightstoneResponseMother.Response.VehicleValuation.ImageGauges.First());
        }

        [Observation]
        public void should_map_image_gauge_data_fields()
        {
            _dataField.Count().ShouldEqual(5);

            _dataField.FirstOrDefault(x => x.Name == "MinValue").Name.ShouldEqual("MinValue");
            _dataField.FirstOrDefault(x => x.Name == "MinValue").Type.ShouldEqual(typeof(double?));

            _dataField.FirstOrDefault(x => x.Name == "MaxValue").Name.ShouldEqual("MaxValue");
            _dataField.FirstOrDefault(x => x.Name == "MaxValue").Type.ShouldEqual(typeof(double?));

            _dataField.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            _dataField.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double?));

            _dataField.FirstOrDefault(x => x.Name == "Quarter").Name.ShouldEqual("Quarter");
            _dataField.FirstOrDefault(x => x.Name == "Quarter").Type.ShouldEqual(typeof(double?));

            _dataField.FirstOrDefault(x => x.Name == "GaugeName").Name.ShouldEqual("GaugeName");
            _dataField.FirstOrDefault(x => x.Name == "GaugeName").Type.ShouldEqual(typeof(string));
        }
    }
}