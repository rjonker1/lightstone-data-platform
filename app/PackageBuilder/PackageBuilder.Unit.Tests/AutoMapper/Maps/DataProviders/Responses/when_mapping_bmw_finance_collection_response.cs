using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Finance;
using Lace.Domain.Core.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestHelper.Helpers.Extensions;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses
{
    public class when_mapping_bmw_finance_collection_response : BaseTestHelper
    {
        private IDataField _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IEnumerable<IRespondWithBmwFinance>, DataField>(LightstoneBmwFinanceResponseMother.Response.Finances);            
        }

        [Observation]
        public void should_map()
        {
            _dataField.Type.ShouldEqual(typeof(IRespondWithBmwFinance[]).ToString());
            _dataField.DataFields.Count().ShouldEqual(1);
            DataFieldExtensions.AssertDataField("BmwFinanceRecord", typeof(BmwFinanceRecord), null, 11, _dataField.DataFields);

            var financeResponse = _dataField.DataFields.Get("BmwFinanceRecord");
            DataFieldExtensions.AssertDataField("Chassis", typeof(string), "Chassis", 1, financeResponse.DataFields);
            DataFieldExtensions.AssertDataField("DealReference", typeof(decimal), "12354785.025", 1, financeResponse.DataFields);
            DataFieldExtensions.AssertDataField("DealStatus", typeof(string), "DealStatus", 1, financeResponse.DataFields);
            DataFieldExtensions.AssertDataField("Description", typeof(string), "Description", 1, financeResponse.DataFields);
            DataFieldExtensions.AssertDataField("Engine", typeof(string), "Engine", 1, financeResponse.DataFields);
            DataFieldExtensions.AssertDataField("ExpireDate", typeof(DateTime), "2015-10-15 00:00:00", 1, financeResponse.DataFields);
            DataFieldExtensions.AssertDataField("FinanceHouse", typeof(string), "FinanceHouse", 1, financeResponse.DataFields);
            DataFieldExtensions.AssertDataField("ProductCategory", typeof(string), "ProductCategory", 1, financeResponse.DataFields);
            DataFieldExtensions.AssertDataField("RegistrationNumber", typeof(string), "RegistrationNumber", 1, financeResponse.DataFields);
            DataFieldExtensions.AssertDataField("RegistrationYear", typeof(int), "2008", 1, financeResponse.DataFields);
            DataFieldExtensions.AssertDataField("StartDate", typeof(DateTime), "2015-01-01 00:00:00", 1, financeResponse.DataFields);
        }
    }
}