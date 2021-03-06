﻿using System.Collections.Generic;
using Lim.Schedule.Core.Identifiers;

namespace Lim.Schedule.Core.Commands
{
    public class ExecuteFlatFilePullConfigurationCommand
    {
        public readonly IEnumerable<FlatFilePullIntegration> Configurations;

        public ExecuteFlatFilePullConfigurationCommand(IEnumerable<FlatFilePullIntegration> configurations)
        {
            Configurations = configurations;
        }
    }

    public class ExecuteFlatFilePushConfigurationCommand
    {
        public readonly IEnumerable<FlatFilePushIntegration> Configurations;

        public ExecuteFlatFilePushConfigurationCommand(IEnumerable<FlatFilePushIntegration> configurations)
        {
            Configurations = configurations;
        }
    }
}
