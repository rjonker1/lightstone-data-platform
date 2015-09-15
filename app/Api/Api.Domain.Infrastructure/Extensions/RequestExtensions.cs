using System;
using System.Threading.Tasks;
using Api.Domain.Core.Contracts;
using Api.Domain.Infrastructure.Bus;
using Api.Domain.Infrastructure.Messages;
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
                        var request = Mapper.Map<Request, IRequest>(context.Request);
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
