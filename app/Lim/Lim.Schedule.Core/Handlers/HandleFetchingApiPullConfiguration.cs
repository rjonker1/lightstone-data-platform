using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Domain.Dto;
using Lim.Domain.Repository;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Identifiers;

namespace Lim.Schedule.Core.Handlers
{
    public class HandleFetchingApiPullConfiguration : IHandleFetchingApiPullConfiguration
    {
        private readonly IReadLimRepository _repository;
        private readonly ILog _log;

        public HandleFetchingApiPullConfiguration(IReadLimRepository repository)
        {
            _repository = repository;
            _log = LogManager.GetLogger(GetType());
        }

        public void Handle(FetchConfigurationCommand command)
        {
            try
            {
                var configs = _repository.Items<ApiPullConfigurationDto>(ApiPullConfigurationDto.Select, new { @FrequencyType = (int)command.Frequency, @Action = (int)command.Action, @IntegrationType = (int)command.Type }).ToList();
                _log.InfoFormat("{0} Api Pull Configurations will be handled", configs.Count());

                HasConfiguration = configs.Any();

                if (!HasConfiguration)
                {
                    _log.InfoFormat("No configurations found for API {0}", command.Action.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occurred handling configurations because of {0}", ex, ex.Message);
            }
        }

        public void Handle(FetchConfigurationForClientCommand command)
        {
            try
            {
                var configs = _repository.Items<ApiPullConfigurationDto>(ApiPullConfigurationDto.Select, new
                {
                    @FrequencyType = (int)command.Frequency,
                    @Action = (int)command.Action,
                    @IntegrationType = (int)command.Type
                }).ToList();

                _log.InfoFormat("{0} Api Pull Configurations for specific client and contract will be handled", configs.Count());

                HasConfiguration = configs.Any();

                if (!HasConfiguration)
                {
                    _log.InfoFormat("No client configurations found for {1} {0} on Contract {2}", command.Action.ToString(),
                       command.Frequency.ToString(), command.ContractId);
                    return;
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occurred handling client configurations because of {0}", ex, ex.Message);
            }
        }

        public void Handle(FetchConfigurationForCustomCommand command)
        {
            try
            {
                var configs =
                    _repository.Items<ApiPullConfigurationDto>(ApiPullConfigurationDto.SelectWithCustomDay,
                        new { @FrequencyType = (int)command.Frequency, @Action = (int)command.Action, @IntegrationType = (int)command.Type, @CustomFrequencyDay = command.CustomDay })
                        .ToList();
                _log.InfoFormat("{0} {1} Api Custom Pull Configurations on {2} will be handled", configs.Count(), command.Frequency.ToString(), command.CustomDay);

                HasConfiguration = configs.Any();

                if (!HasConfiguration)
                {
                    _log.InfoFormat("No custom pull configurations found for {1} {0} on {2}", command.Action.ToString(), command.Frequency.ToString(), command.CustomDay);
                    return;
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occurred handling configurations because of {0}", ex, ex.Message);
            }
        }

        public IEnumerable<ApiPullIntegration> Configurations { get; private set; }
        public bool HasConfiguration { get; private set; }
    }
}