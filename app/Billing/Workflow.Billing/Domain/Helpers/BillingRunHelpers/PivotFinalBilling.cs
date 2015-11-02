using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Repositories;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Domain.Helpers.BillingRunHelpers.Infrastructure;
using Workflow.Reporting.Dtos;

namespace Workflow.Billing.Domain.Helpers.BillingRunHelpers
{
    public class PivotFinalBilling : ReportList, IPivotBilling<PivotFinalBilling>
    {
        private readonly IRepository<StageBilling> _stageBillingRepository;
        private readonly IRepository<FinalBilling> _finalBillingRepository;
        private readonly IRepository<ArchiveBillingTransaction> _archiveBillingRepository;

        private readonly IPublishReportQueue<BillingReport> _report;

        private readonly IPivotFinalBillingTransactions _finalBillingTransactions;

        public PivotFinalBilling(IRepository<StageBilling> stageBillingRepository, IRepository<FinalBilling> finalBillingRepository, 
                                    IRepository<ArchiveBillingTransaction> archiveBillingRepository, IPublishReportQueue<BillingReport> report, 
                                    IPivotFinalBillingTransactions finalBillingTransactions)
        {
            _stageBillingRepository = stageBillingRepository;
            _finalBillingRepository = finalBillingRepository;
            _archiveBillingRepository = archiveBillingRepository;
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
                //// Archive and clean Final Billing for new month
                //foreach (var archiveRecord in _finalBillingRepository)
                //{
                //    if (!_archiveBillingRepository.Any(x => x.StageBillingId == archiveRecord.StageBillingId))
                //        _archiveBillingRepository.SaveOrUpdate(Mapper.Map(archiveRecord, new ArchiveBillingTransaction()));

                //    _finalBillingRepository.Delete(archiveRecord, true);
                //}

                //// Save final version of StageBilling for the month into FinalBilling
                //foreach (var record in _stageBillingRepository)
                //{
                //    if (record.Created <= startBillMonth) continue;

                //    var finalEntity = Mapper.Map(record, new FinalBilling());

                //    _finalBillingRepository.SaveOrUpdate(finalEntity);
                //}

                //InvoicePdfList = _finalBillingTransactions.PivotToInvoicePdf();

                StatementPdfList = _finalBillingTransactions.PivotToStatementPdf();

                PastelReportList.Add(_finalBillingTransactions.PivotToPastelCsv());

                DebitOrderReportList.Add(_finalBillingTransactions.PivotToDebitOrderCsv());

                DebitOrderNotDoneReportList.Add(_finalBillingTransactions.PivotToDebitOrderNotDoneCsv());
            }
            catch (Exception ex)
            {
                this.Error(() => ex.Message);
            }

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