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

            Mapper.CreateMap<ViewColumn, ViewColumnDto>()
                .ForMember(m => m.ViewId, o => o.MapFrom(s => s.View.AggregateId));
            Mapper.CreateMap<ViewColumnDto, ViewColumn>()
                .ForMember(m => m.View, o => o.MapFrom(s => new View() {AggregateId = s.ViewId}));
        }
    }
}
