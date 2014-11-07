using System.Collections.Generic;
using AutoMapper;
using DataPlatform.Shared.Entities;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMappers
{
    public class LightstoneResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IRespondWithValuation, IDataField>()
                .ConvertUsing(s => new DataField(s.GetType().Name, s.GetType(), Mapper.Map<object, IEnumerable<IDataField>>(s)));
            Mapper.CreateMap<IProvideDataFromLightstone, IEnumerable<IDataField>>()
                .ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
        }
    }
}