namespace Workflow.Reporting.Entities
{
    public class ReportDebitOrder
    {
        public string PastelAccountId { get; set; }
        public string AccountName { get; set; }
        public string BankAccountName { get; set; }
        public string AccountType { get; set; }
        public string BranchCode { get; set; }
        public string BankAccountNumber { get; set; }
        public string ContractAmount { get; set; }
        public string BatchAmount { get; set; }
    }
}