
using System;
using PackageBuilder.Domain.Entities.DataProviders.Events;
using PackageBuilder.Domain.MessageHandling;
using PackageBuilder.Domain.Models;
using Raven.Client;

namespace PackageBuilder.Domain.EventHandlers
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

            Guid id = new Guid();

            var update = new ReadDataProvider
            {
                Id = id,
                DataProviderId = command.DataProvierId,
                Name = command.Name,
                Version = command.Version,
                Created = command.Created,
                Edited = command.Edited
            };

            _session.Store(update);
            _session.SaveChanges();
        }

    }
}
