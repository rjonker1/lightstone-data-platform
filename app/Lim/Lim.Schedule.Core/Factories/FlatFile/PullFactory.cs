using Common.Logging;
using Lim.Core;
using Lim.Domain.Base;
using Lim.Schedule.Core.Commands;

namespace Lim.Schedule.Core.Factories.FlatFile
{
    public class PullFactory : AbstractPullFactory<FlatFileInitializePullCommand>
    {
        private static readonly ILog Log = LogManager.GetLogger<PullFactory>();
        private readonly IInitialize<FlatFileInitializePullCommand> _initialize;

        public PullFactory(IInitialize<FlatFileInitializePullCommand> initialize)
        {
            _initialize = initialize;
        }

        public override void Pull(FlatFileInitializePullCommand command)
        {
            _initialize.Init(command);
        }
    }
}