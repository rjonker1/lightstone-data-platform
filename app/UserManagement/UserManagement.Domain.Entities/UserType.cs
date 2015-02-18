using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class UserType : NamedEntity
    {
        public virtual string Value { get; set; }

        protected UserType() { }

        public UserType(string name) : base(name)
        {
            Value = name;
        }

        public override string ToString()
        {
          return "{0} - {1} - {2}".FormatWith(Id, Name, GetType());
        }

        public virtual void UpdateValue(string value)
        {
            Value = value;
            base.Name = value;
        }
    }
}
