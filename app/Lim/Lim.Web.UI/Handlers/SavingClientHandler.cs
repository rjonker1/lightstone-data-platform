using System;
using Lim.Domain.Dto;
using Lim.Domain.Entities.Contracts;
using Lim.Web.UI.Commands;

namespace Lim.Web.UI.Handlers
{
    public class SavingClientHandler : IHandleSavingClient
    {
        //private readonly IDbConnection _connection;
        private readonly IPersistObject<ClientDto> _client;

        public bool IsSaved { get; private set; }

        public SavingClientHandler(IPersistObject<ClientDto> client)
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