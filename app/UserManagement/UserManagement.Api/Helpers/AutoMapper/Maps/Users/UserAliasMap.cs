using System;
using AutoMapper;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Users
{
    public class UserAliasMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<UserAliasDto, UserAlias>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.NewGuid()));
        }
    }
}