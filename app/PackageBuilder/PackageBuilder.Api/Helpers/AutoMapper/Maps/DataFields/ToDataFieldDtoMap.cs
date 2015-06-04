using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataFields
{
    public class ToDataFieldDtoMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<DataField, DataProviderFieldItemDto>()
                .ForMember(d => d.IsSelected, opt => opt.MapFrom(x => x.IsSelected))
                .ForMember(d => d.CostOfSale, opt => opt.MapFrom(x => x.CostOfSale))
                .ForMember(d => d.Industries, opt => opt.MapFrom(x => Mapper.Map<IDataField, IEnumerable<IndustryDto>>(x)));
        }
    }
}