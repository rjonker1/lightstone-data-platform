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
                .Include<PaymentType, ValueEntityDto>()
                .Include<PlatformStatus, PlatformStatusDto>()
                .Include<CreateSource, CreateSourceDto>()
                .Include<CommercialState, ValueEntityDto>()
                .Include<ContractType, ValueEntityDto>()
                .Include<EscalationType, ValueEntityDto>()
                .Include<ContractDuration, ValueEntityDto>()
                .Include<Province, ValueEntityDto>()
                .Include<Role, ValueEntityDto>();
            Mapper.CreateMap<PaymentType, ValueEntityDto>();
            Mapper.CreateMap<PlatformStatus, ValueEntityDto>();
            Mapper.CreateMap<CreateSource, ValueEntityDto>();
            Mapper.CreateMap<CommercialState, ValueEntityDto>();
            Mapper.CreateMap<ContractType, ValueEntityDto>();
            Mapper.CreateMap<EscalationType, ValueEntityDto>();
            Mapper.CreateMap<ContractDuration, ValueEntityDto>();
            Mapper.CreateMap<Province, ValueEntityDto>();
            Mapper.CreateMap<Role, ValueEntityDto>();

            Mapper.CreateMap<ValueEntityDto, ValueEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .Include<ValueEntityDto, PaymentType>()
                .Include<ValueEntityDto, PlatformStatus>()
                .Include<ValueEntityDto, CreateSource>()
                .Include<ValueEntityDto, CommercialState>()
                .Include<ValueEntityDto, ContractType>()
                .Include<ValueEntityDto, EscalationType>()
                .Include<ValueEntityDto, ContractDuration>()
                .Include<ValueEntityDto, Province>()
                .Include<ValueEntityDto, Role>();
            Mapper.CreateMap<ValueEntityDto, PaymentType>();
            Mapper.CreateMap<ValueEntityDto, PlatformStatus>();
            Mapper.CreateMap<ValueEntityDto, CreateSource>();
            Mapper.CreateMap<ValueEntityDto, CommercialState>();
            Mapper.CreateMap<ValueEntityDto, ContractType>();
            Mapper.CreateMap<ValueEntityDto, EscalationType>();
            Mapper.CreateMap<ValueEntityDto, ContractDuration>();
            Mapper.CreateMap<ValueEntityDto, Province>();
            Mapper.CreateMap<ValueEntityDto, Role>();
        }
    }
}