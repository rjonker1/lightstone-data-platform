using System;
using Lim;
using Lim.Domain;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Database.Domain.Events;
using Toolbox.LightstoneAuto.Database.Infrastructure.Commands;

namespace Toolbox.LightstoneAuto.Database.Domain
{
    public class DataSetExport : Aggregate
    {
        private bool _activated;
        private long _id;

        private void Apply(LimEvent @event)
        {
            _id = @event.Id;
            _activated = true;
        }

        private void Apply(DataSetDeActivated @event)
        {
            _activated = false;
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
            if (!_activated)
                ApplyChange(new DataSetDeActivated(_id,command.DataSetId, command.CorrelationId));
        }

        public void Rename(ModifyDataSetExport command)
        {
            ApplyChange(new DataSetModified(_id, command.DataSet, command.CorrelationId, command.EventType, command.EventTypeId, false, command.User, typeof(DataSetDto)));
        }

        public override long Id
        {
            get { return _id; }
        }
    }
}
