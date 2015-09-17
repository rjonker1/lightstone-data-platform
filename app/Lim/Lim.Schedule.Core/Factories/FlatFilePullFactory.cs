using System;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Base;
using Lim.Domain.Dto;
using Lim.Schedule.Core.Commands;

namespace Lim.Schedule.Core.Factories
{
    public class FlatFilePullFactory : AbstractPullFactory<FlatFilePullInitializeCommand>
    {
        private static readonly ILog Log = LogManager.GetLogger<FlatFilePullFactory>();
        private readonly IInitialize<FlatFilePullInitializeCommand> _initialize;

        public FlatFilePullFactory(IInitialize<FlatFilePullInitializeCommand> initialize)
        {
            _initialize = initialize;
        }

        public override void Pull(FlatFilePullInitializeCommand command)
        {
            _initialize.Init(command);
        }
    }
}