using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Customers
{
    public class CustomerMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<Customer, CustomerDto>()
                .AfterMap((s, d) => Mapper.Map(s, d, typeof(Entity), typeof(EntityDto)))
                .ForMember(dest => dest.AccountOwnerName, opt => opt.MapFrom(x => string.Format("{0} {1}", x.AccountOwner.FirstName, x.AccountOwner.LastName)))
                .ForMember(dest => dest.CreateSourceType, opt => opt.MapFrom(x => x.CreateSource.CreateSourceType))
                .ForMember(dest => dest.Industries, opt => opt.MapFrom(x => x.Industries.Select(cind => cind.IndustryId)));

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .ForMember(dest => dest.CommercialState, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<IValueEntityRepository<CommercialState>>().Get(x.CommercialStateId)))
                //.ForMember(dest => dest.CreateSource, opt => opt.MapFrom(x => 
                //    x.CreateSourceId != null 
                //        ? new HashSet<CreateSource>(x.CreateSourceId.Select(id => ServiceLocator.Current.GetInstance<IValueEntityRepository<CreateSource>>().Get(id))) 
                //        : Enumerable.Empty<CreateSource>()))
                .ForMember(dest => dest.CreateSource, opt => opt.Ignore())
                //.ForMember(dest => dest.CreateSource, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<IValueEntityRepository<CreateSource>>().Get(x.CreateSourceId)))
                .ForMember(dest => dest.Industries, opt => opt.MapFrom(c => c.Industries != null 
                    ? new HashSet<CustomerIndustry>(c.Industries.Select(id => new CustomerIndustry (ServiceLocator.Current.GetInstance<IRepository<Customer>>().Get(c.Id), id)))
                    : Enumerable.Empty<CustomerIndustry>()))
                .ForMember(dest => dest.PlatformStatus, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<IValueEntityRepository<PlatformStatus>>().Get(x.PlatformStatusId)))
                .ForMember(dest => dest.Billing, opt => opt.MapFrom(x => Mapper.Map<CustomerDto, Billing>(x)))
                .ForMember(dest => dest.ContactDetail, opt => opt.MapFrom(x => Mapper.Map<CustomerDto, ContactDetail>(x)))
                .ForMember(dest => dest.Clients, opt => opt.MapFrom(x =>
                    x.ClientIds != null
                        ? new HashSet<Client>(x.ClientIds.Select(id => ServiceLocator.Current.GetInstance<INamedEntityRepository<Client>>().Get(id)))
                        : Enumerable.Empty<Client>()))
                .ForMember(dest => dest.Contracts, opt => opt.MapFrom(x =>
                    x.ContractIds != null
                        ? new HashSet<Contract>(x.ContractIds.Select(id => ServiceLocator.Current.GetInstance<INamedEntityRepository<Contract>>().Get(id)))
                        : Enumerable.Empty<Contract>()))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(x =>
                    x.UserIds != null
                        ? new HashSet<User>(x.UserIds.Select(id => ServiceLocator.Current.GetInstance<IRepository<User>>().Get(id)))
                        : Enumerable.Empty<User>()));
        }
    }
}