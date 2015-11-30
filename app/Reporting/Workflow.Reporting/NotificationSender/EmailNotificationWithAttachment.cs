using System;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using DataPlatform.Shared.Helpers.Extensions;
using jsreport.Client;
using Workflow.Reporting.Dtos;
using Workflow.Reporting.Helpers;

namespace Workflow.Reporting.NotificationSender
{
    public class EmailNotificationWithAttachment<T> : ISendNotificationsWithAttachment<ReportDto>
    {

        private readonly ReportingService _reportingService;
        private readonly IEmailBuilder _emailBuilder;

        public EmailNotificationWithAttachment(IEmailBuilder emailBuilder)
        {
            _emailBuilder = emailBuilder;
            _reportingService = new ReportingService(ConfigurationManager.ConnectionStrings["workflow/reporting/jsreport"].ConnectionString);
        }

        public void Send(ReportDto dto, string attachmentFileName)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    var report = _reportingService.RenderAsync(dto.Template.ShortId, dto.Data).Result;

                    if (dto.Data.CustomerClientStatement != null)
                    {
                        _emailBuilder.MailSubject = dto.Data.CustomerClientStatement.CustomerClientName + " Statement";
                        _emailBuilder.MailBody = "Please see attached for Billing Statement Report for: {0}".FormatWith(dto.Data.CustomerClientStatement.CustomerClientName);
                        _emailBuilder.AddAttachment(new Attachment(report.Content, attachmentFileName));
                    }

                    var mailMessage = _emailBuilder.BuildMessage();

                    mailMessage.To.Add(ConfigurationManager.AppSettings["report/email/to"].ToLower());

                    this.Info(() => "Sending Email notification to: " + mailMessage.To);
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