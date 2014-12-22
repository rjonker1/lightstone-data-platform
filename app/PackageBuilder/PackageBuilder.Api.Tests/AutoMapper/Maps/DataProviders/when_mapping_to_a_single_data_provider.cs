﻿using System;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using DataPlatform.Shared.Enums;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.TestHelper;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataProviders
{
    public class when_mapping_to_a_single_data_provider : Specification
    {
        private IDataProvider _dataProvider;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Kernel.ComponentModelCreated += OverrideHelper.OverrideContainerLifestyle;
            container.Install(new ServiceLocatorInstaller(), new BusInstaller(), new NEventStoreInstaller(), new NHibernateInstaller(), new RepositoryInstaller(), new AutoMapperInstaller());

            OverrideHelper.OverrideNhibernateCfg(container);

            _dataProvider = Mapper.Map<DataProviderDto, IDataProvider>(DataProviderDtoMother.Ivid);
        }

        [Observation]
        public void should_map_all_fields()
        {
            _dataProvider.Id.ShouldNotBeNull();
            _dataProvider.Name.ShouldEqual(DataProviderName.Ivid);
            _dataProvider.Description.ShouldEqual("Ivid");
            _dataProvider.SourceConfiguration.IsApiConfiguration.ShouldBeTrue();
            _dataProvider.SourceConfiguration.Url.ShouldEqual("IvidUrlTest");
            _dataProvider.SourceConfiguration.Username.ShouldEqual("IvidUsernameTest");
            _dataProvider.CostOfSale.ShouldEqual(10d);
            _dataProvider.CreatedDate.Date.ShouldEqual(DateTime.Now.Date);
            _dataProvider.EditedDate.Value.Date.ShouldEqual(DateTime.Now.AddDays(1).Date);
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