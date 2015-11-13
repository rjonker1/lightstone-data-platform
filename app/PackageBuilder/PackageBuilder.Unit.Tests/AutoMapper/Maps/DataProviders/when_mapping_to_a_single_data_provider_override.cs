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
    public class when_mapping_to_a_single_data_provider_override : BaseTestHelper
    {
        private IDataProviderOverride _dto;

        public override void Observe()
        {
            _dto = Mapper.Map<DataProviderDto, DataProviderOverride>(DataProviderDtoMother.Ivid);
        }

        [Observation]
        public void should_map_all_fields()
        {
            _dto.Id.ShouldNotBeNull();;
            _dto.CostOfSale.ShouldEqual(10m);
            _dto.RequestFieldOverrides.Count().ShouldEqual(6);
            _dto.DataFieldOverrides.Count().ShouldEqual(32);
            _dto.DataFieldOverrides.FirstOrDefault(x => x.Name == "CarFullname").Name.ShouldNotBeNull();
            _dto.DataFieldOverrides.FirstOrDefault(x => x.Name == "SpecificInformation").DataFieldOverrides.Count().ShouldEqual(7);
        }
    }
}