using Nancy;
using Nancy.Responses.Negotiation;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class CreateSourceModule : NancyModule
    {
        public CreateSourceModule(IRepository<CreateSource> createSources)
        {

            Get["/CreateSources"] = _ =>
            {
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = createSources });
            };
        }
    }
}