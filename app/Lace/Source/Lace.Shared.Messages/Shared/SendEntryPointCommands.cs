using System;
using System.Threading.Tasks;
using Common.Logging;
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
    public class SendEntryPointCommands : ISendCommandsToBus
    {
        private readonly IPublishCommandMessages _publisher;
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        private readonly int _orderOfExecution;

        private readonly Guid _requestId;

        public SendEntryPointCommands(IBus bus, Guid requestAggregateId, int orderOfExecution)
        {
            _publisher = new CommandPublisher(bus);
            _requestId = requestAggregateId;
            _orderOfExecution = orderOfExecution;
        }

        public void Send(CommandType commandType, dynamic payload, dynamic metadata)
        {
            SendToBus(payload, metadata, commandType);
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
            throw new NotImplementedException();
        }

        public void EndCall(dynamic payload, DataProviderStopWatch stopWatch)
        {
            throw new NotImplementedException();
        }

        private DataProviderCommandEnvelope Begin(object payload, MetadataContainer metadata)
        {
            var command = new
            {
                EntryPointReceivedRequest =
                    new EntryPointReceivedRequest(_requestId, DataProviderCommandSource.EntryPoint,
                        "Receiving Request in the Data Provider Entry Point", payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, 1, _orderOfExecution);
        }

        private DataProviderCommandEnvelope End(object payload, object metadata)
        {
            var command = new
            {
                EntryPointFinishedProcessingRequest =
                    new EntryPointFinishedProcessingRequest(_requestId, DataProviderCommandSource.EntryPoint,
                        "End Proccessing Request in Entry Point", payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, 3, _orderOfExecution);
        }

        public DataProviderCommandEnvelope Fault(dynamic payload, MetadataContainer metadata)
        {
            var command = new
            {
                ErrorThrown =
                    new ErrorThrown(_requestId, DataProviderCommandSource.EntryPoint,
                        "An error occurred in the entry point while processing the request", payload, metadata,
                        DateTime.UtcNow,
                        Category.Performance)
            };

            return command.ObjectToJson().GetCommand(_requestId, 2, _orderOfExecution);
        }

        private void Security(dynamic payload, MetadataContainer metadata)
        {
            throw new NotImplementedException();
        }

        private void Configuration(dynamic payload, MetadataContainer metadata)
        {
            throw new NotImplementedException();
        }

        private void Transformation(dynamic payload, MetadataContainer metadata)
        {
            throw new NotImplementedException();
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
                        break;
                    case CommandType.Transformation:
                        break;
                    case CommandType.Security:
                        break;
                    case CommandType.BeginExecution:
                        break;
                    case CommandType.EndExecution:
                        break;
                    case CommandType.StartSourceCall:
                        break;
                    case CommandType.EndSourceCall:
                        break;

                }
            });
        }
    }
}
