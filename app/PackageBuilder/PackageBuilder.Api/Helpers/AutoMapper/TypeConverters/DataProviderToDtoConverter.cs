using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class DataFieldDtosToDataFieldsConverter : TypeConverter<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>
    {
        protected override IEnumerable<IDataField> ConvertCore(IEnumerable<DataProviderFieldItemDto> source)
        {
            return source == null ? Enumerable.Empty<IDataField>() : source.Select(Mapper.Map<DataProviderFieldItemDto, IDataField>).ToList();
        }
    }
}