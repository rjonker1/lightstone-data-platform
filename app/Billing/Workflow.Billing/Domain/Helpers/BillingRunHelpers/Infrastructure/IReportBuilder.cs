using System;
using Workflow.Reporting.Dtos;
using Workflow.Reporting.Entities;

namespace Workflow.Billing.Domain.Helpers.BillingRunHelpers.Infrastructure
{
    public interface IReportBuilder
    {
        ReportInvoice BuildPastelInvoice(int invoiceNumber, string accountNumber, string productName, double productPrice, int productQuantity);
        CustomerClientStatement BuildCustomerClientStatement(Guid customerClientId, DateTime startBillMonth, DateTime endBillMonth);
        ReportDebitOrder BuildDebitOrderRecord(string pastelId, string accountName, string accountType, string bankAccountName, string bankAccountNumber, string branchCode, string contractAmount, string batchAmount);
        ReportDto BuildReport(ReportTemplate template, ReportData data);

        ReportPastelNewCustomer BuildPastelNewCustomerRecord(string dcLink, string accountId, string name, string title, string init, string contactPerson, string physical1,
            string physical2, string physical3, string physical4, string physical5, string physicalPc, string addressee, string post1, string post2,
            string post3, string post4, string post5, string postPc, string deliveredTo, string telephone, string telephone2, string fax1, string fax2,
            string iClassId, string accountTerms, string ct, string taxNumber, string registration, string iAreasId, string creditLimit, string interestRate,
            string discount, string onHold, string bfOpenType, string eMail, string bankLink, string branchCode, string bankAccNum, string bankAccType,
            string autoDisc, string discMtrxRow, string checkTerms, string useEmail, string dTimeStamp, string cAccDescription, string cWebPage,
            string cBankRefNr, string iCurrencyId, string bStatPrint, string bStatEmail, string cStatEmailPass, string bForCurAcc,
            string iSettlementTermsId, string iEuCountryId, string iDefTaxTypeId, string repId, string mainAccLink, string cashDebtor,
            string iIncidentTypeId, string iBusTypeId, string iBusClassId, string iAgentId, string bTaxPrompt, string iArPriceListNameId, string bCodAccount);
    }
}