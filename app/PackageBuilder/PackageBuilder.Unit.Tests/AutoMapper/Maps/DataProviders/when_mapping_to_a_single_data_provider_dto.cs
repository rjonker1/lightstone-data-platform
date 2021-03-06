﻿using System;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders
{
    public class when_mapping_to_a_single_data_provider_dto : BaseTestHelper
    {
        private DataProviderDto _dto;

        public override void Observe()
        {
            _dto = Mapper.Map<IDataProvider, DataProviderDto>(WriteDataProviderMother.Ivid);
        }

        [Observation]
        public void should_map_all_fields()
        {
            _dto.Id.ShouldNotBeNull();
            _dto.Name.ShouldEqual(DataProviderName.IVIDVerify_E_WS.ToString());
            _dto.Description.ShouldEqual("Ivid");
            _dto.SourceConfigurationIsApiConfiguration.ShouldBeTrue();
            _dto.SourceConfigurationUrl.ShouldEqual("authenticate");
            _dto.SourceConfigurationUsername.ShouldEqual("authenticate");
            _dto.CostOfSale.ShouldEqual(10m);
            _dto.CreatedDate.Date.ShouldEqual(DateTime.UtcNow.Date);
            _dto.EditedDate.Value.Date.ShouldEqual(DateTime.UtcNow.AddDays(1).Date);
            _dto.FieldLevelCostPriceOverride.ShouldBeTrue();
            _dto.DataFields.Count().ShouldEqual(6);
            _dto.DataFields.ElementAt(0).Name.ShouldEqual("CarFullname");
            _dto.DataFields.ElementAt(1).Name.ShouldEqual("CategoryCode");
            _dto.DataFields.ElementAt(2).Name.ShouldEqual("CategoryDescription");
            _dto.DataFields.ElementAt(3).Name.ShouldEqual("ColourCode");
            _dto.DataFields.ElementAt(4).Name.ShouldEqual("CategoryDescription");
            _dto.DataFields.ElementAt(5).Name.ShouldEqual("SpecificInformation");
            _dto.DataFields.ElementAt(5).DataFields.Count().ShouldEqual(6);
            _dto.DataFields.ElementAt(5).DataFields.ElementAt(0).Name.ShouldEqual("Colour");
            _dto.DataFields.ElementAt(5).DataFields.ElementAt(1).Name.ShouldEqual("EngineNumber");
            _dto.DataFields.ElementAt(5).DataFields.ElementAt(2).Name.ShouldEqual("LicenseNumber");
            _dto.DataFields.ElementAt(5).DataFields.ElementAt(3).Name.ShouldEqual("Odometer");
            _dto.DataFields.ElementAt(5).DataFields.ElementAt(4).Name.ShouldEqual("RegistrationNumber");
            _dto.DataFields.ElementAt(5).DataFields.ElementAt(5).Name.ShouldEqual("VinNumber");
        }
    }
}