namespace Workflow.Billing.Domain.Dtos
{
    public class StatementPricingSummaryDto
    {
        public virtual string ContractName { get; set; }
        public virtual string Description { get; set; }
        public virtual string PackageName { get; set; }
    }
}