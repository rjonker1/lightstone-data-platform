using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataProviderResponses.LightstoneResponseMap.VehicleValuationResponseMap.Items
{
    public class when_mapping_lightstone_confidence_response : when_not_persisting_entities
    {
        private IEnumerable<IDataField> _dataField;

        public override void Observe()
        {
            base.Observe();

            _dataField = Mapper.Map<IRespondWithConfidenceModel, IEnumerable<IDataField>>(LightstoneResponseMother.Response.VehicleValuation.Confidence.First());
        }

        [Observation]
        public void should_map_confidence_data_fields()
        {
            _dataField.Count().ShouldEqual(3);

            _dataField.FirstOrDefault(x => x.Name == "CarType").Name.ShouldEqual("CarType");
            _dataField.FirstOrDefault(x => x.Name == "CarType").Type.ShouldEqual(typeof(string));

            _dataField.FirstOrDefault(x => x.Name == "Year").Name.ShouldEqual("Year");
            _dataField.FirstOrDefault(x => x.Name == "Year").Type.ShouldEqual(typeof(int));

            _dataField.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            _dataField.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double));
        }
    }
}
