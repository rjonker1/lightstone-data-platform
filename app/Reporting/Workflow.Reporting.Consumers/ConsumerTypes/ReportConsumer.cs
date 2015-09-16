using System;
using System.IO;
using System.Threading.Tasks;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using jsreport.Client;
using Newtonsoft.Json;
using Workflow.Reporting.Dtos;
using System.Configuration;
using Workflow.Reporting.NotificationSender;

namespace Workflow.Reporting.Consumers.ConsumerTypes
{
    public class ReportConsumer
    {
        private readonly ReportingService _reportingService = new ReportingService(ConfigurationManager.ConnectionStrings["workflow/reporting/jsreport"].ConnectionString);

        private readonly ISendNotificationsWithAttachment<ReportDto> _emailPdfNotificationsWithAttachment;

        public ReportConsumer(ISendNotificationsWithAttachment<ReportDto> emailPdfNotificationsWithAttachment)
        {
            _emailPdfNotificationsWithAttachment = emailPdfNotificationsWithAttachment;
        }

        public async Task Consume(IMessage<ReportMessage> message)
        {
            var date = DateTime.UtcNow.ToString("MMMM yyyy");
            var dto = JsonConvert.DeserializeObject<ReportDto>(message.Body.ReportBody);
            var path = @"D:\LSA Reports\Invoices " + date;

            await Task.Run(() =>
            {
                try
                {
                    if (message.Body.ReportType.Equals("pdf"))
                    {
                        CreateFile(dto, path, dto.Data.Customer.Name + " - Invoice.pdf");

                        //Send Email
                        _emailPdfNotificationsWithAttachment.Send(dto);
                    }

                    if (message.Body.ReportType.Equals("pastel")) CreateFile(dto, path, "Pastel.csv");

                    if (message.Body.ReportType.Equals("debitOrder")) CreateFile(dto, path, "DebitOrder.csv");

                    if (message.Body.ReportType.Equals("debitOrderND")) CreateFile(dto, path, "DebitOrderNotDone.csv");
                }
                catch (Exception e)
                {
                    this.Error(() => "The process failed: " + e);
                    throw;
                }
            });
        }

        private void CreateFile(ReportDto dto, string path, string fileName)
        {
            // Determine whether the directory exists. 
            if (!Directory.Exists(path))
            {
                // Try to create the directory.
                Directory.CreateDirectory(path);
                this.Info(() => "The directory was created successfully at " + Directory.GetCreationTime(path));
            }

            //Store to disk
            using (var fileStream = File.Create(path + @"\" + fileName))
            {
                var report = _reportingService.RenderAsync(dto.Template.ShortId, dto.Data).Result;
                report.Content.CopyTo(fileStream);

                this.Info(() => "Report : " + fileName + " created successfully");
            }
        }
    }
}