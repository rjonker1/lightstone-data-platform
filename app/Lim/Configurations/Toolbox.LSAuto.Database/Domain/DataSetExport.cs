using System;
using Lim;
using Lim.Domain;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Domain.Events;
using Toolbox.LightstoneAuto.Infrastructure.Commands;

namespace Toolbox.LightstoneAuto.Domain
{
    public class DataSetExport : Aggregate
    {
        private long _id;

        private void Apply(LimEvent @event)
        {
            _id = @event.Id;
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
                command.User, typeof (DataSetDto)));
        }

        public void Deactivate(DeActivateDataSetExport command)
        {
            ApplyChange(new DataSetDeActivated(_id, command.DataSetId, command.CorrelationId));
        }

        public void Modify(ModifyDataSetExport command)
        {
            ApplyChange(new DataSetModified(_id, command.DataSet, command.CorrelationId, command.EventType, command.EventTypeId, false, command.User,
                typeof (DataSetDto)));
        }

        public override long Id
        {
            get { return _id; }
        }
    }
}