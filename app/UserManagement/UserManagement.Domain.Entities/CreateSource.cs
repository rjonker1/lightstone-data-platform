using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class CreateSource : ValueEntity
    {
        protected CreateSource() { }

        public CreateSource(string val) : base(val)
        {
            Value = val;
        }
    }
}
