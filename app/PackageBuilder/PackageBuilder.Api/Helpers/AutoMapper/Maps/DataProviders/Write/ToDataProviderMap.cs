using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Write
{
    public class ToDataProviderMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>()
                .ConvertUsing(s => s != null ? s.Select(Mapper.Map<DataProviderDto, DataProvider>).ToList() : Enumerable.Empty<DataProvider>());
            Mapper.CreateMap<DataProviderDto, DataProvider>()
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => x.DataFields == null ? Enumerable.Empty<DataField>() : Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataField>>(x.DataFields)));

            Mapper.CreateMap<IEnumerable<IDataProviderOverride>, IEnumerable<DataProvider>>()
               .ConvertUsing(s => s != null ? s.Select(Mapper.Map<IDataProviderOverride, DataProvider>) : Enumerable.Empty<DataProvider>());
            Mapper.CreateMap<IDataProviderOverride, DataProvider>()
                .ConvertUsing<ITypeConverter<IDataProviderOverride, DataProvider>>();
        }
    }
}