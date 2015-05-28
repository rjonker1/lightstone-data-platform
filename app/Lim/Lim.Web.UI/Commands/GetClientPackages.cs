using System;
using System.Collections.Generic;
using Lim.Domain.Dto;

namespace Lim.Web.UI.Commands
{
    public class GetDataPlatformClientPackages
    {
        public readonly Guid ClientId;
        public GetDataPlatformClientPackages(Guid clientId)
        {
            ClientId = clientId;
        }

        public void Set(IEnumerable<DataPlatformPackageDto> packages)
        {
            Packages = packages;
        }

        public IEnumerable<DataPlatformPackageDto> Packages { get; private set; } 
    }
}