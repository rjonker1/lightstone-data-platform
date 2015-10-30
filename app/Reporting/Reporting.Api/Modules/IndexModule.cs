using System;
using System.IO;
using System.Net;
using jsreport.Client;
using Nancy;
using Nancy.Json;
using Nancy.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Workflow.Reporting.Dtos;

namespace Reporting.Api.Modules
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

            Post["/PreBillingReportDownload"] = parameters =>
            {
                DateTime startDate = Convert.ToDateTime(Request.Query["startDate"].ToString());
                DateTime endDate = Convert.ToDateTime(Request.Query["endDate"].ToString());

                var body = Request.Body<dynamic>().ToString();
                var dto = JsonConvert.DeserializeObject<ReportDto>(body);

                var _reportingService = new ReportingService("http://localhost:8856");
                var path = @"D:\LSA Reports";

                //Store to disk
                using (var fileStream = File.Create(path + @"\PreBilling " + startDate.ToString("MMMM dd yyyy") + " - " + endDate.ToString("MMMM dd yyyy") + ".xlsx"))
                {
                    var report = _reportingService.RenderAsync(dto.Template.ShortId, dto.Data).Result;
                    report.Content.CopyTo(fileStream);
                }

                return Response.AsJson(new { message = "Success" });
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