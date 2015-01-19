using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos.ReadModels;
using DataProvider = PackageBuilder.Domain.Entities.DataProviders.ReadModels.DataProvider;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.ReadModels
{
    public class ToDataProviderDtoMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<DataProvider>, IEnumerable<DataProviderDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<DataProvider, DataProviderDto>));
            Mapper.CreateMap<DataProvider, DataProviderDto>();
        }
    }
}