using System;
using System.Collections.Generic;
using System.Linq;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using Raven.Imports.Newtonsoft.Json;
using Topics.Radical.Linq;

namespace LightstoneApp.Infrastructure.Data.Core.Commits
{
    public class Commit
    {
        private String _id;

        [JsonConstructor]
        private Commit()
        {
        }

        private Commit(Guid transactionIdentifier, String correlationId, String aggregateId,
            IEnumerable<IDomainEvent> uncommittedEvents, String userAccount)
        {
            CreatedOn = DateTimeOffset.Now;
            TransactionIdentifier = transactionIdentifier.ToString();
            CorrelationId = correlationId;
            AggregateIdentifier = aggregateId;
            Events = uncommittedEvents;
            UserAccount = userAccount;
        }

        public String Id
        {
            get { return _id; }
            private set
            {
                if (Id != value)
                {
                    _id = value;
                    if (Events != null && Events.Any(e => e.Id == null))
                    {
                        Events.ForEach(1, (idx, evt) =>
                        {
                            ((DomainEvent) evt).Id = Id + "/events/" + idx;

                            return ++idx;
                        });
                    }
                }
            }
        }

        public DateTimeOffset CreatedOn { get; private set; }
        public String TransactionIdentifier { get; private set; }
        public String CorrelationId { get; private set; }
        public String AggregateIdentifier { get; private set; }
        public IEnumerable<IDomainEvent> Events { get; private set; }

        public Boolean IsDispatched { get; private set; }

        public String UserAccount { get; private set; }

        public void MarkAsDispatched()
        {
            IsDispatched = true;
        }

        public class Factory
        {
            public Commit CreateFor(Guid transactionIdentifier, string correlationId, IAggregate aggregate,
                String userAccount)
            {
                var commit = new Commit(transactionIdentifier, correlationId, aggregate.Id,
                    aggregate.GetUncommittedEvents(), userAccount);

                return commit;
            }
        }
    }
}