﻿using System.Collections.Generic;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.WriteModels.Responses
{
    public class LightstoneResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromLightstoneAuto, IEnumerable<IDataField>>()
                .ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            Mapper.CreateMap<IRespondWithValuation, IDataField>()
                .ConvertUsing(s => new DataField("VehicleValuation", s.GetType(), Mapper.Map<object, IEnumerable<IDataField>>(s)));
        }
    }
}