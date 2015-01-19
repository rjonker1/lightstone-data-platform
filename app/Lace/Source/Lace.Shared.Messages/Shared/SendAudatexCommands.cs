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
    public class SendAudatexCommands : ISendCommandsToBus
    {
        private readonly IPublishCommandMessages _publisher;
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        private readonly int _orderOfExecution;

        private readonly Guid _requestId;

        public SendAudatexCommands(IBus bus, Guid requestAggregateId, int orderOfExecution)
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
                //AudatexExecutionHasStarted = new
                //{
                AudatexExecutionHasStarted =
                    new AudatexExecutionHasStarted(_requestId, DataProviderCommandSource.Audatex,
                        CommandDescriptions.StartExecutionDescription(DataProviderCommandSource.Audatex),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
                //}
            };

            return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.FirstThing, _orderOfExecution);
        }

        private DataProviderCommandEnvelope End(object payload, MetadataContainer metadata)
        {
            var command = new
            {
                AudatexExecutionHasEnded =
                    new AudatexExecutionHasEnded(_requestId, DataProviderCommandSource.Audatex,
                        CommandDescriptions.EndExecutionDescription(DataProviderCommandSource.Audatex),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.StoneLast, _orderOfExecution);
        }

        private DataProviderCommandEnvelope StartCall(object payload, MetadataContainer metadata)
        {
            var command = new
            {
                AudatexExecutionHasStarted =
                    new AudatexExecutionHasStarted(_requestId, DataProviderCommandSource.Audatex,
                        CommandDescriptions.StartCallDescription(DataProviderCommandSource.Audatex),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.InTheBegining, _orderOfExecution);
        }

        private DataProviderCommandEnvelope EndCall(object payload, MetadataContainer metadata)
        {
            var command = new
            {
                AudatexExecutionHasEnded =
                    new AudatexExecutionHasEnded(_requestId, DataProviderCommandSource.Audatex,
                        CommandDescriptions.EndCallDescription(DataProviderCommandSource.Audatex),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.AtTheEnd, _orderOfExecution);
        }

        private DataProviderCommandEnvelope Fault(dynamic payload, MetadataContainer metadata)
        {
            var command = new
            {
                AudatexError =
                    new AudatexError(_requestId, DataProviderCommandSource.Audatex,
                        CommandDescriptions.FaultDescription(DataProviderCommandSource.Audatex), payload, metadata,
                        DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private DataProviderCommandEnvelope Security(dynamic payload, MetadataContainer metadata)
        {
            var command = new
            {
                AudatexSecurityFlag = new AudatexSecurityFlag(_requestId, DataProviderCommandSource.Audatex,
                    CommandDescriptions.SecurityDescription(DataProviderCommandSource.Audatex),
                    payload,
                    metadata, DateTime.UtcNow, Category.Security)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private DataProviderCommandEnvelope Configuration(dynamic payload, MetadataContainer metadata)
        {
            var command = new
            {
                AudatexConfigured = new AudatexConfigured(_requestId, DataProviderCommandSource.Audatex,
                    CommandDescriptions.ConfigurationDescription(DataProviderCommandSource.Audatex),
                    payload, metadata,
                    DateTime.UtcNow, Category.Configuration)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private DataProviderCommandEnvelope Transformation(dynamic payload, MetadataContainer metadata)
        {
            var command = new
            {
                AudatexResponseTransformed =
                    new AudatexResponseTransformed(_requestId, DataProviderCommandSource.Audatex,
                        CommandDescriptions.TransformationDescription(DataProviderCommandSource.Audatex),
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
