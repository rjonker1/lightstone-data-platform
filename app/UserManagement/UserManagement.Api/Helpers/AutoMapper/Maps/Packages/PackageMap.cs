using System;
using System.Collections.Generic;
using AutoMapper;
using UserManagement.Api.Helpers.AutoMapper.Maps;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

public class PackageMap : ICreateAutoMapperMaps
{
    public void CreateMaps()
    {
        //Mapper.CreateMap<PackageBuilder.Domain.Entities.Packages.ReadModels.Package, PackageDto>();
        //Mapper.CreateMap<IEnumerable<PackageBuilder.Domain.Entities.Packages.ReadModels.Package>, IEnumerable<PackageDto>>()
        //    .ConvertUsing(s => s.Select(Mapper.Map<PackageBuilder.Domain.Entities.Packages.ReadModels.Package, PackageDto>));

        Mapper.CreateMap<PackageDto, Package>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id));

        Mapper.CreateMap<IEnumerable<string>, IEnumerable<Package>>()
            .ConvertUsing<ITypeConverter<IEnumerable<string>, IEnumerable<Package>>>();
    }
}
