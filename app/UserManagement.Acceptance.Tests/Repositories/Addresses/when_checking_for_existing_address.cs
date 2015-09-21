using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Repositories;
using UserManagement.TestHelper.BaseTests;
using Xunit.Extensions;

namespace UserManagement.Acceptance.Tests.Repositories.Addresses
{
    public class when_checking_for_existing_address : TestDataBaseHelper
    {
        private IAddressRepository _repository;
        public override void Observe()
        {
            RefreshDb(false);
            _repository = new AddressRepository(Session);
            SaveAndFlush(new Address("line1", "line2", "suburb", "city", new Country("South Africa"), "postal code", new Province("Gauteng")));
        }

        [Observation]
        public void should_return_true_if_exists()
        {
            _repository.GetExistingAddress(new Address("line1", "line2", "suburb", "city", new Country("South Africa"), "postal code", new Province("Gauteng"))).ShouldNotBeNull();
        }

        [Observation]
        public void should_return_null()
        {
            _repository.GetExistingAddress(new Address("line", "line2", "suburb", "city", new Country("South Africa"), "postal code", new Province("Gauteng"))).ShouldBeNull();
        }
    }
}