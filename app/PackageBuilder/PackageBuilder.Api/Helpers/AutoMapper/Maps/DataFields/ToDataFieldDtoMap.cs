using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Dtos.WriteModels;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataFields
{
    public class ToDataFieldDtoMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<IDataField>, IEnumerable<DataProviderFieldItemDto>>()
                .ConvertUsing<ITypeConverter<IEnumerable<IDataField>, IEnumerable<DataProviderFieldItemDto>>>();
            Mapper.CreateMap<IDataField, DataProviderFieldItemDto>()
                .ForMember(d => d.Price, opt => opt.MapFrom(x => x.CostOfSale))
                .ForMember(d => d.IsSelected, opt => opt.MapFrom(x => x.IsSelected))
                .ForMember(d => d.Industries, opt => opt.MapFrom(x => Mapper.Map<IDataField, IEnumerable<Industry>>(x)));
        }
    }
}