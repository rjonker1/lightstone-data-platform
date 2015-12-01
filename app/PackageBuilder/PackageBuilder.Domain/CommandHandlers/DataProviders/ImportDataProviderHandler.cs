using System;
using DataPlatform.Shared.Enums;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using Shared.Logging;

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

            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.IVIDVerify_E_WS, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.IVIDTitle_E_WS, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.LSAutoCarStats_I_DB, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.LSAutoSpecs_I_DB, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.LSAutoVINMaster_I_DB, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.Audatex, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.PCubedFica_E_WS, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.PCubedEZScore_E_WS, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.LSAutoDecryptDriverLic_I_WS, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.LSPropertySearch_E_WS, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.LSBusinessCompany_E_WS, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.LSBusinessDirector_E_WS, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.LSConsumerRepair_E_WS, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.BMWFSTitle_E_DB, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.MMCode_E_DB, 0, "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(Guid.NewGuid(), DataProviderName.LSAutoVIN12_I_DB, 0, "Owner", DateTime.UtcNow));

            this.Info(() => "Successfully imported data providers");
        }
    }
}