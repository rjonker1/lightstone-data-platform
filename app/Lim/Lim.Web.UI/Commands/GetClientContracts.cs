using System;
using System.Collections.Generic;
using Lim.Domain.Models;

namespace Lim.Web.UI.Commands
{
    public class GetDataPlatformClientContracts
    {
        public readonly Guid ClientId;
        public GetDataPlatformClientContracts(Guid clientId)
        {
            ClientId = clientId;
        }

        public void Set(IEnumerable<DataPlatformContract> contracts)
        {
            Contracts = contracts;
        }

        public IEnumerable<DataPlatformContract> Contracts { get; private set; } 
    }
}