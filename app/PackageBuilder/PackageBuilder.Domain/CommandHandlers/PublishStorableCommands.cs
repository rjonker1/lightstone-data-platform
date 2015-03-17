using System;
using DataPlatform.Shared.Helpers.Extensions;
using MemBus;
using PackageBuilder.Domain.Core.Contracts.Commands;
using PackageBuilder.Domain.Entities.CommandStore.Commands;

namespace PackageBuilder.Domain.CommandHandlers
{
    public interface IPublishStorableCommands
    {
        void Publish(IDomainCommand command);
    }

    public class PublishStorableCommands : IPublishStorableCommands
    {
        private readonly IBus _bus;

        public PublishStorableCommands(IBus bus)
        {
            _bus = bus;
        }

        public void Publish(IDomainCommand command)
        {
            this.Info(() => "Publishing command {0}".FormatWith(command));
            _bus.Publish(command);
            this.Info(() => "Published command {0}".FormatWith(command));
            this.Info(() => "Storing command {0}".FormatWith(command));
            _bus.Publish(new StoreCommand(Guid.NewGuid(), command));
            this.Info(() => "Stored command {0}".FormatWith(command));
        }
    }
}