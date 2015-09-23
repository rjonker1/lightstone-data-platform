namespace PackageBuilder.Api.Routes
{
    public static class PackageBuilderApi
    {
        public static class PackageRoutes
        {
            public static Route RequestIndex = new Route();
            public static Route RequestLookup = new Route();
            public static Route ProcessCreate = new Route();
            public static Route RequestUpdate = new Route();
            public static Route ProcessUpdate = new Route();
            public static Route ProcessDelete = new Route();
            public static Route Execute = new Route();

            static PackageRoutes()
            {
                RequestIndex.RequestType = RequestType.Get;
                RequestIndex.ApiRoute = "/Packages/{showAll?false}";
                RequestIndex.RestSharpRoute = "/Packages/{showAll}";

                RequestLookup.RequestType = RequestType.Get;
                RequestLookup.ApiRoute = "/PackageLookup/{industryIds?}";
                RequestLookup.RestSharpRoute = "/PackageLookup/{industryIds}";

                ProcessCreate.RequestType = RequestType.Post;
                ProcessCreate.ApiRoute = "/Packages";
                ProcessCreate.RestSharpRoute = ProcessCreate.ApiRoute;

                RequestUpdate.RequestType = RequestType.Get;
                RequestUpdate.ApiRoute = "/Packages/{id:guid}/{version:int}";
                RequestUpdate.RestSharpRoute = "/Packages/{id}/{version}";

                ProcessUpdate.RequestType = RequestType.Put;
                ProcessUpdate.ApiRoute = "/Packages/{id}";
                ProcessUpdate.RestSharpRoute = ProcessUpdate.ApiRoute;

                ProcessDelete.RequestType = RequestType.Delete;
                ProcessDelete.ApiRoute = "/Packages/Delete/{id}";
                ProcessDelete.RestSharpRoute = ProcessDelete.ApiRoute;

                Execute.RequestType = RequestType.Post;
                Execute.ApiRoute = "/Packages/Execute";
                Execute.RestSharpRoute = Execute.ApiRoute;
            }
        }
    }
}
