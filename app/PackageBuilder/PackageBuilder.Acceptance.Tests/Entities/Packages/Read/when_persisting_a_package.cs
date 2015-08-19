using System;
using System.Collections.Generic;
using FluentNHibernate.Testing;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.Domain.Entities.Packages.Read;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestHelper.Helpers;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Entities.Packages.Read
{
    public class when_persisting_a_package : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb();
        }

        [Observation]
        public void should_persist_package()
        {
            new PersistenceSpecification<Package>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.PackageId, Guid.NewGuid())
                .CheckProperty(c => c.Name, "VVi")
                .CheckProperty(c => c.Description, "Description")
                .CheckProperty(c => c.Version, 1)
                .CheckProperty(c => c.DisplayVersion, 0.1m)
                .CheckProperty(c => c.Owner, "Owner")
                .CheckProperty(c => c.CreatedDate, new DateTime(2014, 01, 01))
                .CheckProperty(c => c.EditedDate, new DateTime(2014, 01, 01))
                .CheckList(c => c.Industries, new List<Industry>{new Industry {Name = ""}})
                .VerifyTheMappings();
        }
    }
}