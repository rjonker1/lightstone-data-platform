
namespace PackageBuilder.Domain.Entities
{
    public class Action : NamedEntity, IAction
    {
        public Action(string name)
            : base(name)
        {
        }

        public ICriteria Criteria { get; set; }
    }
}