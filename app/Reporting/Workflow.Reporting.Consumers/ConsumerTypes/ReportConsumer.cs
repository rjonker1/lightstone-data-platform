using System.IO;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using jsreport.Client;
using Newtonsoft.Json;

namespace Workflow.Reporting.Consumers.ConsumerTypes
{
    public class ReportConsumer
    {
        public void Consume(IMessage<ReportMessage> message)
        {
            var dataString = JsonConvert.SerializeObject(message.Body);

            var _reportingService = new ReportingService("http://localhost:8856");

            //Store to disk
            using (var fileStream = File.Create(@"C:\Development\JSReport\report.pdf"))
            {

                var report = _reportingService.RenderAsync("VJGAd9OM", dataString).Result;

                report.Content.CopyTo(fileStream);
            }
        } 
    }
}