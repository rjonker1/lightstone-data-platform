using System;
using Lim;
using Lim.Domain;
using Lim.Domain.Events;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Domain.Events;
using Toolbox.LightstoneAuto.Infrastructure.Commands;

namespace Toolbox.LightstoneAuto.Domain
{
    public class DataSetExport : Aggregate
    {
        private Guid _id;

        private void Apply(LimEvent @event)
        {
            _id = @event.AggregateId;
        }

        private void Apply(DataSetDeActivated @event)
        {
        }

        public DataSetExport()
        {
        }

        public DataSetExport(CreateDataSetExport command)
        {
            ApplyChange(new DataSetExportCreated(command.DataSet, Guid.NewGuid(), command.EventType, command.EventTypeId, command.NewAggregate,
                command.User, typeof(CreateDataSetExport)));
        }

        public void Deactivate(DeActivateDataSetExport command)
        {
            ApplyChange(new DataSetDeActivated(command.DataSetId, command.CorrelationId));
        }

        public void Modify(ModifyDataSetExport command)
        {
            ApplyChange(new DataSetModified(command.DataSet, command.CorrelationId, command.EventType, command.EventTypeId, false, command.User,
                typeof(ModifyDataSetExport)));
        }

        public override Guid Id
        {
            get { return _id; }
        }
    }
}