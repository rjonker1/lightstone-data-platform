using System;
using System.Collections.Generic;
using System.Web.UI;
using AutoMapper;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
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
                .ForMember(d => d.DataProviders, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<IDataProvider>, IEnumerable<DataProviderDto>>(x.DataProviders)))
                .ForMember(d => d.State, opt => opt.MapFrom(src => src.State.Alias));
                //.ForMember(d => d.State, opt => opt.MapFrom(x => Mapper.Map<StateName, State>((StateName)Enum.Parse(typeof(StateName), x.State.Alias, true))));
        }
    }
}