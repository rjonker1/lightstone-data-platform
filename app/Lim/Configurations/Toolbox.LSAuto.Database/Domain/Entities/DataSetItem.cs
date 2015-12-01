using System;
using Toolbox.LightstoneAuto.Database.Domain.Events;

namespace Toolbox.LightstoneAuto.Database.Domain.Entities
{
    public class DataSet : Aggregate
    {
        private bool _activated;
        private Guid _id;

        private void Apply(DataSetCreated @event)
        {
            _id = @event.Id;
            _activated = true;
        }

        private void Apply(DataSetDeActivated @event)
        {
            _activated = false;
        }

        public DataSet()
        {
        }

        public DataSet(Guid id, string name)
        {
            ApplyChange(new DataSetCreated(id, name));
        }

        public void Deactivate()
        {
            if (!_activated)
                ApplyChange(new DataSetDeActivated(_id));
        }

        public override Guid Id
        {
            get { return _id; }
        }
    }
}
