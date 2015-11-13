using System.Collections.Generic;
using Workflow.Reporting.Dtos;
using Workflow.Reporting.Entities;

namespace Workflow.Billing.Domain.Helpers.BillingRunHelpers.Infrastructure
{
    public abstract class ReportList
    {
        public List<ReportDto> InvoicePdfList { get; set; }
        public List<ReportDto> StatementPdfList { get; set; }
        public List<ReportDto> PastelReportList { get; set; }
        public List<ReportInvoice> PastelInvoiceList { get; set; }
        public List<ReportDto> DebitOrderReportList { get; set; }
        public List<ReportDebitOrder> DebitOrderRecordList { get; set; }
        public List<ReportDto> DebitOrderNotDoneReportList { get; set; }
        public List<ReportDebitOrder> DebitOrderNotDoneRecordList { get; set; }
    }
}