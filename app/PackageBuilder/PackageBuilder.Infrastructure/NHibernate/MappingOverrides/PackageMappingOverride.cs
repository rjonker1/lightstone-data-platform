﻿using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using PackageBuilder.Domain.Entities.Packages.ReadModels;

namespace PackageBuilder.Infrastructure.NHibernate.MappingOverrides
{
    public class PackageMappingOverride : IAutoMappingOverride<Package>
    {
        public void Override(AutoMapping<Package> mapping)
        {
            mapping.Map(x => x.DisplayVersion).Scale(1);
            //mapping.HasManyToMany(x => x.Industries).Table("PackageIndustries").ParentKeyColumn("PackageId").ChildKeyColumn("IndustryId");
        }
    }
}