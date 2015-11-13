using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps
{
    public class ComplexObjectMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<object, IEnumerable<DataField>>()
                .ConvertUsing<ITypeConverter<object, IEnumerable<DataField>>>();
        }
    }
}