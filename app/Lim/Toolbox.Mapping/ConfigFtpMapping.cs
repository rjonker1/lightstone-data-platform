using AutoMapper;
using Lim.Dtos;
using Lim.Entities;

namespace Toolbox.Mapping
{
    public class ConfigurationFtpMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ConfigurationFtp, ConfigurationFtpDto>()
                .ConstructUsing(c => ConfigurationFtpDto.Existing(c.Id,
                    Mapper.Map<Configuration, ConfigurationDto>(c.Configuration), c.Host, c.FileName, c.Username, c.Password, c.DateCreated,
                    c.CreatedBy));

            Mapper.CreateMap<ConfigurationFtpDto, ConfigurationFtp>()
                .ForMember(m => m.Configuration, o => o.MapFrom(s => Mapper.Map<ConfigurationDto, Configuration>(s.Configuration)));
        }
    }
}
