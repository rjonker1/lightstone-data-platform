using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMaps
{
    public class DataProviderMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<DataProviderDto, IDataProvider>()
                .ConvertUsing(x => new DataProvider(x.Id, x.Name, Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>(x.DataFields)));

            Mapper.CreateMap<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>()
                .ConvertUsing(x => x.Select(Mapper.Map<DataProviderDto, IDataProvider>));
            //.ConvertUsing<ITypeConverter<DataProviderDto, DataProvider>>();

            //Mapper.CreateMap<IEnumerable<DataProviderDto>, IEnumerable<DataProvider>>()
            //   .ConvertUsing(x => x.Select(Mapper.Map<DataProviderDto, DataProvider>));
        }
    }
}