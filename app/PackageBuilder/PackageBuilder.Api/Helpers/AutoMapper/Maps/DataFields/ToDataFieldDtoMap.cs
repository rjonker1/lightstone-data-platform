using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.Industries.Read;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataFields
{
    public class ToDataFieldDtoMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<DataField>, IEnumerable<DataProviderFieldItemDto>>()
                .ConvertUsing(s => s == null ? Enumerable.Empty<DataProviderFieldItemDto>() : s.Select(Mapper.Map<DataField, DataProviderFieldItemDto>).ToList());
            Mapper.CreateMap<DataField, DataProviderFieldItemDto>()
                .ForMember(d => d.Price, opt => opt.MapFrom(x => x.CostOfSale))
                .ForMember(d => d.Industries, opt => opt.MapFrom(x => Mapper.Map<IDataField, IEnumerable<IIndustry>>(x).Cast<Industry>()));
        }
    }
}