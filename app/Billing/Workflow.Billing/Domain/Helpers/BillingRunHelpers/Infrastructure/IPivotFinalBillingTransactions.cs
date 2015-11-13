using System.Collections.Generic;
using Workflow.Reporting.Dtos;

namespace Workflow.Billing.Domain.Helpers.BillingRunHelpers.Infrastructure
{
    public interface IPivotFinalBillingTransactions
    {
        List<ReportDto> PivotToInvoicePdf();
        List<ReportDto> PivotToStatementPdf();
        ReportDto PivotToPastelCsv();
        ReportDto PivotToDebitOrderCsv();
        ReportDto PivotToDebitOrderNotDoneCsv();
    }
}