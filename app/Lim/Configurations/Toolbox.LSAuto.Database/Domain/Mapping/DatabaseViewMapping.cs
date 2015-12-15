using AutoMapper;
using Lim.Dtos;
using Toolbox.LSAuto.Entities;

namespace Toolbox.LightstoneAuto.Domain.Mapping
{
    public class DatabaseViewMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<LSAuto.Entities.DatabaseView, DatabaseViewDto>();
            Mapper.CreateMap<DatabaseViewDto, LSAuto.Entities.DatabaseView>();

            Mapper.CreateMap<DatabaseViewColumn, DatabaseViewColumnDto>()
                .ForMember(m => m.DatabaseViewId, o => o.MapFrom(s => s.DatabaseView.Id));
            Mapper.CreateMap<DatabaseViewColumnDto, DatabaseViewColumn>();
              //  .ForMember(m => m.DatabaseView.Id, o => o.MapFrom(s => s.DatabaseViewId));


            Mapper.CreateMap<DatabaseViewColumnDto, DatabaseExtractFieldDto>()
                .ForMember(m => m.Id, o => o.Ignore());

            Mapper.CreateMap<DatabaseViewDto, DatabaseExtractDto>()
              .ForMember(m => m.Id, o => o.Ignore())
              .ForMember(m => m.AggregateId, o => o.Ignore())
              .ForMember(m => m.Fields, o => o.MapFrom(s => s.ViewColumns));
        }
    }
}
