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

        public void Handle(AddApiPushConfiguration command)
        {
            IsSaved = new ApiPushMapper(_connection, command.Configuration).Save();
        }

        public void Handle(UpdateApiPushConfiguration command)
        {
            throw new NotImplementedException();
        }

        public void Handle(AddApiPullConfiguration command)
        {
            throw new NotImplementedException();
        }

        public bool IsSaved { get; private set; }
    }
}