using System;
using System.Linq;
using AutoMapper;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.Domain.Entities.Enums.States;
using PackageBuilder.Domain.Entities.Packages.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.Packages
{
    public class when_mapping_to_package : when_persisting_entities_to_db
    {
        private IPackage _package;
        public override void Observe()
        {
            base.Observe();

            Container.Install(new ServiceLocatorInstaller(), new RepositoryInstaller(), new AutoMapperInstaller());

            var state = StateMother.Published;
            SaveAndFlush(state);

            var packageDto = PackageDtoMother.VVi;
            packageDto.State = state;
            _package = Mapper.Map<PackageDto, Package>(packageDto);
        }

        [Observation]
        public void should_map_all_fields()
        {
            _package.Id.ShouldNotBeNull();
            _package.Name.ShouldEqual("VVi");
            _package.Description.ShouldEqual("Description");
            _package.CostOfSale.ShouldEqual(10d);
            _package.RecommendedSalePrice.ShouldEqual(20d);
            _package.Notes.ShouldEqual("Notes");
            _package.Industries.Count().ShouldEqual(1);
            _package.State.Name.ShouldEqual(StateName.Published);
            _package.DisplayVersion.ShouldEqual(0.1m);
            _package.Owner.ShouldEqual("Owner");
            _package.CreatedDate.Date.ShouldEqual(DateTime.UtcNow.Date);
            _package.EditedDate.Value.Date.ShouldEqual(new DateTime().Date);
            _package.DataProviders.Count().ShouldEqual(2);
        }
    }
}