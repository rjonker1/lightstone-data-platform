using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var read = new ReadDataProvider
            {
                Id = new Guid(),
                Name = command.Name,
                Version = command.Version
            };

            _session.Store(read);
            _session.SaveChanges();
        }

    }
}
