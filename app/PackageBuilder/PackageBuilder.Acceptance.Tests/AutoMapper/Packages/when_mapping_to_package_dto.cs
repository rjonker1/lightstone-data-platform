using System;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.AutoMapper.Packages
{
    public class when_mapping_to_package_dto : TestDataBaseHelper
    {
        private PackageDto _packageDto;
        public override async void Observe()
        {
            RefreshDb();

            var state = StateMother.Published;
            SaveAndFlush(state);

            var package = await WritePackageMother.FullVerificationPackage;
            package.State = state;

            _packageDto = Mapper.Map<IPackage, PackageDto>(package);
        }

        [Observation]
        public void should_map_all_fields()
        {
            _packageDto.Id.ShouldNotBeNull();
            _packageDto.Name.ShouldEqual("Full verification");
            _packageDto.Description.ShouldEqual("");
            _packageDto.CostOfSale.ShouldEqual(0m);
            _packageDto.RecommendedSalePrice.ShouldEqual(0m);
            _packageDto.Notes.ShouldEqual("");
            _packageDto.Industries.Count().ShouldEqual(2);
            _packageDto.State.Alias.ShouldEqual("Published");
            _packageDto.DisplayVersion.ShouldEqual(0.1m);
            _packageDto.Owner.ShouldEqual("");
            _packageDto.CreatedDate.Date.ShouldEqual(DateTime.UtcNow.Date);
            _packageDto.EditedDate.Date.ShouldEqual(new DateTime().Date);
            _packageDto.DataProviders.Count().ShouldEqual(6);
        }
    }
}