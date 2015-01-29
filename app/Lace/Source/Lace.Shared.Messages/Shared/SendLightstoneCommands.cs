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
    public class SendLightstoneCommands : ISendCommandsToBus
    {
        private readonly IPublishCommandMessages _publisher;
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        private readonly int _orderOfExecution;

        private readonly Guid _requestId;

        public SendLightstoneCommands(IBus bus, Guid requestAggregateId, int orderOfExecution)
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

        private StartingLightstoneExecution Begin(object payload, MetadataContainer metadata)
        {
            return new StartingLightstoneExecution(new DataProviderCommand(_requestId, DataProviderCommandSource.Lightstone,
                CommandDescriptions.StartExecutionDescription(DataProviderCommandSource.Lightstone),
                payload, metadata, DateTime.UtcNow,
                Category.Performance)
                .ObjectToJson()
                .GetCommandDto(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution));
        }

        private EndingLightstoneExecution End(object payload, object metadata)
        {
            return new EndingLightstoneExecution(new DataProviderCommand(_requestId, DataProviderCommandSource.Lightstone,
                        CommandDescriptions.EndExecutionDescription(DataProviderCommandSource.Lightstone),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
                .ObjectToJson()
                .GetCommandDto(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution));
        }

        private StartingLightstoneDataSourceCall StartCall(object payload, MetadataContainer metadata)
        {
            return new StartingLightstoneDataSourceCall(new DataProviderCommand(_requestId, DataProviderCommandSource.Lightstone,
                        CommandDescriptions.StartCallDescription(DataProviderCommandSource.Lightstone),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
               .ObjectToJson()
               .GetCommandDto(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution));
        }

        private EndingLightstoneDataSourceCall EndCall(object payload, object metadata)
        {
            return new EndingLightstoneDataSourceCall(new DataProviderCommand(_requestId, DataProviderCommandSource.Lightstone,
                        CommandDescriptions.EndCallDescription(DataProviderCommandSource.Lightstone),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
              .ObjectToJson()
              .GetCommandDto(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution));
        }

        private ThrowError Fault(dynamic payload, MetadataContainer metadata)
        {
            return new ThrowError(new DataProviderCommand(_requestId, DataProviderCommandSource.Lightstone,
                        CommandDescriptions.FaultDescription(DataProviderCommandSource.Lightstone), payload, metadata,
                        DateTime.UtcNow,
                        Category.Fault)
              .ObjectToJson()
              .GetCommandDto(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution));
        }

        private RaiseLightstoneSecurityFlag Security(dynamic payload, MetadataContainer metadata)
        {
            return new RaiseLightstoneSecurityFlag(new DataProviderCommand(_requestId, DataProviderCommandSource.Lightstone,
                    CommandDescriptions.SecurityDescription(DataProviderCommandSource.Lightstone),
                    payload,
                    metadata, DateTime.UtcNow, Category.Security)
              .ObjectToJson()
              .GetCommandDto(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution));
        }

        private ConfigureLightstone Configuration(dynamic payload, MetadataContainer metadata)
        {
            return new ConfigureLightstone(new DataProviderCommand(_requestId, DataProviderCommandSource.Lightstone,
                    CommandDescriptions.ConfigurationDescription(DataProviderCommandSource.Lightstone),
                    payload, metadata,
                    DateTime.UtcNow, Category.Configuration)
              .ObjectToJson()
              .GetCommandDto(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution));
        }

        private TransformLightstoneResponse Transformation(dynamic payload, MetadataContainer metadata)
        {
            return new TransformLightstoneResponse(new DataProviderCommand(_requestId, DataProviderCommandSource.Lightstone,
                    CommandDescriptions.TransformationDescription(DataProviderCommandSource.Lightstone),
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
