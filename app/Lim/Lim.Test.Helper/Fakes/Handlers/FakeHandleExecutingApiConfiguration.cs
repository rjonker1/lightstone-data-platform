using System;
using System.Linq;
using Common.Logging;
using Lim.Domain.Entities.Repository;
using Lim.Enums;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Commands;
using Lim.Test.Helper.Fakes.Repository;

namespace Lim.Test.Helper.Fakes.Handlers
{
    public class FakeHandleExecutingApiConfiguration : IHandleExecutingApiConfiguration
    {
        private readonly IAmRepository _repository = new FakeLimPackageResponseRepository();
        private readonly ILog _log = LogManager.GetLogger<FakeHandleExecutingApiConfiguration>();

        public void Handle(ExecuteApiPushConfigurationCommand command)
        {
            command.Configurations.ToList().ForEach(f =>
            {
                var audit = new AuditIntegrationCommand(f.Client.ClientId, f.ConfigurationId, DateTime.UtcNow, (short)IntegrationAction.Push,
                    (short)IntegrationType.Api,
                    f.Configuration.BaseAddress, f.Configuration.Suffix);

                f.Get(_repository, DateTime.Now.AddYears(-10));
                f.Push(audit, _log);
                audit.Successful();
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
