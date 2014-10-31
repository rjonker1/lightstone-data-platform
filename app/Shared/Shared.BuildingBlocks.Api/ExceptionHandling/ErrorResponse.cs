using System;
using System.Net;
using System.Net.Sockets;
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
            var error = new Error { ErrorMessage = summary, FullException = exception.ToString() };
            if (exception is LightstoneAutoException)
            {
                statusCode = HttpStatusCode.InternalServerError;
                error.FullException = null;
            }
            else if (exception is NotImplementedException)
            {
                statusCode = HttpStatusCode.NotImplemented;
                error.FullException = null;
            }
            else if (exception is UnauthorizedAccessException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                error.FullException = null;
            }
            else if (exception is ArgumentException)
            {
                statusCode = HttpStatusCode.BadRequest;
                error.FullException = null;
            }
            else
                error.FullException = null;

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