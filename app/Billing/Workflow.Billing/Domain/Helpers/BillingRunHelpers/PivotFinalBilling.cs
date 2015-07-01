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

        private readonly IPublishReportQueue<BillingReport> _report; 

        public PivotFinalBilling(IRepository<StageBilling> stageBillingRepository, IRepository<FinalBilling> finalBillingRepository, IPublishReportQueue<BillingReport> report)
        {
            _stageBillingRepository = stageBillingRepository;
            _finalBillingRepository = finalBillingRepository;
            _report = report;
        }

        public void Pivot()
        {
            var reportList = new List<ReportDto>();
            var csvReportList = new List<ReportDto>();

            var currentBillMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);
            var previousBillMonth = new DateTime(DateTime.Now.Year, (DateTime.Now.Month - 1), 26);

            this.Info(() => "FinalBilling process started for : {0} - to - {1}".FormatWith(previousBillMonth, currentBillMonth));

            foreach (var stageBilling in _stageBillingRepository)
            {
                var finalEntity = Mapper.Map(stageBilling, new FinalBilling());

                if (!_finalBillingRepository.Any(x => x.StageBillingId == finalEntity.StageBillingId))
                    _finalBillingRepository.SaveOrUpdate(finalEntity);

                foreach (var transaction in _finalBillingRepository)
                {
                    #region Customer Transactions

                    if (transaction.CustomerId != new Guid())
                    {
                        var billedCustomerTransactionsTotal = _finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId && x.IsBillable
                                                                && (x.Created >= previousBillMonth && x.Created <= currentBillMonth))
                                                    .Select(x => x.TransactionId).Distinct().Count();

                        var packagesList =
                            _finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                .Select(x => new ReportPackage
                                {
                                    ItemCode = x.PackageName,
                                    ItemDescription = x.PackageName,
                                    QuantityUnit = billedCustomerTransactionsTotal,
                                    Price = x.Price,
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
                            INVNUMBER = "",
                            ACCOUNTID = transaction.AccountNumber,
                            DESCRIPTION = "",
                            INVDATE = "",
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
                    }
                    #endregion

                    #region Client Transactions

                    if (transaction.ClientId != new Guid())
                    {

                        var billedClientTransactionsTotal = _finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId && x.IsBillable
                                                                && (x.Created >= previousBillMonth && x.Created <= currentBillMonth))
                                                    .Select(x => x.TransactionId).Distinct().Count();

                        var packagesList = _finalBillingRepository.Where(x => x.ClientId == transaction.ClientId)
                            .Select(x => new ReportPackage
                            {
                                ItemCode = x.PackageName,
                                ItemDescription = x.PackageName,
                                QuantityUnit = billedClientTransactionsTotal,
                                Price = x.Price,
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
                    }
                    #endregion
                }

            }

            this.Info(() => "FinalBilling process completed for : {0} - to - {1}".FormatWith(previousBillMonth, currentBillMonth));

            _report.PublishToQueue(reportList, "pdf");
            _report.PublishToQueue(csvReportList, "csv");
        }
    }
}