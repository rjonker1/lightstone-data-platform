using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Nancy;
using Nancy.Responses;

namespace Shared.BuildingBlocks.Api.ExceptionHandling
{
    public class ErrorHtmlPageResponse : HtmlResponse
    {
        static readonly Regex ReplacementTokenRegex = new Regex(@"{{(?<Variable>\w*)}}", RegexOptions.Compiled | RegexOptions.Singleline);
        static readonly string ErrorTemplate;

        static ErrorHtmlPageResponse()
        {
            var stream = typeof(ErrorStatusCodeHandler).Assembly.GetManifestResourceStream(typeof(ErrorStatusCodeHandler).Namespace + ".Error.html");
            if (stream == null) return;
            using (var reader = new StreamReader(stream))
            {
                ErrorTemplate = reader.ReadToEnd();
            }
        }

        public ErrorHtmlPageResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
            ContentType = "text/html; charset=utf-8";
            Contents = Render;

            // Enable CORS
            Headers.Add("Access-Control-Allow-Origin", "*");
            Headers.Add("Access-Control-Allow-Headers", "Content-Type");
            Headers.Add("Access-Control-Allow-Methods", "POST,GET,DELETE,PUT,OPTIONS");
        }

        public string Title { get; set; }
        public string Summary { get; set; }
        public string Details { get; set; }

        void Render(Stream stream)
        {
            var formatArguments = GetErrorPageDetails();

            var page = ReplacementTokenRegex.Replace(ErrorTemplate, match =>
            {
                string value;
                return formatArguments.TryGetValue(match.Groups["Variable"].Value, out value) ? value : string.Empty;
            });

            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine(page);
                writer.Flush();
            }
        }

        Dictionary<string, string> GetErrorPageDetails()
        {
            var parameters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            parameters["ErrorTitle"] = Title;
            parameters["ErrorSummary"] = Summary;
            if (!string.IsNullOrWhiteSpace(Details))
                parameters["ErrorDetails"] = "<h3>Details</h3><pre>" + Details + "</pre>";
            parameters["EmailSubject"] = "Error from Lightstone Auto: " + Summary;
            return parameters;
        }
    }
}