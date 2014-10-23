#region

using System.ComponentModel.DataAnnotations;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

#endregion

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Package : Entity
    {
        public Package()
        {
            this.PackageDataFields = new HashSet<PackageDataField>();
        }
    
        public System.Guid Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public System.Guid StateId { get; set; }
        public string Version { get; set; }
        public Nullable<decimal> CostOfSale { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Edited { get; set; }
        public Nullable<System.Guid> IndustryId { get; set; }
        public Nullable<bool> Published { get; set; }
        public Nullable<decimal> RecomendedRetailPrice { get; set; }
        public Nullable<System.DateTime> RevisionDate { get; set; }
    
        public virtual Industry Industry { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<PackageDataField> PackageDataFields { get; set; }
    }
}
