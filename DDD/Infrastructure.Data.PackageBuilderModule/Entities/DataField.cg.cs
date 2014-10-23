using System.ComponentModel.DataAnnotations;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Infrastructure.Data.PackageBuilder.Module.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class DataField : Entity
    {
        public DataField()
        {
            this.PackageDataFields = new HashSet<PackageDataField>();
        }
    
        public System.Guid Id { get; set; }
        public decimal CostOfSale { get; set; }
        public System.Guid DataProviderId { get; set; }
        public System.Guid IndustryId { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
        public string Label { get; set; }
        public string TypeDefinition { get; set; }
    
        public virtual DataProvider DataProvider { get; set; }
        public virtual Industry Industry { get; set; }
        public virtual ICollection<PackageDataField> PackageDataFields { get; set; }
    }
}
