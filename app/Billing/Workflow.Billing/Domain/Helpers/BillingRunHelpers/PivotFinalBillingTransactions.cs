using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Repositories;
using ServiceStack.Common;
using Shared.Logging;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Domain.Helpers.BillingRunHelpers.Infrastructure;
using Workflow.Reporting.Dtos;
using Workflow.Reporting.Entities;

namespace Workflow.Billing.Domain.Helpers.BillingRunHelpers
{
    public class PivotFinalBillingTransactions : ReportList, IPivotFinalBillingTransactions
    {
        private readonly IRepository<FinalBilling> _finalBillingRepository;
        private readonly IRepository<AccountMeta> _accountMetaRepository;

        private readonly IReportBuilder _reportBuilder;

        readonly DateTime _endBillMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month - 1, 25).AddHours(23).AddMinutes(59).AddSeconds(59);
        readonly DateTime _startBillMonth = new DateTime(DateTime.UtcNow.Year, (DateTime.UtcNow.Month - 2), 26);

        public PivotFinalBillingTransactions(IRepository<FinalBilling> finalBillingRepository, IRepository<AccountMeta> accountMetaRepository, IReportBuilder reportBuilder)
        {
            _finalBillingRepository = finalBillingRepository;
            _accountMetaRepository = accountMetaRepository;
            _reportBuilder = reportBuilder;

            InvoicePdfList = new List<ReportDto>();
            StatementPdfList = new List<ReportDto>();
            PastelInvoiceList = new List<ReportInvoice>();
            DebitOrderRecordList = new List<ReportDebitOrder>();
            DebitOrderNotDoneRecordList = new List<ReportDebitOrder>();
        }

        /// <summary>
        ///     Invoice PDF build-up for Customer || Client
        /// </summary>
        /// <returns>
        ///     List of Invoices
        /// </returns>
        public List<ReportDto> PivotToInvoicePdf()
        {
            this.Info(() => "PivotToInvoicePdf process started");

            try
            {
                var customerClientList = _finalBillingRepository.Select(x => x.CustomerId).Distinct().ToList();
                customerClientList.AddRange(_finalBillingRepository.Select(x => x.ClientId).Distinct());

                foreach (var customerClientId in customerClientList)
                {
                    InvoicePdfList.Add(_reportBuilder.BuildCustomerClientInvoice(customerClientId, _startBillMonth, _endBillMonth));
                }
            }
            catch (Exception e)
            {
                this.Error(() => "An Error Occured while creating InvoicePdf record. See below for details." + e);
            }

            this.Info(() => "PivotToInvoicePdf process completed");
            return InvoicePdfList;
        }

        /// <summary>
        ///     Statement PDF build-up for Customer || Client
        /// </summary>
        /// <returns> 
        ///     List of Statements 
        /// </returns>
        public List<ReportDto> PivotToStatementPdf()
        {
            this.Info(() => "PivotToStatementPdf process started");

            try
            {
                var customerClientList = _finalBillingRepository.Select(x => x.CustomerId).Distinct().ToList();
                customerClientList.AddRange(_finalBillingRepository.Select(x => x.ClientId).Distinct());

                foreach (var customerClientId in customerClientList)
                {
                    var statement = _reportBuilder.BuildCustomerClientStatement(customerClientId, _startBillMonth, _endBillMonth);

                    var statementReport = _reportBuilder.BuildReport(new ReportTemplate { ShortId = ReportTemplateIdentifier.StatementPdf },
                            new ReportData
                            {
                                CustomerClientStatement = statement
                            });

                    var statementReportIndex = StatementPdfList.FindIndex(x =>
                        x.Data.CustomerClientStatement.CustomerClientName == statement.CustomerClientName &&
                        x.Data.CustomerClientStatement.ContractName == statement.ContractName);

                    if (statementReportIndex < 0)
                    {
                        StatementPdfList.Add(statementReport);
                        this.Info(() => "Statement added for: {0}".FormatWith(statementReport.Data.CustomerClientStatement.CustomerClientName));
                    }
                }
            }
            catch (Exception e)
            {
                this.Error(() => "An Error Occured while creating StatementPdf record. See below for details." + e);
            }

            this.Info(() => "PivotToStatementPdf process completed");
            return StatementPdfList;
        }

        /// <summary>
        ///     Pastel CSV build-up for Customer || Client
        /// </summary>
        /// <returns>
        ///     List of Invoices
        /// </returns>
        public ReportDto PivotToPastelCsv()
        {
            var pastelCounter = 1;

            this.Info(() => "PivotToPastelCsv process started");

            foreach (var customerClientId in _finalBillingRepository.Select(x => x.CustomerId != null ? x.CustomerId : x.ClientId).Distinct())
            {
                try
                {
                    var invoices = _finalBillingRepository.Where(x => (x.CustomerId == customerClientId || x.ClientId == customerClientId)
                                                            && (x.Created >= _startBillMonth && x.Created <= _endBillMonth))
                        .Select(x => new ReportInvoice
                        {
                            ACCOUNTID = x.AccountNumber,
                            CDESCRIPTION = x.Package.PackageName,
                            FUNITPRICEEXCL = x.Package.PackageRecommendedPrice.ToString()
                        }).Distinct();

                    foreach (var reportInvoice in invoices)
                    {
                        var invoice = _reportBuilder.BuildPastelInvoice(pastelCounter, reportInvoice.ACCOUNTID,
                            reportInvoice.CDESCRIPTION, Double.Parse(reportInvoice.FUNITPRICEEXCL, CultureInfo.InvariantCulture), _finalBillingRepository.Where(x => (x.CustomerId == customerClientId || x.ClientId == customerClientId)
                                                            && (x.Created >= _startBillMonth && x.Created <= _endBillMonth)).Distinct().Count());

                        var invoiceListIndex = PastelInvoiceList.FindIndex(x => x.CDESCRIPTION == invoice.CDESCRIPTION);
                        if (invoiceListIndex < 0)
                        {
                            PastelInvoiceList.Add(invoice);
                            pastelCounter++;
                        }
                    }
                }
                catch (Exception e)
                {
                    this.Error(() => "An Error Occured while creating PastelCsv record. See below for details." + e);
                }
            }

            this.Info(() => "PivotToPastelCsv process completed");

            return _reportBuilder.BuildReport(new ReportTemplate { ShortId = ReportTemplateIdentifier.PastelCsv },
                new ReportData
                {
                    Invoices = PastelInvoiceList
                });
        }

        /// <summary>
        ///     DebitOrder CSV build-up for Customer || Client
        /// </summary>
        /// <returns>
        ///     List of ReportDebitOrder
        /// </returns>
        public ReportDto PivotToDebitOrderCsv()
        {
            this.Info(() => "PivotToDebitOrderCsv process started");

            foreach (var customerClientId in _finalBillingRepository.Select(x => x.CustomerId != null ? x.CustomerId : x.ClientId).Distinct())
            {
                try
                {
                    var customerClientDetail = _finalBillingRepository.FirstOrDefault(x => x.CustomerId == customerClientId || x.ClientId == customerClientId);

                    var account = _accountMetaRepository.FirstOrDefault(x => x.AccountNumber == customerClientDetail.AccountNumber);

                    var transactions = _finalBillingRepository.Where(x => x.AccountNumber == account.AccountNumber && (x.Created >= _startBillMonth && x.Created <= _endBillMonth))
                        .Select(x => x.UserTransaction.TransactionId).Distinct();

                    var batchTotal = 0.0;

                    foreach (var transactionId in transactions)
                    {
                        // Value in cents for Pastel
                        batchTotal += Math.Round(((_finalBillingRepository.Where(x => x.Id ==
                                                    _finalBillingRepository.Where(br => (br.AccountNumber == account.AccountNumber && br.UserTransaction.TransactionId == transactionId)
                                                    && (x.Created >= _startBillMonth && x.Created <= _endBillMonth))
                                                    .Select(br => br.Id).First())
                                                    .Sum(x => x.Package.PackageRecommendedPrice)) * 100), 2);
                    }

                    var debitOrderRecord = _reportBuilder.BuildDebitOrderRecord(account.AccountNumber, customerClientDetail.CustomerName, "1", account.BankAccountName,
                        account.BillingDebitOrderAccountNumber, account.BillingDebitOrderBranchCode, "0", batchTotal.ToString());

                    if ((debitOrderRecord.AccountName != null) && (debitOrderRecord.BankAccountName != null)
                        && (debitOrderRecord.BranchCode != "0") && (debitOrderRecord.BankAccountNumber != null))
                    {
                        var debitOrderIndex = DebitOrderRecordList.FindIndex(x => x.PastelAccountId == debitOrderRecord.PastelAccountId);
                        if (debitOrderIndex < 0) DebitOrderRecordList.Add(debitOrderRecord);
                    }
                }
                catch (Exception e)
                {
                    this.Error(() => "An Error Occured while creating DebitOrder record. See below for details." + e);
                }
            }

            this.Info(() => "PivotToDebitOrderCsv process completed");

            return _reportBuilder.BuildReport(new ReportTemplate { ShortId = ReportTemplateIdentifier.DebitOrderCsv },
                new ReportData
                {
                    BillDateTime1 = DateTime.UtcNow.ToString("yyyyMMdd"),
                    BillDateTime2 = DateTime.UtcNow.ToString("yyyy/MM/dd"),
                    DebitOrders = DebitOrderRecordList
                });
        }

        /// <summary>
        ///     DebitOrderNotDone CSV build-up for Customer || Client
        /// </summary>
        /// <returns>
        ///     List of ReportDebitOrder
        /// </returns>
        public ReportDto PivotToDebitOrderNotDoneCsv()
        {
            this.Info(() => "PivotToDebitOrderNotDoneCsv process started");

            foreach (var customerClientId in _finalBillingRepository.Select(x => x.CustomerId != null ? x.CustomerId : x.ClientId).Distinct())
            {
                try
                {
                    var customerClientDetail = _finalBillingRepository.FirstOrDefault(x => x.CustomerId == customerClientId || x.ClientId == customerClientId);

                    var account = _accountMetaRepository.FirstOrDefault(x => x.AccountNumber == customerClientDetail.AccountNumber);

                    var transactions = _finalBillingRepository.Where(x => x.AccountNumber == account.AccountNumber).Select(x => x.UserTransaction.TransactionId).Distinct();

                    var batchTotal = 0.0;

                    foreach (var transactionId in transactions)
                    {
                        // Value in cents for Pastel
                        batchTotal += Math.Round(((_finalBillingRepository.Where(x => x.Id ==
                                                    _finalBillingRepository.Where(br => (br.AccountNumber == account.AccountNumber && br.UserTransaction.TransactionId == transactionId)
                                                    && (x.Created >= _startBillMonth && x.Created <= _endBillMonth))
                                                    .Select(br => br.Id).First())
                                                    .Sum(x => x.Package.PackageRecommendedPrice)) * 100), 2);
                    }

                    var debitOrderRecord = _reportBuilder.BuildDebitOrderRecord(account.AccountNumber, customerClientDetail.CustomerName, "1", account.BankAccountName,
                        account.BillingDebitOrderAccountNumber, account.BillingDebitOrderBranchCode, "0", batchTotal.ToString());

                    if ((debitOrderRecord.AccountName == null) || (debitOrderRecord.BankAccountName == null)
                        && (debitOrderRecord.BranchCode == "0") || (debitOrderRecord.BankAccountNumber == null))
                    {
                        var debitOrderIndex = DebitOrderNotDoneRecordList.FindIndex(x => x.PastelAccountId == debitOrderRecord.PastelAccountId);
                        if (debitOrderIndex < 0) DebitOrderNotDoneRecordList.Add(debitOrderRecord);
                    }
                }
                catch (Exception e)
                {
                    this.Error(() => "An Error Occured while creating DebitOrderNotDone record. See below for details." + e);
                }
            }

            this.Info(() => "PivotToDebitOrderNotDoneCsv process completed");

            return _reportBuilder.BuildReport(new ReportTemplate { ShortId = ReportTemplateIdentifier.DebitOrderNotDoneCsv },
                new ReportData
                {
                    BillDateTime1 = DateTime.UtcNow.ToString("yyyyMMdd"),
                    BillDateTime2 = DateTime.UtcNow.ToString("yyyy/MM/dd"),
                    DebitOrders = DebitOrderNotDoneRecordList
                });
        }
    }
}