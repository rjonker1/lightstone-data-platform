using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Contracts
{
    public class ContractMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<Contract, ContractDto>()
                .AfterMap((s, d) => Mapper.Map(s, d, typeof(Entity), typeof(EntityDto)))
                .ForMember(dest => dest.Clients, opt => opt.MapFrom(x => 
                    x.Clients != null && x.Clients.Any() 
                        ? Mapper.Map<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>(x.Clients) 
                        : Enumerable.Empty<NamedEntityDto>()))
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(x => 
                    x.Customers != null && x.Customers.Any() 
                        ? Mapper.Map<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>(x.Customers) 
                        : Enumerable.Empty<NamedEntityDto>()))
                .ForMember(dest => dest.Packages, opt => opt.MapFrom(x => 
                    x.Packages != null && x.Packages.Any() 
                        ? x.Packages.Select(p => new KeyValuePair<Guid, string>(p.PackageId, p.Name)) 
                        : Enumerable.Empty<KeyValuePair<Guid, string>>()));

            Mapper.CreateMap<IEnumerable<Contract>, IEnumerable<ContractDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<Contract, ContractDto>));

            Mapper.CreateMap<ContractDto, Contract>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
               .ForMember(dest => dest.Created, opt => opt.UseDestinationValue())
               //.ForMember(dest => dest.ContractPackages, opt => opt.MapFrom(x => x.PackageIds.Select(id => new ContractPackage(id))))
               .ForMember(dest => dest.Packages, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<string>, IEnumerable<Package>>(x.PackageIdNames)))
               .ForMember(dest => dest.ContractType, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<IValueEntityRepository<ContractType>>().Get(x.ContractTypeId)))
               .ForMember(dest => dest.Clients, opt => opt.MapFrom(x => 
                   x.ClientIds != null 
                        ? new HashSet<Client>(x.ClientIds.Select(id => ServiceLocator.Current.GetInstance<INamedEntityRepository<Client>>().Get(id))) 
                        : Enumerable.Empty<Client>()))
               .ForMember(dest => dest.Customers, opt => opt.MapFrom(x => 
                   x.CustomerIds != null 
                        ? new HashSet<Customer>(x.CustomerIds.Select(id => ServiceLocator.Current.GetInstance<INamedEntityRepository<Customer>>().Get(id))) 
                        : Enumerable.Empty<Customer>()))
               //.ForMember(dest => dest.ContractBundle, opt => opt.MapFrom(x => new ContractBundle{Id = x.ContractBundleId}))
               .AfterMap((src, dest) =>
               {
                   dest.Created = dest.Created ?? DateTime.UtcNow;
               });
        }
    }
}