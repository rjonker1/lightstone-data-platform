using System;
using System.Configuration;
using Nancy;

namespace Shared.BuildingBlocks.Api.Security
{
    public class RootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            var keyStore = ConfigurationManager.AppSettings["TokenAuthKeyStorePath"];
            return new Uri(keyStore).LocalPath;
        }
    }
}