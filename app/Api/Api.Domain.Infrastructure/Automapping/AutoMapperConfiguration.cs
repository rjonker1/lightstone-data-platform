using Api.Domain.Core.Contracts;
using AutoMapper;
using Nancy;
using Newtonsoft.Json;

namespace Api.Domain.Infrastructure.Automapping
{
    public static class AutoMapperConfiguration
    {
        public static void Init()
        {
            Mapper.Initialize(GetConfiguration);
        }

        private static void GetConfiguration(IConfiguration cfg)
        {
            cfg.CreateMap<Request, IRequest>().ConstructUsing((ResolutionContext c) => new RequestDto());
            cfg.CreateMap<Response, IResponse>()
                .ForMember(d => d.Response,
                    opt => opt.MapFrom<string>(s => JsonConvert.SerializeObject(s.Contents.Target)))
                .ConstructUsing((ResolutionContext c) => new ResponseDto());
            //cfg.CreateMap<Request, IRequest>();
            //cfg.CreateMap<Response, IResponse>()
            //    .ForMember(d => d.Response, opt => opt.MapFrom<string>(s => JsonConvert.SerializeObject(s.Contents.Target)));
        }
    }

    public class RequestDto : IRequest
    {

        public string UserHostAddress { get; set; }

        public string Method { get; set; }

        public Url Url { get; set; }

        public string Path { get; set; }

        public dynamic Query { get; set; }

        public dynamic Form { get; set; }

        public RequestHeaders Headers { get; set; }
    }

    public class ResponseDto : IResponse
    {

        public string ContentType { get; set; }

        public System.Collections.Generic.IDictionary<string, string> Headers { get; set; }

        public string ReasonPhrase { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string Response { get; set; }
    }
}