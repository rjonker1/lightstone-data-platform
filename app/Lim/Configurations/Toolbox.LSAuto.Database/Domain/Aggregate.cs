using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.LightstoneAuto.Database.Domain.Base;
using Toolbox.LightstoneAuto.Database.Domain.Extensions;

namespace Toolbox.LightstoneAuto.Database.Domain
{
    public abstract class Aggregate
    {
        private readonly List<Event> _events = new List<Event>();
 
        public abstract Guid Id { get; }
        public int Version { get; protected set; }

        public IEnumerable<Event> GetUncommittedEvents()
        {
            return _events;
        }

        public void UpdateCommitedFlag()
        {
            _events.Clear();
        }

        public void LoadsFromHistory(IEnumerable<Event> history)
        {
            foreach (var e in history) ApplyChange(e, false);
        }

        protected void ApplyChange(Event @event)
        {
            ApplyChange(@event, true);
        }

        private void ApplyChange(Event @event, bool isNew)
        {
            this.AsDynamic().Apply(@event);
            if (isNew) _events.Add(@event);
        }
    }
}
