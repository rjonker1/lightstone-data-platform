using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Read;
using PackageBuilder.Domain.Entities.DataProviders.Read;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Read
{
    public class ToDataProviderDtoMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<DataProvider>, IEnumerable<DataProviderDto>>()
                .ConvertUsing(s => s != null ? s.Select(Mapper.Map<DataProvider, DataProviderDto>) : Enumerable.Empty<DataProviderDto>());
            Mapper.CreateMap<DataProvider, DataProviderDto>();
        }
    }
}