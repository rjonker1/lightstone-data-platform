using System;
using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Enums;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Commands;
using Lim.Test.Helper.Fakes.Repository;

namespace Lim.Test.Helper.Fakes.Handlers
{
    public class FakeHandleExecutingApiConfiguration : IHandleExecutingApiConfiguration
    {
        private readonly IRepository _repository = new FakeLimPackageResponseRepository();
        private readonly ILog _log = LogManager.GetLogger<FakeHandleExecutingApiConfiguration>();

        public void Handle(ExecuteApiPushConfigurationCommand command)
        {
            command.Configurations.ToList().ForEach(f =>
            {
                f.Pusher.Push(f.Command);
                f.Audit.Successful();
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
