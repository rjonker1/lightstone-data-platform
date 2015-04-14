using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Helpers.Extensions;
using Microsoft.Practices.ServiceLocation;
using UserManagement.Domain.Core.Repositories;
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
                .ForMember(dest => dest.CustomerAccountNumber, opt => opt.MapFrom(x => "{0}{1}".FormatWith(x.Name.Substring(0, 3), x.CustomerAccountNumber.Id.ToString().PadLeft(5, '0'))))
                .ForMember(dest => dest.CreateSourceIds, opt => opt.MapFrom(x => x.CreateSources.Select(y => y.Id)));

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .ForMember(dest => dest.CommercialState, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<IValueEntityRepository<CommercialState>>().Get(x.CommercialStateId)))
                .ForMember(dest => dest.CreateSources, opt => opt.MapFrom(x => 
                    x.CreateSourceIds != null 
                        ? new HashSet<CreateSource>(x.CreateSourceIds.Select(id => ServiceLocator.Current.GetInstance<IValueEntityRepository<CreateSource>>().Get(id))) 
                        : Enumerable.Empty<CreateSource>()))
                .ForMember(dest => dest.PlatformStatus, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<IValueEntityRepository<PlatformStatus>>().Get(x.PlatformStatusId)))
                .ForMember(dest => dest.Billing, opt => opt.MapFrom(x => Mapper.Map<CustomerDto, Billing>(x)))
                .ForMember(dest => dest.ContactDetail, opt => opt.MapFrom(x => Mapper.Map<CustomerDto, ContactDetail>(x)));
        }
    }
}