﻿using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps
{
    public class ComplexObjectMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<object, IEnumerable<IDataField>>()
                .ConvertUsing<ITypeConverter<object, IEnumerable<IDataField>>>();
        }
    }
}