using System.Configuration;
using System.Linq;
using Nancy;
using Nancy.ErrorHandling;
using Nancy.Responses;
using Nancy.Responses.Negotiation;

namespace Shared.BuildingBlocks.Api.ExceptionHandling
{
    public sealed class ErrorStatusCodeHandler : IStatusCodeHandler
    {
        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.NotFound
                || statusCode == HttpStatusCode.InternalServerError
                || statusCode == HttpStatusCode.Forbidden
                || statusCode == HttpStatusCode.Unauthorized;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            const string forbiddenMsg = "Sorry, you do not have the required roles to perform this action.";
            const string notFoundMsg = "Sorry, the resource you requested was not found.";
            const string internalMsg = "Sorry, something went wrong. An unexpected error occurred.";

            var clientWantsHtml = ShouldRenderFriendlyErrorPage(context);
            if (!clientWantsHtml)
            {
                if (context.Response is NotFoundResponse)
                {
                    // Normally we return 404's ourselves so we have an ErrorResponse. 
                    // But if no route is matched, Nancy will set a NotFound response itself. 
                    // When this happens we still want to return our nice JSON response.
                    context.Response = ErrorResponse.FromMessage("The resource you requested was not found.").WithStatusCode(statusCode);
                }
                switch (statusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        context.Response = ErrorResponse.FromMessage("Sorry, you do not have permission to perform this action.").WithStatusCode(HttpStatusCode.Unauthorized);
                        break;
                    case HttpStatusCode.Forbidden:
                        context.Response = ErrorResponse.FromMessage(forbiddenMsg).WithStatusCode(HttpStatusCode.Forbidden);
                        break;
                    case HttpStatusCode.NotFound:
                        context.Response = context.Response = ErrorResponse.FromMessage(notFoundMsg).WithStatusCode(HttpStatusCode.NotFound);
                        break;
                    case HttpStatusCode.InternalServerError:
                        context.Response = ErrorResponse.FromMessage(internalMsg).WithStatusCode(HttpStatusCode.InternalServerError);
                        break;
                }

                // Pass the existing response through
                return;
            }

            var error = context.Response as ErrorResponse;
            switch (statusCode)
            {
                case HttpStatusCode.Unauthorized:
                    context.Response = new RedirectResponse(ConfigurationManager.AppSettings["cia/auth"]);
                    break;
                case HttpStatusCode.Forbidden:
                    context.Response = new ErrorHtmlPageResponse(statusCode)
                    {
                        Title = "Permission",
                        Summary = error == null ? forbiddenMsg : error.ErrorMessage
                    };
                    break;
                case HttpStatusCode.NotFound:
                    context.Response = new ErrorHtmlPageResponse(statusCode)
                    {
                        Title = "Not found",
                        Summary = notFoundMsg
                    };
                    break;
                case HttpStatusCode.InternalServerError:
                    context.Response = new ErrorHtmlPageResponse(statusCode)
                    {
                        Title = "Error",
                        Summary = error == null ? internalMsg : error.ErrorMessage,
                        Details = error == null ? null : error.FullException
                    };
                    break;
            }
        }

        static bool ShouldRenderFriendlyErrorPage(NancyContext context)
        {
            var enumerable = context.Request.Headers.Accept;
            var ranges = enumerable.OrderByDescending(o => o.Item2).Select(o => MediaRange.FromString(o.Item1)).ToList();
            foreach (var item in ranges)
            {
                if (item.Matches("application/json"))
                    return false;
                if (item.Matches("text/json"))
                    return false;
                if (item.Matches("text/html"))
                    return true;
            }

            return true;
        }
    }
}