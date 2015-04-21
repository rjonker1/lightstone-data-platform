using System;
using CommonDomain.Persistence;
using NServiceBus;
using Workflow.Lace.Domain.Aggregates;
using Workflow.Lace.Messages.Commands;
using Workflow.Lace.Messages.Core;

namespace Workflow.Transactions.Write.Service.Handlers
{
    public class RequestContextHandler : IHandleMessages<RaisingSecurityFlagCommand>,
        IHandleMessages<ConfiguringDataProviderCommand>, IHandleMessages<TransformingDataProviderResponseCommand>,
        IHandleMessages<ErrorInDataProviderCommand>, IHandleMessages<StartingCallCommand>,
        IHandleMessages<EndingCallCommand>
    {
        private readonly IRepository _repository;

        public RequestContextHandler()
        {
        }

        public RequestContextHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(RaisingSecurityFlagCommand message)
        {
            var @event = _repository.GetById<Request>(message.RequestId);
            @event.RaiseSecurityFlag(message.Id, message.RequestId, message.DataProvider, message.Date,
                CommandType.Security, message.MetaData, message.Payload, message.Message);

            _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(ConfiguringDataProviderCommand message)
        {
            var @event = _repository.GetById<Request>(message.RequestId);
            @event.RaiseSecurityFlag(message.Id, message.RequestId, message.DataProvider, message.Date,
                CommandType.Configuration, message.MetaData, message.Payload, message.Message);

          _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(TransformingDataProviderResponseCommand message)
        {
            var @event = _repository.GetById<Request>(message.RequestId);
            @event.RaiseSecurityFlag(message.Id, message.RequestId, message.DataProvider, message.Date,
                CommandType.Configuration, message.MetaData, message.Payload, message.Message);

           _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(ErrorInDataProviderCommand message)
        {
            var @event = _repository.GetById<Request>(message.RequestId);
            @event.RaiseSecurityFlag(message.Id, message.RequestId, message.DataProvider, message.Date,
                CommandType.Fault, message.MetaData, message.Payload, message.Message);
             _repository.Save(@event, Guid.NewGuid(), null);
        }


        public void Handle(StartingCallCommand message)
        {
            var @event = _repository.GetById<Request>(message.RequestId);
            @event.RaiseSecurityFlag(message.Id, message.RequestId, message.DataProvider, message.Date,
                CommandType.StartSourceCall, message.MetaData, message.Payload, message.Message);

          _repository.Save(@event, Guid.NewGuid(), null);
        }

        public void Handle(EndingCallCommand message)
        {
            var @event = _repository.GetById<Request>(message.RequestId);
            @event.RaiseSecurityFlag(message.Id, message.RequestId, message.DataProvider, message.Date,
                CommandType.EndSourceCall, message.MetaData, message.Payload, message.Message);

           _repository.Save(@event, Guid.NewGuid(), null);
        }

    }
}
