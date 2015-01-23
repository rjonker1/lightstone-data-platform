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
    public class SendRgtVinCommands : ISendCommandsToBus
    {
        private readonly IPublishCommandMessages _publisher;
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        private readonly int _orderOfExecution;

        private readonly Guid _requestId;

        public SendRgtVinCommands(IBus bus, Guid requestAggregateId, int orderOfExecution)
        {
            _publisher = new CommandPublisher(bus);
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
            BusExtensions.SendToBus(End(payload, new MetadataContainer(stopWatch.ToObject())), _publisher, _log);
        }

        public void StartCall(dynamic payload, DataProviderStopWatch stopWatch)
        {
            BusExtensions.SendToBus(StartCall(payload, new MetadataContainer()), _publisher, _log);
            stopWatch.Start();
        }

        public void EndCall(dynamic payload, DataProviderStopWatch stopWatch)
        {
            stopWatch.Stop();
            BusExtensions.SendToBus(EndCall(payload, new MetadataContainer(stopWatch.ToObject())), _publisher, _log);
        }

        public void Send(CommandType commandType, dynamic payload, dynamic metadata)
        {
            SendToBus(payload, metadata, commandType);
        }

        private DataProviderCommandEnvelope Begin(object payload, MetadataContainer metadata)
        {
            var command = new
            {
                RgtVinExecutionHasStarted =
                    new RgtVinExecutionHasStarted(_requestId, DataProviderCommandSource.RgtVin,
                        CommandDescriptions.StartExecutionDescription(DataProviderCommandSource.RgtVin),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.FirstThing, _orderOfExecution);
        }

        private DataProviderCommandEnvelope End(object payload, MetadataContainer metadata)
        {
            var command = new
            {
                RgtVinExecutionHasEnded =
                    new RgtVinExecutionHasEnded(_requestId, DataProviderCommandSource.RgtVin,
                        CommandDescriptions.EndExecutionDescription(DataProviderCommandSource.RgtVin),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.StoneLast, _orderOfExecution);
        }

        private DataProviderCommandEnvelope StartCall(object payload, MetadataContainer metadata)
        {
            var command = new
            {
                RgtVinExecutionHasStarted =
                    new RgtVinExecutionHasStarted(_requestId, DataProviderCommandSource.RgtVin,
                        CommandDescriptions.StartCallDescription(DataProviderCommandSource.RgtVin),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.InTheBegining, _orderOfExecution);
        }

        private DataProviderCommandEnvelope EndCall(object payload, MetadataContainer metadata)
        {
            var command = new
            {
                RgtVinExecutionHasEnded =
                    new RgtVinExecutionHasEnded(_requestId, DataProviderCommandSource.RgtVin,
                        CommandDescriptions.EndCallDescription(DataProviderCommandSource.RgtVin),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.AtTheEnd, _orderOfExecution);
        }

        private DataProviderCommandEnvelope Fault(dynamic payload, MetadataContainer metadata)
        {
            var command = new
            {
                ErrorThrown =
                    new ErrorThrown(_requestId, DataProviderCommandSource.RgtVin,
                        CommandDescriptions.FaultDescription(DataProviderCommandSource.RgtVin), payload, metadata,
                        DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private DataProviderCommandEnvelope Security(dynamic payload, MetadataContainer metadata)
        {
            var command = new
            {
                RgtVinSecurityFlag = new RgtVinSecurityFlag(_requestId, DataProviderCommandSource.RgtVin,
                    CommandDescriptions.SecurityDescription(DataProviderCommandSource.RgtVin),
                    payload,
                    metadata, DateTime.UtcNow, Category.Security)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private DataProviderCommandEnvelope Configuration(dynamic payload, MetadataContainer metadata)
        {
            var command = new
            {
                RgtVinConfigured = new
                {
                    RgtVinConfigured = new RgtVinConfigured(_requestId, DataProviderCommandSource.RgtVin,
                        CommandDescriptions.ConfigurationDescription(DataProviderCommandSource.RgtVin),
                        payload, metadata,
                        DateTime.UtcNow, Category.Configuration)
                }
            };

            return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private DataProviderCommandEnvelope Transformation(dynamic payload, MetadataContainer metadata)
        {
            var command = new
            {
                RgtVinResponseTransformed = new RgtVinResponseTransformed(_requestId, DataProviderCommandSource.RgtVin,
                    CommandDescriptions.TransformationDescription(DataProviderCommandSource.RgtVin),
                    payload, metadata,
                    DateTime.UtcNow, Category.Configuration)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.InTheMiddle, _orderOfExecution);
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
