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
    public class when_mapping_lightstone_frequency_collection_response : BaseTestHelper
    {
        private IDataField _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IEnumerable<IRespondWithFrequencyModel>, DataField>(LightstoneAutoResponseMother.Response.VehicleValuation.Frequency);
        }

        [Observation]
        public void should_map_frequency_data_fields()
        {
            _dataField.Type.ShouldEqual(typeof(IRespondWithFrequencyModel[]).ToString());

            var dataFields = _dataField.DataFields;
            dataFields.Count().ShouldEqual(1);

            var frequencyModel = dataFields.FirstOrDefault();
            frequencyModel.Name.ShouldEqual("FrequencyModel");
            frequencyModel.Type.ShouldEqual(typeof(FrequencyModel).ToString());
            frequencyModel.DataFields.Count().ShouldEqual(3);

            frequencyModel.DataFields.FirstOrDefault(x => x.Name == "CarType").Name.ShouldEqual("CarType");
            frequencyModel.DataFields.FirstOrDefault(x => x.Name == "CarType").Type.ShouldEqual(typeof(string).ToString());

            frequencyModel.DataFields.FirstOrDefault(x => x.Name == "Year").Name.ShouldEqual("Year");
            frequencyModel.DataFields.FirstOrDefault(x => x.Name == "Year").Type.ShouldEqual(typeof(int).ToString());

            frequencyModel.DataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            frequencyModel.DataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double).ToString());
        }
    }
}