using System;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Messages.Core
{
    public static class CommandDescriptions
    {
        public static Func<DataProviderCommandSource, string> StartExecutionDescription =
            (source) => string.Format("Start Executing Data Provider {0}", source.ToString());

        public static Func<DataProviderCommandSource, string> EndExecutionDescription =
            (source) => string.Format("Stop Executing Data Provider {0}", source.ToString());

        public static Func<DataProviderCommandSource, string> StartCallDescription =
            (source) => string.Format("Start Calling Source for Data Provider {0}", source.ToString());

        public static Func<DataProviderCommandSource, string> EndCallDescription =
            (source) => string.Format("Stop Calling Source for Data Provider {0}", source.ToString());

        public static Func<DataProviderCommandSource, string> FaultDescription =
            (source) => string.Format("An error Occurred in Data Provider {0}", source.ToString());

        public static Func<DataProviderCommandSource, string> SecurityDescription =
            (source) => string.Format("Security Configuration in Data Provider {0}", source.ToString());

        public static Func<DataProviderCommandSource, string> ConfigurationDescription =
            (source) => string.Format("Configuration for Data Provider {0}", source.ToString());

        public static Func<DataProviderCommandSource, string> TransformationDescription =
            (source) => string.Format("Transforming response for Data Provider {0}", source.ToString());
    }
}
