using System.Configuration;
using DataPlatform.Shared.Helpers.Extensions;
using MemBus;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.DataImports;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.States.Commands;

namespace PackageBuilder.Domain.CommandHandlers.DataImports
{
    public class ImportStartupDataHandler : AbstractMessageHandler<ImportStartupData>
    {
        private readonly IBus _bus;

        public ImportStartupDataHandler(IBus bus)
        {
            _bus = bus;
        }

        public override void Handle(ImportStartupData command)

        {
            bool importDataOnApiStartUp;
            this.Info(() => "Looking for ImportDataOnApiStartUp AppSetting");
            bool.TryParse(ConfigurationManager.AppSettings["ImportDataOnApiStartUp"], out importDataOnApiStartUp);
            this.Info(() => "Found ImportDataOnApiStartUp - {0} AppSetting".FormatWith(importDataOnApiStartUp));
            
            if (importDataOnApiStartUp)
            {
                ImportData();
                return;
            }

        }

        private void ImportData()
        {
            this.Info(() => "Attempting to import required data");
            _bus.Publish(new ImportIndustry());
            _bus.Publish(new ImportState());
            _bus.Publish(new ImportDataProvider());
            this.Info(() => "Successfully imported required data");
        }
    }
}