using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using Lace.Domain.Core.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestHelper.Helpers.Extensions;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses
{
    public class when_mapping_pcubed_ezscore_collection_response : BaseTestHelper
    {
        private IDataField _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IEnumerable<IRespondWithEzScore>, DataField>(PCubedEzScoreResponseMother.Response.EzScoreRecords);
        }

        [Observation]
        public void should_map()
        {
            _dataField.Type.ShouldEqual(typeof(IRespondWithEzScore[]).ToString());
            _dataField.DataFields.Count().ShouldEqual(1);
            DataFieldExtensions.AssertDataField("EzScoreRecord", typeof(EzScoreRecord), null, 44, _dataField.DataFields);

            var companyResponse = _dataField.DataFields.Get("EzScoreRecord");
            DataFieldExtensions.AssertDataField("Phone1", typeof(string), "Phone1", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Phone2", typeof(string), "Phone2", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Phone3", typeof(string), "Phone3", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("EmailAddress1", typeof(string), "EmailAddress1", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("EmailAddress2", typeof(string), "EmailAddress2", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("EmailAddress3", typeof(string), "EmailAddress3", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Surname", typeof(string), "Surname", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("FirstName", typeof(string), "FirstName", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("IdNumber", typeof(string), "IdNumber", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("DemLsm", typeof(string), "DemLsm", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("FasNonCpaGroupDescriptionShort", typeof(string), "FasNonCpaGroupDescriptionShort", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("MosaicCpaGroupMerged", typeof(string), "MosaicCpaGroupMerged", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("WealthIndex", typeof(string), "WealthIndex", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("CreditGradeNonCpa", typeof(string), "", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("DemHomeOwner", typeof(string), "DemHomeOwner", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("DemDeceased", typeof(string), "Deceased", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("DemPredictedRace", typeof(string), "DemPredictedRace", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("DemGender", typeof(string), "DemGender", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddressPostCode", typeof(string), "PostalAddressPostCode", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddressProvince", typeof(string), "PostalAddressProvince", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddressTownCity", typeof(string), "PostalAddressTownCity", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddressSuburb", typeof(string), "PostalAddressSuburb", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddressLine2", typeof(string), "PostalAddressLine2", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalAddressLine1", typeof(string), "PostalAddressLine1", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("AddressPostCode", typeof(string), "AddressPostCode", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("AddressProvince", typeof(string), "AddressProvince", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("AddressTownCity", typeof(string), "AddressTownCity", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("AddressSuburb", typeof(string), "AddressSuburb", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("AddressLine2", typeof(string), "AddressLine2", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("AddressLine1", typeof(string), "AddressLine1", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ExtractDate", typeof(string), "ExtractDate", 1, companyResponse.DataFields);
        }
    }
}