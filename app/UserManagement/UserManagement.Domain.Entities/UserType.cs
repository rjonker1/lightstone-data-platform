using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class UserType : ValueEntity
    {
        protected UserType() { }

        public UserType(string name) : base(name)
        {
            Value = name;
        }

        public virtual void UpdateValue(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
          return "{0} - {1} - {2}".FormatWith(Id, Value, GetType());
        }
    }
}
