using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    public class CustomerMap : Profile, ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            //Used: CustomerConsumer
            Mapper.CreateMap<CustomerMessage, Customer>();
        }
    }
}