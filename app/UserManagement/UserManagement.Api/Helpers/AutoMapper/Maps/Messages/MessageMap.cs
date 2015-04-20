using System;
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
            Mapper.CreateMap<Customer, CustomerMessage>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.NewGuid()))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(x => x.CustomerAccountNumber.ToString()))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(x => x.Name));
        }
    }
}