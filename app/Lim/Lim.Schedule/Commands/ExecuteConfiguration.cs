using System.Collections.Generic;
using Lim.Schedule.Indentifiers;

namespace Lim.Schedule.Commands
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
        public ExecuteApiPullConfigurationCommand()
        { }
    }
}
