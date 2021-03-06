﻿using System.Collections.Generic;
using Lim.Schedule.Core.Identifiers;

namespace Lim.Schedule.Core.Commands
{
    public class ExecuteApiPushConfigurationCommand
    {
        public readonly IEnumerable<ApiPushIntegration> Configurations;

        public ExecuteApiPushConfigurationCommand(IEnumerable<ApiPushIntegration> configurations)
        {
            Configurations = configurations;
        }
    }

    public class ExecuteApiPullConfigurationCommand
    {
        public readonly IEnumerable<ApiPullIntegration> Configurations;

        public ExecuteApiPullConfigurationCommand(IEnumerable<ApiPullIntegration> configurations)
        {
            Configurations = configurations;
        }
    }
}