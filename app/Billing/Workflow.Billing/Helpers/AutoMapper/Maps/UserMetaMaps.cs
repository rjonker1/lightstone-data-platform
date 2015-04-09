using AutoMapper;
using Shared.Messaging.Billing.Messages;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    public class UserMetaMaps : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<UserMessage, UserMeta>();
        }
    }
}