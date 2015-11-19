using System;
using System.Linq;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Repositories;
using UserManagement.TestHelper.BaseTests;
using Xunit.Extensions;

namespace UserManagement.Acceptance.Tests.Repositories.NoteEntities
{
    public class when_checking_for_existing_note_entities : TestDataBaseHelper
    {
        private IEntityNoteRepository<CustomerNote> _repository;
        private readonly Guid _id = Guid.NewGuid();
        public override void Observe()
        {
            RefreshDb(false);
            _repository = new EntityNoteRepository<CustomerNote>(Session);
            SaveAndFlush(new CustomerNote(new Customer("Cust"), new Note("Text")));
        }

        [Observation]
        public void should_return_true_if_exists()
        {
            _repository.Count().ShouldEqual(1);
        }
    }
}