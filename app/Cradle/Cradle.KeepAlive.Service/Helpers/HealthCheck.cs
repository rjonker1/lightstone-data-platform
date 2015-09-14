using System;
using System.Collections;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using RestSharp;

namespace Cradle.KeepAlive.Service.Helpers
{
    public class HealthCheck
    {
        private readonly CheckEndpoint _checkEndpoint = new CheckEndpoint();

        public void PingDataPlatform()
        {
            var statusCheckList = new Hashtable();

            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key.StartsWith("endpoint/url"))
                {
                    var status = _checkEndpoint.Invoke("", ConfigurationManager.AppSettings[key], "ping", Method.GET);
                    statusCheckList.Add(ConfigurationManager.AppSettings[key], (int)status);
                }
            }

            foreach (DictionaryEntry endPointStatus in statusCheckList)
            {
                if ((int)endPointStatus.Value != 200) SendEmailAlert("API ALERT - " + endPointStatus.Key, 
                                                                        "API Endpoint: " + endPointStatus.Key + "returned the follow status code: " + endPointStatus.Value);
            }
        }

        private void SendEmailAlert(string subject, string body)
        {
            using (var client = new SmtpClient())
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(ConfigurationManager.AppSettings["report/email/from"].ToLower()),
                    Subject = "BETA ALERT NOTIFICATION - " + subject,
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