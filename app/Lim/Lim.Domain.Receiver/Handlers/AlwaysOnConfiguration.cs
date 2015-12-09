using System.Linq;
using Common.Logging;
using EasyNetQ;
using Lim.Domain.Events;
using Lim.Domain.Messaging.Messages;
using Lim.Enums;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Commands;

namespace Lim.Domain.Receiver.Handlers
{
    public class AlwaysOnConfigurationConsumer
    {
        private static readonly ILog Log = LogManager.GetLogger<AlwaysOnConfigurationConsumer>();
        private readonly IHandleFetchingApiPushConfiguration _fetchApiPush;
        private readonly IHandleFetchingApiPullConfiguration _fetchApiPull;
        private readonly IHandleExecutingApiConfiguration _execute;

        public AlwaysOnConfigurationConsumer(IHandleFetchingApiPushConfiguration fetchApiPush, IHandleExecutingApiConfiguration execute,
            IHandleFetchingApiPullConfiguration fetchApiPull)
        {
            _fetchApiPush = fetchApiPush;
            _fetchApiPull = fetchApiPull;
            _execute = execute;
        }

        public void Consume(IMessage<PackageReceived> message)
        {
            _fetchApiPush.Handle(new FetchConfigurationForClientCommand(IntegrationAction.Push, IntegrationType.Api, Frequency.AlwaysOn,
               message.Body.ContractId, message.Body.PackageId));
            if (_fetchApiPush.Configurations == null || !_fetchApiPush.Configurations.Any())
            {
                Log.InfoFormat("There are no always on Push API Integrations for Pacakge Id {0} on Contract {1}  to execute", message.Body.PackageId,
                    message.Body.ContractId);
                return;
            }

            Log.InfoFormat("Executing {0} Always On Push API Integrations", _fetchApiPush.Configurations.Count());
            _execute.Handle(new ExecuteApiPushConfigurationCommand(_fetchApiPush.Configurations));

            _fetchApiPull.Handle(new FetchConfigurationForClientCommand(IntegrationAction.Pull, IntegrationType.Api, Frequency.AlwaysOn,
                message.Body.ContractId, message.Body.PackageId));
            if (!_fetchApiPush.Configurations.Any())
            {
                Log.InfoFormat("There are no always on Pull API Integrations for Pacakge Id {0} on Contract {1} to execute", message.Body.PackageId,
                    message.Body.ContractId);
                return;
            }

            Log.InfoFormat("Executing {0} Always On Pull API Integrations", _fetchApiPush.Configurations.Count());
            _execute.Handle(new ExecuteApiPullConfigurationCommand(_fetchApiPull.Configurations));
        }

        public void Consume(IMessage<PackageConfigurationMessage> message)
        {
            _fetchApiPush.Handle(new FetchConfigurationForClientCommand(IntegrationAction.Push, IntegrationType.Api, Frequency.AlwaysOn,
                message.Body.ContractId, message.Body.PackageId));
            if (_fetchApiPush.Configurations == null || !_fetchApiPush.Configurations.Any())
            {
                Log.InfoFormat("There are no always on Push API Integrations for Pacakge Id {0} on Contract {1}  to execute", message.Body.PackageId,
                    message.Body.ContractId);
                return;
            }

            Log.InfoFormat("Executing {0} Always On Push API Integrations", _fetchApiPush.Configurations.Count());
            _execute.Handle(new ExecuteApiPushConfigurationCommand(_fetchApiPush.Configurations));

            _fetchApiPull.Handle(new FetchConfigurationForClientCommand(IntegrationAction.Pull, IntegrationType.Api, Frequency.AlwaysOn,
                message.Body.ContractId, message.Body.PackageId));
            if (!_fetchApiPush.Configurations.Any())
            {
                Log.InfoFormat("There are no always on Pull API Integrations for Pacakge Id {0} on Contract {1} to execute", message.Body.PackageId,
                    message.Body.ContractId);
                return;
            }

            Log.InfoFormat("Executing {0} Always On Pull API Integrations", _fetchApiPush.Configurations.Count());
            _execute.Handle(new ExecuteApiPullConfigurationCommand(_fetchApiPull.Configurations));

        }
    }
}