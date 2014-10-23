
#region

using System.Data.Common;
using LightstoneApp.Domain.PackageBuilderModule.Entities;



#endregion

namespace LightstoneApp.Domain.PackageBuilderModule.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LightstoneAppDatabaseEntities : DbContext
    {
        public LightstoneAppDatabaseEntities()
            : base("name=LightstoneAppDatabaseEntities")
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }
    
    	public LightstoneAppDatabaseEntities(string nameOrConnectionString) : base(nameOrConnectionString)
    	{	
    	}
    
    	public LightstoneAppDatabaseEntities(string nameOrConnectionString, DbCompiledModel model) : base(nameOrConnectionString, model)
    	{
    	}
    
    	public LightstoneAppDatabaseEntities(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
    	{
    	}
    
    	public LightstoneAppDatabaseEntities(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection) : base(existingConnection, model, contextOwnsConnection)
    	{
    	}
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DataField> DataFields { get; set; }
        public virtual DbSet<DataProvider> DataProviders { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PackageDataField> PackageDataFields { get; set; }
        public virtual DbSet<State> States { get; set; }
    }
}
