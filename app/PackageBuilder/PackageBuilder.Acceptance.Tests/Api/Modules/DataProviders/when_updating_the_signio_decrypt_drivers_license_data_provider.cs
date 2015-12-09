using System;
using System.Linq;
using Castle.MicroKernel.SubSystems.Conversion;
using DataPlatform.Shared.Enums;
using Nancy.Testing;
using PackageBuilder.Acceptance.Tests.Bases;
using PackageBuilder.Api.Helpers.Constants;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.TestHelper.Helpers.Extensions;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Api.Modules.DataProviders
{
    public class when_updating_the_signio_decrypt_drivers_license_data_provider : BaseDataProviderTest
    {
        public when_updating_the_signio_decrypt_drivers_license_data_provider()
        {
            Handler.Handle(new CreateDataProvider(Id, DataProviderName.LSAutoDecryptDriverLic_I_WS, 0, "Owner", DateTime.UtcNow));

            Transaction(Session =>
            {
                Response = Browser.Put(RouteConstants.DataProviderEditRoute.Replace("{id}", Id.ToString()), with =>
                {
                    with.Header("Accept", "application/json");
                    with.JsonBody(DataProviderDtoMother.SignioDecryptDriversLicense);
                });
            });
        }

        public override void Observe()
        {
            DataProvider = WriteRepo.GetById(Id);
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
            DataProvider.Name.ShouldEqual(DataProviderName.LSAutoDecryptDriverLic_I_WS);
            DataProvider.Description.ShouldEqual("SignioDecryptDriversLicense");
            DataProvider.CreatedDate.Date.ShouldEqual(DateTime.UtcNow.Date);
            DataProvider.EditedDate.Value.Date.ShouldEqual(DateTime.UtcNow.Date);
            DataProvider.Owner.ShouldEqual("Owner");
            DataProvider.Version.ShouldEqual(2);
            DataProvider.CostOfSale.ShouldEqual(10);
        }

        [Observation]
        public void should_contain_all_request_fields()
        {
            DataProvider.RequestFields.Count().ShouldEqual(0);
        }

        [Observation]
        public void should_contain_all_data_fields()
        {
            DataProvider.DataFields.Count().ShouldEqual(1);
        }

        [Observation]
        public void should_update_data_field_driving_license_card()
        {
            DataFieldExtensions.AssertDataField("DrivingLicense", "DrivingLicense Definition", "DrivingLicense Label", 10, true, 0, typeof(string), 0, 12);
        }

        [Observation]
        public void should_update_data_field_identity_document()
        {
            var drivingLicense = DataFieldExtensions.AssertDataField("DrivingLicense", "DrivingLicense Definition", "DrivingLicense Label", 10, true, 0, typeof(string), 0, 12);
            var identityDocument = DataFieldExtensions.AssertDataField("IdentityDocument", "IdentityDocument Definition", "IdentityDocument Label", 10, true, 0, typeof(string), 0, 2, drivingLicense.DataFields);

            DataFieldExtensions.AssertDataField("Number", "Number Definition", "Number Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
            DataFieldExtensions.AssertDataField("IdentityType", "IdentityType Definition", "IdentityType Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
        }

        [Observation]
        public void should_update_data_field_person()
        {
            var drivingLicense = DataFieldExtensions.AssertDataField("DrivingLicense", "DrivingLicense Definition", "DrivingLicense Label", 10, true, 0, typeof(string), 0, 12);
            var person = DataFieldExtensions.AssertDataField("Person", "Person Definition", "Person Label", 10, true, 0, typeof(string), 0, 7, drivingLicense.DataFields);

            DataFieldExtensions.AssertDataField("Surname", "Surname Definition", "Surname Label", 10, true, 0, typeof(string), 0, 0, person.DataFields);
            DataFieldExtensions.AssertDataField("Initials", "Initials Definition", "Initials Label", 10, true, 0, typeof(string), 0, 0, person.DataFields);
            DataFieldExtensions.AssertDataField("DriverRestriction1", "DriverRestriction1 Definition", "DriverRestriction1 Label", 10, true, 0, typeof(string), 0, 0, person.DataFields);
            DataFieldExtensions.AssertDataField("DriverRestriction2", "DriverRestriction2 Definition", "DriverRestriction2 Label", 10, true, 0, typeof(string), 0, 0, person.DataFields);
            DataFieldExtensions.AssertDataField("DateOfBirth", "DateOfBirth Definition", "DateOfBirth Label", 10, true, 0, typeof(string), 0, 0, person.DataFields);
            DataFieldExtensions.AssertDataField("PreferenceLanguage", "PreferenceLanguage Definition", "PreferenceLanguage Label", 10, true, 0, typeof(string), 0, 0, person.DataFields);
            DataFieldExtensions.AssertDataField("Gender", "Gender Definition", "Gender Label", 10, true, 0, typeof(string), 0, 0, person.DataFields);
        }

        [Observation]
        public void should_update_data_field_driving_license()
        {
            var drivingLicense = DataFieldExtensions.AssertDataField("DrivingLicense", "DrivingLicense Definition", "DrivingLicense Label", 10, true, 0, typeof(string), 0, 12);
            var identityDocument = DataFieldExtensions.AssertDataField("DrivingLicense", "DrivingLicense Definition", "DrivingLicense Label", 10, true, 0, typeof(string), 0, 2, drivingLicense.DataFields);

            DataFieldExtensions.AssertDataField("CertificateNumber", "CertificateNumber Definition", "CertificateNumber Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
            DataFieldExtensions.AssertDataField("CountryOfIssue", "CountryOfIssue Definition", "CountryOfIssue Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
        }

        [Observation]
        public void should_update_data_field_card()
        {
            var drivingLicense = DataFieldExtensions.AssertDataField("DrivingLicense", "DrivingLicense Definition", "DrivingLicense Label", 10, true, 0, typeof(string), 0, 12);
            var identityDocument = DataFieldExtensions.AssertDataField("Card", "Card Definition", "Card Label", 10, true, 0, typeof(string), 0, 3, drivingLicense.DataFields);

            DataFieldExtensions.AssertDataField("IssueNumber", "IssueNumber Definition", "IssueNumber Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
            DataFieldExtensions.AssertDataField("DateValidFrom", "DateValidFrom Definition", "DateValidFrom Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
            DataFieldExtensions.AssertDataField("DateValidUntil", "DateValidUntil Definition", "DateValidUntil Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
        }

        [Observation]
        public void should_update_data_field_professional_driving_permit()
        {
            var drivingLicense = DataFieldExtensions.AssertDataField("DrivingLicense", "DrivingLicense Definition", "DrivingLicense Label", 10, true, 0, typeof(string), 0, 12);
            var identityDocument = DataFieldExtensions.AssertDataField("ProfessionalDrivingPermit", "ProfessionalDrivingPermit Definition", "ProfessionalDrivingPermit Label", 10, true, 0, typeof(string), 0, 2, drivingLicense.DataFields);

            DataFieldExtensions.AssertDataField("Category", "Category Definition", "Category Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
            DataFieldExtensions.AssertDataField("DateValidUntil", "DateValidUntil Definition", "DateValidUntil Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
        }

        [Observation]
        public void should_update_data_field_vehicle_class_1()
        {
            var drivingLicense = DataFieldExtensions.AssertDataField("DrivingLicense", "DrivingLicense Definition", "DrivingLicense Label", 10, true, 0, typeof(string), 0, 12);
            var identityDocument = DataFieldExtensions.AssertDataField("VehicleClass1", "VehicleClass1 Definition", "VehicleClass1 Label", 10, true, 0, typeof(string), 0, 3, drivingLicense.DataFields);

            DataFieldExtensions.AssertDataField("Code", "Code Definition", "Code Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
            DataFieldExtensions.AssertDataField("VehicleRestriction", "VehicleRestriction Definition", "VehicleRestriction Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
            DataFieldExtensions.AssertDataField("FirstIssueDate", "FirstIssueDate Definition", "FirstIssueDate Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
        }

        [Observation]
        public void should_update_data_field_vehicle_class_2()
        {
            var drivingLicense = DataFieldExtensions.AssertDataField("DrivingLicense", "DrivingLicense Definition", "DrivingLicense Label", 10, true, 0, typeof(string), 0, 12);
            var identityDocument = DataFieldExtensions.AssertDataField("VehicleClass2", "VehicleClass2 Definition", "VehicleClass2 Label", 10, true, 0, typeof(string), 0, 3, drivingLicense.DataFields);

            DataFieldExtensions.AssertDataField("Code", "Code Definition", "Code Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
            DataFieldExtensions.AssertDataField("VehicleRestriction", "VehicleRestriction Definition", "VehicleRestriction Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
            DataFieldExtensions.AssertDataField("FirstIssueDate", "FirstIssueDate Definition", "FirstIssueDate Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
        }

        [Observation]
        public void should_update_data_field_vehicle_class_3()
        {
            var drivingLicense = DataFieldExtensions.AssertDataField("DrivingLicense", "DrivingLicense Definition", "DrivingLicense Label", 10, true, 0, typeof(string), 0, 12);
            var identityDocument = DataFieldExtensions.AssertDataField("VehicleClass3", "VehicleClass3 Definition", "VehicleClass3 Label", 10, true, 0, typeof(string), 0, 3, drivingLicense.DataFields);

            DataFieldExtensions.AssertDataField("Code", "Code Definition", "Code Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
            DataFieldExtensions.AssertDataField("VehicleRestriction", "VehicleRestriction Definition", "VehicleRestriction Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
            DataFieldExtensions.AssertDataField("FirstIssueDate", "FirstIssueDate Definition", "FirstIssueDate Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
        }

        [Observation]
        public void should_update_data_field_vehicle_class_4()
        {
            var drivingLicense = DataFieldExtensions.AssertDataField("DrivingLicense", "DrivingLicense Definition", "DrivingLicense Label", 10, true, 0, typeof(string), 0, 12);
            var identityDocument = DataFieldExtensions.AssertDataField("VehicleClass4", "VehicleClass4 Definition", "VehicleClass4 Label", 10, true, 0, typeof(string), 0, 3, drivingLicense.DataFields);

            DataFieldExtensions.AssertDataField("Code", "Code Definition", "Code Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
            DataFieldExtensions.AssertDataField("VehicleRestriction", "VehicleRestriction Definition", "VehicleRestriction Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
            DataFieldExtensions.AssertDataField("FirstIssueDate", "FirstIssueDate Definition", "FirstIssueDate Label", 10, true, 0, typeof(string), 0, 0, identityDocument.DataFields);
        }

        [Observation]
        public void should_update_data_field_photo()
        {
            var drivingLicense = DataFieldExtensions.AssertDataField("DrivingLicense", "DrivingLicense Definition", "DrivingLicense Label", 10, true, 0, typeof(string), 0, 12);
            DataFieldExtensions.AssertDataField("Photo", "Photo Definition", "Photo Label", 10, true, 0, typeof(string), 0, 0, drivingLicense.DataFields);
        }

        [Observation]
        public void should_update_data_field_cellphone()
        {
            var drivingLicense = DataFieldExtensions.AssertDataField("DrivingLicense", "DrivingLicense Definition", "DrivingLicense Label", 10, true, 0, typeof(string), 0, 12);
            DataFieldExtensions.AssertDataField("Cellphone", "Cellphone Definition", "Cellphone Label", 10, true, 0, typeof(string), 0, 0, drivingLicense.DataFields);
        }

        [Observation]
        public void should_update_data_field_email_address()
        {
            var drivingLicense = DataFieldExtensions.AssertDataField("DrivingLicense", "DrivingLicense Definition", "DrivingLicense Label", 10, true, 0, typeof(string), 0, 12);
            DataFieldExtensions.AssertDataField("EmailAddress", "EmailAddress Definition", "EmailAddress Label", 10, true, 0, typeof(string), 0, 0, drivingLicense.DataFields);
        }
    }
}