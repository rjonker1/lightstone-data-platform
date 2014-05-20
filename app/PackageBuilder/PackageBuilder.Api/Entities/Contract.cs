using System;
using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
{
    public class Contract : NamedEntity, IContract
    {
        public Contract(string name)
            : base(name)
        {
        }

        public ICustomer Customer { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}