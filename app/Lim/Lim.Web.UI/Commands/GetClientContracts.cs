using System;
using System.Collections.Generic;
using Lim.Domain.Models;

namespace Lim.Web.UI.Commands
{
    public class GetClientContracts
    {
        public readonly Guid ClientId;
        public GetClientContracts(Guid clientId)
        {
            ClientId = clientId;
        }

        public void Set(IEnumerable<Contract> contracts)
        {
            Contracts = contracts;
        }

        public IEnumerable<Contract> Contracts { get; private set; } 
    }
}