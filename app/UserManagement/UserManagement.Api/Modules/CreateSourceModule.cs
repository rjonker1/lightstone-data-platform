using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class CreateSourceModule : NancyModule
    {
        public CreateSourceModule(IRepository<CreateSource> createSources)
        {

            Get["/CreateSources"] = _ => Response.AsJson(createSources);
        }
    }
}