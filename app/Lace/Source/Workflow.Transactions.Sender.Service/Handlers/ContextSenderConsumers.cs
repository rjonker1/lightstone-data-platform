using System;
using System.Text;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Lace.Shared.Extensions;
using Workflow.Lace.Domain;
using Workflow.Lace.Domain.Aggregates;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Commands;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Events;
using Workflow.Lace.Messages.Indicators;
using Workflow.Lace.Messages.Infrastructure;
using Workflow.Lace.Persistence;
using Workflow.Transactions.Sender.Service.Views;

namespace Workflow.Transactions.Sender.Service.Handlers
{
    public class ContextSenderConsumers
    {
        private readonly IEventRepository _repository;
        private readonly IPublishEventMessages _publisher;

        public ContextSenderConsumers(IEventRepository repository, IPublishEventMessages publish)
        {
            _repository = repository;
            _publisher = publish;
        }

        public void Consume(IMessage<RaisingSecurityFlagCommand> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .RaiseSecurityFlag(message.Body.Id, message.Body.DataProvider, message.Body.Date,
                        CommandType.Security, message.Body.MetaData, message.Body.Payload, message.Body.Message, message.Body.BillNoRecords);

            var @event =
                new SecurityFlagRaised(Guid.NewGuid(), request.RequestId, (DataProviderCommandSource)request.DataProvider.Id,
                    request.Date, request.CommandType,request.Payload);

            _repository.Add(
                new DataProviderEvent(new EventIndentifier(request.RequestId,
                    new EventPayloadIndentifier(Encoding.UTF8.GetBytes(@event.ObjectToJson()),
                        GetNextSequence(request.RequestId),
                        (DataProviderCommandSource) request.DataProvider.Id,
                        request.CommandType, @event.GetType()),request.Date)));

            _publisher.SendToBus(@event);
        }

        public void Consume(IMessage<ConfiguringDataProviderCommand> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .Configuration(message.Body.Id, message.Body.DataProvider, message.Body.Date,
                        CommandType.Configuration, message.Body.MetaData, message.Body.Payload, message.Body.Message, message.Body.BillNoRecords);

            var @event =
                new DataProviderConfigured(Guid.NewGuid(), request.RequestId, (DataProviderCommandSource)request.DataProvider.Id,
                    request.Date, request.CommandType, request.Payload);

            _repository.Add(
                new DataProviderEvent(new EventIndentifier(request.RequestId,
                    new EventPayloadIndentifier(Encoding.UTF8.GetBytes(@event.ObjectToJson()),
                        GetNextSequence(request.RequestId),
                        (DataProviderCommandSource)request.DataProvider.Id,
                        request.CommandType, @event.GetType()), request.Date)));

            _publisher.SendToBus(@event);
        }

        public void Consume(IMessage<TransformingDataProviderResponseCommand> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .Transformation(message.Body.Id, message.Body.DataProvider, message.Body.Date,
                        CommandType.Transformation, message.Body.MetaData, message.Body.Payload, message.Body.Message, message.Body.BillNoRecords);

            var @event =
                new DataProviderResponseTransformed(Guid.NewGuid(), request.RequestId, (DataProviderCommandSource)request.DataProvider.Id,
                    request.Date, request.CommandType, request.Payload);

            _repository.Add(
                new DataProviderEvent(new EventIndentifier(request.RequestId,
                    new EventPayloadIndentifier(Encoding.UTF8.GetBytes(@event.ObjectToJson()),
                        GetNextSequence(request.RequestId),
                        (DataProviderCommandSource)request.DataProvider.Id,
                        request.CommandType, @event.GetType()), request.Date)));

            _publisher.SendToBus(@event);
        }

        public void Consume(IMessage<ErrorInDataProviderCommand> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .Error(message.Body.Id, message.Body.DataProvider, message.Body.Date,
                        CommandType.Error, message.Body.MetaData, message.Body.Payload, message.Body.Message, message.Body.BillNoRecords);

            var @event =
                new DataProviderError(Guid.NewGuid(), request.RequestId, (DataProviderCommandSource)request.DataProvider.Id,
                    request.Date, request.CommandType, request.Payload);

            _repository.Add(
                new DataProviderEvent(new EventIndentifier(request.RequestId,
                    new EventPayloadIndentifier(Encoding.UTF8.GetBytes(@event.ObjectToJson()),
                        GetNextSequence(request.RequestId),
                        (DataProviderCommandSource)request.DataProvider.Id,
                        request.CommandType, @event.GetType()), request.Date)));

            _publisher.SendToBus(@event);
        }

        public void Consume(IMessage<StartingCallCommand> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .StartCall(message.Body.Id, message.Body.DataProvider, message.Body.Date,
                        CommandType.StartSourceCall, message.Body.MetaData, message.Body.Payload, message.Body.Message, message.Body.BillNoRecords);

            var @event =
                new DataProviderCallStarted(Guid.NewGuid(), request.RequestId, (DataProviderCommandSource)request.DataProvider.Id,
                    request.Date, request.CommandType, request.Payload);

            _repository.Add(
                new DataProviderEvent(new EventIndentifier(request.RequestId,
                    new EventPayloadIndentifier(Encoding.UTF8.GetBytes(@event.ObjectToJson()),
                        GetNextSequence(request.RequestId),
                        (DataProviderCommandSource)request.DataProvider.Id,
                        request.CommandType, @event.GetType()), request.Date)));

            _publisher.SendToBus(@event);
        }

        public void Consume(IMessage<EndingCallCommand> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .EndCall(message.Body.Id, message.Body.DataProvider, message.Body.Date,
                        CommandType.EndSourceCall, message.Body.MetaData, message.Body.Payload, message.Body.Message, message.Body.BillNoRecords);

            var @event =
                new DataProviderCallEnded(Guid.NewGuid(), request.RequestId,
                    (DataProviderCommandSource) request.DataProvider.Id,
                    request.Date, request.CommandType, request.Payload);

            _publisher.SendToBus(@event);

            _repository.Add(
                new DataProviderEvent(new EventIndentifier(request.RequestId,
                    new EventPayloadIndentifier(Encoding.UTF8.GetBytes(@event.ObjectToJson()),
                        GetNextSequence(request.RequestId),
                        (DataProviderCommandSource) request.DataProvider.Id,
                        request.CommandType, @event.GetType()), request.Date)));

            var indicator = new ExecutionDetailForDataProvider(request.RequestId,
                new CommandTypeIdentifier((short) CommandType.EndSourceCall, CommandType.EndSourceCall.ToString()),
                new DataProviderIdentifier((DataProviderCommandSource) request.DataProvider.Id),
                message.Body.MetaData.JsonToObject<PerformanceMetadata>().Results.ElapsedTime.ToString());

            _publisher.SendToBus(indicator);
        }

        private int GetNextSequence(Guid requestId)
        {
            var current = _repository.Item<EventCommitSequence>(EventCommitSequence.SelectStatement(),
                new { @RequestId = requestId }) ?? EventCommitSequence.NewSequence();
            return current.NextCommitSequence;
        }
    }
}
