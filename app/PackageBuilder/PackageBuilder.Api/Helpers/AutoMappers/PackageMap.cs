using System;
using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Entities.Enums;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMappers
{
    public class PackageMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<PackageDto, IPackage>()
                .ForMember(d => d.DataProviders, opt => opt.MapFrom( x => Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>(x.DataProviders)));
            Mapper.CreateMap<IPackage, PackageDto>()
                .ForMember(d => d.DataProviders, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<IDataProvider>, IEnumerable<DataProviderDto>>(x.DataProviders)));

            //.ConvertUsing(x => new Package(x.Id, x.Name, (StateName)Enum.Parse(typeof(StateName), x.Name, true), 
            //    Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>(x.DataProviders)));
        }
    }
}