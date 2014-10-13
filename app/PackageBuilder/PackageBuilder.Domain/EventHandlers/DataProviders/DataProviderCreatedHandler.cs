using PackageBuilder.Domain.Entities.DataProviders.Events;
using PackageBuilder.Domain.Entities.DataProviders.ReadModels;
using PackageBuilder.Domain.MessageHandling;
using Raven.Client;

namespace PackageBuilder.Domain.EventHandlers.DataProviders
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
                DataProviderId = command.Id,
                Name = command.Name,
                Description = command.Description,
                Created = command.Created,
                Version = 1
            };

            _session.Store(read);
            _session.SaveChanges();
        }
    }
}
