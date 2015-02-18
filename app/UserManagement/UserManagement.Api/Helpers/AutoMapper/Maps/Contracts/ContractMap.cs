using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Contracts
{
    public class ContractMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<Contract, ContractDto>()
                .ForMember(dest => dest.Clients, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>(x.Clients)))
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>(x.Customers)));

            Mapper.CreateMap<IEnumerable<Contract>, IEnumerable<ContractDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<Contract, ContractDto>));

            Mapper.CreateMap<ContractDto, Contract>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
               .ForMember(dest => dest.Clients, opt => opt.MapFrom(x => new HashSet<Client>(x.ClientIds.Select(id => (Client)Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(id, typeof(Client)))))))
               .ForMember(dest => dest.Customers, opt => opt.MapFrom(x => new HashSet<Customer>(x.CustomerIds.Select(id => (Customer)Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(id, typeof(Customer)))))))
               .ForMember(dest => dest.ContractType, opt => opt.MapFrom(x => Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(x.ContractTypeId, typeof(ContractType)))))
               .ForMember(dest => dest.EscalationType, opt => opt.MapFrom(x => Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(x.EscalationTypeId, typeof(EscalationType)))))
               .ForMember(dest => dest.ContractDuration, opt => opt.MapFrom(x => Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(x.ContractDurationId, typeof(ContractDuration)))));
        }
    }
}