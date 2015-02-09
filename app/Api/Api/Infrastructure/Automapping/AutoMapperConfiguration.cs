using Api.Domain.Core.Contracts;
using AutoMapper;
using Nancy;
using Newtonsoft.Json;

namespace Api.Infrastructure.Automapping
{
    public static class AutoMapperConfiguration
    {
        public static void Init()
        {
            Mapper.Initialize(GetConfiguration);
        }

        private static void GetConfiguration(IConfiguration cfg)
        {
            cfg.CreateMap<Request, IRequest>();
            cfg.CreateMap<Response, IResponse>()
                .ForMember(d => d.Response, opt => opt.MapFrom<string>(s => JsonConvert.SerializeObject(s.Contents.Target)));
        }
    }
}