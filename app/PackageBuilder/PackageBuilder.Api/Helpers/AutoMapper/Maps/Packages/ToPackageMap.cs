using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.Domain.Entities.Packages.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.Packages
{
    public class ToPackageMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<PackageDto, IPackage>()
                .ForMember(d => d.DataProviders, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>(x.DataProviders)));

            //todo: replace AutoMapper destination objects with concrete implementation instead of interface
            Mapper.CreateMap<PackageDto, Package>()
                .ForMember(d => d.DataProviders, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>(x.DataProviders)));
        }
    }
}