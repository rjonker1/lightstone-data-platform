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

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses
{
    public class when_mapping_director_collection_response : BaseTestHelper
    {
        private IDataField _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IEnumerable<IProvideDirector>, DataField>(LightstoneBusinessDirectorResponseMother.Response.Directors);
        }

        [Observation]
        public void should_map()
        {
            _dataField.Type.ShouldEqual(typeof(IProvideDirector[]).ToString());
            _dataField.DataFields.Count().ShouldEqual(1);
            DataFieldExtensions.AssertDataField("DirectorResponse", typeof(DirectorResponse), null, 58, _dataField.DataFields);

            var companyResponse = _dataField.DataFields.Get("DirectorResponse");
            DataFieldExtensions.AssertDataField("BirthDate", typeof(string), "BirthDate", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("BusinessAddress1", typeof(string), "BusinessAddress1", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("BusinessAddress2", typeof(string), "BusinessAddress2", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("BusinessAddress3", typeof(string), "BusinessAddress3", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("BusinessAddress4", typeof(string), "BusinessAddress4", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("BusinessPostCode", typeof(string), "BusinessPostCode", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("CompanyId", typeof(int), "1003", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("CompanyRegNumber", typeof(string), "2010/018608/07", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("CountryCode", typeof(string), "CountryCode", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("DesignationCode", typeof(string), "DesignationCode", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("DirectorId", typeof(int), "1002", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Estate", typeof(string), "Estate", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ExclCon", typeof(int), "1", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ExecutorAppointDate", typeof(string), "ExecutorAppointDate", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ExecutorName", typeof(string), "ExecutorName", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("FineExpiryDate", typeof(string), "FineExpiryDate", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("FirstName", typeof(string), "FirstName", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("FormLodgeDate", typeof(string), "FormLodgeDate", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("FormReceiveDate", typeof(string), "FormReceiveDate", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("FoundingStatementDate", typeof(string), "FoundingStatementDate", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Id", typeof(int), "1001", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("IdNumber", typeof(string), "IdNumber", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Initials", typeof(string), "Initials", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("LsId", typeof(int), "2", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("MemberContribution", typeof(double), "11", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("MemberContributionType", typeof(string), "MemberContributionType", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("MemberSize", typeof(double), "10", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("NationalityCode", typeof(string), "NationalityCode", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("NatureOfChange", typeof(string), "NatureOfChange", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("OccupationCode", typeof(string), "OccupationCode", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddress1", typeof(string), "PostalAddress1", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddress2", typeof(string), "PostalAddress2", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddress3", typeof(string), "PostalAddress3", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddress4", typeof(string), "PostalAddress4", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalPostCode", typeof(string), "PostalPostCode", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PreviousSurname", typeof(string), "PreviousSurname", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Profession", typeof(string), "Profession", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("RegisteredAddress1", typeof(string), "RegisteredAddress1", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("RegisteredAddress2", typeof(string), "RegisteredAddress2", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("RegisteredAddress3", typeof(string), "RegisteredAddress3", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("RegisteredAddress4", typeof(string), "RegisteredAddress4", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("RegisteredPostCode", typeof(string), "RegisteredPostCode", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("RegisterNumber", typeof(string), "RegisterNumber", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ResidentialAddress1", typeof(string), "ResidentialAddress1", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ResidentialAddress2", typeof(string), "ResidentialAddress2", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ResidentialAddress3", typeof(string), "ResidentialAddress3", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ResidentialAddress4", typeof(string), "ResidentialAddress4", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ResidentialPostCode", typeof(string), "ResidentialPostCode", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ResignationDate", typeof(string), "ResignationDate", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("RsaResident", typeof(string), "RsaResident", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("StatusCode", typeof(string), "StatusCode", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("StatusDate", typeof(string), "StatusDate", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("StatusOrder", typeof(int), "3", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Surname", typeof(string), "Surname", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("SurnameParticular", typeof(string), "SurnameParticular", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("TrusteeName", typeof(string), "TrusteeName", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("TypeCode", typeof(string), "TypeCode", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("WithdrawPublic", typeof(string), "WithdrawPublic", 1, companyResponse.DataFields);
        }
    }
}