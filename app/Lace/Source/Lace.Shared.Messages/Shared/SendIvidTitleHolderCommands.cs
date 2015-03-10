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
    public class SendIvidTitleHolderCommands : ISendMonitoringCommandsToBus
    {
        private readonly IPublishCommandMessages _publisher;
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        private readonly int _orderOfExecution;

        private readonly Guid _requestId;

        public SendIvidTitleHolderCommands(IBus bus, Guid requestAggregateId, int orderOfExecution)
        {
            _publisher = new MonitoringCommandPublisher(bus);
            _requestId = requestAggregateId;
            _orderOfExecution = orderOfExecution;
        }

        public void Begin(dynamic payload, DataProviderStopWatch stopWatch)
        {
            BusExtensions.SendToBus(Begin(payload, new MetadataContainer()),_publisher, _log);
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
                StartIvidTitleHolderExecution =
                    new StartIvidTitleHolderExecution(_requestId, DataProviderCommandSource.IvidTitleHolder,
                        CommandDescriptions.StartExecutionDescription(DataProviderCommandSource.IvidTitleHolder),
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
                EndIvidTitleHolderExecution =
                    new EndIvidTitleHolderExecution(_requestId, DataProviderCommandSource.IvidTitleHolder,
                        CommandDescriptions.EndExecutionDescription(DataProviderCommandSource.IvidTitleHolder),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution);
        }

        private DataProviderMonitoringCommand StartCall(object payload, MetadataContainer metadata)
        {

            var command = new
            {
                StartIvidTitleHolderDataSourceCall =
                    new StartIvidTitleHolderDataSourceCall(_requestId, DataProviderCommandSource.IvidTitleHolder,
                        CommandDescriptions.StartCallDescription(DataProviderCommandSource.IvidTitleHolder),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution);
        }

        private DataProviderMonitoringCommand EndCall(object payload, object metadata)
        {
            var command = new
            {
                EndIvidTitleHolderDataSourceCall =
                    new EndIvidTitleHolderDataSourceCall(_requestId, DataProviderCommandSource.IvidTitleHolder,
                        CommandDescriptions.EndCallDescription(DataProviderCommandSource.IvidTitleHolder),
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
                    new ThrowError(_requestId, DataProviderCommandSource.IvidTitleHolder,
                        CommandDescriptions.FaultDescription(DataProviderCommandSource.IvidTitleHolder), payload, metadata,
                        DateTime.UtcNow,
                        Category.Fault)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private DataProviderMonitoringCommand Security(dynamic payload, MetadataContainer metadata)
        {
            var command = new
            {
                IvidTitleHolderSecurityFlag = new RaiseIvidTitleHolderSecurityFlag(_requestId, DataProviderCommandSource.IvidTitleHolder,
                    CommandDescriptions.SecurityDescription(DataProviderCommandSource.IvidTitleHolder),
                    payload,
                    metadata, DateTime.UtcNow, Category.Security)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private DataProviderMonitoringCommand Configuration(dynamic payload, MetadataContainer metadata)
        {

            var command = new
            {
                ConfigureIvidTitleHolder = new ConfigureIvidTitleHolder(_requestId, DataProviderCommandSource.IvidTitleHolder,
                    CommandDescriptions.ConfigurationDescription(DataProviderCommandSource.IvidTitleHolder),
                    payload, metadata,
                    DateTime.UtcNow, Category.Configuration)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private DataProviderMonitoringCommand Transformation(dynamic payload, MetadataContainer metadata)
        {

            var command = new
            {
                TransformIvidTitleHolderResponse = new TransformIvidTitleHolderResponse(_requestId, DataProviderCommandSource.IvidTitleHolder,
                    CommandDescriptions.TransformationDescription(DataProviderCommandSource.IvidTitleHolder),
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
                        End(payload, new PerformanceMetadata(metadata))
                            .SendToBus(_publisher, _log);
                        break;
                    case CommandType.StartSourceCall:
                        StartCall(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;
                    case CommandType.EndSourceCall:
                        EndCall(payload, new PerformanceMetadata(metadata))
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
