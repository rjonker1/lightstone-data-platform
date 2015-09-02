using AutoMapper;
using Workflow.Billing.Domain.Entities;
using Workflow.Reporting.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    public class PreBillingMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<PreBilling, PreBillingRecord>();
            Mapper.CreateMap<Package, PackageDetail>();
            Mapper.CreateMap<DataProvider, DataProviderDetail>();
            Mapper.CreateMap<UserTransaction, UserTransactionDetail>();
            Mapper.CreateMap<User, UserDetail>();
        }
    }
}