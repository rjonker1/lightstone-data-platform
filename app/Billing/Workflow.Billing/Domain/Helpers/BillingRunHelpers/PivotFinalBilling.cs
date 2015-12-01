using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Repositories;
using ServiceStack.Common;
using Shared.Logging;
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
        private readonly IPivotFinalBillingTransactions _finalBillingTransactions;

        private readonly IPublishReportQueue<BillingReport> _report;

        readonly DateTime _endBillMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month - 1, 25).AddHours(23).AddMinutes(59).AddSeconds(59);
        readonly DateTime _startBillMonth = new DateTime(DateTime.UtcNow.Year, (DateTime.UtcNow.Month - 2), 26);

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
 
        public async Task Pivot()
        {


            this.Info(() => "FinalBilling process started for : {0} - to - {1}".FormatWith(_startBillMonth, _endBillMonth));

            try
            {
                // Archive and clean Final Billing for new month
                _archiveBillingRepository.BatchInsert(Mapper.Map<IEnumerable<FinalBilling>, IEnumerable<ArchiveBillingTransaction>>
                    (_finalBillingRepository), 0);

                // Clean FinalBilling
                _finalBillingRepository.BatchDelete(
                    (_finalBillingRepository), 0);
                
                // Save final version of StageBilling for the month into FinalBilling
                _finalBillingRepository.BatchInsert(Mapper.Map<IEnumerable<StageBilling>, IEnumerable<FinalBilling>>
                        (_stageBillingRepository.Where(x => x.Created >= _startBillMonth && x.Created <= _endBillMonth)), 0);

                //InvoicePdfList = _finalBillingTransactions.PivotToInvoicePdf();

                StatementPdfList = _finalBillingTransactions.PivotToStatementPdf();

                //PastelReportList.Add(_finalBillingTransactions.PivotToPastelCsv());

                //DebitOrderReportList.Add(_finalBillingTransactions.PivotToDebitOrderCsv());

                //DebitOrderNotDoneReportList.Add(_finalBillingTransactions.PivotToDebitOrderNotDoneCsv());
            }
            catch (Exception ex)
            {
                this.Error(() => ex.Message);
            }

            // Publish to Reporting for processing
            // Note Pdf report types get emailed to relevant mailing contacts
            //_report.PublishToQueue(InvoicePdfList, "pdf");
            _report.PublishToQueue(StatementPdfList, "pdf");
            //_report.PublishToQueue(PastelReportList, "pastel");
            //_report.PublishToQueue(DebitOrderReportList, "debitOrder");
            //_report.PublishToQueue(DebitOrderNotDoneReportList, "debitOrderND");

            this.Info(() => "FinalBilling process completed for : {0} - to - {1}".FormatWith(_startBillMonth, _endBillMonth));
        }
    }
}