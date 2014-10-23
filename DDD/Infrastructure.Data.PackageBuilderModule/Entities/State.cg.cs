using System.ComponentModel.DataAnnotations;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Infrastructure.Data.PackageBuilder.Module.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class State : Entity
    {
        public State()
        {
            this.DataProviders = new HashSet<DataProvider>();
            this.Packages = new HashSet<Package>();
        }
    
        public System.Guid Id { get; set; }
        public string Value { get; set; }
    
        public virtual ICollection<DataProvider> DataProviders { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
