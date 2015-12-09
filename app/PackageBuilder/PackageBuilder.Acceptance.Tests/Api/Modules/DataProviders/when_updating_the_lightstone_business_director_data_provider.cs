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

namespace PackageBuilder.Acceptance.Tests.Api.Modules.DataProviders
{
    public class when_updating_the_lightstone_business_director_data_provider : BaseDataProviderTest
    {
        public when_updating_the_lightstone_business_director_data_provider()
        {
            Handler.Handle(new CreateDataProvider(Id, DataProviderName.LSBusinessDirector_E_WS, 0, "Owner", DateTime.UtcNow));

            Transaction(Session =>
            {
                Response = Browser.Put(RouteConstants.DataProviderEditRoute.Replace("{id}", Id.ToString()), with =>
                {
                    with.Header("Accept", "application/json");
                    with.JsonBody(DataProviderDtoMother.LightstoneBusinessDirector);
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
            DataProvider.Name.ShouldEqual(DataProviderName.LSBusinessDirector_E_WS);
            DataProvider.Description.ShouldEqual("LightstoneBusinessDirector");
            DataProvider.CreatedDate.Date.ShouldEqual(DateTime.UtcNow.Date);
            DataProvider.EditedDate.Value.Date.ShouldEqual(DateTime.UtcNow.Date);
            DataProvider.Owner.ShouldEqual("Owner");
            DataProvider.Version.ShouldEqual(2);
            DataProvider.CostOfSale.ShouldEqual(10);
        }

        [Observation]
        public void should_contain_all_request_fields()
        {
            DataProvider.RequestFields.Count().ShouldEqual(3);
        }

        [Observation]
        public void should_contain_all_data_fields()
        {
            DataProvider.DataFields.Count().ShouldEqual(1);
        }

        [Observation]
        public void should_update_request_field_company_name()
        {
            DataFieldExtensions.AssertRequestField("IdentityNumber", RequestFieldType.IdentityNumber, DataProvider.RequestFields);
        }

        [Observation]
        public void should_update_request_field_company_registration_number()
        {
            DataFieldExtensions.AssertRequestField("FirstName", RequestFieldType.FirstName, DataProvider.RequestFields);
        }

        [Observation]
        public void should_update_request_field_company_vat_number()
        {
            DataFieldExtensions.AssertRequestField("Surname", RequestFieldType.Surname, DataProvider.RequestFields);
        }
        [Observation]
        public void should_update_data_field_companies()
        {
            var propertyInformation = DataFieldExtensions.AssertDataField("Directors", "Directors Definition", "Directors Label", 10, true, 0, typeof(string), 0, 58);

            DataFieldExtensions.AssertDataField("Id", "Id Definition", "Id Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("DirectorId", "DirectorId Definition", "DirectorId Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("CompanyId", "CompanyId Definition", "CompanyId Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("CompanyRegNumber", "CompanyRegNumber Definition", "CompanyRegNumber Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("FirstName", "FirstName Definition", "FirstName Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("Initials", "Initials Definition", "Initials Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("Surname", "Surname Definition", "Surname Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("SurnameParticular", "SurnameParticular Definition", "SurnameParticular Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("PreviousSurname", "PreviousSurname Definition", "PreviousSurname Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("IdNumber", "IdNumber Definition", "IdNumber Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("BirthDate", "BirthDate Definition", "BirthDate Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("DesignationCode", "DesignationCode Definition", "DesignationCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("RsaResident", "RsaResident Definition", "RsaResident Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("WithdrawPublic", "WithdrawPublic Definition", "WithdrawPublic Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("CountryCode", "CountryCode Definition", "CountryCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("TypeCode", "TypeCode Definition", "TypeCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("StatusCode", "StatusCode Definition", "StatusCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("StatusDate", "StatusDate Definition", "StatusDate Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("RegisterNumber", "RegisterNumber Definition", "RegisterNumber Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("ExecutorName", "ExecutorName Definition", "ExecutorName Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("ExecutorAppointDate", "ExecutorAppointDate Definition", "ExecutorAppointDate Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("TrusteeName", "TrusteeName Definition", "TrusteeName Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("FormLodgeDate", "FormLodgeDate Definition", "FormLodgeDate Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("FormReceiveDate", "FormReceiveDate Definition", "FormReceiveDate Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("FoundingStatementDate", "FoundingStatementDate Definition", "FoundingStatementDate Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("MemberSize", "MemberSize Definition", "MemberSize Label", 10, true, 0, typeof(double), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("MemberContribution", "MemberContribution Definition", "MemberContribution Label", 10, true, 0, typeof(double), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("MemberContributionType", "MemberContributionType Definition", "MemberContributionType Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("ExclCon", "ExclCon Definition", "ExclCon Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("RegisteredAddress1", "RegisteredAddress1 Definition", "RegisteredAddress1 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("RegisteredAddress2", "RegisteredAddress2 Definition", "RegisteredAddress2 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("RegisteredAddress3", "RegisteredAddress3 Definition", "RegisteredAddress3 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("RegisteredAddress4", "RegisteredAddress4 Definition", "RegisteredAddress4 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("RegisteredPostCode", "RegisteredPostCode Definition", "RegisteredPostCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("ResidentialAddress1", "ResidentialAddress1 Definition", "ResidentialAddress1 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("ResidentialAddress2", "ResidentialAddress2 Definition", "ResidentialAddress2 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("ResidentialAddress3", "ResidentialAddress3 Definition", "ResidentialAddress3 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("ResidentialAddress4", "ResidentialAddress4 Definition", "ResidentialAddress4 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("ResidentialPostCode", "ResidentialPostCode Definition", "ResidentialPostCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("BusinessAddress1", "BusinessAddress1 Definition", "BusinessAddress1 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("BusinessAddress2", "BusinessAddress2 Definition", "BusinessAddress2 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("BusinessAddress3", "BusinessAddress3 Definition", "BusinessAddress3 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("BusinessAddress4", "BusinessAddress4 Definition", "BusinessAddress4 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("BusinessPostCode", "BusinessPostCode Definition", "BusinessPostCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddress1", "PostalAddress1 Definition", "PostalAddress1 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddress2", "PostalAddress2 Definition", "PostalAddress2 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddress3", "PostalAddress3 Definition", "PostalAddress3 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddress4", "PostalAddress4 Definition", "PostalAddress4 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("PostalPostCode", "PostalPostCode Definition", "PostalPostCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("OccupationCode", "OccupationCode Definition", "OccupationCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("FineExpiryDate", "FineExpiryDate Definition", "FineExpiryDate Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("NatureOfChange", "NatureOfChange Definition", "NatureOfChange Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("NationalityCode", "NationalityCode Definition", "NationalityCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("Profession", "Profession Definition", "Profession Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("Estate", "Estate Definition", "Estate Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("LsId", "LsId Definition", "LsId Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
            DataFieldExtensions.AssertDataField("StatusOrder", "StatusOrder Definition", "StatusOrder Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
        }
    }
}