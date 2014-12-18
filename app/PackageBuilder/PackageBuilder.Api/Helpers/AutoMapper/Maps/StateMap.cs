using AutoMapper;
using PackageBuilder.Domain.Entities.Enums;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps
{
    public class StateMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<StateName, State>();
            Mapper.CreateMap<State, StateName>();
        }
    }
}
