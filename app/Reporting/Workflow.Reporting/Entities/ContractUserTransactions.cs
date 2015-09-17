using System.Collections.Generic;

namespace Workflow.Reporting.Entities
{
    public class ContractUserTransactions
    {
        public string User { get; set; }
        public IEnumerable<ContractProductDetail> Products { get; set; } 
    }
}