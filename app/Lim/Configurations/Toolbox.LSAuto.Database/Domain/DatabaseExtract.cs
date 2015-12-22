using System;
using Lim.Domain;
using Lim.Domain.Events;
using Toolbox.LightstoneAuto.Domain.Events;
using Toolbox.LightstoneAuto.Domain.Commands.Dataset;

namespace Toolbox.LightstoneAuto.Domain
{
    public class DatabaseExtract : Aggregate
    {
        private Guid _id;

        private void Apply(LimEvent @event)
        {
            _id = @event.AggregateId;
        }

        private void Apply(DatabaseExtractDeActivated @event)
        {
        }

        public DatabaseExtract()
        {
        }

        public DatabaseExtract(CreateDataExtract command)
        {
            ApplyChange(new DatabaseExtractCreated(command.DatabaseExtract, Guid.NewGuid(), command.EventType, command.EventTypeId, command.NewAggregate,
                command.User, command.Type));
        }

        public void Deactivate(DeActivateDataExtract command)
        {
            Version = command.Version;
            ApplyChange(new DatabaseExtractDeActivated(command.DataSetId, command.CorrelationId));
        }

        public void Modify(ModifyDataExtract command)
        {
            Version = command.Version;
            ApplyChange(new DatabaseExtractModified(command.DatabaseExtract, command.CorrelationId, command.EventType, command.EventTypeId, false, command.User,
                 command.Version,typeof(ModifyDataExtract)));
        }

        public override Guid Id
        {
            get { return _id; }
        }
    }
}