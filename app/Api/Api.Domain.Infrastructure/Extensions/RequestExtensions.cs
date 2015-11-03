using System;
using System.Threading.Tasks;
using Api.Domain.Core.Dto;
using Api.Domain.Core.Messages;
using Api.Domain.Infrastructure.Bus;
using Nancy;

namespace Api.Domain.Infrastructure.Extensions
{
    public static class RequestExtensions
    {
        public static void Report(this NancyContext context, IDispatchMessagesToBus<RequestMetadataMessage> dispatcher, Guid requestId)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        var header = new RequestHeaderMetadataDto(context.Request.Headers.Authorization, context.Request.Headers.Host,
                            context.Request.Headers.UserAgent, context.Request.Headers.ContentType);
                        var url = new RequestUrlMetadataDto(context.Request.Url.Path, context.Request.Url.HostName, context.Request.Url.IsSecure,
                            context.Request.Url.Path, context.Request.Url.Port, context.Request.Url.Query, context.Request.Url.Scheme,
                            context.Request.Url.SiteBase);
                        dispatcher.Dispatch(new RequestMetadataMessage(header, url, requestId, context.CurrentUser.UserName,
                            context.Request.UserHostAddress, context.Request.Method, context.Request.Path));
                    }
                    finally
                    {
                    }

                });
            }
            finally
            {
            }
        }

    }
}
