using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Province : ValueEntity
    {
        protected Province() { }

        public Province(string val) : base(val)
        {
            Value = val;
        }
    }
}
