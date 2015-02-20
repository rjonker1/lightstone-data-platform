using System.Linq;
using AutoMapper;
using Shared.BuildingBlocks.Api.ApiClients;
using StackExchange.Redis;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Redis
{
    public class RedisMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<HashEntry[], ApiUser>()
                .ForMember(id => id.UserName, opt => opt.MapFrom(entries => entries.FirstOrDefault(x => (x.Name + "").ToLower() == "username").Value))
                .ForMember(id => id.Claims, opt => opt.MapFrom(entries => (entries.FirstOrDefault(x => (x.Name + "").ToLower() == "claims").Value + "").Split('|')));
        }
    }
}