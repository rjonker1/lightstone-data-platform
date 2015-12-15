using System;
using Lim.Core;
using Lim.Domain.Client.Commands;
using Lim.Dtos;

namespace Lim.Domain.Client.Handlers
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