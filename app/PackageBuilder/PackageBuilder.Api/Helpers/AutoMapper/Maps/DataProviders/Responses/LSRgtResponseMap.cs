using System.Collections.Generic;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Responses
{
    public class RgtResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromRgt, IEnumerable<DataField>>()
                .ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
        }
    }
}