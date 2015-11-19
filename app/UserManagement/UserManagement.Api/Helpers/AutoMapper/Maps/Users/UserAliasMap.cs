using System;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Users
{
    public class UserAliasMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<ClientUserAlias, UserAliasDto>()
                .ForMember(d => d.DefaultCustomerId, opt => opt.MapFrom(x => x.User.CustomerUsers.FirstOrDefault(cu => cu.IsDefault).Customer.Id))
                .ForMember(d => d.DefaultCustomerName, opt => opt.MapFrom(x => x.User.CustomerUsers.FirstOrDefault(cu => cu.IsDefault).Customer.Name));
            Mapper.CreateMap<UserAliasDto, ClientUserAlias>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.NewGuid()))
                .ForMember(dest => dest.Client, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<IRepository<Client>>().Get(x.ClientId)));
        }
    }
}