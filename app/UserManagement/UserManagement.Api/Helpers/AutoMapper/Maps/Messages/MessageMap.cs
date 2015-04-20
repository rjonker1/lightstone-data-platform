using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Messages
{
    public class MessageMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<User, UserMessage>();
        }
    }
}