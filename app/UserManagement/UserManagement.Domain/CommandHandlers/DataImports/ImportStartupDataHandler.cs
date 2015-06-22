using System.Configuration;
using DataPlatform.Shared.Helpers.Extensions;
using MemBus;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities.Commands.CommercialStates;
using UserManagement.Domain.Entities.Commands.ContractDurations;
using UserManagement.Domain.Entities.Commands.Contracts;
using UserManagement.Domain.Entities.Commands.ContractTypes;
using UserManagement.Domain.Entities.Commands.EscalationTypes;
using UserManagement.Domain.Entities.Commands.PaymentTypes;
using UserManagement.Domain.Entities.Commands.Provinces;
using UserManagement.Domain.Entities.Commands.Roles;
using UserManagement.Domain.Entities.DataImports;

namespace UserManagement.Domain.CommandHandlers.DataImports
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
                ImportData();
        }

        private void ImportData()
        {
            // Uses ExceptionHelper to supress individual imports, to allow for new imports of that type

            this.Info(() => "Attempting to import required data");
            _bus.Publish(new ImportRole());
            _bus.Publish(new ImportProvince());
            _bus.Publish(new ImportContractDuration());
            _bus.Publish(new ImportEscalationType());
            _bus.Publish(new ImportContractType());
            _bus.Publish(new ImportCommercialState());
            _bus.Publish(new ImportPaymentType());
            _bus.Publish(new ImportContractBundle());
            this.Info(() => "Successfully imported required data");
        }
    }
}