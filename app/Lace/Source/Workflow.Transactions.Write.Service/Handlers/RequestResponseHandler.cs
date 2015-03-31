using System;
using CommonDomain.Persistence;
using NServiceBus;
using Workflow.Lace.Domain.Aggregates;
using Workflow.Lace.Messages.Commands;

namespace Workflow.Transactions.Write.Service.Handlers
{
    public class RequestResponseHandler : IHandleMessages<SendRequestToDataProviderCommand>,
        IHandleMessages<GetResponseFromDataProviderCommmand>, IHandleMessages<CreateTransactionCommand>
    {
        private readonly IRepository _repository;

        public RequestResponseHandler()
        {
        }

        public RequestResponseHandler(IRepository repository)
        {
            _repository = repository;
        }


        public void Handle(SendRequestToDataProviderCommand message)
        {
            var @event = _repository.GetById<Request>(message.RequestId) ??
                         Request.ReceiveRequest(message.RequestId, message.DataProvider, message.Date, message.Action,
                             message.State, message.Connection, message.ConnectionType);

            @event.RequestSentToDataProvider(message.Id, message.RequestId, message.DataProvider, message.Date,
                message.ConnectionType, message.Connection, message.Action, message.State);

            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(GetResponseFromDataProviderCommmand message)
        {
            var @event = _repository.GetById<Request>(message.RequestId) ??
                        Request.ReceiveRequest(message.RequestId, message.DataProvider, message.Date, message.Action,
                            message.State, message.Connection, message.ConnectionType);
            @event.ResponseReceivedFromDataProvider(message.Id, message.RequestId, message.DataProvider, message.Date,
                message.Connection, message.ConnectionType, message.Action, message.State);

            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(CreateTransactionCommand message)
        {
            var @event = _repository.GetById<Request>(message.RequestId);
            @event.CreateTransaction(message.Id, message.PackageId, message.PackageVersion, message.Date, message.UserId,
                message.RequestId, message.ContractId, message.System, message.ContractVersion, message.State);

            _repository.Save(@event, Guid.NewGuid(), null);
        }
    }
}
