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
            // Had to comment this out and replace implementation as the common packack was not \
            // being referenced / installed for some reason. Hope the resutl is the same.

            // TODO: revert the implementaion.
            
           // return "{0} - {1} - {2}".FormatWith(Id, Name, GetType());

            return string.Format("{0} - {1} - {2}", Id, Name, GetType());
        }
    }
}
