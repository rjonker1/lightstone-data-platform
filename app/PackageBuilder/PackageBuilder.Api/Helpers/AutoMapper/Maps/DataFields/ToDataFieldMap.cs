using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataFields
{
    public class ToDataFieldMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataField>>()
                .ConvertUsing(s => s == null ? Enumerable.Empty<DataField>() : s.Select(Mapper.Map<DataProviderFieldItemDto, DataField>).ToList());
            Mapper.CreateMap<DataProviderFieldItemDto, DataField>()
                    .ForMember(d => d.Type, opt => opt.ResolveUsing(x => Mapper.Map<string, Type>(x.Type))) 
                    .ForMember(d => d.DataFields, opt => opt.MapFrom(x => x.DataFields == null ? Enumerable.Empty<DataField>() : Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataField>>(x.DataFields.ToList())));

            Mapper.CreateMap<string, Type>()
                .ConstructUsing(s =>
                {
                    return Type.GetType(s);
                });
        }
    }
}