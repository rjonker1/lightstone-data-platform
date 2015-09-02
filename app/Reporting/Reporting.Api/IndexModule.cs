using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using jsreport.Client;
using Nancy;
using Nancy.Json;
using Nancy.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Workflow.Reporting.Dtos;

namespace Reporting.Api
{
    public class IndexModule : NancyModule
    {
        private static int _defaultJsonMaxLength;

        public IndexModule()
        {
            if (_defaultJsonMaxLength == 0)
                _defaultJsonMaxLength = JsonSettings.MaxJsonLength;

            //Hackeroonie - Required, due to complex model structures (Nancy default restriction length [102400])
            JsonSettings.MaxJsonLength = Int32.MaxValue;

            Get["/Generate"] = parameters =>
                {
                    var _reportingService = new ReportingService("http://localhost:8856");

                    //Store to disk
                    using (var fileStream = File.Create(@"C:\Development\JSReport\report.pdf"))
                    {

                        var report = _reportingService.RenderAsync("VJGAd9OM", new
                        {
                            items = new[]
                        {
                            new Item() {ItemCode = "1000/200/002", ItemDescription = "AutoTest", QuantityUnit = 1.00, Price = 16314.67, Vat = 2284.00, Total = 18598.72}
                        }
                        }).Result;

                        report.Content.CopyTo(fileStream);
                    }

                    //Email notification
                    using (var client = new SmtpClient())
                    {

                        var report = _reportingService.RenderAsync("VJGAd9OM", new
                        {
                            items = new[]
                        {
                            new Item() {ItemCode = "1000/200/002", ItemDescription = "AutoTest", QuantityUnit = 1.00, Price = 16314.67, Vat = 2284.00, Total = 18598.72}
                        }
                        }).Result;

                        var mailMessage = new MailMessage
                        {
                            Subject = "Test",
                            IsBodyHtml = true,
                            Body = "Please see attached for Billing Report",
                            BodyEncoding = Encoding.UTF8,
                            From = new MailAddress("mvpreporting@lightstone.co.za")
                        };
                        mailMessage.To.Add("allistairec@lightstone.co.za");
                        mailMessage.Attachments.Add(new Attachment(report.Content,
                                                        "Test.pdf"));

                        //_log.InfoFormat("Sending {0}", name);
                        client.Send(mailMessage);
                        //_log.InfoFormat("Sent {0}", name);
                    }

                    return View["index"];
                };

            Get["/ReportDownload"] = parameters =>
            {
                var file = new FileStream(@"C:\Development\JSReport\report.pdf", FileMode.Open);
                string fileName = "report.pdf";

                var response = new StreamResponse(() => file, MimeTypes.GetMimeType(fileName));

                return response.AsAttachment(fileName);
            };

            Post["/PreBillingReportDownload"] = parameters =>
            {
                var body = Request.Body<dynamic>().ToString();
                var dto = JsonConvert.DeserializeObject<ReportDto>(body);

                var _reportingService = new ReportingService("http://localhost:8856");
                var path = @"D:\LSA Reports";

                //Store to disk
                using (var fileStream = File.Create(path + @"\PreBilling.xlsx"))
                {
                    var report = _reportingService.RenderAsync(dto.Template.ShortId, dto.Data).Result;
                    report.Content.CopyTo(fileStream);
                }

                return Response.AsJson(new { response =  dto.Data });
            };

            Get["PreBillingReportDownload"] = parameters =>
            {
                var file = new FileStream(@"D:\LSA Reports\PreBilling.xlsx", FileMode.Open);
                string fileName = "PreBilling.xlsx";

                var response = new StreamResponse(() => file, MimeTypes.GetMimeType(fileName));

                return response.AsAttachment(fileName);
            };

            Post["/ReportOutput"] = parameters =>
            {

                var body = Request.Body<dynamic>();

                var dataString = JsonConvert.SerializeObject(body);

                var cli = new WebClient();
                cli.Headers[HttpRequestHeader.ContentType] = "application/json";
                string report = cli.UploadString("http://localhost:8856/api/report", dataString);

                return report;
            };

            //CORS for Module
            After.AddItemToEndOfPipeline(nancyContext =>
            {
                nancyContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                nancyContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
                nancyContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,DELETE,PUT,OPTIONS");
            });

        }
    }

    class Item
    {
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public double QuantityUnit { get; set; }
        public double Price { get; set; }
        public double Vat { get; set; }
        public double Total { get; set; }
    }

    public static class BodyBinderExtension
    {
        public static T Body<T>(this Request request)
        {
            request.Body.Position = 0;
            string bodyText;
            using (var bodyReader = new StreamReader(request.Body))
            {
                bodyText = bodyReader.ReadToEnd();
            }

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver()
            };

            return JsonConvert.DeserializeObject<T>(bodyText);
        }
    }

}