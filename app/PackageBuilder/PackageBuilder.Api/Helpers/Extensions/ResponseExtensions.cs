using DataPlatform.Shared.ExceptionHandling;
using Nancy;
using Shared.BuildingBlocks.Api.ExceptionHandling;

namespace PackageBuilder.Api.Helpers.Extensions
{
    public static class ResponseExtensions
    {
        public static Response AsError(this IResponseFormatter formatter, string message)
        {
            return ErrorResponse.FromException(new LightstoneAutoException(message));
        }
    }
}