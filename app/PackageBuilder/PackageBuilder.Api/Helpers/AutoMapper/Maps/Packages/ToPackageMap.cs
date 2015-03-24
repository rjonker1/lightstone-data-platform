using System;
using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Packages.Write;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.Packages
{
    public class ToPackageMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<PackageDto, Package>()
                .ForMember(d => d.State, opt => opt.MapFrom(x => Mapper.Map<Guid, State>(x.State.Id)))
                .ForMember(d => d.DataProviders, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>(x.DataProviders)));
        }
    }
}