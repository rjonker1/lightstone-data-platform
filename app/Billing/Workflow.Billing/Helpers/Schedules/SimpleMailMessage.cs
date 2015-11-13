using System.Net.Mail;

namespace Workflow.Billing.Helpers.Schedules
{
    public class SimpleMailMessage
    {
        public string DisplayName { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public MailMessage ToMailMessage()
        {
            return new MailMessage
            {
                Body = Body,
                IsBodyHtml = true,
                Subject = Subject,
            };
        }
    }
}