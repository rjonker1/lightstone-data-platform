using Common.Logging;
using DataPlatform.Shared.Entities;
using Nancy;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.Domain.Contracts.Enitities;
using Shared.BuildingBlocks.Api;

namespace PackageBuilder.Api.Modules
{
    public class IndexModule : SecureModule
    {
        private readonly ILog _log = LogManager.GetCurrentClassLogger();

        public IndexModule(IPackageLookupRepository packageLookupRepository)
        {
            Get["/package/{action}"] = parameters =>
            {
                var package = packageLookupRepository.Get(Context.CurrentUser.UserName, parameters.action);

                return Response.AsJson((IPackage)package);
            };

            Get["/getUserMetaData"] = parameters =>
            {
                _log.InfoFormat("getUserMetaData");

                var actions = packageLookupRepository.GetActions(Context.CurrentUser.UserName);

                return Response.AsJson(new { path = "/action/{action}", actions });
            };
        }
    }
}