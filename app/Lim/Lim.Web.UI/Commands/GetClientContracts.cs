using System;
using System.Collections.Generic;
using Lim.Domain.Dto;
namespace Lim.Web.UI.Commands
{
    public class GetDataPlatformClientContracts
    {
        public readonly Guid ClientId;
        public GetDataPlatformClientContracts(Guid clientId)
        {
            ClientId = clientId;
        }

        public void Set(IEnumerable<DataPlatformContractDto> contracts)
        {
            Contracts = contracts;
        }

        public IEnumerable<DataPlatformContractDto> Contracts { get; private set; } 
    }
}