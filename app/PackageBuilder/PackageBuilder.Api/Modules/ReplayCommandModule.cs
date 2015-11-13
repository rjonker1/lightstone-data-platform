using MemBus;
using Nancy;
using PackageBuilder.Domain.Entities.CommandStore.Commands;
using Shared.BuildingBlocks.Api.Security;

namespace PackageBuilder.Api.Modules
{
    public class ReplayCommandModule : SecureModule
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