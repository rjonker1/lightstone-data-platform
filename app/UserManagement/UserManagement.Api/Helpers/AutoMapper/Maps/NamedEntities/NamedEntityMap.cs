using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Dtos;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.NamedEntities
{
    public class NamedEntityMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<NamedEntity, NamedEntityDto>();
            Mapper.CreateMap<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<NamedEntity, NamedEntityDto>));
        }
    }
}