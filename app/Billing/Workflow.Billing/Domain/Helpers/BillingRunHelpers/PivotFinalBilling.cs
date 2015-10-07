using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Repositories;
using ServiceStack.Common;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Domain.Helpers.BillingRunHelpers.Infrastructure;
using Workflow.Reporting.Dtos;
using Workflow.Reporting.Entities;

namespace Workflow.Billing.Domain.Helpers.BillingRunHelpers
{
    public class PivotFinalBilling : ReportList, IPivotBilling<PivotFinalBilling>
    {
        private readonly IRepository<StageBilling> _stageBillingRepository;
        private readonly IRepository<FinalBilling> _finalBillingRepository;
        private readonly IRepository<AccountMeta> _accountMetaReporRepository;
        private readonly IRepository<ContractMeta> _contractRepository;
        private readonly IRepository<UserMeta> _userMetaRepository;
        private readonly IRepository<ArchiveBillingTransaction> _archiveBillingRepository;

        private readonly IPublishReportQueue<BillingReport> _report;
        private readonly IReportBuilder _reportBuilder;

        private readonly IPivotFinalBillingTransactions _finalBillingTransactions;

        public PivotFinalBilling(IRepository<StageBilling> stageBillingRepository, IRepository<FinalBilling> finalBillingRepository, IRepository<ArchiveBillingTransaction> archiveBillingRepository,
                                    IRepository<AccountMeta> accountMetaReporRepository,
                                    IPublishReportQueue<BillingReport> report, IReportBuilder reportBuilder, IRepository<ContractMeta> contractRepository, IRepository<UserMeta> userMetaRepository, 
                                    IPivotFinalBillingTransactions finalBillingTransactions)
        {
            _stageBillingRepository = stageBillingRepository;
            _finalBillingRepository = finalBillingRepository;
            _archiveBillingRepository = archiveBillingRepository;
            _accountMetaReporRepository = accountMetaReporRepository;
            _reportBuilder = reportBuilder;
            _contractRepository = contractRepository;
            _userMetaRepository = userMetaRepository;
            _finalBillingTransactions = finalBillingTransactions;
            _report = report;

            PastelReportList = new List<ReportDto>();
            DebitOrderReportList = new List<ReportDto>();
            DebitOrderNotDoneReportList = new List<ReportDto>();
        }

        public void Pivot()
        {
            var endBillMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 25).AddHours(23).AddMinutes(59).AddSeconds(59);
            var startBillMonth = new DateTime(DateTime.UtcNow.Year, (DateTime.UtcNow.Month - 1), 26);

            this.Info(() => "FinalBilling process started for : {0} - to - {1}".FormatWith(startBillMonth, endBillMonth));

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
                    if (record.Created <= startBillMonth) continue;

                    var finalEntity = Mapper.Map(record, new FinalBilling());

                    _finalBillingRepository.SaveOrUpdate(finalEntity);
                }

                InvoicePdfList = _finalBillingTransactions.PivotToInvoicePdf();

                StatementPdfList = _finalBillingTransactions.PivotToStatementPdf();

                PastelInvoiceList = _finalBillingTransactions.PivotToPastelCsv();

                DebitOrderRecordList = _finalBillingTransactions.PivotToDebitOrderCsv();

                DebitOrderNotDoneRecordList = _finalBillingTransactions.PivotToDebitOrderNotDoneCsv();
            }
            catch (Exception ex)
            {
                this.Error(() => ex.Message);
            }

            var pastelReport = _reportBuilder.BuildReport(new ReportTemplate { ShortId = "EJ-dvWnX" },
                new ReportData
                {
                    Invoices = PastelInvoiceList
                });

            var debitOrderReport = _reportBuilder.BuildReport(new ReportTemplate { ShortId = "4ksFqmUp" },
                new ReportData
                {
                    BillDateTime1 = DateTime.UtcNow.ToString("yyyyMMdd"),
                    BillDateTime2 = DateTime.UtcNow.ToString("yyyy/MM/dd"),
                    DebitOrders = DebitOrderRecordList
                });

            var debitOrderNotDoneReport = _reportBuilder.BuildReport(new ReportTemplate { ShortId = "4ksFqmUp" },
                new ReportData
                {
                    BillDateTime1 = DateTime.UtcNow.ToString("yyyyMMdd"),
                    BillDateTime2 = DateTime.UtcNow.ToString("yyyy/MM/dd"),
                    DebitOrders = DebitOrderNotDoneRecordList
                });

            PastelReportList.Add(pastelReport);
            DebitOrderReportList.Add(debitOrderReport);
            DebitOrderNotDoneReportList.Add(debitOrderNotDoneReport);

            // Publish to Reporting for processing
            // Note Pdf report types get emailed to relevant mailing contacts
            _report.PublishToQueue(InvoicePdfList, "pdf");
            _report.PublishToQueue(StatementPdfList, "pdf");
            _report.PublishToQueue(PastelReportList, "pastel");
            _report.PublishToQueue(DebitOrderReportList, "debitOrder");
            _report.PublishToQueue(DebitOrderNotDoneReportList, "debitOrderND");

            this.Info(() => "FinalBilling process completed for : {0} - to - {1}".FormatWith(startBillMonth, endBillMonth));
        }
    }
}