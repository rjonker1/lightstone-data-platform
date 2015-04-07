using System;
using Billing.Domain.Core.Entities;

namespace Billing.Domain.Entities
{
    public class DataProviderTransaction : Entity
    {
        public virtual Guid StreamId { get; protected internal set; }
        public virtual DateTime Date { get; protected internal set; }
        public virtual Guid RequestId { get; protected internal set; }
        public virtual int DataProvider { get; protected internal set; }
        public virtual string DataProviderName { get; protected internal set; }
        public virtual string ConnectionType { get; protected internal set; }
        public virtual string Connection { get; protected internal set; }
        public virtual string Action { get; protected internal set; }
        public virtual string State { get; protected internal set; }
        public virtual int StateId { get; protected internal set; }

        public DataProviderTransaction() { }
    }
}