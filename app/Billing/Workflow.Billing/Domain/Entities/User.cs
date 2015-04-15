
namespace Workflow.Billing.Domain.Entities
{
    public class User : Billing//, ISubclassConvention
    {
        public virtual string Username { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public User() { }

        //public virtual void Apply(ISubclassInstance instance)
        //{
        //    instance.DiscriminatorValue("User Pre");
        //}
    }
}