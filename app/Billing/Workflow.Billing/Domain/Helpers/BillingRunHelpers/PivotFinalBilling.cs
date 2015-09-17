﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Repositories;
using Workflow.Billing.Domain.Entities;
using Workflow.Reporting.Dtos;
using Workflow.Reporting.Entities;

namespace Workflow.Billing.Domain.Helpers.BillingRunHelpers
{
    public class PivotFinalBilling : IPivotBilling<PivotFinalBilling>
    {
        private readonly IRepository<StageBilling> _stageBillingRepository;
        private readonly IRepository<FinalBilling> _finalBillingRepository;
        private readonly IRepository<AccountMeta> _accountMetaReporRepository;
        private readonly IRepository<ContractMeta> _contractRepository;
        private readonly IRepository<UserMeta> _userMetaRepository;
        private readonly IRepository<ArchiveBillingTransaction> _archiveBillingRepository;

        private readonly IPublishReportQueue<BillingReport> _report;
        private readonly IReportBuilder _reportBuilder;

        public PivotFinalBilling(IRepository<StageBilling> stageBillingRepository, IRepository<FinalBilling> finalBillingRepository, IRepository<ArchiveBillingTransaction> archiveBillingRepository,
                                    IRepository<AccountMeta> accountMetaReporRepository,
                                    IPublishReportQueue<BillingReport> report, IReportBuilder reportBuilder, IRepository<ContractMeta> contractRepository, IRepository<UserMeta> userMetaRepository)
        {
            _stageBillingRepository = stageBillingRepository;
            _finalBillingRepository = finalBillingRepository;
            _archiveBillingRepository = archiveBillingRepository;
            _accountMetaReporRepository = accountMetaReporRepository;
            _reportBuilder = reportBuilder;
            _contractRepository = contractRepository;
            _userMetaRepository = userMetaRepository;
            _report = report;
        }

        public void Pivot()
        {
            var invoicePdfList = new List<ReportDto>();
            var statementPdfList = new List<ReportDto>();
            var pastelReportList = new List<ReportDto>();
            var pastelInvoiceList = new List<ReportInvoice>();
            var debitOrderReportList = new List<ReportDto>();
            var debitOrderRecordList = new List<ReportDebitOrder>();
            var debitOrderNotDoneReportList = new List<ReportDto>();
            var debitOrderNotDoneRecordList = new List<ReportDebitOrder>();

            var endBillMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 25).AddHours(23).AddMinutes(59).AddSeconds(59);
            var startBillMonth = new DateTime(DateTime.UtcNow.Year, (DateTime.UtcNow.Month - 1), 26);

            var pastelCounter = 1;

            var accounts = _accountMetaReporRepository;

            this.Info(() => "FinalBilling process started for : {0} - to - {1}".FormatWith(startBillMonth, endBillMonth));

            try
            {
                // Archive and clean Final Billing for new month
                //foreach (var archiveRecord in _finalBillingRepository)
                //{
                //    if (!_archiveBillingRepository.Any(x => x.StageBillingId == archiveRecord.StageBillingId))
                //        _archiveBillingRepository.SaveOrUpdate(Mapper.Map(archiveRecord, new ArchiveBillingTransaction()));

                //    _finalBillingRepository.Delete(archiveRecord);
                //}

                //foreach (var record in _stageBillingRepository)
                //{
                //    if (record.Created <= startBillMonth) continue;

                //    var finalEntity = Mapper.Map(record, new FinalBilling());

                //    _finalBillingRepository.SaveOrUpdate(finalEntity);
                //}

                foreach (var transaction in _finalBillingRepository)
                {
                    #region Customer Transactions

                    if (transaction.CustomerId != new Guid())
                    {
                        this.Info(() => "FinalBilling initiated for Customer: {0}".FormatWith(transaction.CustomerName));
                        var billedCustomerTransactionsTotal = _finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId && x.UserTransaction.IsBillable
                                                                                                 && (x.Created >= startBillMonth && x.Created <= endBillMonth))
                            .Select(x => x.UserTransaction.TransactionId).Distinct().Count();

                        var nonBillableCustomerTransactionsTotal = _finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId && !x.UserTransaction.IsBillable
                                                                                                 && (x.Created >= startBillMonth && x.Created <= endBillMonth))
                            .Select(x => x.UserTransaction.TransactionId).Distinct().Count();

                        #region Invoice PDF Report Build-up

                        var reportPackageList = new List<ReportPackage>();

                        if (billedCustomerTransactionsTotal > 0)
                        {

                            reportPackageList.AddRange(_finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                .Select(x => new ReportPackage
                                {
                                    ItemCode = x.Package.PackageName,
                                    ItemDescription = x.Package.PackageName,
                                    QuantityUnit = _finalBillingRepository.Where(
                                        y => y.CustomerId == transaction.CustomerId && y.UserTransaction.IsBillable
                                             && (y.Created >= startBillMonth && y.Created <= endBillMonth)
                                             && (y.Package.PackageId == x.Package.PackageId))
                                        .Select(y => y.UserTransaction.TransactionId).Distinct().Count(),
                                    Price = x.Package.PackageRecommendedPrice,
                                }).Distinct());
                        }

                        if (nonBillableCustomerTransactionsTotal > 0)
                        {

                            reportPackageList.AddRange(_finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                .Select(x => new ReportPackage
                                {
                                    ItemCode = x.Package.PackageName,
                                    ItemDescription = x.Package.PackageName + " - Non-Billable",
                                    QuantityUnit = _finalBillingRepository.Where(
                                        y => y.CustomerId == transaction.CustomerId && !y.UserTransaction.IsBillable
                                             && (y.Created >= startBillMonth && y.Created <= endBillMonth)
                                             && (y.Package.PackageId == x.Package.PackageId))
                                        .Select(y => y.UserTransaction.TransactionId).Distinct().Count(),
                                    Price = 0,
                                }).Distinct());
                        }



                        var report = _reportBuilder.BuildReport(new ReportTemplate { ShortId = "VJGAd9OM" },
                            new ReportData
                            {
                                Customer = new ReportCustomer
                                {
                                    Name = transaction.CustomerName,
                                    TaxRegistration = account.BillingVatNumber != null ? account.BillingVatNumber.ToInt64() : 0000,
                                    Packages = reportPackageList.Select(y => new ReportPackage
                                    {
                                        ItemCode = y.ItemCode,
                                        ItemDescription = y.ItemDescription,
                                        QuantityUnit = y.QuantityUnit,
                                        Price = y.Price,
                                        Vat = y.Vat
                                    }).ToList()
                                }
                            });

                        //Report Index
                        var reportIndex = invoicePdfList.FindIndex(x => x.Data.Customer.Name == transaction.CustomerName);

                        //Index restriction for new record
                        if (reportIndex < 0) invoicePdfList.Add(report);

                        #endregion

                        #region Statement PDF Report Build-up

                        var contract = _contractRepository.FirstOrDefault(x => x.ContractId == transaction.ContractId);
                        var userTransactions = new List<ContractUserTransactions>();

                        //TODO: Complete user transaction setup for statement
                        //var userTransaction = _finalBillingRepository.Count(x => x.User.UserId == transaction.User.UserId);

                        var statement = _reportBuilder.BuildStatement(transaction.CustomerName, null, contract.ContractName, userTransactions);

                        var statementList = new List<ContractStatement>();
                        var statementIndex = statementList.FindIndex(x => x.Customer == transaction.CustomerName);

                        if (statementIndex < 0) statementList.Add(statement);

                        var statementReport = _reportBuilder.BuildReport(new ReportTemplate { ShortId = "VkTYTvzp" },
                            new ReportData
                            {
                                ContractStatements = statementList
                            });

                        var statementReportIndex = statementPdfList.FindIndex(x => x.Data.ContractStatements.Any(s => s.Customer == transaction.CustomerName));

                        if (statementReportIndex < 0) statementPdfList.Add(statementReport);

                        #endregion

                        #region Pastel CSV Report Build-up

                        var invoice = _reportBuilder.BuildPastelInvoice(pastelCounter, transaction.AccountNumber,
                            transaction.Package.PackageName, transaction.Package.PackageRecommendedPrice);

                        var invoiceListIndex = pastelInvoiceList.FindIndex(x => x.CDESCRIPTION == transaction.Package.PackageName);
                        if (invoiceListIndex < 0)
                        {
                            pastelInvoiceList.Add(invoice);
                            pastelCounter++;
                        }

                        #endregion

                        #region DebitOrder CSV Build-up

                        if (accounts.Any(x => x.AccountNumber == transaction.AccountNumber))
                        {
                            var account = accounts.FirstOrDefault(x => x.AccountNumber == transaction.AccountNumber);

                            var debitOrderRecord = _reportBuilder.BuilDebitOrderRecord(account.AccountNumber, transaction.CustomerName, "1", account.BankAccountName,
                                                                                        account.BankAccountNumber, account.BranchCode.ToString(), "0", "0");

                            if ((debitOrderRecord.AccountName != null) && (debitOrderRecord.BankAccountName != null)
                                && (debitOrderRecord.BranchCode != "0") && (debitOrderRecord.BankAccountNumber != null))
                            {
                                var debitOrderIndex = debitOrderRecordList.FindIndex(x => x.PastelAccountId == debitOrderRecord.PastelAccountId);
                                if (debitOrderIndex < 0) debitOrderRecordList.Add(debitOrderRecord);
                            }
                            else
                            {
                                var debitOrderNotDoneIndex = debitOrderNotDoneRecordList.FindIndex(x => x.PastelAccountId == debitOrderRecord.PastelAccountId);
                                if (debitOrderNotDoneIndex < 0) debitOrderNotDoneRecordList.Add(debitOrderRecord);
                            }
                        }

                        #endregion

                        this.Info(() => "FinalBilling completed for Customer: {0}".FormatWith(transaction.CustomerName));
                    }
                    #endregion

                    #region Client Transactions

                    if (transaction.ClientId != new Guid())
                    {
                        this.Info(() => "FinalBilling initiated for Client: {0}".FormatWith(transaction.ClientName));
                        var billedClientTransactionsTotal = _finalBillingRepository.Where(x => x.ClientId == transaction.ClientId && x.UserTransaction.IsBillable
                                                                                               && (x.Created >= startBillMonth && x.Created <= endBillMonth))
                            .Select(x => x.UserTransaction.TransactionId).Distinct().Count();

                        var nonBillableClientTransactionsTotal = _finalBillingRepository.Where(x => x.ClientId == transaction.ClientId && !x.UserTransaction.IsBillable
                                                                                                 && (x.Created >= startBillMonth && x.Created <= endBillMonth))
                            .Select(x => x.UserTransaction.TransactionId).Distinct().Count();

                        #region Invoice PDF Report Build-up

                        var reportPackageList = new List<ReportPackage>();

                        if (billedClientTransactionsTotal > 0)
                        {

                            reportPackageList.AddRange(_finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                .Select(x => new ReportPackage
                                {
                                    ItemCode = x.Package.PackageName,
                                    ItemDescription = x.Package.PackageName,
                                    QuantityUnit = _finalBillingRepository.Where(
                                        y => y.CustomerId == transaction.CustomerId && y.UserTransaction.IsBillable
                                             && (y.Created >= startBillMonth && y.Created <= endBillMonth)
                                             && (y.Package.PackageId == x.Package.PackageId))
                                        .Select(y => y.UserTransaction.TransactionId).Distinct().Count(),
                                    Price = x.Package.PackageRecommendedPrice,
                                }).Distinct());
                        }

                        if (nonBillableClientTransactionsTotal > 0)
                        {

                            reportPackageList.AddRange(_finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                .Select(x => new ReportPackage
                                {
                                    ItemCode = x.Package.PackageName,
                                    ItemDescription = x.Package.PackageName + " - Non-Billable",
                                    QuantityUnit = _finalBillingRepository.Where(
                                        y => y.CustomerId == transaction.CustomerId && !y.UserTransaction.IsBillable
                                             && (y.Created >= startBillMonth && y.Created <= endBillMonth)
                                             && (y.Package.PackageId == x.Package.PackageId))
                                        .Select(y => y.UserTransaction.TransactionId).Distinct().Count(),
                                    Price = 0,
                                }).Distinct());
                        }



                        var report = _reportBuilder.BuildReport(new ReportTemplate { ShortId = "VJGAd9OM" },
                            new ReportData
                            {
                                Customer = new ReportCustomer
                                {
                                    Name = transaction.CustomerName,
                                    TaxRegistration = account.BillingVatNumber != null ? account.BillingVatNumber.ToInt64() : 0000,
                                    Packages = reportPackageList.Select(y => new ReportPackage
                                    {
                                        ItemCode = y.ItemCode,
                                        ItemDescription = y.ItemDescription,
                                        QuantityUnit = y.QuantityUnit,
                                        Price = y.Price,
                                        Vat = y.Vat
                                    }).ToList()
                                }
                            });

                        //Report Index
                        var reportIndex = invoicePdfList.FindIndex(x => x.Data.Customer.Name == transaction.CustomerName);

                        //Index restriction for new record
                        if (reportIndex < 0) invoicePdfList.Add(report);

                        #endregion

                        #region Pastel CSV Report Build-up

                        var invoice = _reportBuilder.BuildPastelInvoice(pastelCounter, transaction.AccountNumber,
                            transaction.Package.PackageName, transaction.Package.PackageRecommendedPrice);

                        var invoiceListIndex = pastelInvoiceList.FindIndex(x => x.CDESCRIPTION == transaction.Package.PackageName);
                        if (invoiceListIndex < 0)
                        {
                            pastelInvoiceList.Add(invoice);
                            pastelCounter++;
                        }

                        #endregion

                        #region DebitOrder CSV Build-up

                        if (accounts.Any(x => x.AccountNumber == transaction.AccountNumber))
                        {
                            var account = accounts.FirstOrDefault(x => x.AccountNumber == transaction.AccountNumber);

                            var debitOrderRecord = _reportBuilder.BuilDebitOrderRecord(account.AccountNumber, transaction.CustomerName, "1", account.BankAccountName,
                                                                                        account.BankAccountNumber, account.BranchCode.ToString(), "0", "0");

                            if ((debitOrderRecord.AccountName != string.Empty) || (debitOrderRecord.BankAccountName != string.Empty)
                                || (debitOrderRecord.BranchCode != "0") || (debitOrderRecord.BankAccountNumber != string.Empty))
                            {
                                var debitOrderIndex = debitOrderRecordList.FindIndex(x => x.PastelAccountId == debitOrderRecord.PastelAccountId);
                                if (debitOrderIndex < 0) debitOrderRecordList.Add(debitOrderRecord);
                            }
                            else
                            {
                                var debitOrderNotDoneIndex = debitOrderNotDoneRecordList.FindIndex(x => x.PastelAccountId == debitOrderRecord.PastelAccountId);
                                if (debitOrderNotDoneIndex < 0) debitOrderNotDoneRecordList.Add(debitOrderRecord);
                            }
                        }

                        #endregion

                        this.Info(() => "FinalBilling completed for Client: {0}".FormatWith(transaction.ClientName));
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                this.Error(() => ex.Message);
            }

            var pastelReport = _reportBuilder.BuildReport(new ReportTemplate { ShortId = "EJ-dvWnX" },
                new ReportData
                {
                    Invoices = pastelInvoiceList
                });

            var debitOrderReport = _reportBuilder.BuildReport(new ReportTemplate { ShortId = "4ksFqmUp" },
                new ReportData
                {
                    BillDateTime1 = DateTime.UtcNow.ToString("yyyyMMdd"),
                    BillDateTime2 = DateTime.UtcNow.ToString("yyyy/MM/dd"),
                    DebitOrders = debitOrderRecordList
                });

            var debitOrderNotDoneReport = _reportBuilder.BuildReport(new ReportTemplate { ShortId = "4ksFqmUp" },
                new ReportData
                {
                    BillDateTime1 = DateTime.UtcNow.ToString("yyyyMMdd"),
                    BillDateTime2 = DateTime.UtcNow.ToString("yyyy/MM/dd"),
                    DebitOrders = debitOrderNotDoneRecordList
                });

            pastelReportList.Add(pastelReport);
            debitOrderReportList.Add(debitOrderReport);
            debitOrderNotDoneReportList.Add(debitOrderNotDoneReport);

            // Publish to Reporting for processing
            // Note Pdf report types get emailed to relevant mailing contacts
            _report.PublishToQueue(invoicePdfList, "pdf");
            _report.PublishToQueue(statementPdfList, "pdf");
            _report.PublishToQueue(pastelReportList, "pastel");
            _report.PublishToQueue(debitOrderReportList, "debitOrder");
            _report.PublishToQueue(debitOrderNotDoneReportList, "debitOrderND");

            this.Info(() => "FinalBilling process completed for : {0} - to - {1}".FormatWith(startBillMonth, endBillMonth));
        }
    }
}