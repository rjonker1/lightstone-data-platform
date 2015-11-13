using System;
using System.Linq;
using Common.Logging;
using Lim.Schedule.Core.Commands;

namespace Lim.Schedule.Core.Handlers
{
    public class HandleExecutingApiConfiguration : IHandleExecutingApiConfiguration
    {
        private static readonly ILog Log = LogManager.GetLogger<HandleExecutingApiConfiguration>();

        public void Handle(ExecuteApiPushConfigurationCommand command)
        {
            if (command.Configurations == null || !command.Configurations.Any())
            {
                Log.Info("There are not configurations to execute");
                return;
            }

            Log.InfoFormat("Executing {0} API Push Configurations", command.Configurations.Count());
            command.Configurations.ToList().ForEach(f =>
            {
                try
                {
                    Log.InfoFormat("Executing Push Configuration with Key {0}", f.Key);
                    f.Pusher.Push(f.Command);
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("An error occurred executing API Push configuration because of {0}", ex, ex.Message);
                }
            });

            IsHandled = true;
        }

        public void Handle(ExecuteApiPullConfigurationCommand command)
        {
            throw new NotImplementedException();
        }

        public bool IsHandled { get; private set; }
    }
}