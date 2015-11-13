namespace Workflow.Reporting.Entities
{
    public class PreBillingRecord
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string ClientId { get; set; }
        public string BillingType { get; set; }
        public string CustomerName { get; set; }
        public string ClientName { get; set; }
        public string AccountNumber { get; set; }
        public string ContractId { get; set; }
        public string HasTransactions { get; set; }
        public string Created { get; set; }
        public string CreatedBy { get; set; }
        public string BillingId { get; set; }
        public PackageDetail Package { get; set; }
        public DataProviderDetail DataProvider { get; set; }
        public UserTransactionDetail UserTransaction { get; set; }
        public UserDetail User { get; set; }
    }
}