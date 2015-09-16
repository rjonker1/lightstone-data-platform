using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    public class ClientMap : Profile, ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            //Used: ClientConsumer
            Mapper.CreateMap<ClientMessage, Client>();
        }
    }
}