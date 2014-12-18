using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders
{
    public class ToDataProviderOverrideMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<DataProviderDto>, IEnumerable<DataProviderOverride>>()
                .ConvertUsing(s => s.Select(Mapper.Map<DataProviderDto, DataProviderOverride>));
            Mapper.CreateMap<DataProviderDto, DataProviderOverride>()
                .ForMember(d => d.DataFieldOverrides, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataFieldOverride>>(x.DataFields)));
        }
    }
}