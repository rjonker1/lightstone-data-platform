using System;
using CommonDomain.Persistence;
using NServiceBus;
using Workflow.Lace.Domain.Aggregates;
using Workflow.Lace.Messages.Commands;

namespace Workflow.Lace.Write.Service.Handlers
{
    public class RequestResponseHandler : IHandleMessages<ReceiveRequestCommand>,
        IHandleMessages<ReceiveResponseFromDataProviderCommand>, IHandleMessages<SendRequestToDataProviderCommand>,
        IHandleMessages<ReturnResponseCommmand>
    {
        private readonly IRepository _repository;

        public RequestResponseHandler()
        {
        }

        public RequestResponseHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(ReceiveResponseFromDataProviderCommand message)
        {
            var @event = _repository.GetById<Request>(message.RequestId);
            @event.ResponseReceivedFromDataProvider(message.Id, message.RequestId, message.ResponseId,
                message.DataProvider,
                message.ResponsePayload, message.Date);

            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(ReceiveRequestCommand message)
        {
            var @event = Request.ReceiveRequest(message.Id, message.Date);
            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(SendRequestToDataProviderCommand message)
        {
            var @event = _repository.GetById<Request>(message.RequestId);
            @event.RequestSentToDataProvider(message.Id, message.RequestId, message.DataProvider,
                message.RequestPayload, message.Date, message.ConnectionType, message.Connection);

            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(ReturnResponseCommmand message)
        {
            var @event = _repository.GetById<Request>(message.RequestId);
            @event.ReturnResponse(message.Id, message.RequestId, message.Date);

            _repository.Save(@event, Guid.NewGuid(), null);
        }
    }
}
