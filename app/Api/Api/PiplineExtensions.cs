using System;
using AutoMapper;
using Common.Logging;
using Nancy;
using Nancy.Bootstrapper;
using Newtonsoft.Json;

namespace Api
{
    public static class PiplineExtensions
    {
        public static IPipelines EnableMonitoring(this IPipelines pipelines)
        {
            var log = LogManager.GetCurrentClassLogger();
            pipelines.BeforeRequest += context =>
            {
                var iRequest = Mapper.Map<Request, IRequest>(context.Request);
                var request = JsonConvert.SerializeObject(iRequest);

                log.InfoFormat("Request date {0}: {1}", DateTime.Now, request);

                return null;
            };

            pipelines.AfterRequest += context =>
            {
                var response = Mapper.Map<Response, IResponse>(context.Response);

                log.InfoFormat("Response date {0}: {1}", DateTime.Now, response);
            };

            pipelines.OnError += (context, ex) =>
            {
                var iRequest = Mapper.Map<Request, IRequest>(context.Request);
                var request = JsonConvert.SerializeObject(iRequest);

                log.ErrorFormat("Request date {0}: {1}", DateTime.Now, request);

                return HttpStatusCode.InternalServerError;
            };

            return pipelines;
        }

        public static IPipelines EnableCors(this IPipelines pipelines)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline(x =>
            {
                x.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                x.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,DELETE,PUT,OPTIONS");
            });

            return pipelines;
        }
    }
}