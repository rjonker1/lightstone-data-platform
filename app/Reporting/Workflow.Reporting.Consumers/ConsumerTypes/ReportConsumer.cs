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

        private readonly ISendNotifications<ReportDto> _emailPdfNotifications;

        public ReportConsumer(ISendNotifications<ReportDto> emailPdfNotifications)
        {
            _emailPdfNotifications = emailPdfNotifications;
        }

        public async Task Consume(IMessage<ReportMessage> message)
        {

            var _reportingService = new ReportingService(ConfigurationManager.ConnectionStrings["workflow/reporting/jsreport"].ConnectionString);

            var date = DateTime.Now.ToString("MMMM yyyy");
            var dto = JsonConvert.DeserializeObject<ReportDto>(message.Body.ReportBody);

            var path = @"D:\LSA Reports\Invoices " + date;


            await Task.Run(() =>
            {
                try
                {

                    if (message.Body.ReportType.Equals("csv"))
                    {
                        // Determine whether the directory exists. 
                        if (!Directory.Exists(path))
                        {
                            // Try to create the directory.
                            DirectoryInfo di = Directory.CreateDirectory(path);
                            this.Info(
                                () => "The directory was created successfully at " + Directory.GetCreationTime(path));
                        }

                        //Store to disk
                        using (var fileStream = File.Create(path + @"\BillingOutput.csv"))
                        {

                            var report = _reportingService.RenderAsync(dto.Template.ShortId, dto.Data).Result;
                            report.Content.CopyTo(fileStream);

                            this.Info(
                                () => "Report : BillingOutput.csv was created successfully");
                        }

                    }

                    if (message.Body.ReportType.Equals("pdf"))
                    {
                        // Determine whether the directory exists. 
                        if (!Directory.Exists(path))
                        {
                            // Try to create the directory.
                            DirectoryInfo di = Directory.CreateDirectory(path);
                            this.Info(
                                () => "The directory was created successfully at " + Directory.GetCreationTime(path));
                        }

                        //Store to disk
                        using (var fileStream = File.Create(path + @"\" + dto.Data.Customer.Name + " - Invoice.pdf"))
                        {

                            var report = _reportingService.RenderAsync(dto.Template.ShortId, dto.Data).Result;
                            report.Content.CopyTo(fileStream);

                            this.Info(
                                () => "Report : " + dto.Data.Customer.Name + " - Invoice.pdf was created successfully");
                        }

                        //Send Email
                        _emailPdfNotifications.Send(dto);
                    }
                     
                }
                catch (Exception e)
                {
                    this.Error(() => "The process failed: " + e);
                    throw;
                }
            });

        }
    }
}