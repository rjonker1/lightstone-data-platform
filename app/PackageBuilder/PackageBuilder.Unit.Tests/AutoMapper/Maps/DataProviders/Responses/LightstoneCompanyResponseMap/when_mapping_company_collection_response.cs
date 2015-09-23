using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestHelper.Helpers.Extensions;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses.LightstoneCompanyResponseMap
{
    public class when_mapping_company_collection_response : BaseTestHelper
    {
        private IDataField _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IEnumerable<IProvideCompany>, DataField>(LightstoneBusinessCompanyResponseMother.Response.Companies);
        }

        [Observation]
        public void should_map()
        {
            _dataField.Type.ShouldEqual(typeof(IProvideCompany[]).ToString());
            _dataField.DataFields.Count().ShouldEqual(1);
            DataFieldExtensions.AssertDataField("CompanyResponse", typeof(CompanyResponse), null, 42, _dataField.DataFields);

            var companyResponse = _dataField.DataFields.Get("CompanyResponse");
            DataFieldExtensions.AssertDataField("AuthorisedCapital", typeof(double), "10", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("AuthorisedShares", typeof(double), "20", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("BusinessStartDate", typeof(string), "2010/09/09", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("CompanyName", typeof(string), "LIGHTSTONE AUTO", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("CompanyRegNumber", typeof(string), "2010/018608/07", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ConversionNumber", typeof(string), "ConversionNumber", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("CountryCode", typeof(string), "ZA", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("CountryOfOrigin", typeof(string), "South Africa", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Cpa", typeof(bool), "True", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("EnterpriseType", typeof(string), "Private Company (Pty) Ltd)", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("FinancialEffectiveDate", typeof(string), "2010/09/08", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("FinancialYearEnd", typeof(string), "2", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("FormDate", typeof(string), "2010/09/09", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("FormReceivedDate", typeof(string), "2010/09/10", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Id", typeof(int), "3479505", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("IssuedCapital", typeof(double), "30", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("IssuedShares", typeof(double), "40", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("OldRegistrationNumber", typeof(string), "2010/018608/06", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PhysicalAddress1", typeof(string), "FERN GLEN FERNRIDGE OFFICE PARK", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PhysicalAddress2", typeof(string), "5 HUNTER STREET", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PhysicalAddress3", typeof(string), "FERNDALE", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PhysicalAddress4", typeof(string), "Gauteng", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PhysicalPostCode", typeof(string), "2194", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddress1", typeof(string), "P O BOX 418", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddress2", typeof(string), "PINEGOWRIE", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddress3", typeof(string), "PostalAddress3", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddress4", typeof(string), "PostalAddress4", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalPostCode", typeof(string), "2123", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("RegionCode", typeof(string), "7", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("RegionCodeDesc", typeof(string), "Gauteng", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("RegistrationDate", typeof(string), "2010/09/11", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ShortenType", typeof(string), "(Pty) Ltd", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ShortName", typeof(string), "ShortName", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("SicCode", typeof(string), "SicCode", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("SicDescription", typeof(string), "SicDescription", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("StatusCode", typeof(string), "03", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("StatusCodeDesc", typeof(string), "In Business", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("StatusDate", typeof(string), "2010/09/12", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("TaxNumber", typeof(string), "9853212158", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("TranslatedName", typeof(string), "TranslatedName", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("TypeDate", typeof(string), "2010/09/13", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("WithdrawnPublic", typeof(string), "false", 1, companyResponse.DataFields);
        }
    }
}