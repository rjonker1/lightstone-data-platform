using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UserManagement.Api.Modules;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.MetaDetail
{
    public class MetaDetailMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<User, MetaDetailDto>()
                .ForMember(dest => dest.Contracts, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<Contract>, IEnumerable<MetaContractDto>>(x.Contracts)));

            Mapper.CreateMap<Contract, MetaContractDto>()
                .ForMember(dest => dest.Packages, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<Package>, IEnumerable<MetaPackageDto>>(x.Packages)));

            Mapper.CreateMap<Package, MetaPackageDto>()
                .ForMember(dest => dest.PackageId, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.PackageName, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.PackageEventType, opt => opt.MapFrom(x => "Test"));
        }
    }
}