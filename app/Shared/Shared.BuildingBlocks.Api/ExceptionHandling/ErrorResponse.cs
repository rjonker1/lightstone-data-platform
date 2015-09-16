using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Authentication;
using DataPlatform.Shared.ExceptionHandling;
using Nancy.Responses;
using Newtonsoft.Json;
using HttpStatusCode = Nancy.HttpStatusCode;

namespace Shared.BuildingBlocks.Api.ExceptionHandling
{
    public class ErrorResponse : JsonResponse
    {
        readonly Error _error;

        private ErrorResponse(Error error)
            : base(error, new DefaultJsonSerializer())
        {
            Guard.AgainstNull(error, "error");
            _error = error;
        }

        public string ErrorMessage { get { return _error.ErrorMessage; } }
        public string FullException { get { return _error.FullException; } }
        public string[] Errors { get { return _error.Errors; } }

        public static ErrorResponse FromMessage(string message)
        {
            return new ErrorResponse(new Error { ErrorMessage = message });
        }

        public static ErrorResponse FromException(Exception exception)
        {
            //var exception = ex.GetRootError();

            var summary = exception.Message;
            if (exception is WebException || exception is SocketException)
                summary = "";

            var statusCode = HttpStatusCode.InternalServerError;
            var error = new Error();
            if (exception is LightstoneAutoException)
            {
                statusCode = HttpStatusCode.InternalServerError;
                error.ErrorMessage = summary;
            }
            else if (exception is NotImplementedException)
                statusCode = HttpStatusCode.NotImplemented;
            else if (exception is UnauthorizedAccessException)
            {
                statusCode = HttpStatusCode.Forbidden;
                error.ErrorMessage = "Sorry, you do not have permission to perform that action. Please contact Lightstone Auto.";
            }
            else if (exception is AuthenticationException)
                statusCode = HttpStatusCode.Unauthorized;
            else if (exception is ArgumentException)
                statusCode = HttpStatusCode.BadRequest;

            return new ErrorResponse(error) { StatusCode = statusCode };
        }

        class Error
        {
            public string ErrorMessage { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string FullException { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string[] Errors { get; set; }
        }
    }
}