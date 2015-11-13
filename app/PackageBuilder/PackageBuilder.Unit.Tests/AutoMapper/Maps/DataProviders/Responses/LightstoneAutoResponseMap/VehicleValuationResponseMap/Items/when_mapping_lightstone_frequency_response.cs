using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses.LightstoneAutoResponseMap.VehicleValuationResponseMap.Items
{
    public class when_mapping_lightstone_frequency_response : BaseTestHelper
    {
        private IEnumerable<IDataField> _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IRespondWithFrequencyModel, IEnumerable<DataField>>(LightstoneAutoResponseMother.Response.VehicleValuation.Frequency.First());
        }

        [Observation]
        public void should_map_frequency_data_fields()
        {
            _dataField.Count().ShouldEqual(3);

            _dataField.FirstOrDefault(x => x.Name == "CarType").Name.ShouldEqual("CarType");
            _dataField.FirstOrDefault(x => x.Name == "CarType").Type.ShouldEqual(typeof(string).ToString());

            _dataField.FirstOrDefault(x => x.Name == "Year").Name.ShouldEqual("Year");
            _dataField.FirstOrDefault(x => x.Name == "Year").Type.ShouldEqual(typeof(int).ToString());

            _dataField.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            _dataField.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double).ToString());
        }
    }
}