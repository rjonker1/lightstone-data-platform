using System;
using Billing.TestHelper.BaseTests;
using FluentNHibernate.Testing;
using Workflow.Billing.Domain.Entities;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.Billing.Meta
{
    public class when_persisting_package_meta : when_persisting_entities_to_db
    {

        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<PackageMeta>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.PackageId, Guid.NewGuid())
                .CheckProperty(c => c.PackageName, "TESTPackage")
                .VerifyTheMappings();
        }
    }
}