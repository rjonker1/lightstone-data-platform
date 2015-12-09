using System;
using Lim.Domain;
using Lim.Domain.Events;
using Toolbox.LightstoneAuto.Domain.Events;
using Toolbox.LightstoneAuto.Domain.Commands.View;

namespace Toolbox.LightstoneAuto.Domain
{
    public class ViewImport : Aggregate
    {
        private Guid _id;

        private void Apply(LimEvent @event)
        {
            _id = @event.AggregateId;
        }

        public ViewImport()
        {

        }

        public ViewImport(CreateViewImport command)
        {
            ApplyChange(new ViewImportCreated(command.View, command.CorrelationId, command.EventType, command.EventTypeId, command.NewAggregate,
                command.User, command.Type));
        }

        public void Deactivate(DeActivateViewImport command)
        {
            ApplyChange(new ViewImportDeActivated(command.ViewId, command.CorrelationId));
        }

        public void Modify(ModifyViewImport command)
        {
            ApplyChange(new ViewImportModified(command.View, command.CorrelationId, command.EventType, command.EventTypeId, command.NewAggregate, command.User, command.Type));
        }

        public void Reload(ReloadViewImport command)
        {
            ApplyChange(new ViewImportReloaded(command.View, command.CorrelationId, command.EventType, command.EventTypeId, command.NewAggregate,
                command.User, command.Type));
        }

        public override Guid Id
        {
            get { return _id; }
        }
    }
}