using AutoMapper;
using Lim.Dtos;
using Lim.Entities;

namespace Toolbox.Mapping
{
    public class ConfigurationApiMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ConfigurationApi, ApiPushConfigurationDto>()
                .ConstructUsing(
                    config =>
                        ApiPushConfigurationDto.Existing(config.Id, config.Configuration.ConfigurationKey, config.Configuration.FrequencyType.Id,
                            config.Configuration.ActionType.Id, config.Configuration.IntegrationType.Id, config.BaseAddress, config.Suffix,
                            config.Username, config.Password,
                            config.AuthenticationToken, config.AuthenticationKey, config.HasAuthentication, config.AuthenticationType.Id,
                            config.Configuration.Client.Id)).ForAllMembers(opt => opt.Ignore());
            Mapper.CreateMap<ApiPushConfigurationDto, ConfigurationApi>();

            Mapper.CreateMap<ConfigurationApi, ApiPullConfigurationDto>()
                 .ConstructUsing(
                    config =>
                        ApiPullConfigurationDto.Existing(config.Id, config.Configuration.ConfigurationKey, config.Configuration.FrequencyType.Id,
                            config.Configuration.ActionType.Id, config.Configuration.IntegrationType.Id, config.BaseAddress, config.Suffix,
                            config.Username, config.Password,
                            config.AuthenticationToken, config.AuthenticationKey, config.HasAuthentication, config.AuthenticationType.Id,
                            config.Configuration.Client.Id)).ForAllMembers(opt => opt.Ignore());
            Mapper.CreateMap<ApiPullConfigurationDto, ConfigurationApi>();
        }
    }
}