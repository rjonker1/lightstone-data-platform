using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders
{
    public class when_mapping_to_a_data_provider_collection : BaseTestHelper
    {
        private IEnumerable<IDataProvider> _dataProviders;

        public override void Observe()
        {
            _dataProviders = Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<DataProvider>>(new[] { DataProviderDtoMother.Ivid, DataProviderDtoMother.IvidTitleHolder });
        }

        [Observation]
        public void should_map_all_fields()
        {
            _dataProviders.Count().ShouldEqual(2);
        }
    }
}