﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Customers
{
    public class CustomerMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<Customer>, IEnumerable<CustomerDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<Customer, CustomerDto>));
            Mapper.CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.CreateSourceIds, opt => opt.MapFrom(x => x.CreateSources.Select(y => y.Id)));
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .ForMember(dest => dest.CommercialState, opt => opt.MapFrom(x => Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(x.CommercialStateId, typeof(CommercialState)))))
                .ForMember(dest => dest.CreateSources, opt => opt.MapFrom(x => x.CreateSourceIds != null ? new HashSet<CreateSource>(x.CreateSourceIds.Select(id => (CreateSource)Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(id, typeof(CreateSource))))) : Enumerable.Empty<CreateSource>()))
                .ForMember(dest => dest.PlatformStatus, opt => opt.MapFrom(x => Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(x.PlatformStatusId, typeof(PlatformStatus)))))
                .ForMember(dest => dest.Billing, opt => opt.MapFrom(x => Mapper.Map<CustomerDto, Billing>(x)))
                .ForMember(dest => dest.ContactDetail, opt => opt.MapFrom(x => Mapper.Map<CustomerDto, ContactDetail>(x)));
        }
    }
}