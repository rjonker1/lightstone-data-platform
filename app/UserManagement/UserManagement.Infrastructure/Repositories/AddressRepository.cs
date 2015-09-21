using System.Linq;
using NHibernate;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        Address GetExistingAddress(Address address);
    }

    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(ISession session) : base(session)
        {
        }

        /// <summary>
        /// Checks to see if the address exists, if so return existing address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public Address GetExistingAddress(Address address)
        {
            return this.FirstOrDefault(
                x => (x.Line1 + "").Trim().ToLower() == (address.Line1 + "").Trim().ToLower()
                && (x.Line2 + "").Trim().ToLower() == (address.Line2 + "").Trim().ToLower()
                && (x.Suburb + "").Trim().ToLower() == (address.Suburb + "").Trim().ToLower()
                && (x.City + "").Trim().ToLower() == (address.City + "").Trim().ToLower()
                && (x.PostalCode + "").Trim().ToLower() == (address.PostalCode + "").Trim().ToLower()
                && address.Province != null && (x.Province != null && (x.Province.Value + "").Trim().ToLower() == (address.Province.Value + "").Trim().ToLower())
                && address.Country != null && (x.Country != null && (x.Country.Value + "").Trim().ToLower() == (address.Country.Value + "").Trim().ToLower())
                );
        }
    }
}