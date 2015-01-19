using System;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.Industries.Commands;

namespace PackageBuilder.Domain.CommandHandlers.Industries
{
    public class ImportIndustryHandler : AbstractMessageHandler<ImportIndustry>
    {
        private readonly IHandleMessages _handler;

        public ImportIndustryHandler(IHandleMessages handler)
        {
            _handler = handler;
        }

        public override void Handle(ImportIndustry command)
        {
            this.Info(() => "Attempting to import industries");

            try
            {
                _handler.Handle(new CreateIndustry(new Guid(), "All", true));
            }
            catch (LightstoneAutoException exception)
            {
                this.Warn(() => exception);
            }

            this.Info(() => "Successfully imported industries");
        }
    }
}