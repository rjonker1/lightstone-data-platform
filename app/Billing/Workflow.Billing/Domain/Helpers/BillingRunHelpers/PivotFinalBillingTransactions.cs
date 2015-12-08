using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Repositories;
using Nancy.Extensions;
using NHibernate;
using NHibernate.Transform;
using ServiceStack.Common;
using Shared.Logging;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Domain.Helpers.BillingRunHelpers.Infrastructure;
using Workflow.Reporting.Dtos;
using Workflow.Reporting.Entities;

namespace Workflow.Billing.Domain.Helpers.BillingRunHelpers
{
    public class StatementDetail
    {
        public virtual string AccountContact { get; set; }
        public virtual string AccountNumber { get; set; }
        public virtual string ConsultantName { get; set; }
        public virtual string ContractName { get; set; }
        public virtual string CustomerClientName { get; set; }
        public virtual string StatementPeriod { get; set; }
    }

    public class UserTransactionDto
    {
        public virtual string Username { get; set; }
        public virtual string PackageName { get; set; }
        public virtual int Transactions { get; set; }
        public virtual int BillableTransactions { get; set; }
    }

    public class PricingSummaryDto
    {
        public virtual string ContractName { get; set; }
        public virtual string Description { get; set; }
        public virtual string PackageName { get; set; }
    }

    public class PivotFinalBillingTransactions : ReportList, IPivotFinalBillingTransactions
    {
        private readonly IRepository<FinalBilling> _finalBillingRepository;
        private readonly IRepository<AccountMeta> _accountMetaRepository;
        private readonly IRepository<ContractMeta> _contractRepository;
        private readonly IRepository<PackageMeta> _packageMetaRepository;

        private readonly ISession _session;

        private readonly IReportBuilder _reportBuilder;

        readonly DateTime _endBillMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month - 1, 25).AddHours(23).AddMinutes(59).AddSeconds(59);
        readonly DateTime _startBillMonth = new DateTime(DateTime.UtcNow.Year, (DateTime.UtcNow.Month - 2), 26);

        public PivotFinalBillingTransactions(IRepository<FinalBilling> finalBillingRepository, IRepository<AccountMeta> accountMetaRepository,
                                                IRepository<ContractMeta> contractRepository, IReportBuilder reportBuilder, IRepository<PackageMeta> packageMetaRepository, ISession session)
        {
            _finalBillingRepository = finalBillingRepository;
            _accountMetaRepository = accountMetaRepository;
            _contractRepository = contractRepository;
            _reportBuilder = reportBuilder;
            _packageMetaRepository = packageMetaRepository;
            _session = session;

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

            foreach (var customerClientId in _finalBillingRepository.Select(x => x.CustomerId != null ? x.CustomerId : x.ClientId).Distinct())
            {
                var customerClientDetail = _finalBillingRepository.FirstOrDefault(x => x.CustomerId == customerClientId || x.ClientId == customerClientId);

                var account = _accountMetaRepository.FirstOrDefault(x => x.AccountNumber == customerClientDetail.AccountNumber);

                var billedTransactionsTotal =
                    _finalBillingRepository.Where(
                        x => (x.CustomerId == customerClientId || x.ClientId == customerClientId) && x.UserTransaction.IsBillable
                             && (x.Created >= _startBillMonth && x.Created <= _endBillMonth))
                        .Select(x => x.UserTransaction.TransactionId).Distinct().Count();

                var nonBillableTransactionsTotal =
                _finalBillingRepository.Where(
                    x => (x.CustomerId == customerClientId || x.ClientId == customerClientId) && !x.UserTransaction.IsBillable
                         && (x.Created >= _startBillMonth && x.Created <= _endBillMonth))
                    .Select(x => x.UserTransaction.TransactionId).Distinct().Count();

                try
                {
                    var reportPackageList = new List<ReportPackage>();

                    if (billedTransactionsTotal > 0)
                    {
                        reportPackageList.AddRange(
                            _finalBillingRepository.Where(x => x.CustomerId == customerClientId || x.ClientId == customerClientId)
                                .Select(x => new ReportPackage
                                {
                                    ItemCode = x.Package.PackageName,
                                    ItemDescription = x.Package.PackageName,
                                    QuantityUnit = _finalBillingRepository.Where(
                                        y => y.CustomerId == customerClientId && y.UserTransaction.IsBillable
                                             && (y.Created >= _startBillMonth && y.Created <= _endBillMonth)
                                             && (y.Package.PackageId == x.Package.PackageId))
                                        .Select(y => y.UserTransaction.TransactionId).Distinct().Count(),
                                    Price = x.Package.PackageRecommendedPrice,
                                }).Distinct());
                    }

                    if (nonBillableTransactionsTotal > 0)
                    {
                        reportPackageList.AddRange(
                            _finalBillingRepository.Where(x => x.CustomerId == customerClientId || x.ClientId == customerClientId)
                                .Select(x => new ReportPackage
                                {
                                    ItemCode = x.Package.PackageName,
                                    ItemDescription = x.Package.PackageName + " - Non-Billable",
                                    QuantityUnit = _finalBillingRepository.Where(
                                        y => y.CustomerId == customerClientId && !y.UserTransaction.IsBillable
                                             && (y.Created >= _startBillMonth && y.Created <= _endBillMonth)
                                             && (y.Package.PackageId == x.Package.PackageId))
                                        .Select(y => y.UserTransaction.TransactionId).Distinct().Count(),
                                    Price = 0,
                                }).Distinct());
                    }

                    var report = _reportBuilder.BuildReport(new ReportTemplate { ShortId = ReportTemplateIdentifier.InvoicePdf },
                        new ReportData
                        {
                            Customer = new ReportCustomer
                            {
                                Name = customerClientDetail.CustomerName != null ? customerClientDetail.CustomerName : customerClientDetail.ClientName,
                                TaxRegistration =
                                    account.BillingVatNumber != null ? account.BillingVatNumber.ToInt64() : 0000,
                                Packages = reportPackageList.Select(y => new ReportPackage
                                {
                                    ItemCode = y.ItemCode,
                                    ItemDescription = y.ItemDescription,
                                    QuantityUnit = y.QuantityUnit,
                                    Price = y.Price,
                                    Vat = account.BillingVatNumber != null ? account.BillingVatNumber.ToInt() : 0000
                                }).ToList()
                            }
                        });

                    InvoicePdfList.Add(report);
                }
                catch (Exception e)
                {
                    this.Error(() => "An Error Occured while creating InvoicePdf record. See below for details." + e);
                }
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
                var customerList = _finalBillingRepository.Select(x => x.CustomerId).Distinct();

                foreach (var customerId in customerList)
                {
                    var statement = new CustomerClientStatement();
                    var userTransactions = new List<ContractUserTransactions>();

                    var statementDetail = _session.CreateSQLQuery(@"EXEC BillingStatementDetails @CustomerClientId=:CustomerClientId")
                        .SetGuid("CustomerClientId", new Guid(customerId.ToString()))
                        .SetResultTransformer(Transformers.AliasToBean(typeof(StatementDetail)))
                        .List<StatementDetail>();

                    statement.AccountContact = statementDetail[0].AccountContact;
                    statement.AccountNumber = statementDetail[0].AccountNumber;
                    statement.ConsultantName = statementDetail[0].ConsultantName;
                    statement.ContractName = statementDetail[0].ContractName;
                    statement.CustomerClientName = statementDetail[0].CustomerClientName;
                    statement.StatementPeriod = _startBillMonth.ToString("yyyy/MM/dd") + " - " +
                                                _endBillMonth.ToString("yyyy/MM/dd");

                    var ut = _session.CreateSQLQuery(@"EXEC BillingStatementUserTransactions @CustomerClientId=:CustomerClientId, @StartDate=:StartDate, @EndDate=:EndDate")
                            .SetParameter("CustomerClientId", new Guid(customerId.ToString()))
                            .SetParameter("StartDate", _startBillMonth)
                            .SetParameter("EndDate", _endBillMonth)
                            .SetResultTransformer(Transformers.AliasToBean(typeof(UserTransactionDto)))
                            .List<UserTransactionDto>();

                    foreach (var userTransactionDto in ut)
                    {
                        var products = new List<ContractProductDetail>
                        {
                            new ContractProductDetail
                            {
                                BillableTransactionCount = userTransactionDto.BillableTransactions,
                                TransactionCount = userTransactionDto.Transactions,
                                PackageName = userTransactionDto.PackageName
                            }
                        };

                        var index = userTransactions.FindIndex(x => x.User == userTransactionDto.Username);

                        if (index < 0)
                        {
                            userTransactions.Add(new ContractUserTransactions
                            {
                                Products = products,
                                User = userTransactionDto.Username
                            });

                            continue;
                        }

                        var productRange = userTransactions[index].Products.ToList();
                        productRange.AddRange(products);
                        userTransactions[index].Products = productRange;
                    }

                    statement.UserTransactions = userTransactions;

                    var ps = _session.CreateSQLQuery(@"EXEC BillingStatementPricingSummary @CustomerClientId=:CustomerClientId, @StartDate=:StartDate, @EndDate=:EndDate")
                            .SetParameter("CustomerClientId", new Guid(customerId.ToString()))
                            .SetParameter("StartDate", _startBillMonth)
                            .SetParameter("EndDate", _endBillMonth)
                            .SetResultTransformer(Transformers.AliasToBean(typeof(PricingSummaryDto)))
                            .List<PricingSummaryDto>();

                    statement.PricingSummaries = ps.Select(pricingSummaryDto => new PricingSummary
                    {
                        ContractName = pricingSummaryDto.ContractName,
                        PackageName = pricingSummaryDto.PackageName,
                        Description = pricingSummaryDto.Description
                    }).ToList();


                    // Build Statement
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

            //this.Info(() => "PivotToStatementPdf process started");

            //foreach (var customerClientId in _finalBillingRepository.Select(x => x.CustomerId != null ? x.CustomerId : x.ClientId).Distinct())
            //{
            //    var customerClientTransactions = _finalBillingRepository.Where(x => (x.CustomerId == customerClientId || x.ClientId == customerClientId)
            //                                                        && (x.Created >= _startBillMonth && x.Created <= _endBillMonth));

            //    try
            //    {
            //        var statement = new CustomerClientStatement();

            //        foreach (var transaction in customerClientTransactions)
            //        {


            //            var account = _accountMetaRepository.FirstOrDefault(x => x.AccountNumber == transaction.AccountNumber);
            //            var contract = _contractRepository.FirstOrDefault(x => x.ContractId == transaction.ContractId);

            //            // Workaround for temporary missing contract id's due to initial failed async deployment
            //            if (contract.ContractId.Equals(new Guid())) continue;

            //            var index = StatementPdfList.FindIndex(x =>
            //                                        (x.Data.CustomerClientStatement.CustomerClientName == transaction.CustomerName || 
            //                                            x.Data.CustomerClientStatement.CustomerClientName == transaction.ClientName) &&
            //                                        x.Data.CustomerClientStatement.ContractName == contract.ContractName);

            //            if (index > 0) continue;

            //            var pricingSummaryList = new List<PricingSummary>();
            //            var userTransactionsList = new List<ContractUserTransactions>();

            //            // Customer transaction
            //            if (transaction.ClientId == new Guid())
            //            {
            //                statement.StatementPeriod = _startBillMonth.ToString("yyyy/MM/dd") + " - " + _endBillMonth.ToString("yyyy/MM/dd");
            //                statement.CustomerClientName = transaction.CustomerName;
            //                statement.ConsultantName = account.AccountOwner;
            //                statement.AccountContact = account.BillingAccountContactName;
            //                statement.AccountNumber = account.BillingAccountContactNumber;
            //                statement.ContractName = contract.ContractName;

            //                // Bundle check
            //                if (contract.HasPackagePriceOverride)
            //                {
            //                    pricingSummaryList.AddRange(customerClientTransactions
            //                        .Select(x => new PricingSummary
            //                        {
            //                            ContractName = _contractRepository.Where(t => t.ContractId == x.ContractId).Select(t => t.ContractName).First(),
            //                            PackageName = _packageMetaRepository.Where(t => t.PackageId == x.Package.PackageId).Select(t => t.PackageName).First(),
            //                            Description = _contractRepository.Where(t => t.ContractId == x.ContractId).Select(t => t.ContractBundleTransactionLimit).First() +
            //                                            " @ " + contract.ContractBundlePrice + ". " +
            //                                            _contractRepository.Where(t => t.ContractId == x.ContractId).Select(t => t.ContractBundleName).First()
            //                        }).DistinctBy(x => x.PackageName));
            //                }
            //                else
            //                {
            //                    pricingSummaryList.AddRange(customerClientTransactions
            //                        .Select(x => new PricingSummary
            //                        {
            //                            ContractName = _contractRepository.Where(t => t.ContractId == x.ContractId).Select(t => t.ContractName).First(),
            //                            PackageName = _packageMetaRepository.Where(t => t.PackageId == x.Package.PackageId).Select(t => t.PackageName).First(),
            //                            Description = "Per request @ " + x.Package.PackageRecommendedPrice
            //                        }).DistinctBy(x => x.PackageName));
            //                }

            //                statement.PricingSummaries = pricingSummaryList;

            //                var users = customerClientTransactions.Select(x => x.User.UserId).Distinct();

            //                foreach (var userId in users)
            //                {
            //                    var userTransactions = customerClientTransactions.Where(x => x.User.UserId == userId).DistinctBy(x => x.UserTransaction.RequestId);

            //                    var userProductList = new List<ContractProductDetail>();

            //                    userProductList.AddRange(userTransactions
            //                        .Select(x => new ContractProductDetail
            //                        {
            //                            PackageName = x.Package.PackageName,
            //                            TransactionCount = userTransactions.Count(t => t.Package.PackageId == x.Package.PackageId),
            //                            BillableTransactionCount = userTransactions.Count(t => t.Package.PackageId == x.Package.PackageId &&
            //                                                            t.BillingType == "BILLABLE")
            //                        }).DistinctBy(x => x.PackageName));

            //                    userTransactionsList.Add(new ContractUserTransactions
            //                     {
            //                         User = userTransactions.Where(x => x.User.UserId == userId).Select(x => x.User.Username).First(),
            //                         Products = userProductList
            //                     });
            //                }

            //                statement.UserTransactions = userTransactionsList;
            //            }

            //            // Client
            //            if (transaction.CustomerId == new Guid())
            //            {
            //                statement.StatementPeriod = _startBillMonth.ToString("yyyy/MM/dd") + " - " + _endBillMonth.ToString("yyyy/MM/dd");
            //                statement.CustomerClientName = transaction.ClientName;
            //                statement.ConsultantName = account.AccountOwner;
            //                statement.AccountContact = account.BillingAccountContactName;
            //                statement.AccountNumber = account.BillingAccountContactNumber;
            //                statement.ContractName = contract.ContractName;

            //                if (contract.HasPackagePriceOverride)
            //                {
            //                    pricingSummaryList.AddRange(customerClientTransactions
            //                        .Select(x => new PricingSummary
            //                        {
            //                            ContractName = _contractRepository.Where(t => t.ContractId == x.ContractId).Select(t => t.ContractName).First(),
            //                            PackageName = _packageMetaRepository.Where(t => t.PackageId == x.Package.PackageId).Select(t => t.PackageName).First(),
            //                            Description = _contractRepository.Where(t => t.ContractId == x.ContractId).Select(t => t.ContractBundleTransactionLimit).First() +
            //                                            " @ " + contract.ContractBundlePrice + ". " +
            //                                            _contractRepository.Where(t => t.ContractId == x.ContractId).Select(t => t.ContractBundleName).First()
            //                        }).DistinctBy(x => x.PackageName));
            //                }
            //                else
            //                {
            //                    pricingSummaryList.AddRange(customerClientTransactions
            //                        .Select(x => new PricingSummary
            //                        {
            //                            ContractName = _contractRepository.Where(t => t.ContractId == x.ContractId).Select(t => t.ContractName).First(),
            //                            PackageName = _packageMetaRepository.Where(t => t.PackageId == x.Package.PackageId).Select(t => t.PackageName).First(),
            //                            Description = "Per request @ " + x.Package.PackageRecommendedPrice
            //                        }).DistinctBy(x => x.PackageName));
            //                }

            //                statement.PricingSummaries = pricingSummaryList;

            //                var users = customerClientTransactions.Select(x => x.User.UserId).Distinct();

            //                foreach (var userId in users)
            //                {
            //                    var userTransactions = customerClientTransactions.Where(x => x.User.UserId == userId).DistinctBy(x => x.UserTransaction.RequestId);

            //                    var userProductList = new List<ContractProductDetail>();

            //                    userProductList.AddRange(userTransactions
            //                        .Select(x => new ContractProductDetail
            //                        {
            //                            PackageName = x.Package.PackageName,
            //                            TransactionCount = userTransactions.Count(t => t.Package.PackageId == x.Package.PackageId)
            //                        }).DistinctBy(x => new { x.PackageName }));

            //                    userTransactionsList.Add(new ContractUserTransactions
            //                    {
            //                        User = userTransactions.Where(x => x.User.UserId == userId).Select(x => x.User.Username).First(),
            //                        Products = userProductList
            //                    });
            //                }

            //                statement.UserTransactions = userTransactionsList.OrderByDescending(x => x.User);
            //            }

            //            // Build Statement
            //            var statementReport = _reportBuilder.BuildReport(new ReportTemplate { ShortId = ReportTemplateIdentifier.StatementPdf },
            //            new ReportData
            //            {
            //                CustomerClientStatement = statement
            //            });

            //            var statementReportIndex = StatementPdfList.FindIndex(x =>
            //                                        x.Data.CustomerClientStatement.CustomerClientName == statement.CustomerClientName &&
            //                                        x.Data.CustomerClientStatement.ContractName == statement.ContractName);

            //            if (statementReportIndex < 0)
            //            {
            //                StatementPdfList.Add(statementReport);
            //                this.Info(() => "Statement added for: {0}".FormatWith(statementReport.Data.CustomerClientStatement.CustomerClientName));

            //                break;
            //            }
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        this.Error(() => "An Error Occured while creating StatementPdf record. See below for details." + e);
            //    }
            //}

            //this.Info(() => "PivotToStatementPdf process completed");
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