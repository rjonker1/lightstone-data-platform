using AutoMapper;
using Lim.Dtos;
using Lim.Entities;

namespace Toolbox.Mapping
{
    public class ConfigurationMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Configuration, ConfigurationDto>();
        }
    }
}
