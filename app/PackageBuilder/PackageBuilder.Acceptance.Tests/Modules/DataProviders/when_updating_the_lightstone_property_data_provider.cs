﻿using System;
using System.Linq;
using DataPlatform.Shared.Enums;
using Nancy.Testing;
using PackageBuilder.Acceptance.Tests.Bases;
using PackageBuilder.Api.Helpers.Constants;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.Enums.Requests;
using PackageBuilder.TestHelper.Helpers.Extensions;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Modules.DataProviders
{
    public class when_updating_the_lightstone_property_data_provider : BaseDataProviderTest
    {
        public when_updating_the_lightstone_property_data_provider()
        {
            Handler.Handle(new CreateDataProvider(Id, DataProviderName.LSPropertySearch_E_WS, 0, "Owner", DateTime.UtcNow));

            Transaction(Session =>
            {
                Response = Browser.Put(RouteConstants.DataProviderEditRoute.Replace("{id}", Id.ToString()), with =>
                {
                    with.Header("Accept", "application/json");
                    with.JsonBody(DataProviderDtoMother.LightstoneProperty);
                });
            });

            DataProvider = WriteRepo.GetById(Id);
        }

        public override void Observe()
        {

        }

        [Observation]
        public void should_return_success_response()
        {
            Response.Body.AsString().ShouldNotBeNull();
            Response.Body.AsString().ShouldContain("Success");
        }

        [Observation]
        public void should_update_root_properties()
        {
            DataProvider.Name.ShouldEqual(DataProviderName.LSPropertySearch_E_WS);
            DataProvider.Description.ShouldEqual("LightstoneProperty");
            DataProvider.CreatedDate.Date.ShouldEqual(DateTime.UtcNow.Date);
            DataProvider.EditedDate.Value.Date.ShouldEqual(DateTime.UtcNow.Date);
            DataProvider.Owner.ShouldEqual("Owner");
            DataProvider.Version.ShouldEqual(2);
            DataProvider.CostOfSale.ShouldEqual(10);
        }

        [Observation]
        public void should_contain_all_request_fields()
        {
            DataProvider.RequestFields.Count().ShouldEqual(1);
        }

        [Observation]
        public void should_contain_all_data_fields()
        {
            DataProvider.DataFields.Count().ShouldEqual(1);
        }

        [Observation]
        public void should_update_request_field_engine_number()
        {
            DataFieldExtensions.AssertRequestField("IdentityNumber", RequestFieldType.IdentityNumber, DataProvider.RequestFields);
        }

        [Observation]
        public void should_update_data_field_property_information()
        {
            var propertyInformation = DataFieldExtensions.AssertDataField("PropertyInformation", "PropertyInformation Definition", "PropertyInformation Label", 10, true, 0, typeof(string), 0, 52);

            DataFieldExtensions.AssertDataField("SrId", "SrId Definition", "SrId Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("PropertyId", "PropertyId Definition", "PropertyId Label", 10, true, 0, typeof(decimal), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("DeedId", "DeedId Definition", "DeedId Label", 10, true, 0, typeof(decimal), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("PropertyTypeId", "PropertyTypeId Definition", "PropertyTypeId Label", 10, true, 0, typeof(decimal), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("SsId", "SsId Definition", "SsId Label", 10, true, 0, typeof(decimal), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("NadId", "NadId Definition", "NadId Label", 10, true, 0, typeof(decimal), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("PropertyType", "PropertyType Definition", "PropertyType Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("Province", "Province Definition", "Province Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("Muncipality", "Muncipality Definition", "Muncipality Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("Deedtown", "Deedtown Definition", "Deedtown Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("FarmName", "FarmName Definition", "FarmName Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("SectionalTitle", "SectionalTitle Definition", "SectionalTitle Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("Unit", "Unit Definition", "Unit Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("Portion", "Portion Definition", "Portion Label", 10, true, 0, typeof(decimal), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("BuyerName", "BuyerName Definition", "BuyerName Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("FirstName", "FirstName Definition", "FirstName Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("SecondMiddleName", "SecondMiddleName Definition", "SecondMiddleName Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("ThirdMiddleName", "ThirdMiddleName Definition", "ThirdMiddleName Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("Surname", "Surname Definition", "Surname Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("PersonTypeId", "PersonTypeId Definition", "PersonTypeId Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("BuyerIdCk", "BuyerIdCk Definition", "BuyerIdCk Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("MunicId", "MunicId Definition", "MunicId Label", 10, true, 0, typeof(decimal), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("ProvId", "ProvId Definition", "ProvId Label", 10, true, 0, typeof(decimal), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("StreetNumber", "StreetNumber Definition", "StreetNumber Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("StreetType", "StreetType Definition", "StreetType Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("PostalCode", "PostalCode Definition", "PostalCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("UserId", "UserId Definition", "UserId Label", 10, true, 0, typeof(Guid), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("Garage", "Garage Definition", "Garage Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("SectionSchemeNumber", "SectionSchemeNumber Definition", "SectionSchemeNumber Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("SectionlSchemeUnitNoFrom", "SectionlSchemeUnitNoFrom Definition", "SectionlSchemeUnitNoFrom Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("SectionalSchemeUnitTo", "SectionalSchemeUnitTo Definition", "SectionalSchemeUnitTo Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("Size", "Size Definition", "Size Label", 10, true, 0, typeof(double), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("XCoOrdinates", "XCoOrdinates Definition", "XCoOrdinates Label", 10, true, 0, typeof(double), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("YCoOrdinates", "YCoOrdinates Definition", "YCoOrdinates Label", 10, true, 0, typeof(double), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("Suburb", "Suburb Definition", "Suburb Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("TitleDeedNo", "TitleDeedNo Definition", "TitleDeedNo Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("RegistrationDate", "RegistrationDate Definition", "RegistrationDate Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("Township", "Township Definition", "Township Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("PurchasePrice", "PurchasePrice Definition", "PurchasePrice Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("PurchaseDate", "PurchaseDate Definition", "PurchaseDate Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("BondNumber", "BondNumber Definition", "BondNumber Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("TownshipAlt", "TownshipAlt Definition", "TownshipAlt Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("RemainingExtent", "RemainingExtent Definition", "RemainingExtent Label", 10, true, 0, typeof(bool), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("AdditionalDescription", "AdditionalDescription Definition", "AdditionalDescription Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("SuburbId", "SuburbId Definition", "SuburbId Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("StreetId", "StreetId Definition", "StreetId Label", 10, true, 0, typeof(decimal), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("ActiveStatus", "ActiveStatus Definition", "ActiveStatus Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("EstateName", "EstateName Definition", "EstateName Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("EstateId", "EstateId Definition", "EstateId Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("ReqStatusId", "ReqStatusId Definition", "ReqStatusId Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("EstimatedCoOrdinates", "EstimatedCoOrdinates Definition", "EstimatedCoOrdinates Label", 10, true, 0, typeof(bool), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("MiddleName", "MiddleName Definition", "MiddleName Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
        }
    }
}