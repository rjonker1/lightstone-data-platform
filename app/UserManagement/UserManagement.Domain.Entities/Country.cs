using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Country : ValueEntity
    {
        protected Country() { }

        public Country(string val) : base(val)
        {
            Value = val;
        }
    }
}
