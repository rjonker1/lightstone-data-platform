using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Write
{
    public class ToDataProviderOverrideMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<DataProviderDto, DataProviderOverride>()
                .ForMember(d => d.RequestFieldOverrides, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataFieldOverride>>(x.RequestFields)))
                .ForMember(d => d.DataFieldOverrides, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataFieldOverride>>(x.DataFields)));
        }
    }
}