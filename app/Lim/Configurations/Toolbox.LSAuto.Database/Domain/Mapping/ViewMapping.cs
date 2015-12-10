using AutoMapper;
using Lim.Dtos;
using Toolbox.LSAuto.Entities;

namespace Toolbox.LightstoneAuto.Domain.Mapping
{
    public class ViewMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<View, ViewDto>();
            Mapper.CreateMap<ViewDto, View>();

            Mapper.CreateMap<ViewColumn, ViewColumnDto>();
            Mapper.CreateMap<ViewColumnDto, ViewColumn>();
        }
    }
}
