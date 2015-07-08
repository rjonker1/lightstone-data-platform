using System;
using System.Text;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Identifiers;
using EasyNetQ;
using Lace.Shared.Extensions;
using Workflow.Billing.Messages.Publishable;
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
    public class RequestSenderConsumers
    {
        private readonly IEventRepository _repository;
        private readonly IPublishEventMessages _publisher;

        public RequestSenderConsumers(IEventRepository repository, IPublishEventMessages publish)
        {
            _repository = repository;
            _publisher = publish;
        }

        public void Consume(IMessage<SendRequestToDataProviderCommand> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .RequestSentToDataProvider(message.Body.DataProvider, message.Body.Date,
                        message.Body.Connection, message.Body.Payload);

            var @event =
                new RequestToDataProvider(Guid.NewGuid(), request.RequestId, request.DataProvider,
                    request.Date, request.Connection);

            _repository.Add(
                new DataProviderEvent(new EventIndentifier(request.RequestId,
                    new EventPayloadIndentifier(Encoding.UTF8.GetBytes(@event.ObjectToJson()),
                        GetNextSequence(request.RequestId),
                        (DataProviderCommandSource) request.DataProvider.Id,
                        request.CommandType, @event.GetType()))));

            _publisher.SendToBus(@event);
            //new DataProviderEventBus(BusFactory.CreateAdvancedBus("workflow/dataprovider/queue")).Send(@event,
            //    "DataPlatform.DataProvider.Receiver", "DataPlatform.DataProvider.Receiver");
        }

        public void Consume(IMessage<GetResponseFromDataProviderCommmand> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .ResponseReceivedFromDataProvider(message.Body.DataProvider, message.Body.Date,
                        message.Body.Connection, message.Body.Payload);

            var @event =
                new ResponseFromDataProvider(Guid.NewGuid(), request.RequestId, request.DataProvider,
                    request.Date, request.Connection, request.Payload);

            _repository.Add(
                new DataProviderEvent(new EventIndentifier(request.RequestId,
                    new EventPayloadIndentifier(Encoding.UTF8.GetBytes(@event.ObjectToJson()),
                        GetNextSequence(request.RequestId),
                        (DataProviderCommandSource) request.DataProvider.Id,
                        request.CommandType, @event.GetType()))));

            _publisher.SendToBus(@event);
        }

        public void Consume(IMessage<CreateTransactionCommand> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .CreateTransaction(message.Body.PackageId, message.Body.PackageVersion, message.Body.Date,
                        message.Body.UserId, message.Body.ContractId, message.Body.System, message.Body.ContractVersion,
                        message.Body.State, message.Body.AccountNumber, message.Body.PackageCostPrice, message.Body.PackageRecommendedPrice);

            var @event =
                new BillTransactionMessage(request.Package,
                    new UserIdentifier(message.Body.UserId),
                    new RequestIdentifier(message.Body.RequestId, new SystemIdentifier(message.Body.System)),
                    request.Date, message.Body.Id,
                    request.State,
                    new ContractIdentifier(message.Body.ContractId, new VersionIdentifier(message.Body.ContractVersion)),
                    new AccountIdentifier(message.Body.AccountNumber));

            _repository.Add(
                new DataProviderEvent(new EventIndentifier(request.RequestId,
                    new EventPayloadIndentifier(Encoding.UTF8.GetBytes(@event.ObjectToJson()),
                        GetNextSequence(request.RequestId), DataProviderCommandSource.EntryPoint,
                        request.CommandType, @event.GetType()))));

            _publisher.SendToBus(@event);
        }

        public void Consume(IMessage<ReceiveEntryPointRequest> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .EntryPointRequest(message.Body.Date, message.Body.Request, message.Body.Payload);

            var @event =
                new EntryPointReceivedRequest(Guid.NewGuid(), request.Date, request.RequestId,
                    request.Payload, request.RequestContext);

            _repository.Add(
                new DataProviderEvent(new EventIndentifier(request.RequestId,
                    new EventPayloadIndentifier(Encoding.UTF8.GetBytes(@event.ObjectToJson()),
                        GetNextSequence(request.RequestId),
                        (DataProviderCommandSource) request.DataProvider.Id,
                        request.CommandType, @event.GetType()))));

            _publisher.SendToBus(@event);
        }

        public void Consume(IMessage<ReturnEntryPointResponse> message)
        {
            var request =
                Request.InitRequest(message.Body.RequestId)
                    .EntryPointResponse(message.Body.Date,message.Body.State,message.Body.Payload,message.Body.Request);

            var @event =
                new EntryPointReturnedResponse(Guid.NewGuid(), request.RequestId, request.Date, request.Payload,
                    request.State, request.RequestContext);

            _repository.Add(
                new DataProviderEvent(new EventIndentifier(request.RequestId,
                    new EventPayloadIndentifier(Encoding.UTF8.GetBytes(@event.ObjectToJson()),
                        GetNextSequence(request.RequestId),
                        (DataProviderCommandSource)request.DataProvider.Id,
                        request.CommandType, @event.GetType()))));

            _publisher.SendToBus(@event);
        }

        private int GetNextSequence(Guid requestId)
        {
            var current = _repository.Item<EventCommitSequence>(EventCommitSequence.SelectStatement(),
                new {@RequestId = requestId}) ?? EventCommitSequence.NewSequence();
            return current.NextCommitSequence;
        }
    }
}
