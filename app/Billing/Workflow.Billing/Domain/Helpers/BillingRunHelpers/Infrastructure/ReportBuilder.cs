using System;
using System.Collections.Generic;
using Workflow.Reporting.Dtos;
using Workflow.Reporting.Entities;

namespace Workflow.Billing.Domain.Helpers.BillingRunHelpers.Infrastructure
{
    public class ReportBuilder : IReportBuilder
    {
        public ReportInvoice BuildPastelInvoice(int invoiceNumber, string accountNumber, string productName, double productPrice, int productQuantity)
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
                FQUANTITY = productQuantity.ToString(),
                FUNITPRICEEXCL = productPrice.ToString(),
                ITAXTYPEID = "1",
                ISTOCKCODEID = "",
                Project = "LIVE20",
                Tax_Number = ""
            };
        }

        public ContractStatement BuildStatement(string customerName, string clientName, string contractName, IEnumerable<ContractUserTransactions> userTransactions)
        {
            return new ContractStatement()
            {
                Customer = customerName,
                Client = clientName,
                ContractName = contractName,
                UserTransactions = userTransactions
            };
        }

        public ReportDebitOrder BuildDebitOrderRecord(string pastelId, string accountName, string accountType, string bankAccountName, string bankAccountNumber, string branchCode, string contractAmount, string batchAmount)
        {
            return new ReportDebitOrder
            {
                PastelAccountId = pastelId,
                AccountName = accountName,
                AccountType = accountType,
                BankAccountName = bankAccountName,
                BankAccountNumber = bankAccountNumber,
                BranchCode = branchCode,
                ContractAmount = contractAmount,
                BatchAmount = batchAmount
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

        public ReportPastelNewCustomer BuildPastelNewCustomerRecord(string dcLink, string accountId, string name, string title, string init, string contactPerson, string physical1,
                                            string physical2, string physical3, string physical4, string physical5, string physicalPc, string addressee, string post1, string post2,
                                            string post3, string post4, string post5, string postPc, string deliveredTo, string telephone, string telephone2, string fax1, string fax2,
                                            string iClassId, string accountTerms, string ct, string taxNumber, string registration, string iAreasId, string creditLimit, string interestRate,
                                            string discount, string onHold, string bfOpenType, string eMail, string bankLink, string branchCode, string bankAccNum, string bankAccType,
                                            string autoDisc, string discMtrxRow, string checkTerms, string useEmail, string dTimeStamp, string cAccDescription, string cWebPage,
                                            string cBankRefNr, string iCurrencyId, string bStatPrint, string bStatEmail, string cStatEmailPass, string bForCurAcc,
                                            string iSettlementTermsId, string iEuCountryId, string iDefTaxTypeId, string repId, string mainAccLink, string cashDebtor,
                                            string iIncidentTypeId, string iBusTypeId, string iBusClassId, string iAgentId, string bTaxPrompt, string iArPriceListNameId, string bCodAccount)
        {
            return new ReportPastelNewCustomer
            {
                DCLink = dcLink,
                AccountID = accountId,
                Name = name,
                Title = title,
                Init = init,
                Contact_Person = contactPerson,
                Physical1 = physical1,
                Physical2 = physical2,
                Physical3 = physical3,
                Physical4 = physical4,
                Physical5 = physical5,
                PhysicalPC = physicalPc,
                Addressee = addressee,
                Post1 = post1,
                Post2 = post2,
                Post3 = post3,
                Post4 = post4,
                Post5 = post5,
                PostPC = postPc,
                Delivered_To = deliveredTo,
                Telephone = telephone,
                Telephone2 = telephone2,
                Fax1 = fax1,
                Fax2 = fax2,
                iClassID = iClassId,
                AccountTerms = accountTerms,
                CT = ct,
                Tax_Number = taxNumber,
                Registration = registration,
                iAreasID = iAreasId,
                Credit_Limit = creditLimit,
                Interest_Rate = interestRate,
                Discount = discount,
                On_Hold = onHold,
                BFOpenType = bfOpenType,
                EMail = eMail,
                BankLink = bankLink,
                BranchCode = branchCode,
                BankAccNum = bankAccNum,
                BankAccType = bankAccType,
                AutoDisc = autoDisc,
                DiscMtrxRow = discMtrxRow,
                CheckTerms = checkTerms,
                UseEmail = useEmail,
                dTimeStamp = dTimeStamp,
                cAccDescription = cAccDescription,
                cWebPage = cWebPage,
                cBankRefNr = cBankRefNr,
                iCurrencyID = iCurrencyId,
                bStatPrint = bStatPrint,
                bStatEmail = bStatEmail,
                cStatEmailPass = cStatEmailPass,
                bForCurAcc = bForCurAcc,
                iSettlementTermsID = iSettlementTermsId,
                iEUCountryID = iEuCountryId,
                iDefTaxTypeID = iDefTaxTypeId,
                RepID = repId,
                MainAccLink = mainAccLink,
                CashDebtor = cashDebtor,
                iIncidentTypeID = iIncidentTypeId,
                iBusTypeID = iBusTypeId,
                iBusClassID = iBusClassId,
                iAgentID = iAgentId,
                bTaxPrompt = bTaxPrompt,
                iARPriceListNameID = iArPriceListNameId,
                bCODAccount = bCodAccount,
            };
        }
    }
}

