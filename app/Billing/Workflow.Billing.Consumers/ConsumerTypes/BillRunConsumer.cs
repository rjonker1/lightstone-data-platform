using System;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using EasyNetQ;
using Workflow.Billing.Domain.Helpers.BillingRunHelpers;
using Workflow.Billing.Domain.NotificationSender;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class BillRunConsumer
    {
        private readonly IPivotBilling<PivotStageBilling> _pivotStageBilling;
        private readonly IPivotBilling<PivotFinalBilling> _pivotFinalBilling;
        private readonly ISendNotifications _emailNotification;

        public BillRunConsumer(IPivotBilling<PivotStageBilling> pivotStageBilling, IPivotBilling<PivotFinalBilling> pivotFinalBilling, ISendNotifications emailNotification)
        {
            _pivotStageBilling = pivotStageBilling;
            _pivotFinalBilling = pivotFinalBilling;
            _emailNotification = emailNotification;
        }

        public void Consume(IMessage<BillingMessage> message)
        {
            if (message.Body.RunType == "Stage")
            {
                _pivotStageBilling.Pivot();

                //TODO: Move logic to scheduler
                if (DateTime.Now.Day == 26)
                {
                    var mailMessage = new MailMessage
                    {
                        Subject = "StageBilling process completed",
                        IsBodyHtml = true,
                        Body =
                            "Please note that StageBilling has run, please review transactions and Customer/Client information by the 28th of this month.",
                        BodyEncoding = Encoding.UTF8,
                        From = new MailAddress("mvpreporting@lightstone.co.za")
                    };

                    mailMessage.To.Add(ConfigurationManager.AppSettings["report/email/to"].ToLower());
                    //mailMessage.To.Add(ConfigurationManager.AppSettings["report/email/to/secondary"].ToLower());

                    _emailNotification.Send(mailMessage);
                }
            }
                
            if (message.Body.RunType == "Final")
                _pivotFinalBilling.Pivot();
        }
    }
}