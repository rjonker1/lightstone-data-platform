using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders
{
    public class when_mapping_to_a_data_provider_dto_collection : Specification
    {
        private IEnumerable<DataProviderDto> _dtos;

        public override void Observe()
        {
            _dtos = Mapper.Map<IEnumerable<IDataProvider>, IEnumerable<DataProviderDto>>(new[] { WriteDataProviderMother.Ivid, WriteDataProviderMother.IvidTitleHolder});
        }

        [Observation]
        public void should_map_all_fields()
        {
            _dtos.Count().ShouldEqual(2);
        }
    }
}