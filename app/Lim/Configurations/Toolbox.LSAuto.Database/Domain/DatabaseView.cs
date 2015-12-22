using System;
using Lim.Domain;
using Lim.Domain.Events;
using Toolbox.LightstoneAuto.Domain.Events;
using Toolbox.LightstoneAuto.Domain.Commands.View;

namespace Toolbox.LightstoneAuto.Domain
{
    public class DatabaseView : Aggregate
    {
        private Guid _id;

        private void Apply(LimEvent @event)
        {
            _id = @event.AggregateId;
        }

        public DatabaseView()
        {

        }

        public DatabaseView(LoadView command)
        {
            ApplyChange(new DatabaseViewLoaded(command.DatabaseView, command.CorrelationId, command.EventType, command.EventTypeId, command.NewAggregate,
                command.User, command.Type));
        }
        
        public void Modify(ModifyView command)
        {
            Version = command.Version;
            ApplyChange(new DatabaseViewModified(command.DatabaseView, command.CorrelationId, command.EventType, command.EventTypeId, command.NewAggregate, command.User,command.Version, command.Type));
        }

        public override Guid Id
        {
            get { return _id; }
        }
    }
}