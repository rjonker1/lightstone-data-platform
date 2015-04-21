using AutoMapper;
using DataPlatform.Shared.Repositories;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    public class StageBillingMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IRepository<PreBilling>, IRepository<StageBilling>>();
        }
    }
}