using AutoMapper;
using Lim.Dtos;
using Toolbox.LSAuto.Entities;

namespace Toolbox.LightstoneAuto.Domain.Mapping
{
    public class DatabaseExtractMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<LSAuto.Entities.DatabaseExtract, DatabaseExtractDto>();
            Mapper.CreateMap<DatabaseExtractDto, LSAuto.Entities.DatabaseExtract>();
          
            Mapper.CreateMap<DatabaseExtractField, DatabaseExtractFieldDto>();
            Mapper.CreateMap<DatabaseExtractFieldDto, DatabaseExtractField>();
        }
    }
}
