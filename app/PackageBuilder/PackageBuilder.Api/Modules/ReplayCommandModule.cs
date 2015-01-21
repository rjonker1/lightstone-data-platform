using MemBus;
using Nancy;
using PackageBuilder.Domain.Entities.CommandStore.Commands;

namespace PackageBuilder.Api.Modules
{
    public class ReplayCommandModule : NancyModule
    {
        public ReplayCommandModule(IBus bus)
        {
            Get["/Replay"] = parameters =>
            {
                bus.Publish(new ReplayCommand());
                return Response.AsJson("Done!");
            };
        }
    }
}