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

        private StartingRgtVinExecution Begin(object payload, MetadataContainer metadata)
        {
            return new StartingRgtVinExecution(new DataProviderCommand(_requestId, DataProviderCommandSource.RgtVin,
                CommandDescriptions.StartExecutionDescription(DataProviderCommandSource.RgtVin),
                payload, metadata, DateTime.UtcNow,
                Category.Performance)
                .ObjectToJson()
                .GetCommandDto(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution));
        }

        private EndingRgtVinExecution End(object payload, object metadata)
        {
            return new EndingRgtVinExecution(new DataProviderCommand(_requestId, DataProviderCommandSource.RgtVin,
                        CommandDescriptions.EndExecutionDescription(DataProviderCommandSource.RgtVin),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
                .ObjectToJson()
                .GetCommandDto(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution));
        }

        private StartingRgtVinDataSourceCall StartCall(object payload, MetadataContainer metadata)
        {
            return new StartingRgtVinDataSourceCall(new DataProviderCommand(_requestId, DataProviderCommandSource.RgtVin,
                        CommandDescriptions.StartCallDescription(DataProviderCommandSource.RgtVin),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
               .ObjectToJson()
               .GetCommandDto(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution));
        }

        private EndingRgtVinDataSourceCall EndCall(object payload, object metadata)
        {
            return new EndingRgtVinDataSourceCall(new DataProviderCommand(_requestId, DataProviderCommandSource.RgtVin,
                        CommandDescriptions.EndCallDescription(DataProviderCommandSource.RgtVin),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
              .ObjectToJson()
              .GetCommandDto(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution));
        }

        private ThrowError Fault(dynamic payload, MetadataContainer metadata)
        {
            return new ThrowError(new DataProviderCommand(_requestId, DataProviderCommandSource.RgtVin,
                        CommandDescriptions.FaultDescription(DataProviderCommandSource.RgtVin), payload, metadata,
                        DateTime.UtcNow,
                        Category.Fault)
              .ObjectToJson()
              .GetCommandDto(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution));
        }

        private RaiseRgtVinSecurityFlag Security(dynamic payload, MetadataContainer metadata)
        {
            return new RaiseRgtVinSecurityFlag(new DataProviderCommand(_requestId, DataProviderCommandSource.RgtVin,
                    CommandDescriptions.SecurityDescription(DataProviderCommandSource.RgtVin),
                    payload,
                    metadata, DateTime.UtcNow, Category.Security)
              .ObjectToJson()
              .GetCommandDto(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution));
        }

        private ConfigureRgtVin Configuration(dynamic payload, MetadataContainer metadata)
        {
            return new ConfigureRgtVin(new DataProviderCommand(_requestId, DataProviderCommandSource.RgtVin,
                    CommandDescriptions.ConfigurationDescription(DataProviderCommandSource.RgtVin),
                    payload, metadata,
                    DateTime.UtcNow, Category.Configuration)
              .ObjectToJson()
              .GetCommandDto(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution));
        }

        private TransformRgtVinResponse Transformation(dynamic payload, MetadataContainer metadata)
        {
            return new TransformRgtVinResponse(new DataProviderCommand(_requestId, DataProviderCommandSource.RgtVin,
                    CommandDescriptions.TransformationDescription(DataProviderCommandSource.RgtVin),
                    payload, metadata,
                    DateTime.UtcNow, Category.Configuration)
            .ObjectToJson()
            .GetCommandDto(_requestId, (int)DisplayOrder.AtTheEnd, _orderOfExecution));
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
