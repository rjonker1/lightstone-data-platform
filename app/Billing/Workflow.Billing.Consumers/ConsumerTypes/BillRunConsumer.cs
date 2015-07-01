using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Billing.Domain.Dtos;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Newtonsoft.Json;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Domain.Helpers.BillingRunHelpers;
using Workflow.Reporting.Dtos;
using Workflow.Reporting.Entities;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class BillRunConsumer
    {
        private readonly IRepository<StageBilling> _stageBillingRepository;
        private readonly IRepository<FinalBilling> _finalBillingRepository;

        private readonly IAdvancedBus _bus;

        private readonly IPivotBilling<PivotStageBilling> _pivotStageBilling;
        //private readonly IPivotBilling<PivotFinalBilling> _pivotFinalBilling;

        public BillRunConsumer(IRepository<StageBilling> stageBillingRepository, IRepository<FinalBilling> finalBillingRepository, IAdvancedBus bus, IPivotBilling<PivotStageBilling> pivotStageBilling)
        {
            _stageBillingRepository = stageBillingRepository;
            _finalBillingRepository = finalBillingRepository;
            _bus = bus;
            _pivotStageBilling = pivotStageBilling;
            //_pivotFinalBilling = pivotFinalBilling;
        }

        public void Consume(IMessage<BillingMessage> message)
        {

            var bus = new TransactionBus(_bus);
            var reportList = new List<ReportDto>();
            var csvReportList = new List<ReportDto>();

            #region Pivot PreBilling - Stage

            if (message.Body.RunType == "Stage")
                _pivotStageBilling.Pivot();

            #endregion

            #region Pivot StageBilling - Final

            var currentBillMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);
            var previousBillMonth = new DateTime(DateTime.Now.Year, (DateTime.Now.Month - 1), 26);

            if (message.Body.RunType == "Final")
            {

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
            }
            #endregion

            #region Report Queue

            //PDF
            foreach (var report in reportList)
            {
                bus.SendDynamic(new ReportMessage
                {
                    Id = Guid.NewGuid(),
                    ReportBody = JsonConvert.SerializeObject(report),
                    ReportType = "pdf"
                });
            }

            //CSV
            foreach (var report in csvReportList)
            {
                bus.SendDynamic(new ReportMessage
                {
                    Id = Guid.NewGuid(),
                    ReportBody = JsonConvert.SerializeObject(report),
                    ReportType = "csv"
                });
            }
            #endregion

        }
    }
}