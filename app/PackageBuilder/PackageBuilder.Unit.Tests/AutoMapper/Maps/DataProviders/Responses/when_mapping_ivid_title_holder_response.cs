﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses
{
    public class when_mapping_ivid_title_holder_response : BaseTestHelper
    {
        private IEnumerable<IDataField> _dataFields;
        public override void Observe()
        {
            _dataFields = Mapper.Map<IProvideDataFromIvidTitleHolder, IEnumerable<DataField>>(IvidTitleHolderResponseMother.Response);
        }

        [Observation]
        public void should_map_all_ivid_title_holder_data_fields()
        {
            _dataFields.Count().ShouldEqual(14);

            _dataFields.FirstOrDefault(x => x.Name == "BankName").Name.ShouldEqual("BankName");
            _dataFields.FirstOrDefault(x => x.Name == "BankName").Type.ShouldEqual(typeof(string).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "AccountNumber").Name.ShouldEqual("AccountNumber");
            _dataFields.FirstOrDefault(x => x.Name == "AccountNumber").Type.ShouldEqual(typeof(string).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "DateOpened").Name.ShouldEqual("DateOpened");
            _dataFields.FirstOrDefault(x => x.Name == "DateOpened").Type.ShouldEqual(typeof(DateTime?).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "FlaggedOnAnpr").Name.ShouldEqual("FlaggedOnAnpr");
            _dataFields.FirstOrDefault(x => x.Name == "FlaggedOnAnpr").Type.ShouldEqual(typeof(bool).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "FinancialInterestsHeading").Name.ShouldEqual("FinancialInterestsHeading");
            _dataFields.FirstOrDefault(x => x.Name == "FinancialInterestsHeading").Type.ShouldEqual(typeof(string).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "AccountOpenDate").Name.ShouldEqual("AccountOpenDate");
            _dataFields.FirstOrDefault(x => x.Name == "AccountOpenDate").Type.ShouldEqual(typeof(string).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "AccountClosedDate").Name.ShouldEqual("AccountClosedDate");
            _dataFields.FirstOrDefault(x => x.Name == "AccountClosedDate").Type.ShouldEqual(typeof(string).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "AgreementType").Name.ShouldEqual("AgreementType");
            _dataFields.FirstOrDefault(x => x.Name == "AgreementType").Type.ShouldEqual(typeof(string).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "YearOfLiabilityForLicensing").Name.ShouldEqual("YearOfLiabilityForLicensing");
            _dataFields.FirstOrDefault(x => x.Name == "YearOfLiabilityForLicensing").Type.ShouldEqual(typeof(string).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "RequestFinancialInterestInvite").Name.ShouldEqual("RequestFinancialInterestInvite");
            _dataFields.FirstOrDefault(x => x.Name == "RequestFinancialInterestInvite").Type.ShouldEqual(typeof(string).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "FinancialInterestAvailable").Name.ShouldEqual("FinancialInterestAvailable");
            _dataFields.FirstOrDefault(x => x.Name == "FinancialInterestAvailable").Type.ShouldEqual(typeof(bool).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "PartialResponse").Name.ShouldEqual("PartialResponse");
            _dataFields.FirstOrDefault(x => x.Name == "PartialResponse").Type.ShouldEqual(typeof(bool).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "HasErrors").Name.ShouldEqual("HasErrors");
            _dataFields.FirstOrDefault(x => x.Name == "HasErrors").Type.ShouldEqual(typeof(bool).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "ExpiredMessage").Name.ShouldEqual("ExpiredMessage");
            _dataFields.FirstOrDefault(x => x.Name == "ExpiredMessage").Type.ShouldEqual(typeof(string).ToString());
        }
    }
}