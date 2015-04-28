using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Requests;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Fields;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataProviders.Requests
{
    public class when_mapping_rgt_vin_request : when_not_persisting_entities
    {
        private IEnumerable<IDataField> _dataFields;
        public override void Observe()
        {
            base.Observe();

            //_dataFields = Mapper.Map<IAmDataProviderRequest, IEnumerable<IDataField>>(new RgtVinRequest(new VinNumberRequestField("")));
        }

        [Observation]
        public void should_map_all_rgt_vin_data_fields()
        {
            _dataFields.Count().ShouldEqual(1);
            _dataFields.FirstOrDefault(x => x.Name == "Vin Number").ShouldNotBeNull();

            var requestFields = Mapper.Map<IEnumerable<IDataField>, IEnumerable<IAmRequestField>>(_dataFields);
            var types = requestFields.Select(x => x.GetType());
            types.Count().ShouldEqual(1);
            types.ShouldContain(typeof(VinNumberRequestField));
        }
    }
}