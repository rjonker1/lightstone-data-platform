using System;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders
{
    public class when_mapping_to_a_single_data_provider : BaseTestHelper
    {
        private IDataProvider _dataProvider;

        public override void Observe()
        {
            _dataProvider = Mapper.Map<DataProviderDto, DataProvider>(DataProviderDtoMother.Ivid);
        }

        [Observation]
        public void should_map_all_fields()
        {
            _dataProvider.Id.ShouldNotBeNull();
            _dataProvider.Name.ShouldEqual(DataProviderName.Ivid);
            _dataProvider.Description.ShouldEqual("Ivid");
            _dataProvider.SourceConfiguration.IsApiConfiguration.ShouldBeTrue();
            _dataProvider.SourceConfiguration.Url.ShouldEqual("authenticate");
            _dataProvider.SourceConfiguration.Username.ShouldEqual("authenticate");
            _dataProvider.CostOfSale.ShouldEqual(10m);
            _dataProvider.CreatedDate.Date.ShouldEqual(DateTime.UtcNow.Date);
            _dataProvider.EditedDate.Value.Date.ShouldEqual(DateTime.UtcNow.AddDays(1).Date);
            _dataProvider.FieldLevelCostPriceOverride.ShouldBeTrue();
            _dataProvider.DataFields.Count().ShouldEqual(2);
            _dataProvider.DataFields.ElementAt(0).Name.ShouldEqual("CarFullname");
            _dataProvider.DataFields.ElementAt(1).Name.ShouldEqual("SpecificInformation");
            _dataProvider.DataFields.ElementAt(1).DataFields.Count().ShouldEqual(6);
            _dataProvider.DataFields.ElementAt(1).DataFields.ElementAt(0).Name.ShouldEqual("Colour");
            _dataProvider.DataFields.ElementAt(1).DataFields.ElementAt(1).Name.ShouldEqual("EngineNumber");
            _dataProvider.DataFields.ElementAt(1).DataFields.ElementAt(2).Name.ShouldEqual("LicenseNumber");
            _dataProvider.DataFields.ElementAt(1).DataFields.ElementAt(3).Name.ShouldEqual("Odometer");
            _dataProvider.DataFields.ElementAt(1).DataFields.ElementAt(4).Name.ShouldEqual("RegistrationNumber");
            _dataProvider.DataFields.ElementAt(1).DataFields.ElementAt(5).Name.ShouldEqual("VinNumber");
        }
    }
}