using System;
using PackageBuilder.Domain.Entities.Packages.Events;
using PackageBuilder.Domain.Entities.Packages.ReadModels;
using PackageBuilder.Domain.MessageHandling;
using Raven.Client;

namespace PackageBuilder.Domain.EventHandlers.Packages
{
    public class PackageCreatedHandler : AbstractMessageHandler<PackageCreated>
    {
        private readonly IDocumentSession _session;

        public PackageCreatedHandler(IDocumentSession session)
        {
            _session = session;
        }

        public override void Handle(PackageCreated command)
        {
            _session.Store(new Package(Guid.NewGuid(), command.Id, command.Name, null, command.Owner));
        }
    }
}
