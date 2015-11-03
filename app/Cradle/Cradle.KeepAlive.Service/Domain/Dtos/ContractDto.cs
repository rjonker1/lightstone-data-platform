using System;

namespace Cradle.KeepAlive.Service.Domain.Dtos
{
    public class ContractDto
    {
        public Guid ContractId { get; set; }
        public string ContractName { get; set; }
        public MenuDto Menu { get; set; }
    }
}