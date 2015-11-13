using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    public class UserMetaMaps : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            //Used: EntityConsumer
            Mapper.CreateMap<UserMessage, UserMeta>();

            //Used: TransactionConsumer
            Mapper.CreateMap<UserMeta, User>();
        }
    }
}