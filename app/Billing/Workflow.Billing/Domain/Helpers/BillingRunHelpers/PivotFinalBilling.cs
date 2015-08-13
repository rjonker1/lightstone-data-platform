using System;
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
        private readonly IRepository<ArchiveBillingTransaction> _archiveBillingRepository; 

        private readonly IPublishReportQueue<BillingReport> _report;

        public PivotFinalBilling(IRepository<StageBilling> stageBillingRepository, IRepository<FinalBilling> finalBillingRepository,  IRepository<ArchiveBillingTransaction> archiveBillingRepository,
                                    IPublishReportQueue<BillingReport> report)
        {
            _stageBillingRepository = stageBillingRepository;
            _finalBillingRepository = finalBillingRepository;
            _archiveBillingRepository = archiveBillingRepository;
            _report = report;
        }

        public void Pivot()
        {
            var reportList = new List<ReportDto>();
            var csvReportList = new List<ReportDto>();

            var currentBillMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);
            var previousBillMonth = new DateTime(DateTime.Now.Year, (DateTime.Now.Month - 1), 26);

            this.Info(() => "FinalBilling process started for : {0} - to - {1}".FormatWith(previousBillMonth, currentBillMonth));

            try
            {
                // Archive and clean Final Billing for new month
                foreach (var archiveRecord in _finalBillingRepository)
                {
                    _archiveBillingRepository.SaveOrUpdate(Mapper.Map(archiveRecord, new ArchiveBillingTransaction()));
                    _finalBillingRepository.Delete(archiveRecord);
                }

                foreach (var record in _stageBillingRepository)
                {
                    if (record.Created <= previousBillMonth) continue;

                    var finalEntity = Mapper.Map(record, new FinalBilling());

                    _finalBillingRepository.SaveOrUpdate(finalEntity);
                }

                foreach (var transaction in _finalBillingRepository)
                {
                    #region Customer Transactions

                    if (transaction.CustomerId != new Guid())
                    {
                        this.Info(() => "FinalBilling initiated for Customer: {0}".FormatWith(transaction.CustomerName));
                        var billedCustomerTransactionsTotal = _finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId && x.UserTransaction.IsBillable
                                                                                                 && (x.Created >= previousBillMonth && x.Created <= currentBillMonth))
                            .Select(x => x.UserTransaction.TransactionId).Distinct().Count();

                        var packagesList =
                            _finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                .Select(x => new ReportPackage
                                {
                                    ItemCode = x.Package.PackageName,
                                    ItemDescription = x.Package.PackageName,
                                    QuantityUnit = billedCustomerTransactionsTotal,
                                    Price = x.Package.PackageRecommendedPrice,
                                    //Vat = 0
                                }).Distinct();

                        var reportData = new ReportDto()
                        {
                            Template = new ReportTemplate { ShortId = "VJGAd9OM" },
                            Data = new ReportData
                            {
                                Customer = new ReportCustomer
                                {
                                    Name = transaction.CustomerName,
                                    TaxRegistration = 4190195679,
                                    Packages = packagesList.ToList()
                                }
                            }
                        };

                        //Report Index
                        var reportIndex = reportList.FindIndex(x => x.Data.Customer.Name == transaction.CustomerName);

                        //Index restriction for new record
                        if (reportIndex < 0) reportList.Add(reportData);

                        #region CSV Report Build-up

                        var invoiceList = new List<ReportInvoice>();

                        var invoice = new ReportInvoice
                        {
                            DOCTYPE = "INV",
                            INVNUMBER = transaction.UserTransaction.RequestId.ToString(),
                            ACCOUNTID = transaction.AccountNumber,
                            DESCRIPTION = "",
                            INVDATE = DateTime.UtcNow.ToString(),
                            TAXINCLUSIVE = "",
                            ORDERNUM = "",
                            CDESCRIPTION = "",
                            FQUANTITY = billedCustomerTransactionsTotal.ToString(),
                            FUNITPRICEEXCL = "",
                            ITAXTYPEID = "",
                            ISTOCKCODEID = "",
                            Project = "",
                            Tax_Number = ""
                        };

                        var invoiceListIndex = invoiceList.FindIndex(x => x.ACCOUNTID == transaction.AccountNumber);
                        if (invoiceListIndex < 0) invoiceList.Add(invoice);

                        var csvReportData = new ReportDto()
                        {
                            Template = new ReportTemplate { ShortId = "EJ-dvWnX" },
                            Data = new ReportData
                            {
                                Invoices = invoiceList
                            }
                        };

                        //Report Index
                        var csvReportIndex = csvReportList.FindIndex(x => x.Data.Invoices.Any(i => i.ACCOUNTID == transaction.AccountNumber));

                        //Index restriction for new record
                        if (csvReportIndex < 0) csvReportList.Add(csvReportData);

                        #endregion

                        this.Info(() => "FinalBilling completed for Customer: {0}".FormatWith(transaction.CustomerName));
                    }
                    #endregion

                    #region Client Transactions

                    if (transaction.ClientId != new Guid())
                    {
                        this.Info(() => "FinalBilling initiated for Client: {0}".FormatWith(transaction.ClientName));
                        var billedClientTransactionsTotal = _finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId && x.UserTransaction.IsBillable
                                                                                               && (x.Created >= previousBillMonth && x.Created <= currentBillMonth))
                            .Select(x => x.UserTransaction.TransactionId).Distinct().Count();

                        var packagesList = _finalBillingRepository.Where(x => x.ClientId == transaction.ClientId)
                            .Select(x => new ReportPackage
                            {
                                ItemCode = x.Package.PackageName,
                                ItemDescription = x.Package.PackageName,
                                QuantityUnit = billedClientTransactionsTotal,
                                Price = x.Package.PackageRecommendedPrice,
                                //Vat = 2284
                            }).Distinct();

                        var reportData = new ReportDto
                        {
                            Template = new ReportTemplate { ShortId = "VJGAd9OM" },
                            Data = new ReportData
                            {
                                Customer = new ReportCustomer
                                {
                                    Name = transaction.ClientName,
                                    TaxRegistration = 4190195679,
                                    Packages = packagesList.ToList()
                                }
                            }
                        };

                        //Report Index
                        var reportIndex = reportList.FindIndex(x => x.Data.Customer.Name == transaction.ClientName);

                        //Index restriction for new record
                        if (reportIndex < 0) reportList.Add(reportData);

                        #region CSV Report Build-up

                        var invoiceList = new List<ReportInvoice>();

                        var invoice = new ReportInvoice
                        {
                            DOCTYPE = "INV",
                            INVNUMBER = "",
                            ACCOUNTID = transaction.AccountNumber,
                            DESCRIPTION = "",
                            INVDATE = "",
                            TAXINCLUSIVE = "",
                            ORDERNUM = "",
                            CDESCRIPTION = "",
                            FQUANTITY = billedClientTransactionsTotal.ToString(),
                            FUNITPRICEEXCL = "",
                            ITAXTYPEID = "",
                            ISTOCKCODEID = "",
                            Project = "",
                            Tax_Number = ""
                        };

                        var invoiceListIndex = invoiceList.FindIndex(x => x.ACCOUNTID == transaction.AccountNumber);
                        if (invoiceListIndex < 0) invoiceList.Add(invoice);

                        var csvReportData = new ReportDto
                        {
                            Template = new ReportTemplate { ShortId = "EJ-dvWnX" },
                            Data = new ReportData
                            {
                                Invoices = invoiceList
                            }
                        };

                        //Report Index
                        var csvReportIndex = csvReportList.FindIndex(x => x.Data.Invoices.Any(i => i.ACCOUNTID == transaction.AccountNumber));

                        //Index restriction for new record
                        if (csvReportIndex < 0) csvReportList.Add(csvReportData);

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

            this.Info(() => "FinalBilling process completed for : {0} - to - {1}".FormatWith(previousBillMonth, currentBillMonth));

            _report.PublishToQueue(reportList, "pdf");
            _report.PublishToQueue(csvReportList, "csv");
        }
    }
}