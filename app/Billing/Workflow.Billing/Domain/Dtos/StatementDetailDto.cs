namespace Workflow.Billing.Domain.Dtos
{
    public class StatementDetailDto
    {
        public virtual string AccountContact { get; set; }
        public virtual string AccountNumber { get; set; }
        public virtual string ConsultantName { get; set; }
        public virtual string ContractName { get; set; }
        public virtual string CustomerClientName { get; set; }
        public virtual string StatementPeriod { get; set; }
    }
}