using System;
using AutoMapper;
using PackageBuilder.Domain.Entities.Enums.DataProviders;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps
{
    public class StateMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<Guid, State>()
                .ConvertUsing<ITypeConverter<Guid, State>>();
            Mapper.CreateMap<State, StateName>();
        }
    }
}
