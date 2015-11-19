using System;
using System.Linq;
using UserManagement.Domain.Entities;
using UserManagement.TestHelper.BaseTests;
using UserManagement.Infrastructure.Helpers;
using Xunit.Extensions;

namespace UserManagement.Acceptance.Tests.Repositories.EntitiesByTypeRepositories
{
    //public class when_checking_for_existing_note_entities : TestDataBaseHelper
    //{
    //    private IEntityByTypeRepository _repository;
    //    private readonly Guid _id = Guid.NewGuid();
    //    public override void Observe()
    //    {
    //        RefreshDb(false);
    //        _repository = new EntityByTypeRepository(Container);
    //        SaveAndFlush(new CustomerNote(new Customer("Cust"), new Note("Text", new User())));
    //    }

    //    [Observation]
    //    public void should_return_true_if_exists()
    //    {
    //        _repository.GetEntityNotes(typeof(CustomerNote)).Count().ShouldEqual(1);
    //    }
    //}
}