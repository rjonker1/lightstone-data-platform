using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Dtos.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.WriteModels
{
    public class ToDataProviderMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>()
                .ConvertUsing(x => x.Select(Mapper.Map<DataProviderDto, IDataProvider>).ToList());
            Mapper.CreateMap<DataProviderDto, IDataProvider>()
                .ConvertUsing<ITypeConverter<DataProviderDto, IDataProvider>>();

            Mapper.CreateMap<IEnumerable<DataProviderOverride>, IEnumerable<IDataProvider>>()
               .ConvertUsing(s => s.Select(Mapper.Map<DataProviderOverride, IDataProvider>));
            Mapper.CreateMap<DataProviderOverride, IDataProvider>()
                .ConvertUsing<ITypeConverter<DataProviderOverride, IDataProvider>>();
        }
    }
}