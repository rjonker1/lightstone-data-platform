using System;
using System.Linq;
using DataPlatform.Shared.Enums;
using Nancy.Testing;
using PackageBuilder.Acceptance.Tests.Bases;
using PackageBuilder.Api.Helpers.Constants;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.Enums.Requests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Modules.DataProviders
{
    public class when_updating_the_ivid_data_provider : BaseDataProviderTest
    {
        public when_updating_the_ivid_data_provider()
        {
            Handler.Handle(new CreateDataProvider(Id, DataProviderName.IVIDVerify_E_WS, 0, "Owner", DateTime.UtcNow));

            Transaction(Session =>
            {
                Response = Browser.Put(RouteConstants.DataProviderEditRoute.Replace("{id}", Id.ToString()), with =>
                {
                    with.Header("Accept", "application/json");
                    with.JsonBody(DataProviderDtoMother.Ivid);
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
            DataProvider.Name.ShouldEqual(DataProviderName.IVIDVerify_E_WS);
            DataProvider.Description.ShouldEqual("Ivid");
            DataProvider.CreatedDate.Date.ShouldEqual(DateTime.Now.Date);
            DataProvider.EditedDate.Value.Date.ShouldEqual(DateTime.Now.Date);
            DataProvider.Owner.ShouldEqual("Owner");
            DataProvider.Version.ShouldEqual(2);
            DataProvider.CostOfSale.ShouldEqual(10);
        }

        [Observation]
        public void should_contain_all_request_fields()
        {
            DataProvider.RequestFields.Count().ShouldEqual(6);
        }

        [Observation]
        public void should_contain_all_data_fields()
        {
            DataProvider.DataFields.Count().ShouldEqual(32);
        }

        [Observation]
        public void should_update_request_field_engine_number()
        {
            AssertRequestField("EngineNumber", RequestFieldType.EngineNumber);
        }

        [Observation]
        public void should_update_request_field_chassis_number()
        {
            AssertRequestField("ChassisNumber", RequestFieldType.ChassisNumber);
        }

        [Observation]
        public void should_update_request_field_vin_number()
        {
            AssertRequestField("VinNumber", RequestFieldType.VinNumber);
        }

        [Observation]
        public void should_update_request_field_license_number()
        {
            AssertRequestField("LicenseNumber", RequestFieldType.LicenseNumber);
        }

        [Observation]
        public void should_update_request_field_register_number()
        {
            AssertRequestField("RegisterNumber", RequestFieldType.RegisterNumber);
        }

        [Observation]
        public void should_update_request_field_make()
        {
            AssertRequestField("Make", RequestFieldType.Make);
        }

        [Observation]
        public void should_update_data_field_specific_information()
        {
            AssertDataField("SpecificInformation", "SpecificInformation Definition", "SpecificInformation Label", 10, true, 0, typeof(string), 0, 7);
        }

        [Observation]
        public void should_update_data_field_estimated_value()
        {
            var specificInfo = AssertDataField("SpecificInformation", "SpecificInformation Definition", "SpecificInformation Label", 10, true, 0, typeof(string), 0, 7);

            AssertDataField("Odometer", "Odometer Definition", "Odometer Label", 10, true, 0, typeof(string), 0, 0, specificInfo.DataFields);
            AssertDataField("Colour", "Colour Definition", "Colour Label", 10, true, 0, typeof(string), 0, 0, specificInfo.DataFields);
            AssertDataField("RegistrationNumber", "RegistrationNumber Definition", "RegistrationNumber Label", 10, true, 0, typeof(string), 0, 0, specificInfo.DataFields);
            AssertDataField("VinNumber", "VinNumber Definition", "VinNumber Label", 10, true, 0, typeof(string), 0, 0, specificInfo.DataFields);
            AssertDataField("LicenseNumber", "LicenseNumber Definition", "LicenseNumber Label", 10, true, 0, typeof(string), 0, 0, specificInfo.DataFields);
            AssertDataField("EngineNumber", "EngineNumber Definition", "EngineNumber Label", 10, true, 0, typeof(string), 0, 0, specificInfo.DataFields);
            AssertDataField("CategoryDescription", "CategoryDescription Definition", "CategoryDescription Label", 10, true, 0, typeof(string), 0, 0, specificInfo.DataFields);
        }

        [Observation]
        public void should_update_data_field_status_message()
        {
            AssertDataField("StatusMessage", "StatusMessage Definition", "StatusMessage Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_reference()
        {
            AssertDataField("Reference", "Reference Definition", "Reference Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_license()
        {
            AssertDataField("License", "License Definition", "License Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_registration()
        {
            AssertDataField("Registration", "Registration Definition", "Registration Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_registration_date()
        {
            AssertDataField("RegistrationDate", "RegistrationDate Definition", "RegistrationDate Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_vin()
        {
            AssertDataField("Vin", "Vin Definition", "Vin Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_engine()
        {
            AssertDataField("Engine", "Engine Definition", "Engine Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_displacement()
        {
            AssertDataField("Displacement", "Displacement Definition", "Displacement Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_tare()
        {
            AssertDataField("Tare", "Tare Definition", "Tare Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_make_code()
        {
            AssertDataField("MakeCode", "MakeCode Definition", "MakeCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_make_description()
        {
            AssertDataField("MakeDescription", "MakeDescription Definition", "MakeDescription Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_model_code()
        {
            AssertDataField("ModelCode", "ModelCode Definition", "ModelCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_model_description()
        {
            AssertDataField("ModelDescription", "ModelDescription Definition", "ModelDescription Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_colour_code()
        {
            AssertDataField("ColourCode", "ColourCode Definition", "ColourCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_colour_description()
        {
            AssertDataField("ColourDescription", "ColourDescription Definition", "ColourDescription Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_driven_code()
        {
            AssertDataField("DrivenCode", "DrivenCode Definition", "DrivenCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_driven_description()
        {
            AssertDataField("DrivenDescription", "DrivenDescription Definition", "DrivenDescription Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_category_code()
        {
            AssertDataField("CategoryCode", "CategoryCode Definition", "CategoryCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_category_description()
        {
            AssertDataField("CategoryDescription", "CategoryDescription Definition", "CategoryDescription Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_description_code()
        {
            AssertDataField("DescriptionCode", "DescriptionCode Definition", "DescriptionCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_description()
        {
            AssertDataField("Description", "Description Definition", "Description Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_economic_sector_code()
        {
            AssertDataField("EconomicSectorCode", "EconomicSectorCode Definition", "EconomicSectorCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_economic_sector_description()
        {
            AssertDataField("EconomicSectorDescription", "EconomicSectorDescription Definition", "EconomicSectorDescription Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_life_status_code()
        {
            AssertDataField("LifeStatusCode", "LifeStatusCode Definition", "LifeStatusCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_life_status_description()
        {
            AssertDataField("LifeStatusDescription", "LifeStatusDescription Definition", "LifeStatusDescription Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_sap_mark_code()
        {
            AssertDataField("SapMarkCode", "SapMarkCode Definition", "SapMarkCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_sap_mark_description()
        {
            AssertDataField("SapMarkDescription", "SapMarkDescription Definition", "SapMarkDescription Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_has_issues()
        {
            AssertDataField("HasIssues", "HasIssues Definition", "HasIssues Label", 10, true, 0, typeof(bool));
        }

        [Observation]
        public void should_update_data_field_has_errors()
        {
            AssertDataField("HasErrors", "HasErrors Definition", "HasErrors Label", 10, true, 0, typeof(bool));
        }

        [Observation]
        public void should_update_data_field_has_no_records()
        {
            AssertDataField("HasNoRecords", "HasNoRecords Definition", "HasNoRecords Label", 10, true, 0, typeof(bool));
        }

        [Observation]
        public void should_update_data_field_car_full_name()
        {
            AssertDataField("CarFullname", "CarFullname Definition", "CarFullname Label", 10, true, 0, typeof(string));
        }
    }
}