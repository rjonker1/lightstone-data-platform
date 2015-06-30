using System;
using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using UserManagement.Domain.Dtos;
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
                .ForMember(dest => dest.Created, opt => opt.MapFrom(x => DateTime.UtcNow))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(x => GetType().FullName))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(x => x.CustomerAccountNumber.ToString()))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(x => x.Name));

            Mapper.CreateMap<Client, ClientMessage>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.NewGuid()))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(x => DateTime.UtcNow))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(x => GetType().FullName))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(x => x.ClientAccountNumber.ToString()))
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(x => x.Name));

            Mapper.CreateMap<Contract, ContractMessage>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.NewGuid()))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(x => DateTime.UtcNow))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(x => GetType().FullName))
                .ForMember(dest => dest.ContractId, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.ContractName, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(x => x.IsActive))
                .ForMember(dest => dest.ContractBundleId, opt => opt.MapFrom(x => x.ContractBundleId));

            Mapper.CreateMap<CustomerDto, CustomerMessage>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.NewGuid()))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(x => DateTime.UtcNow))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(x => GetType().FullName))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(x => x.CustomerAccountNumber.ToString()))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(x => x.Name));

            Mapper.CreateMap<ClientDto, ClientMessage>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.NewGuid()))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(x => DateTime.UtcNow))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(x => GetType().FullName))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(x => x.ClientAccountNumber.ToString()))
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(x => x.Name));

            Mapper.CreateMap<ContractDto, ContractMessage>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.NewGuid()))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(x => DateTime.UtcNow))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(x => GetType().FullName))
                .ForMember(dest => dest.ContractId, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.ContractName, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(x => x.IsActive))
                .ForMember(dest => dest.ContractBundleId, opt => opt.MapFrom(x => x.ContractBundleId))
                .ForMember(dest => dest.ContractBundleTransactionLimit, opt => opt.Ignore())
                .ForMember(dest => dest.ContractBundlePrice, opt => opt.Ignore())
                .ForMember(dest => dest.ContractBundleId, opt => opt.MapFrom(x => x.ContractBundleId));
        }
    }
}