using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataFields
{
    public class ToDataFieldOverrideMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<DataProviderFieldItemDto, DataFieldOverride>()
                .ForMember(d => d.CostOfSale, opt => opt.MapFrom(x => x.Price))
                .ForMember(d => d.IsSelected, opt => opt.MapFrom(x => x.IsSelected))
                .ForMember(d => d.RequestFieldOverrides, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataFieldOverride>>(x.RequestFields)))
                .ForMember(d => d.DataFieldOverrides, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataFieldOverride>>(x.DataFields)));
        }
    }
}