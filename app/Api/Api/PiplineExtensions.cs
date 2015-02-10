using System;
using Api.Domain.Core.Contracts;
using AutoMapper;
using Nancy;
using Nancy.Bootstrapper;
using Newtonsoft.Json;

namespace Api
{
    public static class PiplineExtensions
    {
        public static IPipelines EnableMonitoring(this IPipelines pipelines)
        {
            //
            //ILog log = LogManager.GetCurrentClassLogger();
            pipelines.BeforeRequest += context =>
            {
                var iRequest = Mapper.Map<Request, IRequest>(context.Request);
                var request = JsonConvert.SerializeObject(iRequest);

                //log.InfoFormat("Request date {0}: {1}", DateTime.Now, request);

                return null;
            };

            pipelines.AfterRequest += context =>
            {
                //var response = Mapper.Map<Response, IResponse>(context.Response);

                //log.InfoFormat("Response date {0}: {1}", DateTime.Now, response);
            };

            pipelines.OnError += (context, ex) =>
            {
                var iRequest = Mapper.Map<Request, IRequest>(context.Request);
                var request = JsonConvert.SerializeObject(iRequest);

                //log.ErrorFormat("Request date {0}: {1}", DateTime.Now, request);

                return HttpStatusCode.InternalServerError;
            };

            return pipelines;
        }
    }
}