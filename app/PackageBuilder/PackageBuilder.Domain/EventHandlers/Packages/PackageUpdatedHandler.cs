using System;
using PackageBuilder.Domain.Entities.DataProviders.Events;
using PackageBuilder.Domain.Entities.DataProviders.ReadModels;
using PackageBuilder.Domain.MessageHandling;
using Raven.Client;

namespace PackageBuilder.Domain.EventHandlers.Packages
{
    public class PackageUpdatedHandler : AbstractMessageHandler<DataProviderUpdated>
    {
        private readonly IDocumentSession _session;

        public PackageUpdatedHandler(IDocumentSession session)
        {
            _session = session;
        }

        public override void Handle(DataProviderUpdated command)
        {
            var update = new ReadDataProvider
            {
                Id = Guid.NewGuid(),
                DataProviderId = command.DataProvierId,
                Name = command.Name,
                Version = command.Version,
                Created = command.Created,
                Edited = command.Edited
            };

            _session.Store(update);
        }
    }
}
