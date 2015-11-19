using System;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Addresses
{
    public class AddressMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<AddressDto, Address>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .ForMember(dest => dest.Province, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<IRepository<Province>>().Get(x.ProvinceId)))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<IRepository<Country>>().Get(x.CountryId)));
        }
    }
}