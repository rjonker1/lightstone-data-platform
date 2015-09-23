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
    public class when_mapping_lightstone_amortised_value_collection_response : BaseTestHelper
    {
        private IDataField _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IEnumerable<IRespondWithAmortisedValueModel>, DataField>(LightstoneAutoResponseMother.Response.VehicleValuation.AmortisedValues);
        }

        [Observation]
        public void should_map_amortised_value_data_fields()
        {
            _dataField.Type.ShouldEqual(typeof(IRespondWithAmortisedValueModel[]).ToString());

            var dataFields = _dataField.DataFields;
            dataFields.Count().ShouldEqual(1);

            var amortiesedValueModel = dataFields.FirstOrDefault();
            amortiesedValueModel.Name.ShouldEqual("AmortisedValueModel");
            amortiesedValueModel.Type.ShouldEqual(typeof(AmortisedValueModel).ToString());
            amortiesedValueModel.DataFields.Count().ShouldEqual(2);

            amortiesedValueModel.DataFields.FirstOrDefault(x => x.Name == "Year").Name.ShouldEqual("Year");
            amortiesedValueModel.DataFields.FirstOrDefault(x => x.Name == "Year").Type.ShouldEqual(typeof(string).ToString());

            amortiesedValueModel.DataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            amortiesedValueModel.DataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(decimal).ToString());
        }
    }
}