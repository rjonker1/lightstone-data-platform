using System.Configuration;
using System.Net.Mail;
using System.Text;

namespace Cradle.KeepAlive.Service.Helpers.Notifications
{
    public class EmailAlert
    {
        public void SendEmail(string subject, string body)
        {
            using (var client = new SmtpClient())
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(ConfigurationManager.AppSettings["report/email/from"].ToLower()),
                    Subject = ConfigurationManager.AppSettings["report/email/environment/subject"] + " - " + subject,
                    IsBodyHtml = true,
                    Body = body,
                    BodyEncoding = Encoding.UTF8
                };
                mailMessage.To.Add(ConfigurationManager.AppSettings["report/email/to"].ToLower());

                client.Send(mailMessage);
            }
        } 
    }
}