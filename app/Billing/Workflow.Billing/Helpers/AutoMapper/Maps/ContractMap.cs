using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    public class ContractMap : Profile, ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<ContractMessage, ContractMeta>();
        }
    }
}