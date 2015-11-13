using System;
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
            //Mapper.CreateMap<NamedEntity, NamedEntityDto>();

            Mapper.CreateMap<NamedEntity, NamedEntityDto>()
                .ForMember(x => x.AssemblyQualifiedName, opt => opt.MapFrom(x => x.GetType().AssemblyQualifiedName))
                .Include<Client, NamedEntityDto>()
                .Include<Contract, NamedEntityDto>()
                .Include<ContractBundle, NamedEntityDto>()
                .Include<Customer, NamedEntityDto>()
                .Include<Package, NamedEntityDto>();
            Mapper.CreateMap<Client, NamedEntityDto>();
            Mapper.CreateMap<Contract, NamedEntityDto>();
            Mapper.CreateMap<ContractBundle, NamedEntityDto>();
            Mapper.CreateMap<Customer, NamedEntityDto>();
            Mapper.CreateMap<Package, NamedEntityDto>();

            Mapper.CreateMap<NamedEntityDto, NamedEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id));
        }
    }
}