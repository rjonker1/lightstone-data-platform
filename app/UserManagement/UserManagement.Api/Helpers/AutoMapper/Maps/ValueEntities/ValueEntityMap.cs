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
            Mapper.CreateMap<ValueEntityDto, PaymentType>();
            Mapper.CreateMap<ValueEntityDto, PlatformStatus>();
            Mapper.CreateMap<ValueEntityDto, CreateSource>();
            Mapper.CreateMap<ValueEntityDto, CommercialState>();
            Mapper.CreateMap<ValueEntityDto, ContractType>();
            Mapper.CreateMap<ValueEntityDto, EscalationType>();
            Mapper.CreateMap<ValueEntityDto, ContractDuration>();
            Mapper.CreateMap<ValueEntityDto, Province>();
            Mapper.CreateMap<ValueEntityDto, UserType>();
            Mapper.CreateMap<ValueEntityDto, Role>();
        }
    }
}