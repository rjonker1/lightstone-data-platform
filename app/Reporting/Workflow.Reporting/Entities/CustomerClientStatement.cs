using System.Collections.Generic;

namespace Workflow.Reporting.Entities
{
    public class CustomerClientStatement
    {
        public string StatementPeriod { get; set; }
        public string CustomerClientName { get; set; }
        public string ConsultantName { get; set; }
        public string AccountContact { get; set; }
        public string AccountNumber { get; set; }
        public string ContractName { get; set; }
        public IEnumerable<PricingSummary> PricingSummaries { get; set; }
        public IEnumerable<ContractUserTransactions> UserTransactions { get; set; } 
    }

    public class PricingSummary
    {
        public string ContractName { get; set; }
        public string PackageName { get; set; }
        public string Description { get; set; }
    }
}