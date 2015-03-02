using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Clients
{
    public class ClientMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<Client>, IEnumerable<ClientDto>>()
               .ConvertUsing(s => s.Select(Mapper.Map<Client, ClientDto>));

            Mapper.CreateMap<Client, ClientDto>();
            //    .ForMember(dest => dest.Contracts, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>(x.Contracts)));

            Mapper.CreateMap<ClientDto, Client>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                //.ForMember(dest => dest.Contracts, opt => opt.MapFrom(x => x.ContractIds != null ? new HashSet<Contract>(x.ContractIds.Select(id => (Contract)Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(id, typeof(Contract))))) : Enumerable.Empty<Contract>()))
                .ForMember(dest => dest.ContactDetail, opt => opt.MapFrom(x => Mapper.Map<ClientDto, ContactDetail>(x)))
                .ForMember(dest => dest.ClientUsers, opt => opt.Ignore());
        }
    }
}