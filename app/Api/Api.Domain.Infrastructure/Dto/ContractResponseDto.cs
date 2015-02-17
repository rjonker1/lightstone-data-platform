using System;
using NHibernate.Mapping.ByCode;

namespace Api.Domain.Infrastructure.Dto
{
    public class ContractResponse
    {
        public Guid ContractId { get; set; }
        public ContractPackage Package { get; set; }
    }

    public class ContractPackage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public bool? IsActivated { get; set; }
    }
}
