using System;
using System.Collections.Generic;
using Lim.Domain.Dto;

namespace Lim.Test.Helper.Fakes
{
    public class FakeTransactions
    {
        public static List<PackageTransactionDto> ForPushApi()
        {
            return new List<PackageTransactionDto>()
            {
                PackageTransactionDto.Set(Guid.NewGuid(), Guid.NewGuid(), "user", Guid.NewGuid(), 12333, DateTime.Now, Guid.NewGuid(), "[{'id':'9fce37f2-fcb0-43b1-9436-ab031f280d10','name':4,'description':null,'costOfSale':0,'sourceConfiguration':{'isApiConfiguration':true,'url':null,'username':null,'password':null,'connectionString':''},'responseType':null,'fieldLevelCostPriceOverride':false,'owner':null,'createdDate':'0001-01-01T00:00:00.0000000+02:00','editedDate':null,'requestFields':[],'dataFields':[{'dataProviderId':'00000000-0000-0000-0000-000000000000','namespace':'CarId','name':'CarId','label':null,'value':'107483','definition':null,'industries':[{'name':'All','isSelected':true,'id':'cb545e92-801f-463e-b21a-669fa4303d38'}],'costOfSale':0,'isSelected':true,'order':0,'type':'System.Nullable`1[System.Int32]','dataFields':[]},{'dataProviderId':'00000000-0000-0000-0000-000000000000','namespace':'Year','name':'Year','label':null,'value':'2008','definition':null,'industries':[{'name':'All','isSelected':true,'id':'cb545e92-801f-463e-b21a-669fa4303d38'}],'costOfSale':0,'isSelected':true,'order':0,'type':'System.Nullable`1[System.Int32]','dataFields':[]},{'dataProviderId':'00000000-0000-0000-0000-000000000000','namespace':'ImageUrl','name':'ImageUrl','label':null,'value':'http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg','definition':null,'industries':[{'name':'All','isSelected':true,'id':'cb545e92-801f-463e-b21a-669fa4303d38'}],'costOfSale':0,'isSelected':true,'order':0,'type':'System.String','dataFields':[]},{'dataProviderId':'00000000-0000-0000-0000-000000000000','namespace':'Quarter','name':'Quarter','label':null,'value':'3rd Quarter','definition':null,'industries':[{'name':'All','isSelected':true,'id':'cb545e92-801f-463e-b21a-669fa4303d38'}],'costOfSale':0,'isSelected':true,'order':0,'type':'System.String','dataFields':[]},{'dataProviderId':'00000000-0000-0000-0000-000000000000','namespace':'CarFullname','name':'CarFullname','label':null,'value':'TOYOTA Auris 1.6 RT 5-dr','definition':null,'industries':[{'name':'All','isSelected':true,'id':'cb545e92-801f-463e-b21a-669fa4303d38'}],'costOfSale':0,'isSelected':true,'order':0,'type':'System.String','dataFields':[]}],'version':0}]",
                    true,DateTime.UtcNow)
            };
        }
    }
}