using System;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.Enums;
using PackageBuilder.Domain.Entities.States.Commands;

namespace PackageBuilder.Domain.CommandHandlers.States
{
    public class ImportStateHandler : AbstractMessageHandler<ImportState>
    {
        private readonly IPublishStorableCommands _publisher;

        public ImportStateHandler(IPublishStorableCommands publisher)
        {
            _publisher = publisher;
        }

        public override void Handle(ImportState command)
        {
            this.Info(() => "Attempting to import states");

            foreach (var state in (StateName[])Enum.GetValues(typeof(StateName)))
                _publisher.Publish(new CreateState(Guid.NewGuid(), state));

            this.Info(() => "Successfully imported states");
        }
    }
}