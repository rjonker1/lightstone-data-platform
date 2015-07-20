using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.Domain.Entities.Industries.Read;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.Industries
{
    public class IndustryMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IIndustry, IndustryDto>();
            Mapper.CreateMap<IndustryDto, IIndustry>();

            Mapper.CreateMap<DataProviderFieldItemDto, IEnumerable<IIndustry>>()
                .ConvertUsing<ITypeConverter<DataProviderFieldItemDto, IEnumerable<IIndustry>>>();

            Mapper.CreateMap<IDataField, IEnumerable<IndustryDto>>()
                .ConvertUsing<ITypeConverter<IDataField, IEnumerable<IndustryDto>>>();

            Mapper.CreateMap<PackageDto, IEnumerable<IIndustry>>()
                .ConvertUsing(Mapper.Map<PackageDto, IEnumerable<Industry>>);
            Mapper.CreateMap<PackageDto, IEnumerable<Industry>>()
                .ConvertUsing<ITypeConverter<PackageDto, IEnumerable<Industry>>>();

            Mapper.CreateMap<IPackage, IEnumerable<IndustryDto>>()
                .ConvertUsing<ITypeConverter<IPackage, IEnumerable<IndustryDto>>>();
        }
    }
}