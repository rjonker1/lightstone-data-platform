using System;
using PackageBuilder.Domain.Entities.DataProviders.Events;
using PackageBuilder.Domain.Entities.DataProviders.ReadModels;
using PackageBuilder.Domain.MessageHandling;
using Raven.Client;

namespace PackageBuilder.Domain.EventHandlers.DataProviders
{
    public class DataProviderUpdatedHandler : AbstractMessageHandler<DataProviderUpdated>
    {
        private readonly IDocumentSession _session;

        public DataProviderUpdatedHandler(IDocumentSession session)
        {
            _session = session;
        }

        public override void Handle(DataProviderUpdated command)
        {
            _session.Store(new DataProvider(Guid.NewGuid(), command.DataProvierId, command.Name, 0d, command.Description, command.Owner));
        }
    }
}
