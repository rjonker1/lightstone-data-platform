#region

using System.ComponentModel.DataAnnotations;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

#endregion

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class PackageDataField : Entity
    {
        public System.Guid Id { get; set; }
        public System.Guid DataFieldId { get; set; }
        public System.Guid PackageId { get; set; }
        public short Priority { get; set; }
        public bool Selected { get; set; }
        public string UnifiedName { get; set; }
    
        public virtual DataField DataField { get; set; }
        public virtual Package Package { get; set; }
    }
}
