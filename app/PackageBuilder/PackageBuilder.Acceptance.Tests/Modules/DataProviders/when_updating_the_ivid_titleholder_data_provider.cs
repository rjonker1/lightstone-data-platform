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
    public class when_updating_the_ivid_titleholder_data_provider : BaseDataProviderTest
    {
        public when_updating_the_ivid_titleholder_data_provider()
        {
            Handler.Handle(new CreateDataProvider(Id, DataProviderName.IvidTitleHolder, 0, "Owner", DateTime.UtcNow));

            Transaction(Session =>
            {
                Response = Browser.Put(RouteConstants.DataProviderEditRoute.Replace("{id}", Id.ToString()), with =>
                {
                    with.Header("Accept", "application/json");
                    with.JsonBody(DataProviderDtoMother.IvidTitleHolder);
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
            DataProvider.Name.ShouldEqual(DataProviderName.IvidTitleHolder);
            DataProvider.Description.ShouldEqual("IvidTitleHolder");
            DataProvider.CreatedDate.Date.ShouldEqual(DateTime.Now.Date);
            DataProvider.EditedDate.Value.Date.ShouldEqual(DateTime.Now.Date);
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
            DataProvider.DataFields.Count().ShouldEqual(14);
        }

        [Observation]
        public void should_update_request_field_vin_number()
        {
            AssertRequestField("VinNumber", RequestFieldType.VinNumber);
        }

        [Observation]
        public void should_update_data_field_bank_name()
        {
            AssertDataField("BankName", "BankName Definition", "BankName Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_account_number()
        {
            AssertDataField("AccountNumber", "AccountNumber Definition", "AccountNumber Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_date_opened()
        {
            AssertDataField("DateOpened", "DateOpened Definition", "DateOpened Label", 10, true, 0, typeof(DateTime?));
        }

        [Observation]
        public void should_update_data_field_flagged_on_anpr()
        {
            AssertDataField("FlaggedOnAnpr", "FlaggedOnAnpr Definition", "FlaggedOnAnpr Label", 10, true, 0, typeof(bool));
        }

        [Observation]
        public void should_update_data_field_financial_interests_heading()
        {
            AssertDataField("FinancialInterestsHeading", "FinancialInterestsHeading Definition", "FinancialInterestsHeading Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_account_open_date()
        {
            AssertDataField("AccountOpenDate", "AccountOpenDate Definition", "AccountOpenDate Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_account_closed_date()
        {
            AssertDataField("AccountClosedDate", "AccountClosedDate Definition", "AccountClosedDate Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_agreement_type()
        {
            AssertDataField("AgreementType", "AgreementType Definition", "AgreementType Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_year_of_liability_for_licensing()
        {
            AssertDataField("YearOfLiabilityForLicensing", "YearOfLiabilityForLicensing Definition", "YearOfLiabilityForLicensing Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_request_financial_interest_invite()
        {
            AssertDataField("RequestFinancialInterestInvite", "RequestFinancialInterestInvite Definition", "RequestFinancialInterestInvite Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_financial_interest_available()
        {
            AssertDataField("FinancialInterestAvailable", "FinancialInterestAvailable Definition", "FinancialInterestAvailable Label", 10, true, 0, typeof(bool));
        }

        [Observation]
        public void should_update_data_field_partial_response()
        {
            AssertDataField("PartialResponse", "PartialResponse Definition", "PartialResponse Label", 10, true, 0, typeof(bool));
        }

        [Observation]
        public void should_update_data_field_has_errors()
        {
            AssertDataField("HasErrors", "HasErrors Definition", "HasErrors Label", 10, true, 0, typeof(bool));
        }

        [Observation]
        public void should_update_data_field_espired_message()
        {
            AssertDataField("ExpiredMessage", "ExpiredMessage Definition", "ExpiredMessage Label", 10, true, 0, typeof(string));
        }
    }
}