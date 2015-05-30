using System.Linq;
using Common.Logging;
using EasyNetQ;
using Lim.Domain.Messaging.Messages;
using Lim.Enums;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Commands;

namespace Lim.Domain.Receiver.Handlers
{
    public class AlwaysOnConfigurationConsumer
    {
        private readonly ILog _log;
        private readonly IHandleFetchingApiPushConfiguration _fetchApiPush;
        private readonly IHandleFetchingApiPullConfiguration _fetchApiPull;
        private readonly IHandleExecutingApiConfiguration _execute;

        public AlwaysOnConfigurationConsumer(IHandleFetchingApiPushConfiguration fetchApiPush, IHandleExecutingApiConfiguration execute, IHandleFetchingApiPullConfiguration fetchApiPull)
        {
            _fetchApiPush = fetchApiPush;
            _fetchApiPull = fetchApiPull;
            _execute = execute;
            _log = LogManager.GetLogger(GetType());
        }

        public void Consume(IMessage<PackageConfigurationMessage> message)
        {
            _log.InfoFormat("Receiving message with package with Package Id {0} on Contract {1}", message.Body.PackageId, message.Body.ContractId);

            _log.Info("Fetching Always On Push API Integrations");

            _fetchApiPush.Handle(new FetchConfigurationForClientCommand(IntegrationAction.Push, IntegrationType.Api, Frequency.AlwaysOn,message.Body.ContractId,message.Body.PackageId));
            if (!_fetchApiPush.Configurations.Any())
            {
                _log.InfoFormat("There are no always on Push API Integrations for Pacakge Id {0} on Contract {1}  to execute",message.Body.PackageId,message.Body.ContractId);
                return;
            }

            _log.InfoFormat("Executing {0} Always On Push API Integrations", _fetchApiPush.Configurations.Count());
            _execute.Handle(new ExecuteApiPushConfigurationCommand(_fetchApiPush.Configurations));

            _log.Info("Fetching Always On Pull API Integrations");

            _fetchApiPull.Handle(new FetchConfigurationForClientCommand(IntegrationAction.Pull, IntegrationType.Api, Frequency.AlwaysOn, message.Body.ContractId, message.Body.PackageId));
            if (!_fetchApiPush.Configurations.Any())
            {
                _log.InfoFormat("There are no always on Pull API Integrations for Pacakge Id {0} on Contract {1} to execute", message.Body.PackageId, message.Body.ContractId);
                return;
            }

            _log.InfoFormat("Executing {0} Always On Pull API Integrations", _fetchApiPush.Configurations.Count());
            _execute.Handle(new ExecuteApiPullConfigurationCommand(_fetchApiPull.Configurations));
        
        }
    }
}
