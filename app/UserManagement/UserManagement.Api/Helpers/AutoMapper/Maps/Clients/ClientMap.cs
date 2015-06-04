using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using UserManagement.Domain.Core.Repositories;
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

            Mapper.CreateMap<Client, ClientDto>()
                .ForMember(dest => dest.Industries, opt => opt.MapFrom(x => x.Industries.Select(cind => cind.IndustryId)));
            //    .ForMember(dest => dest.Contracts, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>(x.Contracts)));

            Mapper.CreateMap<ClientDto, Client>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .ForMember(dest => dest.Industries, opt => opt.MapFrom(c => new HashSet<ClientIndustry>(
                    c.Industries.Select(id => new ClientIndustry { Client = ServiceLocator.Current.GetInstance<IRepository<Client>>().Get(c.Id), IndustryId = id }))))
				.ForMember(dest => dest.CommercialState, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<IValueEntityRepository<CommercialState>>().Get(x.CommercialStateId)))
                //.ForMember(dest => dest.Contracts, opt => opt.MapFrom(x => x.ContractIds != null ? new HashSet<Contract>(x.ContractIds.Select(id => (Contract)Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(id, typeof(Contract))))) : Enumerable.Empty<Contract>()))
                .ForMember(dest => dest.Billing, opt => opt.MapFrom(x => Mapper.Map<ClientDto, Billing>(x)))
                .ForMember(dest => dest.ContactDetail, opt => opt.MapFrom(x => Mapper.Map<ClientDto, ContactDetail>(x)))
                .ForMember(dest => dest.ClientUsers, opt => opt.Ignore());
        }
    }
}