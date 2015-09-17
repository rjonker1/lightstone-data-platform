using System.Collections.Generic;

namespace Workflow.Reporting.Entities
{
    public class ContractStatement
    {
        public string Customer { get; set; }
        public string Client { get; set; }
        public string ContractName { get; set; }
        public IEnumerable<ContractUserTransactions> UserTransactions { get; set; } 

    }
}