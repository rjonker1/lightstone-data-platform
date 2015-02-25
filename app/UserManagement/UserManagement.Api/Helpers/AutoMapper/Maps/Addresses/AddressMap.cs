using System;
using AutoMapper;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Addresses
{
    public class AddressMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<AddressDto, Address>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .ForMember(dest => dest.Province, opt => opt.MapFrom(x => Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(x.ProvinceId, typeof(Province)))));
        }
    }
}