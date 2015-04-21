using System.Collections.Generic;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Responses
{
    public class PCubedFicaResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromPCubedFicaVerfication, IEnumerable<DataField>>()
                 .ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
        }
    }
}