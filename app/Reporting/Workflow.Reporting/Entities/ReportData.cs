using System.Collections.Generic;

namespace Workflow.Reporting.Entities
{
    public class ReportData
    {
        public string BillDateTime1 { get; set; }
        public string BillDateTime2 { get; set; }
        public IEnumerable<ReportInvoice> Invoices { get; set; }
        //public IEnumerable<ContractStatement> ContractStatements { get; set; } 
        public IEnumerable<PreBillingRecord> PreBillingData { get; set; }
        public IEnumerable<ReportDebitOrder> DebitOrders { get; set; } 
        public IEnumerable<ReportPastelNewCustomer> PastelNewCustomers { get; set; }
        public CustomerClientInvoice CustomerClientInvoice { get; set; } 
        public CustomerClientStatement CustomerClientStatement { get; set; } 
    }
}