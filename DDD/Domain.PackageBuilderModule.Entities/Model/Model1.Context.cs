﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DTO.PackageBuilder;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
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
