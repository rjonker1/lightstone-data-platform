using System;
using Nancy;

namespace PackageBuilder.Api.Helpers.ExceptionHandling
{
    public class HttpResponseExceptionHandler
    {
        public static Response HandleExceptions(Exception err, NancyContext ctx)
        {
            var result = new Response {ReasonPhrase = err.Message};

            if (err is NotImplementedException)
                result.StatusCode = HttpStatusCode.NotImplemented;
            else if (err is UnauthorizedAccessException)
                result.StatusCode = HttpStatusCode.Unauthorized;
            else if (err is ArgumentException)
                result.StatusCode = HttpStatusCode.BadRequest;
            else
                result.StatusCode = HttpStatusCode.InternalServerError;

            return result;
        }
    }
}