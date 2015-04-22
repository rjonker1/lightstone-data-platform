using System.Collections.Generic;
using AutoMapper;
using Lace.Domain.Core.Entities.Requests.Fields;
using Lace.Domain.Core.Requests.Contracts;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Requests
{
    public class IvidRequestMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {

            Mapper.CreateMap<IAmDataProviderRequest, IEnumerable<IAmRequestField>>()
                .ConvertUsing<ITypeConverter<IAmDataProviderRequest, IEnumerable<IAmRequestField>>>();

            Mapper.CreateMap<IAmEngineNumberRequestField, EngineNumberRequestField>();  
        }
    }
}