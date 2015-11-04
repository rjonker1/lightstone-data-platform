using Api.Domain.Core.Contracts;
using Api.Domain.Core.Dto;
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
}