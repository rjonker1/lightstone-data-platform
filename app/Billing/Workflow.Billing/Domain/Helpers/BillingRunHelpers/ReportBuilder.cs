using System;
using Workflow.Reporting.Dtos;
using Workflow.Reporting.Entities;

namespace Workflow.Billing.Domain.Helpers.BillingRunHelpers
{
    public class ReportBuilder
    {
        public ReportInvoice BuildPastelInvoice(int invoiceNumber, string accountNumber, string productName, double productPrice)
        {
            return new ReportInvoice
            {
                DOCTYPE = "INV",
                INVNUMBER = invoiceNumber.ToString(),
                ACCOUNTID = accountNumber,
                DESCRIPTION = "Sale Invoice",
                INVDATE = DateTime.UtcNow.ToString("dd/MM/yyyy"),
                TAXINCLUSIVE = "0",
                ORDERNUM = invoiceNumber.ToString(),
                CDESCRIPTION = productName,
                FQUANTITY = "1",
                FUNITPRICEEXCL = productPrice.ToString(),
                ITAXTYPEID = "1",
                ISTOCKCODEID = "",
                Project = "LIVE20",
                Tax_Number = ""
            };
        }

        public ReportDto BuildReport(ReportTemplate template, ReportData data)
        {
            return new ReportDto
            {
                Template = template,
                Data = data
            };
        }
    }
}