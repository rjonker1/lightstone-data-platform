﻿using System;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Enums;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.AutoMapper.DataProviders
{
    public class when_mapping_an_override_to_a_single_data_provider : TestDataBaseHelper
    {
        private readonly IDataProvider _dataProvider;

        public when_mapping_an_override_to_a_single_data_provider()
        {
            RefreshDb();

            var dataProvider = WriteDataProviderMother.Ivid;
            var id = Guid.NewGuid();
            var entity = new DataProvider(id, dataProvider.Name,
                dataProvider.Description, dataProvider.CostOfSale, dataProvider.ResponseType,
                dataProvider.Owner, dataProvider.CreatedDate, null, dataProvider.DataFields, 2);

            var repository = Container.Resolve<INEventStoreRepository<DataProvider>>();

            repository.Save(entity, id);

            var dataProviderOverride = (DataProviderOverride)DataProviderOverrideMother.Ivid;
            dataProviderOverride.Id = id;
            _dataProvider = Mapper.Map<IDataProviderOverride, DataProvider>(dataProviderOverride);
        }

        public override void Observe()
        {
            
        }

        [Observation]
        public void should_data_provider_properties()
        {
            _dataProvider.Id.ShouldNotBeNull();
            _dataProvider.Name.ShouldEqual(DataProviderName.IVIDVerify_E_WS);
            //_dataProvider.Description.ShouldEqual("Ivid");
            _dataProvider.SourceConfiguration.IsApiConfiguration.ShouldBeTrue();
            _dataProvider.SourceConfiguration.Url.ShouldEqual("authenticate");
            _dataProvider.SourceConfiguration.Username.ShouldEqual("authenticate");
            //_dataProvider.CreatedDate.Date.ShouldEqual(DateTime.UtcNow.Date);
            _dataProvider.FieldLevelCostPriceOverride.ShouldBeFalse();
        }

        [Observation]
        public void should_override_data_provider_cost()
        {
            _dataProvider.CostOfSale.ShouldEqual(20m);
        }

        [Observation]
        public void should_map_data_fields_from_override_collection_which_do_exist_in_data_provider_collection()
        {
            _dataProvider.DataFields.First(x => x.Name == "SpecificInformation").Name.ShouldEqual("SpecificInformation");
            _dataProvider.DataFields.First(x => x.Name == "SpecificInformation").DataFields.Count().ShouldEqual(6);
            _dataProvider.DataFields.First(x => x.Name == "SpecificInformation").DataFields.ElementAt(0).Name.ShouldEqual("Colour");
            _dataProvider.DataFields.First(x => x.Name == "SpecificInformation").DataFields.ElementAt(1).Name.ShouldEqual("EngineNumber");
            _dataProvider.DataFields.First(x => x.Name == "SpecificInformation").DataFields.ElementAt(2).Name.ShouldEqual("LicenseNumber");
            _dataProvider.DataFields.First(x => x.Name == "SpecificInformation").DataFields.ElementAt(3).Name.ShouldEqual("Odometer");
            _dataProvider.DataFields.First(x => x.Name == "SpecificInformation").DataFields.ElementAt(4).Name.ShouldEqual("RegistrationNumber");
            _dataProvider.DataFields.First(x => x.Name == "SpecificInformation").DataFields.ElementAt(5).Name.ShouldEqual("VinNumber");
        }

        [Observation]
        public void should_not_map_data_fields_from_override_collection_which_do_not_exist_in_data_provider_collection()
        {
            _dataProvider.DataFields.FirstOrDefault(x => x.Name == "Vin").ShouldBeNull();
            _dataProvider.DataFields.FirstOrDefault(x => x.Name == "License").ShouldBeNull();
            _dataProvider.DataFields.FirstOrDefault(x => x.Name == "Registration").ShouldBeNull();
        }

        [Observation]
        public void should_not_override_data_fields_that_do_not_exist_in_override_collection()
        {
            _dataProvider.DataFields.First(x => x.Name == "CarFullname").CostOfSale.ShouldEqual(0d);
            _dataProvider.DataFields.First(x => x.Name == "CategoryCode").CostOfSale.ShouldEqual(0d);
            _dataProvider.DataFields.First(x => x.Name == "CategoryDescription").CostOfSale.ShouldEqual(0d);
            _dataProvider.DataFields.First(x => x.Name == "ColourCode").CostOfSale.ShouldEqual(0d);
            _dataProvider.DataFields.First(x => x.Name == "CategoryDescription").CostOfSale.ShouldEqual(0d);
        }

        [Observation]
        public void should_override_specific_information_data_field_price()
        {
            _dataProvider.DataFields.First(x => x.Name == "SpecificInformation").DataFields.First(x => x.Name == "Colour").CostOfSale.ShouldEqual(25d);
            _dataProvider.DataFields.First(x => x.Name == "SpecificInformation").DataFields.First(x => x.Name == "EngineNumber").CostOfSale.ShouldEqual(25d);
            _dataProvider.DataFields.First(x => x.Name == "SpecificInformation").DataFields.First(x => x.Name == "LicenseNumber").CostOfSale.ShouldEqual(25d);
            _dataProvider.DataFields.First(x => x.Name == "SpecificInformation").DataFields.First(x => x.Name == "Odometer").CostOfSale.ShouldEqual(25d);
            _dataProvider.DataFields.First(x => x.Name == "SpecificInformation").DataFields.First(x => x.Name == "RegistrationNumber").CostOfSale.ShouldEqual(25d);
            _dataProvider.DataFields.First(x => x.Name == "SpecificInformation").DataFields.First(x => x.Name == "VinNumber").CostOfSale.ShouldEqual(25d);
        }
    }
}