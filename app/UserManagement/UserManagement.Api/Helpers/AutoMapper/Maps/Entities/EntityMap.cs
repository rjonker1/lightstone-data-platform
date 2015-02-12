using System;
using System.Collections.Generic;
using AutoMapper;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Entities
{
    public class EntityMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<Tuple<Guid, Type>, Entity>()
                .ConvertUsing<ITypeConverter<Tuple<Guid, Type>, Entity>>();

            Mapper.CreateMap<Tuple<IEnumerable<Guid>, Type>, HashSet<Entity>>()
               .ConvertUsing<ITypeConverter<Tuple<IEnumerable<Guid>, Type>, HashSet<Entity>>>();
        }
    }
}