namespace Workflow.Billing.Domain.Dtos
{
    public class StatementUserTransactionDto
    {
        public virtual string Username { get; set; }
        public virtual string PackageName { get; set; }
        public virtual int Transactions { get; set; }
        public virtual int BillableTransactions { get; set; }
    }
}