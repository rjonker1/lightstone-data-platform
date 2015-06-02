using System;

namespace Lim.Domain.Entities
{
    public class IntegrationTracking    
    {
        public virtual long Id { get; set; }
        public virtual ActionType Action { get; set; }
        public virtual FrequencyType Frequency { get; set; }
        public virtual IntegrationType Type { get; set; }
        public virtual DateTime MaxTransactionDate { get; set; }
        public virtual long TransactionCount { get; set; }
        public virtual DateTime Updated { get; set; }
    }
}
