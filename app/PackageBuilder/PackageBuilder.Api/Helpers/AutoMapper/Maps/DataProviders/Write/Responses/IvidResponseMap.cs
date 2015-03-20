﻿using System.Collections.Generic;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Write.Responses
{
    public class IvidResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromIvid, IEnumerable<IDataField>>()
                .ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            Mapper.CreateMap<IProvideVehicleSpecificInformation, IDataField>()
                .ConvertUsing(s => new DataField("SpecificInformation", s.GetType(), Mapper.Map<object, IEnumerable<IDataField>>(s)));

            Mapper.CreateMap<IvidResponse, IEnumerable<IDataField>>()
                .ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
        }
    }
}