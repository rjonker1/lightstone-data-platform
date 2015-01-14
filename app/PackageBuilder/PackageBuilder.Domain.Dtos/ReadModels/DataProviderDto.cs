using System;

namespace PackageBuilder.Domain.Dtos.ReadModels
{
    public class DataProviderDto
    {
        public Guid DataProviderId { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public double CostPrice { get; protected set; }
        public int? Version { get; protected set; }
        public string Owner { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime? EditedDate { get; protected set; } 
    }
}