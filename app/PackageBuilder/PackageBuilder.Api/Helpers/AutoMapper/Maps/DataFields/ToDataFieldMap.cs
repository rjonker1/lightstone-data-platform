using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataFields
{
    public class ToDataFieldMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>()
                .ConvertUsing<ITypeConverter<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>>();
            Mapper.CreateMap<DataProviderFieldItemDto, IDataField>()
                .ConvertUsing<ITypeConverter<DataProviderFieldItemDto, IDataField>>();
        }
    }
}