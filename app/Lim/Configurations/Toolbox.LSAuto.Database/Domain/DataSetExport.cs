using System;
using Lim.Domain;
using Lim.Domain.Events;
using Toolbox.LightstoneAuto.Domain.Events;
using Toolbox.LightstoneAuto.Domain.Commands.Dataset;

namespace Toolbox.LightstoneAuto.Domain
{
    public class DataSetExport : Aggregate
    {
        private Guid _id;

        private void Apply(LimEvent @event)
        {
            _id = @event.AggregateId;
        }

        private void Apply(DataSetExportDeActivated @event)
        {
        }

        public DataSetExport()
        {
        }

        public DataSetExport(CreateDataSetExport command)
        {
            ApplyChange(new DataSetExportCreated(command.DataSet, Guid.NewGuid(), command.EventType, command.EventTypeId, command.NewAggregate,
                command.User, command.Type));
        }

        public void Deactivate(DeActivateDataSetExport command)
        {
            ApplyChange(new DataSetExportDeActivated(command.DataSetId, command.CorrelationId));
        }

        public void Modify(ModifyDataSetExport command)
        {
            ApplyChange(new DataSetExportModified(command.DataSet, command.CorrelationId, command.EventType, command.EventTypeId, false, command.User,
                typeof(ModifyDataSetExport)));
        }

        public override Guid Id
        {
            get { return _id; }
        }
    }
}