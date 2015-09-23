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
    public class when_mapping_lightstone_confidence_collection_response : BaseTestHelper
    {
        private IDataField _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IEnumerable<IRespondWithConfidenceModel>, DataField>(LightstoneAutoResponseMother.Response.VehicleValuation.Confidence);
        }

        [Observation]
        public void should_map_confidence_data_fields()
        {
            _dataField.Type.ShouldEqual(typeof(IRespondWithConfidenceModel[]).ToString());

            var dataFields = _dataField.DataFields;
            dataFields.Count().ShouldEqual(1);

            var confidenceModel = dataFields.FirstOrDefault();
            confidenceModel.Name.ShouldEqual("ConfidenceModel");
            confidenceModel.Type.ShouldEqual(typeof(ConfidenceModel).ToString());
            confidenceModel.DataFields.Count().ShouldEqual(3);

            confidenceModel.DataFields.FirstOrDefault(x => x.Name == "CarType").Name.ShouldEqual("CarType");
            confidenceModel.DataFields.FirstOrDefault(x => x.Name == "CarType").Type.ShouldEqual(typeof(string).ToString());

            confidenceModel.DataFields.FirstOrDefault(x => x.Name == "Year").Name.ShouldEqual("Year");
            confidenceModel.DataFields.FirstOrDefault(x => x.Name == "Year").Type.ShouldEqual(typeof(int).ToString());

            confidenceModel.DataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            confidenceModel.DataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double).ToString());
        }
    }
}