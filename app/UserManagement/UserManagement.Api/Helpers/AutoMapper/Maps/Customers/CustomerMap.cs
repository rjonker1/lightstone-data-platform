using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Enums;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Customers
{
    public class CustomerMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<Customer, CustomerDto>()
                .AfterMap((s, d) =>
                {
                    Mapper.Map(s, d, typeof(Entity), typeof(EntityDto));
                })
                .ForMember(dest => dest.AccountOwnerName, opt => opt.MapFrom(x => x.AccountOwner != null ? x.AccountOwner.FullName : ""))
                .ForMember(dest => dest.Industries, opt => opt.MapFrom(x => x.Industries.Select(cind => cind.IndustryId)));

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .ForMember(dest => dest.Individual, opt => opt.MapFrom(x => Mapper.Map<CustomerDto, Individual>(x)))
                .ForMember(dest => dest.Created, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.CommercialState, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<IRepository<CommercialState>>().Get(x.CommercialStateId)))
                .ForMember(dest => dest.CreateSource, opt => opt.Ignore())
                .ForMember(dest => dest.Industries, opt => opt.MapFrom(c => c.Industries != null
                    ? new HashSet<CustomerIndustry>(c.Industries.Select(id => new CustomerIndustry(ServiceLocator.Current.GetInstance<IRepository<Customer>>().Get(c.Id), id)))
                    : Enumerable.Empty<CustomerIndustry>()))
                .ForMember(dest => dest.Billing, opt => opt.MapFrom(x => Mapper.Map<CustomerDto, Billing>(x)))
                .ForMember(dest => dest.Clients, opt => opt.MapFrom(x =>
                    x.ClientIds != null
                        ? new HashSet<Client>(x.ClientIds.Select(id => ServiceLocator.Current.GetInstance<IRepository<Client>>().Get(id)))
                        : Enumerable.Empty<Client>()))
                .ForMember(dest => dest.Contracts, opt => opt.MapFrom(x =>
                    x.ContractIds != null
                        ? new HashSet<Contract>(x.ContractIds.Select(id => ServiceLocator.Current.GetInstance<IRepository<Contract>>().Get(id)))
                        : Enumerable.Empty<Contract>()))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(x =>
                    x.UserIds != null
                        ? new HashSet<User>(x.UserIds.Select(id => ServiceLocator.Current.GetInstance<IRepository<User>>().Get(id)))
                        : Enumerable.Empty<User>()))
                .AfterMap((src, dest) =>
                {
                    dest.Created = dest.Created ?? DateTime.UtcNow;

                    var physicalDto = new AddressDto
                    {
                        Id = src.PhysicalAddressId,
                        Line1 = src.PhysicalAddressLine1,
                        Line2 = src.PhysicalAddressLine2,
                        Suburb = src.PhysicalAddressSuburb,
                        City = src.PhysicalAddressCity,
                        PostalCode = src.PhysicalAddressPostalCode,
                        ProvinceId = src.PhysicalAddressProvinceId,
                        CountryId = src.PhysicalAddressCountryId
                    };
                    var postalDto = new AddressDto
                    {
                        Id = src.PostalAddressId,
                        Line1 = src.PostalAddressLine1,
                        Line2 = src.PostalAddressLine2,
                        Suburb = src.PostalAddressSuburb,
                        City = src.PostalAddressCity,
                        PostalCode = src.PostalAddressPostalCode,
                        ProvinceId = src.PostalAddressProvinceId,
                        CountryId = src.PostalAddressCountryId
                    };

                    var physicalAddress = Mapper.Map(physicalDto, ServiceLocator.Current.GetInstance<IRepository<Address>>().Get(src.PhysicalAddressId));
                    var postalAddress = Mapper.Map(postalDto, ServiceLocator.Current.GetInstance<IRepository<Address>>().Get(src.PostalAddressId));

                    dest.SetAddress(physicalAddress, AddressType.Physical);
                    dest.SetAddress(postalAddress, AddressType.Postal);
                });
            
            Mapper.CreateMap<CustomerDto, Individual>()
               .ConvertUsing<ITypeConverter<CustomerDto, Individual>>();
        }
    }
}