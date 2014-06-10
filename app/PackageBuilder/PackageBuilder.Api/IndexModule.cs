namespace PackageBuilder.Api
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Post["/package/{action}"] = parameters =>
            {
                var package = new PackageLookup().Get(Context.CurrentUser.UserName, parameters.action);

                return Response.AsJson(new {package});
            };

            Post["/getUserMetaData"] = parameters =>
            {
                var actions = new PackageLookup().GetActions(Context.CurrentUser.UserName);

                return Response.AsJson(new { path = "/action/{action}", actions });
            };
        }
    }
}