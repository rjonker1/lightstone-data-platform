using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

            Mapper.CreateMap<IEnumerable<IDataProviderOverride>, IEnumerable<IDataProvider>>()
               .ConvertUsing(s => s.Select(Mapper.Map<IDataProviderOverride, IDataProvider>));
            Mapper.CreateMap<IDataProviderOverride, IDataProvider>()
                .ConvertUsing<ITypeConverter<IDataProviderOverride, IDataProvider>>();
        }
    }
}