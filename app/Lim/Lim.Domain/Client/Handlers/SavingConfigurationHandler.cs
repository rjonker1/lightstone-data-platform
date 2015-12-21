using System;
using Lim.Core;
using Lim.Domain.Pull.Commands;
using Lim.Domain.Push;
using Lim.Domain.Push.Commands;

namespace Lim.Domain.Client.Handlers
{
    public class SavingConfigurationHandler : IHandleSavingConfiguration
    {
        //private readonly IDbConnection _connection;
        private readonly IPersist<PushApiDataPlatformConfiguration> _persistence;

        public SavingConfigurationHandler(IPersist<PushApiDataPlatformConfiguration> persistence)
        {
            _persistence = persistence;
        }

        public void Handle(AddApiPushConfiguration command)
        {
            //IsSaved = new ApiPushCommit(_connection, command.Configuration).Save();
            IsSaved = _persistence.Persist(command.ApiDataPlatformConfiguration);
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