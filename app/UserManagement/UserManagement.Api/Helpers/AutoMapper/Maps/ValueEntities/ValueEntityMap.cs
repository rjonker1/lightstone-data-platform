using System;
using AutoMapper;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.ValueEntities
{
    public class ValueEntityMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<ValueEntity, ValueEntityDto>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(x => x.AssemblyQualifiedName, opt => opt.MapFrom(x => x.GetType().AssemblyQualifiedName))
                .Include<CommercialState, ValueEntityDto>()
                .Include<ContractType, ValueEntityDto>()
                .Include<Country, ValueEntityDto>()
                .Include<Province, ValueEntityDto>()
                .Include<Role, ValueEntityDto>();
            Mapper.CreateMap<CommercialState, ValueEntityDto>();
            Mapper.CreateMap<ContractType, ValueEntityDto>();
            Mapper.CreateMap<Country, ValueEntityDto>();
            Mapper.CreateMap<Province, ValueEntityDto>();
            Mapper.CreateMap<Role, ValueEntityDto>();

            Mapper.CreateMap<ValueEntityDto, ValueEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .Include<ValueEntityDto, CommercialState>()
                .Include<ValueEntityDto, ContractType>()
                .Include<ValueEntityDto, Country>()
                .Include<ValueEntityDto, Province>()
                .Include<ValueEntityDto, Role>();
            Mapper.CreateMap<ValueEntityDto, CommercialState>();
            Mapper.CreateMap<ValueEntityDto, ContractType>();
            Mapper.CreateMap<ValueEntityDto, Country>();
            Mapper.CreateMap<ValueEntityDto, Province>();
            Mapper.CreateMap<ValueEntityDto, Role>();
        }
    }
}