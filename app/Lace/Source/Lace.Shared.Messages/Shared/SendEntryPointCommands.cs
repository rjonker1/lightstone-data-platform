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
        private readonly ILog _log;
        private readonly int _orderOfExecution;

        private readonly Guid _requestId;

        public SendEntryPointCommands(IBus bus, Guid requestAggregateId, int orderOfExecution)
        {
            _publisher = new CommandPublisher(bus);
            _requestId = requestAggregateId;
            _orderOfExecution = orderOfExecution;
            _log = LogManager.GetLogger(GetType());
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

        private DataProviderMonitoringCommand Begin(object payload, MetadataContainer metadata)
        {
            var command = new
            {
                EntryPointReceivingRequest =
                    new EntryPointReceivingRequest(_requestId, DataProviderCommandSource.EntryPoint,
                        CommandDescriptions.StartExecutionDescription(DataProviderCommandSource.EntryPoint),
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
                EntryPointProcessedAndReturningRequest =
                    new EntryPointProcessedAndReturningRequest(_requestId, DataProviderCommandSource.EntryPoint,
                        CommandDescriptions.StartExecutionDescription(DataProviderCommandSource.EntryPoint),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            var cmd = command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.FirstThing, _orderOfExecution);
            return cmd;
        }

        public DataProviderMonitoringCommand Fault(dynamic payload, MetadataContainer metadata)
        {
            var command = new
            {
                ThrowError =
                    new ThrowError(_requestId, DataProviderCommandSource.EntryPoint,
                        CommandDescriptions.FaultDescription(DataProviderCommandSource.EntryPoint), payload, metadata,
                        DateTime.UtcNow,
                        Category.Fault)
            };

            return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.InTheMiddle, _orderOfExecution);
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
