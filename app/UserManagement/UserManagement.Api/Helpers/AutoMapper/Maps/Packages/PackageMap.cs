using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Packages
{
    public class PackageMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<Package, PackageDto>();
            Mapper.CreateMap<IEnumerable<Package>, IEnumerable<PackageDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<Package, PackageDto>));

            Mapper.CreateMap<PackageDto, Package>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id));
        }
    }
}