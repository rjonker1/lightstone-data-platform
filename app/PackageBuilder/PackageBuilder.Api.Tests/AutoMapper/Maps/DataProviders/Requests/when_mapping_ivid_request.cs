using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Entities.Requests;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataProviders.Requests
{
    public class when_mapping_ivid_request : when_not_persisting_entities
    {
        private IEnumerable<IAmRequestField> _dataFields;
        public override void Observe()
        {
            base.Observe();

            _dataFields = Mapper.Map<IAmDataProviderRequest, IEnumerable<IAmRequestField>>(new IvidStandardRequest());
        }

        [Observation]
        public void should_map_all_ivid_data_fields()
        {
            _dataFields.Count().ShouldEqual(32);

            
        }
    }
}