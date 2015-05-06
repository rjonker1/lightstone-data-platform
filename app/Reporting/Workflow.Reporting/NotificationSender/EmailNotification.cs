using System;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using DataPlatform.Shared.Helpers.Extensions;
using jsreport.Client;
using Workflow.Reporting.Dtos;

namespace Workflow.Reporting.NotificationSender
{
    public class EmailNotification<T> : ISendNotifications<ReportDto>
    {

        ReportingService _reportingService = new ReportingService(ConfigurationManager.ConnectionStrings["workflow/reporting/jsreport"].ConnectionString);

        public void Send(ReportDto dto)
        {
            try
            {
                using (var client = new SmtpClient())
                {

                    var report = _reportingService.RenderAsync(dto.Template.ShortId, dto.Data).Result;

                    var mailMessage = new MailMessage
                    {
                        Subject = dto.Data.Customer.Name + " Invoice",
                        IsBodyHtml = true,
                        Body = "Please see attached for Billing Invoice Report",
                        BodyEncoding = Encoding.UTF8,
                        From = new MailAddress("mvpreporting@lightstone.co.za")
                    };
                    mailMessage.To.Add(ConfigurationManager.AppSettings["report/email/to"].ToLower());
                    mailMessage.Attachments.Add(new Attachment(report.Content,
                        ""+ dto.Data.Customer.Name + " - Invoice.pdf"));

                    this.Info(() => "Sending Email notification to: "+ mailMessage.To);
                    client.Send(mailMessage);
                    this.Info(() => "Sent Email notification to: " + mailMessage.To);
                }
            }
            catch (Exception e)
            {
                this.Error(() => "Erorr sending email " + e);
            }
        }
    }
}