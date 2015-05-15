using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Domain.Models;
using Lim.Schedule.Commands;
using Lim.Schedule.Core;
using Lim.Schedule.Indentifiers;
using Lim.Schedule.Repositories;

namespace Lim.Schedule.Handlers
{
    public class HandleFetchingApiPullConfiguration : IHandleFetchingApiPullConfiguration
    {
        private readonly IRepository _repository;
        private readonly ILog _log;

        public HandleFetchingApiPullConfiguration(IRepository repository)
        {
            _repository = repository;
            _log = LogManager.GetLogger(GetType());
        }

        public void Handle(FetchConfigurationCommand command)
        {
            try
            {
                var configs = _repository.Get<ApiPullConfiguration>(ApiPullConfiguration.Select, new { }).ToList();
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

        public IEnumerable<ApiPullIntegration> Configurations { get; private set; }
        public bool HasConfiguration { get; private set; }
    }
}