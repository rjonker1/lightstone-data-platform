using System;
using System.Threading.Tasks;
using Api.Domain.Core.Contracts;
using Api.Domain.Infrastructure.Bus;
using Api.Domain.Infrastructure.Messages;
using AutoMapper;
using Common.Logging;
using Nancy;

namespace Api.Domain.Infrastructure.Extensions
{
    public static class RequestExtensions
    {
        //public static void Dispatch(this IRequest request, IDispatchMessagesToBus<RequestReportMessage> dispatcher, ILog log)
        //{
        //    try
        //    {
        //        Task.Factory.StartNew(() => dispatcher.Dispatch(new RequestReportMessage(request)));
        //    }
        //    catch (Exception ex)
        //    {
        //        log.ErrorFormat("Cannot send request information to the bus because of {0}", ex, ex.Message);
        //    }
        //}

        public static void Report(this Nancy.NancyContext context, IDispatchMessagesToBus<RequestReportMessage> dispatcher, Guid requestId)
        {
            try
            {
                
                Task.Factory.StartNew(() =>
                {
                    var request = Mapper.Map<Request, IRequest>(context.Request);
                    dispatcher.Dispatch(new RequestReportMessage(request, requestId));
                });
            }
            catch
            {
            }
        }

    }
}
