﻿using System.Collections.Generic;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Responses
{
    public class LightstoneDirectorResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromLightstoneBusinessDirector, IEnumerable<DataField>>()
               .ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            Mapper.CreateMap<IEnumerable<IProvideDirector>, DataField>()
              .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
              .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IProvideDirector>()));
            Mapper.CreateMap<IProvideDirector, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
        }
    }
}