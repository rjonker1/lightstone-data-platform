using System.Collections.Generic;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.WriteModels.Responses
{
    public class PCubedFicaResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromPCubedFicaVerfication, IEnumerable<IDataField>>()
                 .ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
        }
    }
}