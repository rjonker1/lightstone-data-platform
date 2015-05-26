using System;
using System.Data;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Mappers;

namespace Lim.Web.UI.Handlers
{
    public class SavingClientHandler : IHandleSavingClient
    {
        private readonly IDbConnection _connection;

        public bool IsSaved { get; private set; }

        public SavingClientHandler(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Handle(AddClient command)
        {
            IsSaved = new ClientMapper(_connection, command.Client).Save();
        }

        public void Handle(UpdateClient command)
        {
            throw new NotImplementedException();
        }
    }
}