using System;

namespace Api.Domain.Core.Meta
{
    public class Contract
    {
        public Guid ContractId { get; set; }
        public string ContractName { get; set; }
        public Menu Menu { get; set; }
    }
}