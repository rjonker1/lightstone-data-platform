using PackageBuilder.Domain.Entities.DataProviders.Events;
using PackageBuilder.Domain.MessageHandling;
using PackageBuilder.Domain.Models;
using Raven.Client;

namespace PackageBuilder.Domain.EventHandlers
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
                Created = command.Created,
                Version = 1
            };

            _session.Store(read);
            _session.SaveChanges();
        }
    }
}
