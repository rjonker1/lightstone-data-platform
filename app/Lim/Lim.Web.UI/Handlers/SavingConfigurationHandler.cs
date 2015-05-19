using System;
using System.Data;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Mappers;

namespace Lim.Web.UI.Handlers
{
    public class SavingConfigurationHandler : IHandleSavingConfiguration
    {
        private readonly IDbConnection _connection;

        public SavingConfigurationHandler(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Handle(InsertApiPushConfiguration command)
        {
            IsSaved = new ApiPushConfigurationMapper(_connection, command.Configuration).InsertUpdate();
        }

        public void Handle(UpdateApiPushConfiguration command)
        {
            throw new NotImplementedException();
        }

        public void Handle(InsertApiPullConfiguration command)
        {
            throw new NotImplementedException();
        }

        public bool IsSaved { get; private set; }
    }
}