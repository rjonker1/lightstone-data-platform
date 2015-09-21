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

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Clients
{
    public class ClientMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<Client, ClientDto>()
                .AfterMap((s, d) => Mapper.Map(s, d, typeof(Entity), typeof(EntityDto)))
                .ForMember(dest => dest.AccountOwnerName, opt => opt.MapFrom(x => x.AccountOwner != null ? string.Format("{0} {1}", x.AccountOwner.FirstName, x.AccountOwner.LastName) : ""))
                .ForMember(dest => dest.Industries, opt => opt.MapFrom(x => x.Industries.Select(cind => cind.IndustryId)))
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>(x.Customers)))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(x => x.Users.Select(r => string.Format("{0} {1}", r.FirstName, r.LastName))));
            //.ForMember(dest => dest.UserAliases, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<Entity>, IEnumerable<EntityDto>>(x.UserAliases)));

            Mapper.CreateMap<ClientDto, Client>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .ForMember(dest => dest.Individual, opt => opt.MapFrom(x => Mapper.Map<ClientDto, Individual>(x)))
                .ForMember(dest => dest.Created, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.Industries, opt => opt.MapFrom(c => c.Industries != null
                    ? new HashSet<ClientIndustry>(c.Industries.Select(id => new ClientIndustry(ServiceLocator.Current.GetInstance<IRepository<Client>>().Get(c.Id), id)))
                    : Enumerable.Empty<ClientIndustry>()))
                .ForMember(dest => dest.CommercialState, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<IValueEntityRepository<CommercialState>>().Get(x.CommercialStateId)))
                //.ForMember(dest => dest.Contracts, opt => opt.MapFrom(x => x.ContractIds != null ? new HashSet<Contract>(x.ContractIds.Select(id => (Contract)Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(id, typeof(Contract))))) : Enumerable.Empty<Contract>()))
                .ForMember(dest => dest.Billing, opt => opt.MapFrom(x => Mapper.Map<ClientDto, Billing>(x)))
                .ForMember(dest => dest.UserAliases, opt => opt.Ignore())
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(x =>
                    x.CustomerIds != null
                        ? new HashSet<Customer>(x.CustomerIds.Select(id => ServiceLocator.Current.GetInstance<INamedEntityRepository<Customer>>().Get(id)))
                        : Enumerable.Empty<Customer>()))
                .ForMember(dest => dest.Contracts, opt => opt.MapFrom(x =>
                    x.ContractIds != null
                        ? new HashSet<Contract>(x.ContractIds.Select(id => ServiceLocator.Current.GetInstance<INamedEntityRepository<Contract>>().Get(id)))
                        : Enumerable.Empty<Contract>()))
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
            //.ForMember(dest => dest.UserAliases, opt => opt.MapFrom(x =>
            //    x.UserIds != null
            //        ? new HashSet<UserAlias>(x.UserIds.Select(id => ServiceLocator.Current.GetInstance<IRepository<UserAlias>>().Get(id)))
            //        : Enumerable.Empty<UserAlias>()));
            //.ForMember(dest => dest.ClientUsers, opt => opt.Ignore());

            Mapper.CreateMap<ClientDto, Individual>()
               .ConvertUsing<ITypeConverter<ClientDto, Individual>>();
        }
    }
}