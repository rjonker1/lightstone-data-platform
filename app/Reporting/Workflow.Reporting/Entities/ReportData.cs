using System.Collections.Generic;

namespace Workflow.Reporting.Entities
{
    public class ReportData
    {
        public ReportCustomer Customer { get; set; }
        public IEnumerable<ReportInvoice> Invoices { get; set; }
        public IEnumerable<PreBillingRecord> PreBillingData { get; set; }
        public IEnumerable<ReportDebitOrder> DebitOrders { get; set; } 
    }
}