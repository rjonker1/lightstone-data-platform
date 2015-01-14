using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps
{
    public class IndustryMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IDataField, IEnumerable<Industry>>()
                .ConvertUsing<ITypeConverter<IDataField, IEnumerable<Industry>>>();
        }
    }
}