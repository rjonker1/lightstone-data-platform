using System;
using AutoMapper;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Clients
{
    public class ClientMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<Client, ClientDto>();
            Mapper.CreateMap<ClientDto, Client>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .ForMember(dest => dest.ContactDetail, opt => opt.Ignore())
                //.ForMember(dest => dest.Packages, opt => opt.Ignore())
                .ForMember(dest => dest.ClientUsers, opt => opt.Ignore());
        }
    }
}