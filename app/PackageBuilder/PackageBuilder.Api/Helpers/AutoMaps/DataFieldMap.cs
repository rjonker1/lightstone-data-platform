using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMaps
{
    public class DataFieldMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<DataProviderFieldItemDto, IDataField>()
                .ConvertUsing(x => new DataField(x.Name, null));
            Mapper.CreateMap<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>()
                .ConvertUsing(x => x.Select(Mapper.Map<DataProviderFieldItemDto, IDataField>));
            Mapper.CreateMap<DataProviderDto, DataProvider>()
                .ConvertUsing(x => new DataProvider(x.Id, x.Name, Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>(x.DataFields)));
                //.ConvertUsing<ITypeConverter<DataProviderDto, DataProvider>>();
        }
    }
}