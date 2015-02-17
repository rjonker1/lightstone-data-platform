using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.ClientUsers
{
    public class ClientUserMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<ClientUser, ClientUserDto>();
            Mapper.CreateMap<IEnumerable<ClientUser>, IEnumerable<ClientUserDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<ClientUser, ClientUserDto>));

            Mapper.CreateMap<ClientUserDto, ClientUser>()
                .ConvertUsing<ITypeConverter<ClientUserDto, ClientUser>>();
            Mapper.CreateMap<IEnumerable<ClientUserDto>, IEnumerable<ClientUser>>()
                .ConvertUsing(s => s.Select(Mapper.Map<ClientUserDto, ClientUser>));
        }
    }
}