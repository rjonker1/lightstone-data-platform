using System;
using Lim.Core;
using Lim.Domain.Dto;
using Lim.Web.UI.Commands;

namespace Lim.Web.UI.Handlers
{
    public class SavingClientHandler : IHandleSavingClient
    {
        private readonly IPersist<ClientDto> _client;

        public bool IsSaved { get; private set; }

        public SavingClientHandler(IPersist<ClientDto> client)
        {
            _client = client;
        }

        public void Handle(AddClient command)
        {
            IsSaved = _client.Persist(command.Client);
        }

        public void Handle(UpdateClient command)
        {
            throw new NotImplementedException();
        }
    }
}