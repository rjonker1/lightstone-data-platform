namespace Workflow.Reporting.Entities
{
    public class DataProviderDetail
    {
        public string DataProviderId { get; set; }
        public string DataProviderName { get; set; }
        public string CostPrice { get; set; }
        public string RecommendedPrice { get; set; }
        public virtual string ResponseState { get; set; }
        public virtual string TransactionState { get; set; }
    }
}