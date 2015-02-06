using System;
using System.Linq;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;
using Nancy;
using Nancy.Responses.Negotiation;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Core.Repositories;

namespace UserManagement.Api.Modules
{
    public class LookupModule : NancyModule
    {
        public LookupModule()
        {
            Get["/Lookups/{type}"] = parameters =>
            {
                var container = ServiceLocator.Current.GetInstance<IWindsorContainer>();
                var typeName = parameters.type.ToString();
                var type = Type.GetType(typeName);
                var executorType = typeof(INamedEntityRepository<>).MakeGenericType(type);
                var executor = (IQueryable)container.Resolve(executorType);

                return Negotiate
                    .WithView("Index")
                    .WithModel(new LookupViewModel(type))
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = executor });
            };
        }
    }
}