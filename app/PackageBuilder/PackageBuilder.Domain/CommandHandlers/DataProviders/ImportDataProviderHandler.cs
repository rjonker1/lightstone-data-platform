using System;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.DataProviders.Commands;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders
{
    public class ImportDataProviderHandler : AbstractMessageHandler<ImportDataProvider>
    {
        private readonly IPublishStorableCommands _publisher;

        public ImportDataProviderHandler(IPublishStorableCommands publisher)
        {
            _publisher = publisher;
        }

        public override void Handle(ImportDataProvider command)
        {
            this.Info(() => "Attempting to import data providers");

            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.Ivid, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.IvidTitleHolder, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.LightstoneAuto, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.Rgt, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.RgtVin, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.Audatex, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.PCubedFica, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.SignioDecryptDriversLicense, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.LightstoneProperty, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.LightstoneBusinessCompany, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.LightstoneBusinessDirector, 0, "Owner", DateTime.UtcNow));

            this.Info(() => "Successfully imported data providers");
        }
    }
}