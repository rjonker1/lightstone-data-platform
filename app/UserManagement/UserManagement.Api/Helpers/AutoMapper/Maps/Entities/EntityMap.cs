using System;
using AutoMapper;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Dtos;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Entities
{
    public class EntityMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            const string southAfricaStandardTime = "South Africa Standard Time";
            Mapper.CreateMap<Entity, EntityDto>()
                .ForMember(d => d.Created, opt => opt.MapFrom(x => x.Created.HasValue 
                    ? TimeZoneInfo.ConvertTimeFromUtc(x.Created.Value, TimeZoneInfo.FindSystemTimeZoneById(southAfricaStandardTime)) + ""
                    : ""))
                .ForMember(d => d.Modified, opt => opt.MapFrom(x => x.Modified.HasValue 
                    ? TimeZoneInfo.ConvertTimeFromUtc(x.Modified.Value, TimeZoneInfo.FindSystemTimeZoneById(southAfricaStandardTime)) + ""
                    : ""));
        }
    }
}