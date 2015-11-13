using System;
using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Nancy;
using Nancy.Security;
using Shared.BuildingBlocks.Api.Security;

namespace PackageBuilder.Api.Modules
{
    public class PackageEventTypeModule : SecureModule
    {
        public PackageEventTypeModule()
        {
            this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString() });

            const string petRoute = "/PackageEventTypes";

            Get[petRoute] = parameters =>
                Response.AsJson((from object e in Enum.GetValues(typeof (PackageEventType)) select new [] {e.ToString(), e}));
        }
    }
}