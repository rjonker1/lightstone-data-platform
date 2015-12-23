using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Base;
using Lim.Dtos;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Identifiers;

namespace Lim.Schedule.Core.Factories.Api
{
    public class FetchPullFactory : AbstractFetchFactory<FetchConfigurationCommand, IEnumerable<ApiPullIntegration>>
    {
        private readonly IRepository _repository;
        private static readonly ILog Log = LogManager.GetLogger<FetchPullFactory>();

        public FetchPullFactory(IRepository repository)
        {
            _repository = repository;
        }

        public override IEnumerable<ApiPullIntegration> Fetch(FetchConfigurationCommand command)
        {
            try
            {
                //TODO: No Api Pull Integrations to get
              
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occurred fetching configurations for API because of {0}", ex, ex.Message);
            }

            return Enumerable.Empty<ApiPullIntegration>();
        }

        private IEnumerable<ApiPullIntegration> Map(IEnumerable<ConfigurationApiDto> configs)
        {
            return Enumerable.Empty<ApiPullIntegration>();
        }
    }
}