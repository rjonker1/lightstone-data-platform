﻿using PackageBuilder.Domain.DataProviders.Events;
using PackageBuilder.Domain.MessageHandling;
using PackageBuilder.Domain.Models;
using Raven.Client;

namespace PackageBuilder.Domain.DataProviders.Commands.Handlers
{
    public class DataProviderCreatedHandler : AbstractMessageHandler<DataProviderCreated>
    {
        private readonly IDocumentSession _session;

        public DataProviderCreatedHandler(IDocumentSession session)
        {
            _session = session;
        }

        public override void Handle(DataProviderCreated command)
        {
            var read = new ReadDataProvider
            {
                Id = command.Id,
                Name = command.Name,
                Version = 1
            };

            _session.Store(read);
            _session.SaveChanges();
        }
    }
}
