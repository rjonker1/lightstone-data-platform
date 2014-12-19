using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class DataFieldDtoToDataFieldConverter : TypeConverter<DataProviderFieldItemDto, IDataField>
    {
        protected override IDataField ConvertCore(DataProviderFieldItemDto source)
        {
            return new DataField(
                source.Name, 
                source.Label, 
                source.Definition, 
                source.Industries,
                System.Convert.ToDouble(source.Price), System.Convert.ToBoolean(source.IsSelected),
                Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>(source.DataFields)
                );
        }
    }
}