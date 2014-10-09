using System.Linq;
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
            Mapper.CreateMap<DataProviderDto, DataProvider>()
                .ConvertUsing(x => new DataProvider(x.Id, x.Name, x.DataFields.Select(Mapper.Map<DataProviderFieldItemDto, IDataField>)));
            //.ConvertUsing<ITypeConverter<DataProviderDto, DataProvider>>();
        }
    }
}