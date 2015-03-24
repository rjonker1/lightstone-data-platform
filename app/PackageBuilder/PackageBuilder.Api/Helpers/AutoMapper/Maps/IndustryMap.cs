using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps
{
    public class IndustryMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IDataField, IEnumerable<IIndustry>>()
                .ConvertUsing<ITypeConverter<IDataField, IEnumerable<IIndustry>>>();
        }
    }
}