using System;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.Industries.Commands;

namespace PackageBuilder.Domain.CommandHandlers.Industries
{
    public class ImportIndustryHandler : AbstractMessageHandler<ImportIndustry>
    {
        private readonly IPublishStorableCommands _publisher;

        public ImportIndustryHandler(IPublishStorableCommands publisher)
        {
            _publisher = publisher;
        }

        public override void Handle(ImportIndustry command)
        {
            this.Info(() => "Attempting to import industries");
           
            _publisher.Publish(new CreateIndustry(Guid.NewGuid(), "All", true));

            this.Info(() => "Successfully imported industries");
        }
    }
}