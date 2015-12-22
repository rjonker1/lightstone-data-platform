using AutoMapper;
using Lim.Dtos;
using Toolbox.LSAuto.Entities;

namespace Toolbox.LightstoneAuto.Domain.Mapping
{
    public class DatabaseExtractMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<LSAuto.Entities.DatabaseExtract, DatabaseExtractDto>()
                .ForMember(m => m.FieldCount, o => o.MapFrom(s => s.Fields.Count))
                .ForMember(m => m.ViewId, o => o.MapFrom(s => s.View.Id));
            Mapper.CreateMap<DatabaseExtractDto, LSAuto.Entities.DatabaseExtract>();
          
            Mapper.CreateMap<DatabaseExtractField, DatabaseExtractFieldDto>();
            Mapper.CreateMap<DatabaseExtractFieldDto, DatabaseExtractField>();
        }
    }
}
