using System.Collections.Generic;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMappers
{
    public class IvidResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromIvid, IEnumerable<IDataField>>()
                .ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            Mapper.CreateMap<IProvideVehicleSpecificInformation, IDataField>()
                .ConvertUsing(s => new DataField("SpecificInformation", s.GetType(), Mapper.Map<object, IEnumerable<IDataField>>(s)));
        }
    }
}