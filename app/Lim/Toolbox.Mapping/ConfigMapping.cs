using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lim.Dtos;
using Lim.Entities;

namespace Toolbox.Mapping
{
    public class ConfigurationMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Configuration, ConfigurationDto>()
                .ConstructUsing(
                    config =>
                        ConfigurationDto.Existing(config.Id, config.ConfigurationKey, config.ActionType.Id, config.IntegrationType.Id,
                            config.FrequencyType.Id,
                            config.Client.Id, config.IsActive, config.ActionType.Type, config.FrequencyType.Type, config.IntegrationType.Type,
                            config.DateCreated, config.CustomFrequencyTime, config.CustomFrequencyDay)
                            .WithClients(Mapper.Map<List<IntegrationClient>, List<IntegrationClientDto>>(config.IntegrationClients.ToList()))
                            .WithContracts(Mapper.Map<List<IntegrationContract>, List<IntegrationContractDto>>(config.IntegrationContracts.ToList()))
                            .WithPackages(Mapper.Map<List<IntegrationPackage>, List<IntegrationPackageDto>>(config.IntegrationPackages.ToList()))
                            .WithDataExtracts(Mapper.Map<List<IntegrationDataExtract>, List<IntegrationDataExtractDto>>(config.IntegrationDataExtracts.ToList()))
                            )
                .ForAllMembers(opt => opt.Ignore());

            Mapper.CreateMap<ConfigurationDto, Configuration>();
        }
    }
}