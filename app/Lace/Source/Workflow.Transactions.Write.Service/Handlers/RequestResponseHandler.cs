using System;
using CommonDomain.Persistence;
using NEventStore;
using NServiceBus;
using Workflow.Lace.Domain.Aggregates;
using Workflow.Lace.Messages.Commands;

namespace Workflow.Transactions.Write.Service.Handlers
{
    public class RequestResponseHandler : IHandleMessages<SendRequestToDataProviderCommand>,
        IHandleMessages<GetResponseFromDataProviderCommmand>, IHandleMessages<CreateTransactionCommand>,
        IHandleMessages<ReceiveEntryPointRequest>, IHandleMessages<ReturnEntryPointResponse>
    {
        private readonly IRepository _repository;

        public RequestResponseHandler()
        {
        }

        public RequestResponseHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(ReceiveEntryPointRequest message)
        {
            var @event = _repository.GetById<Request>(message.RequestId);

            if (@event == null)
            {
                @event = Request.ReceiveRequest(message.RequestId, message.Date, message.Request, message.Payload);
            }
            else
            {
                @event.EntryPointRequest(message.RequestId, message.Date, message.Request, message.Payload);
            }
            
            _repository.Save(@event, Guid.NewGuid());
        }

        public void Handle(ReturnEntryPointResponse message)
        {
            var @event = _repository.GetById<Request>(message.RequestId);

            if (@event == null)
            {
                @event = Request.ReceiveRequest(message.RequestId, message.Date, message.State, message.Payload,
                    message.Request);
            }
            else
            {
                @event.EntryPointResponse(message.RequestId, message.Date, message.State, message.Payload,
                    message.Request);
            }
            
            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(SendRequestToDataProviderCommand message)
        {
            var @event = _repository.GetById<Request>(message.RequestId);

            if (@event == null)
            {
                @event = Request.ReceiveRequest(message.RequestId, message.DataProvider, message.Date,
                    message.Connection, message.Payload);
            }
            else
            {
                @event.RequestSentToDataProvider(message.RequestId, message.DataProvider, message.Date,
                    message.Connection,
                    message.Payload);
            }
           
            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(GetResponseFromDataProviderCommmand message)
        {
            var @event = _repository.GetById<Request>(message.RequestId);
            if (@event == null)
            {
                @event = Request.ReceiveRequest(message.RequestId, message.DataProvider, message.Date,
                    message.Connection, message.Payload);
            }
            else
            {
                @event.ResponseReceivedFromDataProvider(message.RequestId, message.DataProvider, message.Date,
                    message.Connection, message.Payload);
            }

            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(CreateTransactionCommand message)
        {

            var @event = _repository.GetById<Request>(message.RequestId);
            @event.CreateTransaction(message.Id, message.PackageId, message.PackageVersion, message.Date, message.UserId,
                message.RequestId, message.ContractId, message.System, message.ContractVersion, message.State,
                message.AccountNumber);
            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(Request message)
        {
            
        }
    }
}
