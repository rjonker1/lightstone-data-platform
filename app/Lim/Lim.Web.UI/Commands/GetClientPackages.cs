using System;
using System.Collections.Generic;
using Lim.Domain.Models;

namespace Lim.Web.UI.Commands
{
    public class GetDataPlatformClientPackages
    {
        public readonly Guid ClientId;
        public GetDataPlatformClientPackages(Guid clientId)
        {
            ClientId = clientId;
        }

        public void Set(IEnumerable<DataPlatformPackage> packages)
        {
            Packages = packages;
        }

        public IEnumerable<DataPlatformPackage> Packages { get; private set; } 
    }
}