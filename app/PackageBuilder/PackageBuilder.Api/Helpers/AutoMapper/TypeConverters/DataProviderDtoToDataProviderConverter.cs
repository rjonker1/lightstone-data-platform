using System;
using System.Collections.Generic;
using AutoMapper;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class DataProviderDtoToDataProviderConverter : TypeConverter<DataProviderDto, IDataProvider>
    {
        protected override IDataProvider ConvertCore(DataProviderDto source)
        {
            return new DataProvider(
                source.Id,
                (DataProviderName) Enum.Parse(typeof (DataProviderName), source.Name, true), 
                source.Description,
                source.CostOfSale, 
                null, 
                source.FieldLevelCostPriceOverride, 
                source.Owner, 
                source.CreatedDate,
                source.EditedDate,
                Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>(source.DataFields)
                );
        }
    }
}