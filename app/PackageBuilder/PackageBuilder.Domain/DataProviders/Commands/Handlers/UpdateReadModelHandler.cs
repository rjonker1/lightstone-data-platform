using System;
using System.Collections.Generic;
using System.Linq;
using PackageBuilder.Domain.MessageHandling;
using PackageBuilder.Domain.Models;
using Raven.Client;
using Raven.Client.Document;

namespace PackageBuilder.Domain.DataProviders.Commands.Handlers
{
    public class UpdateReadModelHandler : AbstractMessageHandler<UpdateReadModel>
    {

        public override void Handle(UpdateReadModel command)
        {

            var read = new ReadDataProvider()
            {
                Id = command.Id,
                Name = command.Name,
                Version = command.Version
            };

            var documentStore = new DocumentStore { ConnectionStringName = "packageBuilder/database" };
            documentStore.Initialize();

            using (IDocumentSession session = documentStore.OpenSession())
            {
                session.Store(read);
                session.SaveChanges();
            }

        }
    }
}
