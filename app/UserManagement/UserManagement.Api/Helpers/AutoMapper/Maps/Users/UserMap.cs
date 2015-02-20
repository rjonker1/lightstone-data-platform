﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Users
{
    public class UserMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<User>, IEnumerable<UserDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<User, UserDto>));

            Mapper.CreateMap<User, UserDto>()
                .ForMember(dest => dest.RoleIds, opt => opt.MapFrom(x => x.Roles.Select(y => y.Id)))
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>(x.Customers)))
                .ForMember(dest => dest.ClientUsers, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<ClientUser>, IEnumerable<ClientUserDto>>(x.ClientUsers)));

            Mapper.CreateMap<UserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(x => Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(x.UserTypeId, typeof (UserType)))))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(x => x.RoleIds != null ? new HashSet<Role>(x.RoleIds.Select(id => (Role)Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(id, typeof(Role))))) : Enumerable.Empty<Role>()))
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(x => x.CustomerIds != null ? new HashSet<Customer>(x.CustomerIds.Select(id => (Customer)Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(id, typeof(Customer))))) : Enumerable.Empty<Customer>()))
                .ForMember(dest => dest.ClientUsers, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<ClientUserDto>, IEnumerable<ClientUser>>(x.ClientUsers)))
                .AfterMap((src, dest) =>
                {
                    foreach (var clientuser in dest.ClientUsers)
                        clientuser.LinkUser(dest);
                });
            //.ForMember(dest => dest.Roles, opt => opt.MapFrom(x => Mapper.Map<Tuple<IEnumerable<Guid>, Type>, HashSet<Role>>(new Tuple<IEnumerable<Guid>, Type>(x.RoleIds, typeof(Role)))));
        }
    }
}