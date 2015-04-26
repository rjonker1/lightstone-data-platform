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
using Workflow.Lace.Persistence;
using Workflow.Transactions.Sender.Service.Views;

namespace Workflow.Transactions.Sender.Service.Handlers
{
    public class ContextSenderConsumers
    {
        private readonly ICommandRepository _repository;
        private readonly IPublishCommandMessages _publisher;

        public ContextSenderConsumers(ICommandRepository repository, IPublishCommandMessages publish)
        {
            _repository = repository;
            _publisher = publish;
        }

        public void Consume(IMessage<RaisingSecurityFlagCommand> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .RaiseSecurityFlag(message.Body.Id, message.Body.DataProvider, message.Body.Date,
                        CommandType.Security, message.Body.MetaData, message.Body.Payload, message.Body.Message);

            var @event =
                new SecurityFlagRaised(Guid.NewGuid(), request.RequestId, (DataProviderCommandSource)request.DataProvider.Id,
                    request.Date, request.CommandType,request.Payload);

            _repository.Add(
                new DataProviderCommand(new CommandIndentifier(request.RequestId,
                    new CommandPayloadIndentifier(Encoding.UTF8.GetBytes(request.ObjectToJson()),
                        GetNextSequence(request.RequestId),
                        (DataProviderCommandSource) request.DataProvider.Id,
                        request.CommandType, @event.GetType()))));

            _publisher.SendToBus(@event);
        }

        public void Consume(IMessage<ConfiguringDataProviderCommand> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .Configuration(message.Body.Id, message.Body.DataProvider, message.Body.Date,
                        CommandType.Security, message.Body.MetaData, message.Body.Payload, message.Body.Message);

            var @event =
                new DataProviderConfigured(Guid.NewGuid(), request.RequestId, (DataProviderCommandSource)request.DataProvider.Id,
                    request.Date, request.CommandType, request.Payload);

            _repository.Add(
                new DataProviderCommand(new CommandIndentifier(request.RequestId,
                    new CommandPayloadIndentifier(Encoding.UTF8.GetBytes(request.ObjectToJson()),
                        GetNextSequence(request.RequestId),
                        (DataProviderCommandSource)request.DataProvider.Id,
                        request.CommandType, @event.GetType()))));

            _publisher.SendToBus(@event);
        }

        public void Consume(IMessage<TransformingDataProviderResponseCommand> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .Transformation(message.Body.Id, message.Body.DataProvider, message.Body.Date,
                        CommandType.Security, message.Body.MetaData, message.Body.Payload, message.Body.Message);

            var @event =
                new DataProviderResponseTransformed(Guid.NewGuid(), request.RequestId, (DataProviderCommandSource)request.DataProvider.Id,
                    request.Date, request.CommandType, request.Payload);

            _repository.Add(
                new DataProviderCommand(new CommandIndentifier(request.RequestId,
                    new CommandPayloadIndentifier(Encoding.UTF8.GetBytes(request.ObjectToJson()),
                        GetNextSequence(request.RequestId),
                        (DataProviderCommandSource)request.DataProvider.Id,
                        request.CommandType, @event.GetType()))));

            _publisher.SendToBus(@event);
        }

        public void Consume(IMessage<ErrorInDataProviderCommand> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .Error(message.Body.Id, message.Body.DataProvider, message.Body.Date,
                        CommandType.Security, message.Body.MetaData, message.Body.Payload, message.Body.Message);

            var @event =
                new DataProviderError(Guid.NewGuid(), request.RequestId, (DataProviderCommandSource)request.DataProvider.Id,
                    request.Date, request.CommandType, request.Payload);

            _repository.Add(
                new DataProviderCommand(new CommandIndentifier(request.RequestId,
                    new CommandPayloadIndentifier(Encoding.UTF8.GetBytes(request.ObjectToJson()),
                        GetNextSequence(request.RequestId),
                        (DataProviderCommandSource)request.DataProvider.Id,
                        request.CommandType, @event.GetType()))));

            _publisher.SendToBus(@event);
        }

        public void Consume(IMessage<StartingCallCommand> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .StartCall(message.Body.Id, message.Body.DataProvider, message.Body.Date,
                        CommandType.Security, message.Body.MetaData, message.Body.Payload, message.Body.Message);

            var @event =
                new DataProviderCallStarted(Guid.NewGuid(), request.RequestId, (DataProviderCommandSource)request.DataProvider.Id,
                    request.Date, request.CommandType, request.Payload);

            _repository.Add(
                new DataProviderCommand(new CommandIndentifier(request.RequestId,
                    new CommandPayloadIndentifier(Encoding.UTF8.GetBytes(request.ObjectToJson()),
                        GetNextSequence(request.RequestId),
                        (DataProviderCommandSource)request.DataProvider.Id,
                        request.CommandType, @event.GetType()))));

            _publisher.SendToBus(@event);
        }

        public void Consume(IMessage<EndingCallCommand> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .EndCall(message.Body.Id, message.Body.DataProvider, message.Body.Date,
                        CommandType.Security, message.Body.MetaData, message.Body.Payload, message.Body.Message);

            var @event =
                new DataProviderCallEnded(Guid.NewGuid(), request.RequestId,
                    (DataProviderCommandSource) request.DataProvider.Id,
                    request.Date, request.CommandType, request.Payload);

            _repository.Add(
                new DataProviderCommand(new CommandIndentifier(request.RequestId,
                    new CommandPayloadIndentifier(Encoding.UTF8.GetBytes(request.ObjectToJson()),
                        GetNextSequence(request.RequestId),
                        (DataProviderCommandSource) request.DataProvider.Id,
                        request.CommandType, @event.GetType()))));

            _publisher.SendToBus(@event);
        }

        private int GetNextSequence(Guid requestId)
        {
            var current = _repository.Item<CommandCommitSequence>(CommandCommitSequence.SelectStatement(),
                new { @RequestId = requestId }) ?? CommandCommitSequence.NewSequence();
            return current.NextCommitSequence;
        }
    }
}
