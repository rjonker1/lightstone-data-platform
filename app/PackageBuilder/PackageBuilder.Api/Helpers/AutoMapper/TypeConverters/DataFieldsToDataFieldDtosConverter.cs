using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class DataFieldsToDataFieldDtosConverter : TypeConverter<IEnumerable<IDataField>, IEnumerable<DataProviderFieldItemDto>>
    {
        protected override IEnumerable<DataProviderFieldItemDto> ConvertCore(IEnumerable<IDataField> source)
        {
            return source == null ? Enumerable.Empty<DataProviderFieldItemDto>() : source.Select(Mapper.Map<IDataField, DataProviderFieldItemDto>).ToList();
        }
    }
}