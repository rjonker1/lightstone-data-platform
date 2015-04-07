using System;
using System.Threading.Tasks;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Shared.Extensions;
using NServiceBus;
using Workflow.Lace.Messages.Commands;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Extensions;
using Workflow.Lace.Messages.Shared;

namespace Workflow.Lace.Messages.Infrastructure
{
    public interface IBuildMonitoringCommands
    {
        void Begin(object payload, MetadataContainer metadata, DisplayOrder displayOrder);
        void End(object payload, object metadata, DisplayOrder displayOrder);
        void StartCall(object payload, MetadataContainer metadata, DisplayOrder displayOrder);
        void EndCall(object payload, object metadata, DisplayOrder displayOrder);
        void Fault(dynamic payload, MetadataContainer metadata, DisplayOrder displayOrder);
        void Security(dynamic payload, MetadataContainer metadata, DisplayOrder displayOrder);
        void Configuration(dynamic payload, MetadataContainer metadata, DisplayOrder displayOrder);
        void Transformation(dynamic payload, MetadataContainer metadata, DisplayOrder displayOrder);
        void SendToBus<T>(T payload, dynamic metadata, CommandType type) where T : class;
    }

    public class MonitoringCommandBuilder : IBuildMonitoringCommands
    {
        private readonly IPublishCommandMessages _publisher;
        private readonly ILog _log;
        private readonly int _orderOfExecution;
        private readonly Guid _requestId;
        private readonly DataProviderCommandSource _source;
        public MonitoringCommandBuilder(IBus bus, Guid requestAggregateId, int orderOfExecution,
            DataProviderCommandSource source)
        {
            _log = LogManager.GetLogger(GetType());
            _publisher = new WorkflowCommandPublisher(bus, _log);
            _requestId = requestAggregateId;
            _orderOfExecution = orderOfExecution;
            _source = source;
        }

        public void Begin(object payload, MetadataContainer metadata, DisplayOrder displayOrder)
        {
            var command = new
            {
                StartIvidExecution =
                    new StartIvidExecution(_requestId, _source,
                        CommandDescriptions.StartExecutionDescription(_source),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            command.ObjectToJson()
                .GetCommand(_requestId, (int) displayOrder, _orderOfExecution)
                .SendToBus(_publisher, _log);
        }

        public void End(object payload, object metadata, DisplayOrder displayOrder)
        {
            var command = new
            {
                EndIvidExecution =
                    new EndIvidExecution(_requestId, _source,
                        CommandDescriptions.EndExecutionDescription(_source),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            command.ObjectToJson()
                .GetCommand(_requestId, (int) displayOrder, _orderOfExecution)
                .SendToBus(_publisher, _log);
        }

        public void StartCall(object payload, MetadataContainer metadata, DisplayOrder displayOrder)
        {
            var command = new
            {
                StartIvidDataSourceCall =
                    new StartIvidDataSourceCall(_requestId, _source,
                        CommandDescriptions.StartCallDescription(_source),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            command.ObjectToJson()
                .GetCommand(_requestId, (int) displayOrder, _orderOfExecution)
                .SendToBus(_publisher, _log);
        }

        public void EndCall(object payload, object metadata, DisplayOrder displayOrder)
        {
            var command = new
            {
                EndIvidDataSourceCall =
                    new EndIvidDataSourceCall(_requestId, _source,
                        CommandDescriptions.EndCallDescription(_source),
                        payload, metadata, DateTime.UtcNow,
                        Category.Performance)
            };

            command.ObjectToJson()
                .GetCommand(_requestId, (int) displayOrder, _orderOfExecution)
                .SendToBus(_publisher, _log);
        }

        public void Fault(dynamic payload, MetadataContainer metadata, DisplayOrder displayOrder)
        {

            var command = new
            {
                ThrowError =
                    new ThrowError(_requestId, _source,
                        CommandDescriptions.FaultDescription(_source), payload, metadata,
                        DateTime.UtcNow,
                        Category.Fault)
            };

            command.ObjectToJson().GetCommand(_requestId, (int) displayOrder, _orderOfExecution)
                .SendToBus(_publisher, _log);
        }

        public void Security(dynamic payload, MetadataContainer metadata, DisplayOrder displayOrder)
        {
            var command = new
            {
                IvidSecurityFlag = new RaiseIvidSecurityFlag(_requestId, _source,
                    CommandDescriptions.SecurityDescription(_source),
                    payload,
                    metadata, DateTime.UtcNow, Category.Security)
            };

            command.ObjectToJson()
                .GetCommand(_requestId, (int) displayOrder, _orderOfExecution)
                .SendToBus(_publisher, _log);
        }

        public void Configuration(dynamic payload, MetadataContainer metadata, DisplayOrder displayOrder)
        {

            var command = new
            {
                ConfigureIvid = new ConfigureIvid(_requestId, _source,
                    CommandDescriptions.ConfigurationDescription(_source),
                    payload, metadata,
                    DateTime.UtcNow, Category.Configuration)
            };

            command.ObjectToJson()
                .GetCommand(_requestId, (int) displayOrder, _orderOfExecution)
                .SendToBus(_publisher, _log);
        }

        public void Transformation(dynamic payload, MetadataContainer metadata, DisplayOrder displayOrder)
        {

            var command = new
            {
                TransformIvidResponse = new TransformIvidResponse(_requestId, _source,
                    CommandDescriptions.TransformationDescription(_source),
                    payload, metadata,
                    DateTime.UtcNow, Category.Configuration)
            };

            command.ObjectToJson()
                .GetCommand(_requestId, (int) displayOrder, _orderOfExecution)
                .SendToBus(_publisher, _log);
        }

        public void SendToBus<T>(T payload, dynamic metadata, CommandType type) where T : class
        {
            Task.Run(() =>
            {
                switch (type)
                {
                    case CommandType.Fault:
                        Fault(payload, new MetadataContainer(metadata), DisplayOrder.InTheMiddle);
                        break;
                    case CommandType.Accounting:
                        break;
                    case CommandType.Configuration:
                        Configuration(payload, new MetadataContainer(metadata), DisplayOrder.InTheMiddle);
                        break;
                    case CommandType.Security:
                        Security(payload, new MetadataContainer(metadata), DisplayOrder.InTheMiddle);
                        break;
                    case CommandType.BeginExecution:
                        Begin(payload, new MetadataContainer(metadata), DisplayOrder.FirstThing);
                        break;
                    case CommandType.EndExecution:
                        End(payload, new MetadataContainer(metadata), DisplayOrder.FirstThing);
                        break;
                    case CommandType.StartSourceCall:
                        StartCall(payload, new MetadataContainer(metadata), DisplayOrder.FirstThing);
                        break;
                    case CommandType.EndSourceCall:
                        EndCall(payload, new MetadataContainer(metadata), DisplayOrder.FirstThing);
                        break;
                    case CommandType.Transformation:
                        Transformation(payload, new MetadataContainer(metadata), DisplayOrder.InTheMiddle);
                        break;
                }
            });
        }
    }
}
