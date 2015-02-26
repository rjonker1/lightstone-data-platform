using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.NamedEntities
{
    public class NamedEntityMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<NamedEntity, NamedEntityDto>();
            Mapper.CreateMap<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<NamedEntity, NamedEntityDto>));

            Mapper.CreateMap<NamedEntityDto, NamedEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .Include<NamedEntityDto, PaymentType>()
                .Include<NamedEntityDto, PlatformStatus>()
                .Include<NamedEntityDto, CreateSource>()
                .Include<NamedEntityDto, CommercialState>()
                .Include<NamedEntityDto, ContractType>()
                .Include<NamedEntityDto, EscalationType>()
                .Include<NamedEntityDto, ContractDuration>()
                .Include<NamedEntityDto, Province>()
                .Include<NamedEntityDto, UserType>()
                .Include<NamedEntityDto, Role>();

            Mapper.CreateMap<NamedEntityDto, PaymentType>();
            Mapper.CreateMap<NamedEntityDto, PlatformStatus>();
            Mapper.CreateMap<NamedEntityDto, CreateSource>();
            Mapper.CreateMap<NamedEntityDto, CommercialState>();
            Mapper.CreateMap<NamedEntityDto, ContractType>();
            Mapper.CreateMap<NamedEntityDto, EscalationType>();
            Mapper.CreateMap<NamedEntityDto, ContractDuration>();
            Mapper.CreateMap<NamedEntityDto, Province>();
            Mapper.CreateMap<NamedEntityDto, UserType>();
            Mapper.CreateMap<NamedEntityDto, Role>();
        }
    }
}