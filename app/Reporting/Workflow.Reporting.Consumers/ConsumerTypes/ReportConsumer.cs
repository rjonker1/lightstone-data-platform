using System.IO;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using jsreport.Client;
using Newtonsoft.Json;
using Workflow.Reporting.Dtos;

namespace Workflow.Reporting.Consumers.ConsumerTypes
{
    public class ReportConsumer
    {
        public void Consume(IMessage<ReportMessage> message)
        {
            //var dataString = JsonConvert.SerializeObject(message.Body.ReportBody);

            var dto = JsonConvert.DeserializeObject<ReportDto>(message.Body.ReportBody);

            var _reportingService = new ReportingService("http://localhost:8856");

            //Store to disk
            using (var fileStream = File.Create(@"C:\Development\JSReport\"+dto.Data.Customer.Name+" - Invoice.pdf"))
            {

                var report = _reportingService.RenderAsync(dto.Template.ShortId, dto.Data).Result;

                report.Content.CopyTo(fileStream);
            }
        } 
    }
}