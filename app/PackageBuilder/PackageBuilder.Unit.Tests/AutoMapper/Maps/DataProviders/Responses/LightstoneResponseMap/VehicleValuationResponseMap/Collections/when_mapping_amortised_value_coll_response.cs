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
    public class when_mapping_lightstone_amortised_value_collection_response : when_not_persisting_entities
    {
        private IDataField _dataField;

        public override void Observe()
        {
            base.Observe();

            _dataField = Mapper.Map<IEnumerable<IRespondWithAmortisedValueModel>, DataField>(LightstoneResponseMother.Response.VehicleValuation.AmortisedValues);
        }

        [Observation]
        public void should_map_amortised_value_data_fields()
        {
            _dataField.Name.ShouldEqual("AmortisedValues");
            _dataField.Type.ShouldEqual(typeof(List<IRespondWithAmortisedValueModel>).ToString());

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(2);

            dataFields.FirstOrDefault(x => x.Name == "Year").Name.ShouldEqual("Year");
            dataFields.FirstOrDefault(x => x.Name == "Year").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            dataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(decimal).ToString());
        }
    }
}