using System;
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
            DataProvider.CreatedDate.Date.ShouldEqual(DateTime.UtcNow.Date);
            DataProvider.EditedDate.Value.Date.ShouldEqual(DateTime.UtcNow.Date);
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
            DataFieldExtensions.AssertRequestField("EngineNumber", RequestFieldType.EngineNumber, DataProvider.RequestFields);
        }

        [Observation]
        public void should_update_request_field_chassis_number()
        {
            DataFieldExtensions.AssertRequestField("ChassisNumber", RequestFieldType.ChassisNumber, DataProvider.RequestFields);
        }

        [Observation]
        public void should_update_request_field_vin_number()
        {
            DataFieldExtensions.AssertRequestField("VinNumber", RequestFieldType.VinNumber, DataProvider.RequestFields);
        }

        [Observation]
        public void should_update_request_field_license_number()
        {
            DataFieldExtensions.AssertRequestField("LicenseNumber", RequestFieldType.LicenseNumber, DataProvider.RequestFields);
        }

        [Observation]
        public void should_update_request_field_register_number()
        {
            DataFieldExtensions.AssertRequestField("RegisterNumber", RequestFieldType.RegisterNumber, DataProvider.RequestFields);
        }

        [Observation]
        public void should_update_request_field_make()
        {
            DataFieldExtensions.AssertRequestField("Make", RequestFieldType.Make, DataProvider.RequestFields);
        }

        [Observation]
        public void should_update_data_field_specific_information()
        {
            DataFieldExtensions.AssertDataField("SpecificInformation", "SpecificInformation Definition", "SpecificInformation Label", 10, true, 0, typeof(string), 0, 7);
        }

        [Observation]
        public void should_update_data_field_estimated_value()
        {
            var specificInfo = DataFieldExtensions.AssertDataField("SpecificInformation", "SpecificInformation Definition", "SpecificInformation Label", 10, true, 0, typeof(string), 0, 7);

            DataFieldExtensions.AssertDataField("Odometer", "Odometer Definition", "Odometer Label", 10, true, 0, typeof(string), 0, 0, specificInfo.DataFields);
            DataFieldExtensions.AssertDataField("Colour", "Colour Definition", "Colour Label", 10, true, 0, typeof(string), 0, 0, specificInfo.DataFields);
            DataFieldExtensions.AssertDataField("RegistrationNumber", "RegistrationNumber Definition", "RegistrationNumber Label", 10, true, 0, typeof(string), 0, 0, specificInfo.DataFields);
            DataFieldExtensions.AssertDataField("VinNumber", "VinNumber Definition", "VinNumber Label", 10, true, 0, typeof(string), 0, 0, specificInfo.DataFields);
            DataFieldExtensions.AssertDataField("LicenseNumber", "LicenseNumber Definition", "LicenseNumber Label", 10, true, 0, typeof(string), 0, 0, specificInfo.DataFields);
            DataFieldExtensions.AssertDataField("EngineNumber", "EngineNumber Definition", "EngineNumber Label", 10, true, 0, typeof(string), 0, 0, specificInfo.DataFields);
            DataFieldExtensions.AssertDataField("CategoryDescription", "CategoryDescription Definition", "CategoryDescription Label", 10, true, 0, typeof(string), 0, 0, specificInfo.DataFields);
        }

        [Observation]
        public void should_update_data_field_status_message()
        {
            DataFieldExtensions.AssertDataField("StatusMessage", "StatusMessage Definition", "StatusMessage Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_reference()
        {
            DataFieldExtensions.AssertDataField("Reference", "Reference Definition", "Reference Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_license()
        {
            DataFieldExtensions.AssertDataField("License", "License Definition", "License Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_registration()
        {
            DataFieldExtensions.AssertDataField("Registration", "Registration Definition", "Registration Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_registration_date()
        {
            DataFieldExtensions.AssertDataField("RegistrationDate", "RegistrationDate Definition", "RegistrationDate Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_vin()
        {
            DataFieldExtensions.AssertDataField("Vin", "Vin Definition", "Vin Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_engine()
        {
            DataFieldExtensions.AssertDataField("Engine", "Engine Definition", "Engine Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_displacement()
        {
            DataFieldExtensions.AssertDataField("Displacement", "Displacement Definition", "Displacement Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_tare()
        {
            DataFieldExtensions.AssertDataField("Tare", "Tare Definition", "Tare Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_make_code()
        {
            DataFieldExtensions.AssertDataField("MakeCode", "MakeCode Definition", "MakeCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_make_description()
        {
            DataFieldExtensions.AssertDataField("MakeDescription", "MakeDescription Definition", "MakeDescription Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_model_code()
        {
            DataFieldExtensions.AssertDataField("ModelCode", "ModelCode Definition", "ModelCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_model_description()
        {
            DataFieldExtensions.AssertDataField("ModelDescription", "ModelDescription Definition", "ModelDescription Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_colour_code()
        {
            DataFieldExtensions.AssertDataField("ColourCode", "ColourCode Definition", "ColourCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_colour_description()
        {
            DataFieldExtensions.AssertDataField("ColourDescription", "ColourDescription Definition", "ColourDescription Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_driven_code()
        {
            DataFieldExtensions.AssertDataField("DrivenCode", "DrivenCode Definition", "DrivenCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_driven_description()
        {
            DataFieldExtensions.AssertDataField("DrivenDescription", "DrivenDescription Definition", "DrivenDescription Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_category_code()
        {
            DataFieldExtensions.AssertDataField("CategoryCode", "CategoryCode Definition", "CategoryCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_category_description()
        {
            DataFieldExtensions.AssertDataField("CategoryDescription", "CategoryDescription Definition", "CategoryDescription Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_description_code()
        {
            DataFieldExtensions.AssertDataField("DescriptionCode", "DescriptionCode Definition", "DescriptionCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_description()
        {
            DataFieldExtensions.AssertDataField("Description", "Description Definition", "Description Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_economic_sector_code()
        {
            DataFieldExtensions.AssertDataField("EconomicSectorCode", "EconomicSectorCode Definition", "EconomicSectorCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_economic_sector_description()
        {
            DataFieldExtensions.AssertDataField("EconomicSectorDescription", "EconomicSectorDescription Definition", "EconomicSectorDescription Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_life_status_code()
        {
            DataFieldExtensions.AssertDataField("LifeStatusCode", "LifeStatusCode Definition", "LifeStatusCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_life_status_description()
        {
            DataFieldExtensions.AssertDataField("LifeStatusDescription", "LifeStatusDescription Definition", "LifeStatusDescription Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_sap_mark_code()
        {
            DataFieldExtensions.AssertDataField("SapMarkCode", "SapMarkCode Definition", "SapMarkCode Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_sap_mark_description()
        {
            DataFieldExtensions.AssertDataField("SapMarkDescription", "SapMarkDescription Definition", "SapMarkDescription Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_has_issues()
        {
            DataFieldExtensions.AssertDataField("HasIssues", "HasIssues Definition", "HasIssues Label", 10, true, 0, typeof(bool));
        }

        [Observation]
        public void should_update_data_field_has_errors()
        {
            DataFieldExtensions.AssertDataField("HasErrors", "HasErrors Definition", "HasErrors Label", 10, true, 0, typeof(bool));
        }

        [Observation]
        public void should_update_data_field_has_no_records()
        {
            DataFieldExtensions.AssertDataField("HasNoRecords", "HasNoRecords Definition", "HasNoRecords Label", 10, true, 0, typeof(bool));
        }

        [Observation]
        public void should_update_data_field_car_full_name()
        {
            DataFieldExtensions.AssertDataField("CarFullname", "CarFullname Definition", "CarFullname Label", 10, true, 0, typeof(string));
        }
    }
}