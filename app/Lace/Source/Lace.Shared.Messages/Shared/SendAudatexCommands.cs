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

        private StartingAudatexExecution Begin(object payload, MetadataContainer metadata)
        {
            return new StartingAudatexExecution(new DataProviderCommand(_requestId, DataProviderCommandSource.Audatex,
                CommandDescriptions.StartExecutionDescription(DataProviderCommandSource.Audatex),
                payload, metadata, DateTime.UtcNow,
                Category.Performance)
                .ObjectToJson()
                .GetCommandDto(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution));
        }

        private EndingAudatexExecution End(object payload, object metadata)
        {
            return new EndingAudatexExecution(new DataProviderCommand(_requestId, DataProviderCommandSource.Audatex,
                        CommandDescriptions.EndExecutionDescription(DataProviderCommandSource.Audatex),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
                .ObjectToJson()
                .GetCommandDto(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution));
        }

        private StartingAudatexDataSourceCall StartCall(object payload, MetadataContainer metadata)
        {
            return new StartingAudatexDataSourceCall(new DataProviderCommand(_requestId, DataProviderCommandSource.Audatex,
                        CommandDescriptions.StartCallDescription(DataProviderCommandSource.Audatex),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
               .ObjectToJson()
               .GetCommandDto(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution));
        }

        private EndingAudatexDataSourceCall EndCall(object payload, object metadata)
        {
            return new EndingAudatexDataSourceCall(new DataProviderCommand(_requestId, DataProviderCommandSource.Audatex,
                        CommandDescriptions.EndCallDescription(DataProviderCommandSource.Audatex),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
              .ObjectToJson()
              .GetCommandDto(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution));
        }

        private ThrowError Fault(dynamic payload, MetadataContainer metadata)
        {
            return new ThrowError(new DataProviderCommand(_requestId, DataProviderCommandSource.Audatex,
                        CommandDescriptions.FaultDescription(DataProviderCommandSource.Audatex), payload, metadata,
                        DateTime.UtcNow,
                        Category.Fault)
              .ObjectToJson()
              .GetCommandDto(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution));
        }

        private RaiseAudatexSecurityFlag Security(dynamic payload, MetadataContainer metadata)
        {
            return new RaiseAudatexSecurityFlag(new DataProviderCommand(_requestId, DataProviderCommandSource.Audatex,
                    CommandDescriptions.SecurityDescription(DataProviderCommandSource.Audatex),
                    payload,
                    metadata, DateTime.UtcNow, Category.Security)
              .ObjectToJson()
              .GetCommandDto(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution));
        }

        private ConfigureAudatex Configuration(dynamic payload, MetadataContainer metadata)
        {
            return new ConfigureAudatex(new DataProviderCommand(_requestId, DataProviderCommandSource.Audatex,
                    CommandDescriptions.ConfigurationDescription(DataProviderCommandSource.Audatex),
                    payload, metadata,
                    DateTime.UtcNow, Category.Configuration)
              .ObjectToJson()
              .GetCommandDto(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution));
        }

        private TransformAudatexResponse Transformation(dynamic payload, MetadataContainer metadata)
        {
            return new TransformAudatexResponse(new DataProviderCommand(_requestId, DataProviderCommandSource.Audatex,
                    CommandDescriptions.TransformationDescription(DataProviderCommandSource.Audatex),
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
