#region

using System.ComponentModel.DataAnnotations;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

#endregion

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class DataProvider : Entity
    {
        public DataProvider()
        {
            this.DataFields = new HashSet<DataField>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public bool OverrideFieldLevelCostOfSale { get; set; }
        public string Owner { get; set; }
        public string SourceURL { get; set; }
        public System.Guid StateId { get; set; }
        public string Version { get; set; }
        public Nullable<decimal> CostOfSale { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Edited { get; set; }
        public Nullable<System.DateTime> RevisionDate { get; set; }
    
        public virtual ICollection<DataField> DataFields { get; set; }
        public virtual State State { get; set; }
    }
}
