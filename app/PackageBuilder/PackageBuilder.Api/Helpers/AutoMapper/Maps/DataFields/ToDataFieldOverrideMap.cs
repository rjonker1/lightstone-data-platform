using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataFields
{
    public class ToDataFieldOverrideMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataFieldOverride>>()
                .ConvertUsing(s => s.Select(Mapper.Map<DataProviderFieldItemDto, DataFieldOverride>));
            Mapper.CreateMap<DataProviderFieldItemDto, DataFieldOverride>()
                .ForMember(d => d.CostOfSale, opt => opt.MapFrom(x => x.Price))
                .ForMember(d => d.DataFieldOverrides, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataFieldOverride>>(x.DataFields)));
        }
    }
}