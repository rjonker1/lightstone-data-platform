using Common.Logging;
using System;
using System.Threading.Tasks;
using DataPlatform.Shared.Enums;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Commands;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Dto;
using Lace.Shared.Monitoring.Messages.Infrastructure.Extensions;
using Lace.Shared.Monitoring.Messages.Publisher;
using NServiceBus;


namespace Lace.Shared.Monitoring.Messages.Shared
{
    public class SendSignioCommands : ISendMonitoringCommandsToBus
    {
        private readonly IPublishCommandMessages _publisher;
        private readonly ILog _log;
        private readonly int _orderOfExecution;

        private readonly Guid _requestId;

        public SendSignioCommands(IBus bus, Guid requestAggregateId, int orderOfExecution)
        {
            _log = LogManager.GetLogger(GetType());
            _publisher = new MonitoringCommandPublisher(bus);
            _requestId = requestAggregateId;
            _orderOfExecution = orderOfExecution;
        }

        public void Begin(dynamic payload, DataProviderStopWatch stopWatch)
        {
            BusExtensions.SendToBus(Begin(payload, new MetadataContainer()), _publisher, _log);
            stopWatch.Start();
        }

        public void End(dynamic payload, DataProviderStopWatch stopWatch)
        {
            stopWatch.Stop();
            BusExtensions.SendToBus(End(payload, new PerformanceMetadata(stopWatch.ToObject())), _publisher, _log);
        }

        public void StartCall(dynamic payload, DataProviderStopWatch stopWatch)
        {
            BusExtensions.SendToBus(StartCall(payload, new MetadataContainer()), _publisher, _log);
            stopWatch.Start();
        }

        public void EndCall(dynamic payload, DataProviderStopWatch stopWatch)
        {
            stopWatch.Stop();
            BusExtensions.SendToBus(EndCall(payload, new PerformanceMetadata(stopWatch.ToObject())), _publisher, _log);
        }

        public void Send(CommandType commandType, dynamic payload, dynamic metadata)
        {
            SendToBus(payload, metadata, commandType);
        }

        private DataProviderMonitoringCommand Begin(object payload, MetadataContainer metadata)
        {
            var command = new
            {
                StartSignioExecution =
                    new StartSignioExecution(_requestId, DataProviderCommandSource.SignioDecryptDriversLicense,
                        CommandDescriptions.StartExecutionDescription(DataProviderCommandSource.SignioDecryptDriversLicense),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            var cmd = command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution);
            return cmd;
        }

        private DataProviderMonitoringCommand End(object payload, object metadata)
        {
            var command = new
            {
                EndSignioExecution =
                    new EndSignioExecution(_requestId, DataProviderCommandSource.SignioDecryptDriversLicense,
                        CommandDescriptions.EndExecutionDescription(DataProviderCommandSource.SignioDecryptDriversLicense),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution);
        }

        private DataProviderMonitoringCommand StartCall(object payload, MetadataContainer metadata)
        {

            var command = new
            {
                StartSignioDataSourceCall =
                    new StartSignioDataSourceCall(_requestId, DataProviderCommandSource.SignioDecryptDriversLicense,
                        CommandDescriptions.StartCallDescription(DataProviderCommandSource.SignioDecryptDriversLicense),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution);
        }

        private DataProviderMonitoringCommand EndCall(object payload, object metadata)
        {
            var command = new
            {
                EndSignioDataSourceCall =
                    new EndSignioDataSourceCall(_requestId, DataProviderCommandSource.SignioDecryptDriversLicense,
                        CommandDescriptions.EndCallDescription(DataProviderCommandSource.SignioDecryptDriversLicense),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution);
        }

        private DataProviderMonitoringCommand Fault(dynamic payload, MetadataContainer metadata)
        {

            var command = new
            {
                ThrowError =
                    new ThrowError(_requestId, DataProviderCommandSource.SignioDecryptDriversLicense,
                        CommandDescriptions.FaultDescription(DataProviderCommandSource.SignioDecryptDriversLicense), payload, metadata,
                        DateTime.UtcNow,
                        Category.Fault)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private DataProviderMonitoringCommand Security(dynamic payload, MetadataContainer metadata)
        {
            var command = new
            {
                SignioSecurityFlag = new RaiseSignioSecurityFlag(_requestId, DataProviderCommandSource.SignioDecryptDriversLicense,
                    CommandDescriptions.SecurityDescription(DataProviderCommandSource.SignioDecryptDriversLicense),
                    payload,
                    metadata, DateTime.UtcNow, Category.Security)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private DataProviderMonitoringCommand Configuration(dynamic payload, MetadataContainer metadata)
        {

            var command = new
            {
                ConfigureSignio = new ConfigureSignio(_requestId, DataProviderCommandSource.SignioDecryptDriversLicense,
                    CommandDescriptions.ConfigurationDescription(DataProviderCommandSource.SignioDecryptDriversLicense),
                    payload, metadata,
                    DateTime.UtcNow, Category.Configuration)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private DataProviderMonitoringCommand Transformation(dynamic payload, MetadataContainer metadata)
        {

            var command = new
            {
                TransformSignioResponse = new TransformSignioResponse(_requestId, DataProviderCommandSource.SignioDecryptDriversLicense,
                    CommandDescriptions.TransformationDescription(DataProviderCommandSource.SignioDecryptDriversLicense),
                    payload, metadata,
                    DateTime.UtcNow, Category.Configuration)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution);
        }


        private void SendToBus<T>(T payload, dynamic metadata, CommandType type) where T : class
        {
            Task.Run(() =>
            {
                switch (type)
                {
                    case CommandType.Fault:
                        Fault(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;
                    case CommandType.Accounting:
                        break;
                    case CommandType.Configuration:
                        Configuration(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;
                    case CommandType.Security:
                        Security(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;
                    case CommandType.BeginExecution:
                        Begin(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;
                    case CommandType.EndExecution:
                        End(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;
                    case CommandType.StartSourceCall:
                        StartCall(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;
                    case CommandType.EndSourceCall:
                        EndCall(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;
                    case CommandType.Transformation:
                        Transformation(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;

                }
            });
        }
    }
}
