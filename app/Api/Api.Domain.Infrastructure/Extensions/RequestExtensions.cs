using System;
using System.Threading.Tasks;
using Api.Domain.Core.Contracts;
using Api.Domain.Core.Dto;
using Api.Domain.Core.Messages;
using Api.Domain.Infrastructure.Bus;
using AutoMapper;
using Nancy;

namespace Api.Domain.Infrastructure.Extensions
{
    public static class RequestExtensions
    {
        public static void Report(this Nancy.NancyContext context, IDispatchMessagesToBus<RequestReportMessage> dispatcher, Guid requestId)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        var request = new RequestDto
                        {
                            Headers = context.Request.Headers,
                            Url = context.Request.Url,
                            Form = context.Request.Form,
                            Method = context.Request.Method,
                            Path = context.Request.Path,
                            Query = context.Request.Query,
                            UserHostAddress = context.Request.UserHostAddress
                        };
                        dispatcher.Dispatch(new RequestReportMessage(request, requestId));
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
