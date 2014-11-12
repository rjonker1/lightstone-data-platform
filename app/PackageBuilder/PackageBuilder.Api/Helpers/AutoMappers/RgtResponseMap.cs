using System.Collections.Generic;
using AutoMapper;
using DataPlatform.Shared.Entities;
using Lace.Domain.Core.Contracts.DataProviders;

namespace PackageBuilder.Api.Helpers.AutoMappers
{
    public class RgtResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromRgt, IEnumerable<IDataField>>()
                .ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
        }
    }
}