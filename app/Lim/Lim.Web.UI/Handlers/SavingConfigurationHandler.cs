﻿using System;
using Lim.Core;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Models.Api;

namespace Lim.Web.UI.Handlers
{
    public class SavingConfigurationHandler : IHandleSavingConfiguration
    {
        //private readonly IDbConnection _connection;
        private readonly IPersist<PushConfiguration> _persistence;

        public SavingConfigurationHandler(IPersist<PushConfiguration> persistence)
        {
            _persistence = persistence;
        }

        public void Handle(AddApiPushConfiguration command)
        {
            //IsSaved = new ApiPushCommit(_connection, command.Configuration).Save();
            IsSaved = _persistence.Persist(command.Configuration);
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