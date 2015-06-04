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
            Mapper.CreateMap<DataProviderDto, DataProvider>()
                .ForMember(d => d.RequestFields, opt => opt.MapFrom(x => x.DataFields == null ? Enumerable.Empty<DataField>() : Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataField>>(x.RequestFields)))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => x.DataFields == null ? Enumerable.Empty<DataField>() : Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataField>>(x.DataFields)));

            Mapper.CreateMap<IDataProviderOverride, DataProvider>()
                .ConvertUsing<ITypeConverter<IDataProviderOverride, DataProvider>>();
        }
    }
}