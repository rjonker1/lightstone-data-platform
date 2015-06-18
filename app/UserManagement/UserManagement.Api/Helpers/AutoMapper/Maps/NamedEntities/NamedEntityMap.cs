using System;
using AutoMapper;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Dtos;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.NamedEntities
{
    public class NamedEntityMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<NamedEntity, NamedEntityDto>();

            Mapper.CreateMap<NamedEntityDto, NamedEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id));
        }
    }
}