using System;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.Industries.Commands;
using Shared.Logging;

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
            this.Info(() => "Attempting to import data industries");

            _publisher.Publish(new CreateIndustry(Guid.NewGuid(), "Automotive", false));
            _publisher.Publish(new CreateIndustry(Guid.NewGuid(), "Dealerships", false));
            _publisher.Publish(new CreateIndustry(Guid.NewGuid(), "Finance", false));
            _publisher.Publish(new CreateIndustry(Guid.NewGuid(), "Insurance", false));

            this.Info(() => "Successfully imported industries");
        }
    }
}