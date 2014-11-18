using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PackageBuilder.Domain.Entities.Enums;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMappers
{
    class StateMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<StateName, State>();
            Mapper.CreateMap<State, StateName>();
        }
    }
}
