using System.Collections.Generic;
using AutoMapper;
using DataPlatform.Shared.Entities;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMappers
{
    public class IvidResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideVehicleSpecificInformation, IDataField>()
                .ConvertUsing(s => new DataField(s.GetType().Name, s.GetType(), Mapper.Map<object, IEnumerable<IDataField>>(s)));
            Mapper.CreateMap<IProvideDataFromIvid, IEnumerable<IDataField>>()
                .ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
        }
    }
}