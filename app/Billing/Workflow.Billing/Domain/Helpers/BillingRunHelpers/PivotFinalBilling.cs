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

        public PivotFinalBilling(IRepository<StageBilling> stageBillingRepository, IRepository<FinalBilling> finalBillingRepository, IRepository<ArchiveBillingTransaction> archiveBillingRepository,
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
            var pastelInvoiceList = new List<ReportInvoice>();

            var currentBillMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);
            var previousBillMonth = new DateTime(DateTime.Now.Year, (DateTime.Now.Month - 1), 26);

            var pastelCounter = 1;

            this.Info(() => "FinalBilling process started for : {0} - to - {1}".FormatWith(previousBillMonth, currentBillMonth));

            try
            {
                // Archive and clean Final Billing for new month
                foreach (var archiveRecord in _finalBillingRepository)
                {
                    if (!_archiveBillingRepository.Any(x => x.StageBillingId == archiveRecord.StageBillingId))
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

                        var nonBillableCustomerTransactionsTotal = _finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId && !x.UserTransaction.IsBillable
                                                                                                 && (x.Created >= previousBillMonth && x.Created <= currentBillMonth))
                            .Select(x => x.UserTransaction.TransactionId).Distinct().Count();

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
                                             && (y.Created >= previousBillMonth && y.Created <= currentBillMonth)
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
                                             && (y.Created >= previousBillMonth && y.Created <= currentBillMonth)
                                             && (y.Package.PackageId == x.Package.PackageId))
                                        .Select(y => y.UserTransaction.TransactionId).Distinct().Count(),
                                    Price = 0,
                                }).Distinct());
                        }

                        var reportData = new ReportDto()
                        {
                            Template = new ReportTemplate { ShortId = "VJGAd9OM" },
                            Data = new ReportData
                            {
                                Customer = new ReportCustomer
                                {
                                    Name = transaction.CustomerName,
                                    TaxRegistration = 0,
                                    Packages = reportPackageList.Select(y => new ReportPackage
                                    {
                                        ItemCode = y.ItemCode,
                                        ItemDescription = y.ItemDescription,
                                        QuantityUnit = y.QuantityUnit,
                                        Price = y.Price,
                                        Vat = y.Vat
                                    }).ToList()
                                }
                            }
                        };

                        //Report Index
                        var reportIndex = reportList.FindIndex(x => x.Data.Customer.Name == transaction.CustomerName);

                        //Index restriction for new record
                        if (reportIndex < 0) reportList.Add(reportData);

                        #region CSV Report Build-up

                        var invoice = BuildReportInovice(pastelCounter, transaction.AccountNumber,
                            transaction.Package.PackageName, transaction.Package.PackageRecommendedPrice);

                        var invoiceListIndex = pastelInvoiceList.FindIndex(x => x.CDESCRIPTION == transaction.Package.PackageName);
                        if (invoiceListIndex < 0)
                        {
                            pastelInvoiceList.Add(invoice);
                            pastelCounter++;
                        }

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
                                    TaxRegistration = 0,
                                    Packages = packagesList.ToList()
                                }
                            }
                        };

                        //Report Index
                        var reportIndex = reportList.FindIndex(x => x.Data.Customer.Name == transaction.ClientName);

                        //Index restriction for new record
                        if (reportIndex < 0) reportList.Add(reportData);

                        #region CSV Report Build-up

                        var invoice = BuildReportInovice(pastelCounter, transaction.AccountNumber,
                            transaction.Package.PackageName, transaction.Package.PackageRecommendedPrice);

                        var invoiceListIndex = pastelInvoiceList.FindIndex(x => x.CDESCRIPTION == transaction.Package.PackageName);
                        if (invoiceListIndex < 0)
                        {
                            pastelInvoiceList.Add(invoice);
                            pastelCounter++;
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

            var csvReportData = new ReportDto()
            {
                Template = new ReportTemplate { ShortId = "EJ-dvWnX" },
                Data = new ReportData
                {
                    Invoices = pastelInvoiceList
                }
            };

            csvReportList.Add(csvReportData);

            this.Info(() => "FinalBilling process completed for : {0} - to - {1}".FormatWith(previousBillMonth, currentBillMonth));

            _report.PublishToQueue(reportList, "pdf");
            _report.PublishToQueue(csvReportList, "csv");
        }

        private ReportInvoice BuildReportInovice(int invoiceNumber, string accountNumber, string productName, double productPrice)
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
    }
}