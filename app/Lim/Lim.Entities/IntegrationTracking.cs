using System;

namespace Lim.Entities
{
    public class IntegrationTracking    
    {
        public virtual long Id { get; set; }
        public virtual Configuration Configuration { get; set; }
        public virtual DateTime MaxTransactionDate { get; set; }
        public virtual long TransactionCount { get; set; }
        public virtual DateTime Updated { get; set; }
    }
}
