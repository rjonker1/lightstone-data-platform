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
    public class when_updating_the_lightstone_business_company_data_provider : BaseDataProviderTest
    {
        public when_updating_the_lightstone_business_company_data_provider()
        {
            Handler.Handle(new CreateDataProvider(Id, DataProviderName.LightstoneBusinessCompany, 0, "Owner", DateTime.UtcNow));

            Transaction(Session =>
            {
                Response = Browser.Put(RouteConstants.DataProviderEditRoute.Replace("{id}", Id.ToString()), with =>
                {
                    with.Header("Accept", "application/json");
                    with.JsonBody(DataProviderDtoMother.LightstoneBusinessCompany);
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
            DataProvider.Name.ShouldEqual(DataProviderName.LightstoneBusinessCompany);
            DataProvider.Description.ShouldEqual("LightstoneBusinessCompany");
            DataProvider.CreatedDate.Date.ShouldEqual(DateTime.Now.Date);
            DataProvider.EditedDate.Value.Date.ShouldEqual(DateTime.Now.Date);
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
            AssertRequestField("CompanyName", RequestFieldType.CompanyName);
        }

        [Observation]
        public void should_update_request_field_company_registration_number()
        {
            AssertRequestField("CompanyRegistrationNumber", RequestFieldType.CompanyRegistrationNumber);
        }

        [Observation]
        public void should_update_request_field_company_vat_number()
        {
            AssertRequestField("CompanyVatNumber", RequestFieldType.CompanyVatNumber);
        }
        [Observation]
        public void should_update_data_field_companies()
        {
            var propertyInformation = AssertDataField("Companies", "Companies Definition", "Companies Label", 10, true, 0, typeof(string), 0, 42);

            AssertDataField("Id", "Id Definition", "Id Label", 10, true, 0, typeof(int), 0, 0, propertyInformation.DataFields);
            AssertDataField("EnterpriseType", "EnterpriseType Definition", "EnterpriseType Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("ShortenType", "ShortenType Definition", "ShortenType Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("CompanyRegNumber", "CompanyRegNumber Definition", "CompanyRegNumber Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("OldRegistrationNumber", "OldRegistrationNumber Definition", "OldRegistrationNumber Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("TypeDate", "TypeDate Definition", "TypeDate Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("CompanyName", "CompanyName Definition", "CompanyName Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("ShortName", "ShortName Definition", "ShortName Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("TranslatedName", "TranslatedName Definition", "TranslatedName Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("RegistrationDate", "RegistrationDate Definition", "RegistrationDate Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("BusinessStartDate", "BusinessStartDate Definition", "BusinessStartDate Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("WithdrawnPublic", "WithdrawnPublic Definition", "WithdrawnPublic Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("StatusCode", "StatusCode Definition", "StatusCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("StatusDate", "StatusDate Definition", "StatusDate Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("SicCode", "SicCode Definition", "SicCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("FinancialYearEnd", "FinancialYearEnd Definition", "FinancialYearEnd Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("FinancialEffectiveDate", "FinancialEffectiveDate Definition", "FinancialEffectiveDate Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("PhysicalAddress1", "PhysicalAddress1 Definition", "PhysicalAddress1 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("PhysicalAddress2", "PhysicalAddress2 Definition", "PhysicalAddress2 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("PhysicalAddress3", "PhysicalAddress3 Definition", "PhysicalAddress3 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("PhysicalAddress4", "PhysicalAddress4 Definition", "PhysicalAddress4 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("PhysicalPostCode", "PhysicalPostCode Definition", "PhysicalPostCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("PostalAddress1", "PostalAddress1 Definition", "PostalAddress1 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("PostalAddress2", "PostalAddress2 Definition", "PostalAddress2 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("PostalAddress3", "PostalAddress3 Definition", "PostalAddress3 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("PostalAddress4", "PostalAddress4 Definition", "PostalAddress4 Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("PostalPostCode", "PostalPostCode Definition", "PostalPostCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("CountryCode", "CountryCode Definition", "CountryCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("CountryOfOrigin", "CountryOfOrigin Definition", "CountryOfOrigin Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("RegionCode", "RegionCode Definition", "RegionCode Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("AuthorisedCapital", "AuthorisedCapital Definition", "AuthorisedCapital Label", 10, true, 0, typeof(double), 0, 0, propertyInformation.DataFields);
            AssertDataField("AuthorisedShares", "AuthorisedShares Definition", "AuthorisedShares Label", 10, true, 0, typeof(double), 0, 0, propertyInformation.DataFields);
            AssertDataField("IssuedCapital", "IssuedCapital Definition", "IssuedCapital Label", 10, true, 0, typeof(double), 0, 0, propertyInformation.DataFields);
            AssertDataField("IssuedShares", "IssuedShares Definition", "IssuedShares Label", 10, true, 0, typeof(double), 0, 0, propertyInformation.DataFields);
            AssertDataField("FormReceivedDate", "FormReceivedDate Definition", "FormReceivedDate Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("FormDate", "FormDate Definition", "FormDate Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("ConversionNumber", "ConversionNumber Definition", "ConversionNumber Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("TaxNumber", "TaxNumber Definition", "TaxNumber Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("Cpa", "Cpa Definition", "Cpa Label", 10, true, 0, typeof(bool), 0, 0, propertyInformation.DataFields);
            AssertDataField("StatusCodeDesc", "StatusCodeDesc Definition", "StatusCodeDesc Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("RegionCodeDesc", "RegionCodeDesc Definition", "RegionCodeDesc Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
            AssertDataField("SicDescription", "SicDescription Definition", "SicDescription Label", 10, true, 0, typeof(string), 0, 0, propertyInformation.DataFields);
        }
    }
}