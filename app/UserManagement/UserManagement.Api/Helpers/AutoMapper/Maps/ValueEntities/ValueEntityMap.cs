using System;
using System.Collections.Generic;
using System.Linq;
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
            Mapper.CreateMap<IEnumerable<ValueEntity>, IEnumerable<ValueEntityDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<ValueEntity, ValueEntityDto>));
       
            Mapper.CreateMap<PaymentType, ValueEntityDto>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(x => x.AssemblyQualifiedName, opt => opt.MapFrom(x => x.GetType().AssemblyQualifiedName));
            Mapper.CreateMap<PlatformStatus, ValueEntityDto>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(x => x.AssemblyQualifiedName, opt => opt.MapFrom(x => x.GetType().AssemblyQualifiedName));
            Mapper.CreateMap<CreateSource, ValueEntityDto>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(x => x.AssemblyQualifiedName, opt => opt.MapFrom(x => x.GetType().AssemblyQualifiedName));
            Mapper.CreateMap<CommercialState, ValueEntityDto>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(x => x.AssemblyQualifiedName, opt => opt.MapFrom(x => x.GetType().AssemblyQualifiedName));
            Mapper.CreateMap<ContractType, ValueEntityDto>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(x => x.AssemblyQualifiedName, opt => opt.MapFrom(x => x.GetType().AssemblyQualifiedName));
            Mapper.CreateMap<EscalationType, ValueEntityDto>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(x => x.AssemblyQualifiedName, opt => opt.MapFrom(x => x.GetType().AssemblyQualifiedName));
            Mapper.CreateMap<ContractDuration, ValueEntityDto>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(x => x.AssemblyQualifiedName, opt => opt.MapFrom(x => x.GetType().AssemblyQualifiedName));
            Mapper.CreateMap<Province, ValueEntityDto>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(x => x.AssemblyQualifiedName, opt => opt.MapFrom(x => x.GetType().AssemblyQualifiedName));
            Mapper.CreateMap<UserType, ValueEntityDto>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(x => x.AssemblyQualifiedName, opt => opt.MapFrom(x => x.GetType().AssemblyQualifiedName));
            Mapper.CreateMap<Role, ValueEntityDto>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(x => x.AssemblyQualifiedName, opt => opt.MapFrom(x => x.GetType().AssemblyQualifiedName));

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
                .Include<ValueEntityDto, UserType>()
                .Include<ValueEntityDto, Role>();
            Mapper.CreateMap<ValueEntityDto, PaymentType>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id));
            Mapper.CreateMap<ValueEntityDto, PlatformStatus>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id));
            Mapper.CreateMap<ValueEntityDto, CreateSource>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id));
            Mapper.CreateMap<ValueEntityDto, CommercialState>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id));
            Mapper.CreateMap<ValueEntityDto, ContractType>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id));
            Mapper.CreateMap<ValueEntityDto, EscalationType>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id));
            Mapper.CreateMap<ValueEntityDto, ContractDuration>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id));
            Mapper.CreateMap<ValueEntityDto, Province>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id));
            Mapper.CreateMap<ValueEntityDto, UserType>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id));
            Mapper.CreateMap<ValueEntityDto, Role>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id));
        }
    }
}