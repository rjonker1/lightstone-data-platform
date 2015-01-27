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
    public class SendRgtCommands : ISendCommandsToBus
    {
        private readonly IPublishCommandMessages _publisher;
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        private readonly int _orderOfExecution;

        private readonly Guid _requestId;

        public SendRgtCommands(IBus bus, Guid requestAggregateId, int orderOfExecution)
        {
            _publisher = new CommandPublisher(bus);
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

        private DataProviderCommandEnvelope Begin(object payload, MetadataContainer metadata)
        {
            var command = new
            {
                    RgtExecutionHasStarted =
                        new RgtExecutionHasStarted(_requestId, DataProviderCommandSource.Rgt,
                            CommandDescriptions.StartExecutionDescription(DataProviderCommandSource.Rgt),
                            payload, metadata, DateTime.UtcNow,
                            Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution);
        }

        private DataProviderCommandEnvelope End(object payload, object metadata)
        {
            var command = new
            {
                    RgtExecutionHasEnded =
                        new RgtExecutionHasEnded(_requestId, DataProviderCommandSource.Rgt,
                            CommandDescriptions.EndExecutionDescription(DataProviderCommandSource.Rgt),
                            payload, metadata, DateTime.UtcNow,
                            Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.StoneLast, _orderOfExecution);
        }

        private DataProviderCommandEnvelope StartCall(object payload, MetadataContainer metadata)
        {
            var command = new
            {
                    RgtDataSourceCallHasStarted =
                        new RgtDataSourceCallHasStarted(_requestId, DataProviderCommandSource.Rgt,
                            CommandDescriptions.StartCallDescription(DataProviderCommandSource.Rgt),
                            payload, metadata, DateTime.UtcNow,
                            Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.InTheBegining, _orderOfExecution);
        }

        private DataProviderCommandEnvelope EndCall(object payload, object metadata)
        {
            var command = new
            {
                    RgtDataSourceCallHasEnded =
                        new RgtDataSourceCallHasEnded(_requestId, DataProviderCommandSource.Rgt,
                            CommandDescriptions.EndCallDescription(DataProviderCommandSource.Rgt),
                            payload, metadata, DateTime.UtcNow,
                            Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.AtTheEnd, _orderOfExecution);
        }

        private DataProviderCommandEnvelope Fault(dynamic payload, MetadataContainer metadata)
        {
            var command = new
            {
                //RgtError = new
                //{
                ErrorThrown =
                    new ErrorThrown(_requestId, DataProviderCommandSource.Rgt,
                        CommandDescriptions.FaultDescription(DataProviderCommandSource.Rgt), payload, metadata,
                        DateTime.UtcNow,
                        Category.Performance)
                //}
            };

            return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private DataProviderCommandEnvelope Security(dynamic payload, MetadataContainer metadata)
        {
            var command = new
            {
                    RgtSecurityFlag = new RgtSecurityFlag(_requestId, DataProviderCommandSource.Rgt,
                        CommandDescriptions.SecurityDescription(DataProviderCommandSource.Rgt),
                        payload,
                        metadata, DateTime.UtcNow, Category.Security)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private DataProviderCommandEnvelope Configuration(dynamic payload, MetadataContainer metadata)
        {
            var command = new
            {
                    RgtConfigured = new RgtConfigured(_requestId, DataProviderCommandSource.Rgt,
                        CommandDescriptions.ConfigurationDescription(DataProviderCommandSource.Rgt),
                        payload, metadata,
                        DateTime.UtcNow, Category.Configuration)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private DataProviderCommandEnvelope Transformation(dynamic payload, MetadataContainer metadata)
        {
            var command = new
            {
                    RgtResponseTransformed = new RgtResponseTransformed(_requestId, DataProviderCommandSource.Rgt,
                        CommandDescriptions.TransformationDescription(DataProviderCommandSource.Rgt),
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
