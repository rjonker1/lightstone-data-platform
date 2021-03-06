﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Users
{
    public class UserMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<User, UserDto>()
                .AfterMap((s, d) => Mapper.Map(s, d, typeof(Entity), typeof(EntityDto)))
                .ForMember(dest => dest.RoleIds, opt => opt.MapFrom(x => x.Roles.Select(y => y.Id)))
                .ForMember(dest => dest.RoleValues, opt => opt.MapFrom(x => x.Roles.Select(r => r.Value)))
                .ForMember(dest => dest.Clients, opt => opt.MapFrom(x => x.Clients.Select(r => r.Name)))
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>(x.Customers)));

            Mapper.CreateMap<UserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .ForMember(dest => dest.Individual, opt => opt.MapFrom(x => Mapper.Map<UserDto, Individual>(x)))
                .ForMember(dest => dest.Created, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(x =>
                    x.RoleIds != null
                        ? new HashSet<Role>(
                            x.RoleIds.Select(
                                id => ServiceLocator.Current.GetInstance<IValueEntityRepository<Role>>().Get(id)))
                        : Enumerable.Empty<Role>()))
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(x =>
                    x.CustomerIds != null
                        ? new HashSet<Customer>(
                            x.CustomerIds.Select(id => ServiceLocator.Current.GetInstance<INamedEntityRepository<Customer>>().Get(id))).ToList()
                        : Enumerable.Empty<Customer>()))
                .AfterMap((src, dest) =>
                {
                    dest.Created = dest.Created ?? DateTime.UtcNow;
                });

            Mapper.CreateMap<UserDto, Individual>()
                .ConvertUsing<ITypeConverter<UserDto, Individual>>();
        }
    }
}