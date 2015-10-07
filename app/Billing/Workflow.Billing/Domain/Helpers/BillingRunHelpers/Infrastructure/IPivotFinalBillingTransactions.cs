using System.Collections.Generic;
using Workflow.Billing.Domain.Entities;
using Workflow.Reporting.Dtos;
using Workflow.Reporting.Entities;

namespace Workflow.Billing.Domain.Helpers.BillingRunHelpers.Infrastructure
{
    public interface IPivotFinalBillingTransactions
    {
        List<ReportDto> PivotToInvoicePdf();
        List<ReportDto> PivotToStatementPdf();
        List<ReportInvoice> PivotToPastelCsv();
        List<ReportDebitOrder> PivotToDebitOrderCsv();
        List<ReportDebitOrder> PivotToDebitOrderNotDoneCsv();
    }
}