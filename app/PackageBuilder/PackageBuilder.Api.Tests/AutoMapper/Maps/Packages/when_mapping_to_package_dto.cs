using System;
using System.Linq;
using AutoMapper;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.Packages
{
    public class when_mapping_to_package_dto : when_persisting_entities_to_db
    {
        private PackageDto _packageDto;
        public override void Observe()
        {
            base.Observe();

            Container.Install(new ServiceLocatorInstaller(), new RepositoryInstaller(), new AutoMapperInstaller());

            _packageDto = Mapper.Map<IPackage, PackageDto>(WritePackageMother.FullVerificationPackage);
        }

        [Observation]
        public void should_map_all_fields()
        {
            _packageDto.Id.ShouldNotBeNull();
            _packageDto.Name.ShouldEqual("Full verification");
            _packageDto.Description.ShouldEqual("");
            _packageDto.CostOfSale.ShouldEqual(0d);
            _packageDto.RecommendedSalePrice.ShouldEqual(0d);
            _packageDto.Notes.ShouldEqual("");
            _packageDto.Industries.Count().ShouldEqual(2);
            _packageDto.State.Alias.ShouldEqual("Published");
            _packageDto.DisplayVersion.ShouldEqual(0.1m);
            _packageDto.Owner.ShouldEqual("");
            _packageDto.CreatedDate.Date.ShouldEqual(DateTime.Now.Date);
            _packageDto.EditedDate.Date.ShouldEqual(new DateTime().Date);
            _packageDto.DataProviders.Count().ShouldEqual(6);
        }
    }
}