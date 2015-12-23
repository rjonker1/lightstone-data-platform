using AutoMapper;
using Lim.Dtos;
using Lim.Entities;

namespace Toolbox.Mapping
{
    public class ConfigurationApiMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ConfigurationApi, ConfigurationApiDto>()
                .ConstructUsing(
                    config =>
                        ConfigurationApiDto.Existing(config.Id, config.BaseAddress, config.Suffix,
                            config.Username, config.Password,
                            config.AuthenticationToken, config.AuthenticationKey, config.HasAuthentication, config.AuthenticationType.Id,
                            Mapper.Map<Configuration, ConfigurationDto>(config.Configuration))).ForAllMembers(opt => opt.Ignore());

            Mapper.CreateMap<ConfigurationApiDto, ConfigurationApi>()
                .ForMember(m => m.Configuration, o => o.MapFrom(s => Mapper.Map<ConfigurationDto, Configuration>(s.Configuration)));

        }
    }
}