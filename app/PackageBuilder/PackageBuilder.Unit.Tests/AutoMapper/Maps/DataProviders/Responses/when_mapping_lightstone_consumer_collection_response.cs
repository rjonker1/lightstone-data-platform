using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using Lace.Domain.Core.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestHelper.Helpers.Extensions;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses
{
    public class when_mapping_lightstone_consumer_collection_response : BaseTestHelper
    {
        private IDataField _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IEnumerable<IRespondWithRepairData>, DataField>(LightstoneConsumerResponseMother.Response.RepairData);
        }

        [Observation]
        public void should_map()
        {
            _dataField.Type.ShouldEqual(typeof(IRespondWithRepairData[]).ToString());
            _dataField.DataFields.Count().ShouldEqual(1);
            DataFieldExtensions.AssertDataField("RepairDataResponse", typeof(RepairDataResponse), null, 6, _dataField.DataFields);

            var repairResponse = _dataField.DataFields.Get("RepairDataResponse");
            DataFieldExtensions.AssertDataField("Cost", typeof(string), "50000", 1, repairResponse.DataFields);
            DataFieldExtensions.AssertDataField("Date", typeof(int), "20150101", 1, repairResponse.DataFields);
            DataFieldExtensions.AssertDataField("DriversName", typeof(string), "DriversName", 1, repairResponse.DataFields);
            DataFieldExtensions.AssertDataField("Location", typeof(string), "Location", 1, repairResponse.DataFields);
            DataFieldExtensions.AssertDataField("VehicleDescription", typeof(string), "VehicleDescription", 1, repairResponse.DataFields);
        }
    }
}