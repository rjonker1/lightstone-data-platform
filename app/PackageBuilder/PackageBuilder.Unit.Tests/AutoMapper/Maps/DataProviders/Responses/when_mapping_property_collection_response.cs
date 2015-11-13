using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Property;
using Lace.Domain.Core.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestHelper.Helpers.Extensions;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses
{
    public class when_mapping_property_collection_response : BaseTestHelper
    {
        private IDataField _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IEnumerable<IRespondWithProperty>, DataField>(LightstonePropertyResponseMother.Response.PropertyInformation);
        }

        [Observation]
        public void should_map()
        {
            _dataField.Type.ShouldEqual(typeof(IRespondWithProperty[]).ToString());
            _dataField.DataFields.Count().ShouldEqual(1);
            DataFieldExtensions.AssertDataField("PropertyModel", typeof(PropertyModel), null, 52, _dataField.DataFields);

            var companyResponse = _dataField.DataFields.Get("PropertyModel");
            DataFieldExtensions.AssertDataField("SrId", typeof(int), "1", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PropertyId", typeof(decimal), "20", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("DeedId", typeof(decimal), "0", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PropertyTypeId", typeof(decimal), "16", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("SsId", typeof(decimal), "22", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("NadId", typeof(decimal), "0", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PropertyType", typeof(string), "FH", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Province", typeof(string), "GA", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Muncipality", typeof(string), "CITY OF JOHANNESBURG", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Deedtown", typeof(string), "MAROELADA", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("FarmName", typeof(string), "FarmName", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("SectionalTitle", typeof(string), "SectionalTitle", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Unit", typeof(int), "2", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Portion", typeof(decimal), "21", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("BuyerName", typeof(string), "WOOLFSON MURRAY GRANT", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("FirstName", typeof(string), "MURRAY", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("SecondMiddleName", typeof(string), "SecondMiddleName", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ThirdMiddleName", typeof(string), "ThirdMiddleName", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Surname", typeof(string), "WOOLFSON", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PersonTypeId", typeof(string), "PP", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("BuyerIdCk", typeof(string), "7902065199085", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("MunicId", typeof(decimal), "18", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ProvId", typeof(decimal), "17", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("StreetNumber", typeof(string), "StreetNumber", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("StreetType", typeof(string), "StreetType", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PostalCode", typeof(string), "PostalCode", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("UserId", typeof(Guid), new Guid().ToString(), 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Garage", typeof(int), "7", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("SectionSchemeNumber", typeof(string), "SectionSchemeNumber", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("SectionlSchemeUnitNoFrom", typeof(int), "5", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("SectionalSchemeUnitTo", typeof(int), "4", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Size", typeof(double), "14", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("XCoOrdinates", typeof(double), "27.985247", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("YCoOrdinates", typeof(double), "-26.023466", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Suburb", typeof(string), "MAROELADAL", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("TitleDeedNo", typeof(string), "610", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("RegistrationDate", typeof(string), "20120530", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("Township", typeof(string), "MAROELADAL EXT 23", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PurchasePrice", typeof(int), "1690000", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("PurchaseDate", typeof(int), "20130101", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("BondNumber", typeof(string), "B22499/2012", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("TownshipAlt", typeof(string), "MAROELADAL EXT 23", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("RemainingExtent", typeof(bool), "False", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("AdditionalDescription", typeof(string), "AdditionalDescription", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("SuburbId", typeof(int), "3", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("StreetId", typeof(decimal), "23", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ActiveStatus", typeof(string), "Active", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("EstateName", typeof(string), "WATERFORD ESTATE", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("EstateId", typeof(int), "8", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("ReqStatusId", typeof(int), "6", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("EstimatedCoOrdinates", typeof(bool), "True", 1, companyResponse.DataFields);
            DataFieldExtensions.AssertDataField("MiddleName", typeof(string), "GRANT", 1, companyResponse.DataFields);
        }
    }
}