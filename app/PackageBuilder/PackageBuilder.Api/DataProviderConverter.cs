using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.Api
{
    public class DataProviderConverter : TypeConverter<DataProviderDto, DataProvider>
    {
        protected override DataProvider ConvertCore(DataProviderDto source)
        {
            return new DataProvider(source.Id, source.Name, source.DataFields.Select(Mapper.Map<DataProviderFieldItemDto, IDataField>));
        }
    }
}