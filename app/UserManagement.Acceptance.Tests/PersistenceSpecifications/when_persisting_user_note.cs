using FluentNHibernate.Testing;
using UserManagement.Domain.Entities;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Acceptance.Tests.PersistenceSpecifications
{
    public class when_persisting_user_note : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb(false);
        }

        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<UserNote>(Session, new CustomEqualityComparer())
                .CheckReference(c => c.Entity, new User{UserName = "User"})
                .CheckReference(c => c.Note, new Note("NoteText"))
                .VerifyTheMappings();
        }
    }
}