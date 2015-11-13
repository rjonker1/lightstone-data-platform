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

        ReportingService _reportingService = new ReportingService(ConfigurationManager.ConnectionStrings["workflow/reporting/jsreport"].ConnectionString);
        private IEmailBuilder _emailBuilder;

        public EmailNotificationWithAttachment(IEmailBuilder emailBuilder)
        {
            _emailBuilder = emailBuilder;
        }

        public void Send(ReportDto dto)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    var report = _reportingService.RenderAsync(dto.Template.ShortId, dto.Data).Result;

                    if (dto.Data.Customer != null)
                    {
                        _emailBuilder.MailSubject = dto.Data.Customer.Name + " Invoice";
                        _emailBuilder.MailBody = "Please see attached for Billing Invoice Report";
                        _emailBuilder.AddAttachment(new Attachment(report.Content, "" + dto.Data.Customer.Name + " - Invoice.pdf"));
                    }

                    if (dto.Data.ContractStatements != null)
                    {
                        var fileName = dto.Data.ContractStatements.Select(x => x.ContractName).FirstOrDefault();
                        _emailBuilder.MailSubject = fileName + " Statement";
                        _emailBuilder.MailBody = "Please see attached for Billing Invoice Report";
                        _emailBuilder.AddAttachment(new Attachment(report.Content, fileName + " - Statement.pdf"));
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