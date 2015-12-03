using System;
using System.Text;
using Lim.Domain;
using Lim.Domain.Extensions;
using Toolbox.LightstoneAuto.Database.Domain.Events;
using Toolbox.LightstoneAuto.Database.Infrastructure.Commands;

namespace Toolbox.LightstoneAuto.Database.Domain
{
    public class DataSetExport : Aggregate
    {
        private bool _activated;
        private Guid _id;

        private void Apply(DataSetExportCreated @event)
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

        public DataSetExport(CreateDataSetExport createCommand)
        {
            EventType = createCommand.EventType;
            EventTypeId = createCommand.EventTypeId;
            AggregateNew = createCommand.NewAggregate;
            CreatedBy = createCommand.CreatedBy;
            Payload = Encoding.UTF8.GetBytes(createCommand.DataSet.ObjectToJson());


            ApplyChange(new DataSetExportCreated(createCommand.DataSet, createCommand.EventType, createCommand.EventTypeId, createCommand.Type,
                createCommand.NewAggregate, createCommand.CreatedBy));
        }

        public void Deactivate()
        {
            if (!_activated)
                ApplyChange(new DataSetDeActivated(_id));
        }

        public void Rename(string name)
        {
            ApplyChange(new DataSetRenamed(_id, name));
        }

        public override Guid Id
        {
            get { return _id; }
        }
    }
}
