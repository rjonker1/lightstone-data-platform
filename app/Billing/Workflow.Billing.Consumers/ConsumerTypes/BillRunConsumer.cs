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
using Workflow.Reporting.Dtos;
using Workflow.Reporting.Entities;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class BillRunConsumer
    {
        private readonly IRepository<PreBilling> _preBillingrRepository;
        private readonly IRepository<StageBilling> _stageBillingRepository;
        private readonly IRepository<FinalBilling> _finalBillingRepository;

        private readonly IAdvancedBus _bus;

        public BillRunConsumer(IRepository<PreBilling> preBillingrRepository, IRepository<StageBilling> stageBillingRepository, IRepository<FinalBilling> finalBillingRepository, IAdvancedBus bus)
        {
            _preBillingrRepository = preBillingrRepository;
            _stageBillingRepository = stageBillingRepository;
            _finalBillingRepository = finalBillingRepository;
            _bus = bus;
        }

        public void Consume(IMessage<BillingMessage> message)
        {

            var bus = new TransactionBus(_bus);
            var reportList = new List<ReportDto>();
            var csvReportList = new List<ReportDto>();

            #region Map PreBilling - Stage

            foreach (var preBilling in _preBillingrRepository)
            {
                var stageEntity = Mapper.Map(preBilling, new StageBilling());
                //var finalEntity = Mapper.Map(preBilling, new FinalBilling());

                #region StageBilling

                if (message.Body.RunType == "Stage")
                    if (!_stageBillingRepository.Any(x => x.PreBillingId == stageEntity.PreBillingId))
                        _stageBillingRepository.SaveOrUpdate(stageEntity);

                #endregion

            }
            #endregion

            #region Map StageBilling - Final

            var thisMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25, 0, 0, 0);
            var lastMonth = new DateTime(DateTime.Now.Year, (DateTime.Now.Month - 1), 26, 0, 0, 0);

            if (message.Body.RunType == "Final")
            {
                
                this.Info(() => "FinalBilling process started for : {0} - to - {1}".FormatWith(lastMonth, thisMonth));

                foreach (var stageBilling in _stageBillingRepository)
                {
                    var finalEntity = Mapper.Map(stageBilling, new FinalBilling());

                    #region FinalBilling

                    if (!_finalBillingRepository.Any(x => x.StageBillingId == finalEntity.StageBillingId))
                        _finalBillingRepository.SaveOrUpdate(finalEntity);

                    foreach (var transaction in _finalBillingRepository)
                    {

                        //Customer
                        if (transaction.CustomerId != new Guid())
                        {
                            var billedCustomerTransactionsTotal = _finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId && x.IsBillable
                                                                    && (x.Created >= lastMonth && x.Created <= thisMonth))
                                                        .Select(x => x.TransactionId).Distinct().Count();

                            var packagesList =
                                _finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                    .Select(x => new ReportPackage
                                    {
                                        ItemCode = "1000/200/002",
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


                            //CSV Report Build-up

                            var invoiceList = new List<ReportInvoice>();
                            
                            var invoice =  new ReportInvoice
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

                            /////// END ////////
                        }

                        //Client
                        if (transaction.ClientId != new Guid())
                        {

                            var billedClientTransactionsTotal = _finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId && x.IsBillable
                                                                    && (x.Created >= lastMonth && x.Created <= thisMonth))
                                                        .Select(x => x.TransactionId).Distinct().Count();

                            var packagesList = _finalBillingRepository.Where(x => x.ClientId == transaction.ClientId)
                                .Select(x => new ReportPackage
                                {
                                    ItemCode = "1000/200/002",
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


                            //CSV Report Build-up

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

                            /////// END ////////
                        }
                    }

                }

                this.Info(() => "FinalBilling process completed for : {0} - to - {1}".FormatWith(lastMonth, thisMonth));
                #endregion
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