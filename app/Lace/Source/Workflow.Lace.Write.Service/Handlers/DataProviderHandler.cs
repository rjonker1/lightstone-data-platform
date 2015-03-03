using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDomain.Persistence;
using NServiceBus;
using Workflow.Lace.Messages.Commands;

namespace Workflow.Lace.Write.Service.Handlers
{
    public class DataProviderCommandHandler : IHandleMessages<ReceiveRequestCommand>, IHandleMessages<ReceiveResponseCommand>
    {
        private readonly IRepository _repository;

        public DataProviderCommandHandler()
        {
        }

        public DataProviderCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(ReceiveResponseCommand message)
        {
            throw new NotImplementedException();
        }

        public void Handle(ReceiveRequestCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
