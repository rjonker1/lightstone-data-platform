using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataFields
{
    public class ToDataFieldMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<DataField, DataField>()
                //.ForMember(d => d.CostOfSale, opt => opt.MapFrom(x => x.CostOfSale))
                .ForMember(d => d.DataFields, opt => opt.Ignore()); // Needs to ignore for amending DP structure functionality
            Mapper.CreateMap<IDataFieldOverride, DataField>()
                //.ForMember(d => d.CostOfSale, opt => opt.UseDestinationValue())
                .ForMember(d => d.Industries, opt => opt.UseDestinationValue());

            Mapper.CreateMap<DataProviderFieldItemDto, IDataField>()
                .ConstructUsing(Mapper.Map<DataProviderFieldItemDto, DataField>);
            Mapper.CreateMap<DataProviderFieldItemDto, DataField>()
                    .ForMember(d => d.Type, opt => opt.ResolveUsing(x => Mapper.Map<string, Type>(x.Type)))
                    //.ForMember(d => d.CostOfSale, opt => opt.UseDestinationValue())
                    .ForMember(d => d.Industries, opt => opt.MapFrom(x => Mapper.Map<DataProviderFieldItemDto, IEnumerable<IIndustry>>(x)))
                    .ForMember(d => d.DataFields, opt => opt.MapFrom(x => x.DataFields == null ? Enumerable.Empty<DataField>() : Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataField>>(x.DataFields.ToList())));

            Mapper.CreateMap<string, Type>()
                .ConstructUsing(s =>
                {
                    return Type.GetType(s);
                });
        }
    }
}