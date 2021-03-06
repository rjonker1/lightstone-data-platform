﻿using System;
using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.Packages
{
    public class ToPackageDtoMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IPackage, PackageDto>()
                .ForMember(d => d.DataProviders, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<IDataProvider>, IEnumerable<DataProviderDto>>(x.DataProviders)))
                .ForMember(d => d.Industries, opt => opt.MapFrom(x => Mapper.Map<IPackage, IEnumerable<IndustryDto>>(x)))
                .ForMember(d => d.State, opt => opt.MapFrom(src => Mapper.Map<Guid, State>(src.State.Id)));
            //.ForMember(d => d.State, opt => opt.MapFrom(x => Mapper.Map<StateName, State>((StateName)Enum.Parse(typeof(StateName), x.State.Alias, true))));
        }
    }
}