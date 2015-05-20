using System;
using System.Collections.Generic;
using Lim.Domain.Models;

namespace Lim.Web.UI.Commands
{
    public class GetClientPackages
    {
        public readonly Guid ClientId;
        public GetClientPackages(Guid clientId)
        {
            ClientId = clientId;
        }

        public void Set(IEnumerable<Package> packages)
        {
            Packages = packages;
        }

        public IEnumerable<Package> Packages { get; private set; } 
    }
}