using System.Collections.Generic;
using FluentNHibernate.Testing;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Enums;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Acceptance.Tests.PersistenceSpecifications
{
    public class when_persisting_individual : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb(false);
        }

        [Observation]
        public void should_persist()
        {
            var individual = new Individual("Name", "Surname", "IdNumber");
            new PersistenceSpecification<Individual>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Name, "Name")
                .CheckProperty(c => c.Surname, "Surname")
                .CheckProperty(c => c.IdNumber, "IdNumber")
                .CheckList(c => c.Addresses, new HashSet<IndividualAddress>(new[] { new IndividualAddress(individual, new Address("Line1", "Line2", "Suburb", "City", new Country("South Africa"), "Postal code", new Province("Gauteng")), AddressType.Physical), }))
                .VerifyTheMappings(individual);
        }
    }
}